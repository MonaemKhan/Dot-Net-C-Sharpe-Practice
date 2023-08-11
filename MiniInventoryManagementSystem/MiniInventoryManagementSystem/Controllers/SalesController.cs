using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiniInventoryManagementSystem.DbCon;
using MiniInventoryManagementSystem.Models;
using MiniInventoryManagementSystem.Models.SupportClass;
using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

namespace MiniInventoryManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        private readonly DbConnectionContext _context;
        public SalesController(DbConnectionContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {
            List<Sales> sale = await _context.SalesTable.ToListAsync();
            List<Customer> customer = await _context.CustomerTable.ToListAsync();
            List<SalesMan> salesman = await _context.SalesManTable.ToListAsync();
            List<Product> product = await _context.ProductTable.ToListAsync();
            List<SalesDetails> salesdetails = await _context.SalesDetailsTable.ToListAsync();
            List<Catagory> catagories = await _context.CatagoryTable.ToListAsync();

            var item = from sa in sale
                       join cust in customer on sa.Sales_CustomerId equals cust.CustomerId
                       join sm in salesman on sa.Sales_SalesManId equals sm.SalesManId
                       join sd in salesdetails on sa.SalesId equals sd.SalesDetails_SalesId
                       join p in product on sd.SalesDetails_ProductId equals p.ProductId
                       join ca in catagories on p.Product_CatagoryId equals ca.CatagoryId
                       select new { sa.SalesId,sa.Sales_SalesManId,sa.Sales_CustomerId,sa.SalesDate,
                            sm.SalesManName,cust.CustomerName,
                            sd.SalesDetailsId,sd.SalesDetailsPrice,sd.SalesDetailsQuantity,sd.SalesDetails_ProductId,
                            p.ProductName,ca.CatagoryName};
            List<Sales_and_SalesDetails> salesandsalesdetails = new List<Sales_and_SalesDetails>();
            foreach(var da in item)
            {
                salesandsalesdetails.Add(
                    new Sales_and_SalesDetails()
                    {
                        SalesDetailsId = da.SalesDetailsId,
                        SalesDetailsPrice = da.SalesDetailsPrice,
                        SalesDetailsQuantity = da.SalesDetailsQuantity,
                        SalesDetails_ProductId = da.SalesDetails_ProductId,
                        SalesDetails_ProductName = da.ProductName,
                        catagoryName = da.CatagoryName,

                         //sales
                        SalesId = da.SalesId,
                        Sales_SalesManId = da.Sales_SalesManId,
                        Sales_SalesManName = da.SalesManName,
                        Sales_CustomerId = da.Sales_CustomerId,
                        Sales_CustomerName = da.CustomerName,
                        SalesDate = da.SalesDate,
                        TotalPrice = da.SalesDetailsPrice*da.SalesDetailsQuantity
                    });
            }
            return View(salesandsalesdetails);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var salesdetails = await _context.SalesDetailsTable.FindAsync(id);

            var sale = await _context.SalesTable.FindAsync(salesdetails.SalesDetails_SalesId);
            var customer = await _context.CustomerTable.FindAsync(sale.Sales_CustomerId);
            var salesman = await _context.SalesManTable.FindAsync(sale.Sales_SalesManId);

            var product = await _context.ProductTable.FindAsync(salesdetails.SalesDetails_ProductId);
            var catagories = await _context.CatagoryTable.FindAsync(product.Product_CatagoryId);

            List<Sales_and_SalesDetails> ssd = new List<Sales_and_SalesDetails>()
            {
                new Sales_and_SalesDetails()
                {
                        SalesDetailsId = salesdetails.SalesDetailsId,
                        SalesDetailsPrice = salesdetails.SalesDetailsPrice,
                        SalesDetailsQuantity = salesdetails.SalesDetailsQuantity,
                        SalesDetails_ProductId = salesdetails.SalesDetails_ProductId,
                        SalesDetails_ProductName = product.ProductName,
                        catagoryName = catagories.CatagoryName,

                         //sales
                        SalesId = sale.SalesId,
                        Sales_SalesManId = sale.Sales_SalesManId,
                        Sales_SalesManName = salesman.SalesManName,
                        Sales_CustomerId = sale.Sales_CustomerId,
                        Sales_CustomerName = customer.CustomerName,
                        SalesDate = sale.SalesDate,
                        TotalPrice = salesdetails.SalesDetailsPrice*salesdetails.SalesDetailsQuantity
                }
            };

            ViewBag.ProductList = await _context.ProductTable.ToListAsync();
            ViewBag.SalesManList = await _context.SalesManTable.ToListAsync();
            ViewBag.CustomerList = await _context.CustomerTable.ToListAsync();
            return View(ssd[0]);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(Sales_and_SalesDetails salesdetails)
        {
            List<Sales> sale = new List<Sales>()
            {
                new Sales()
                {
                    SalesId = salesdetails.SalesId,
                    Sales_SalesManId = salesdetails.Sales_SalesManId,
                    Sales_CustomerId = salesdetails.Sales_CustomerId,
                    SalesDate = salesdetails.SalesDate
                }
            };

            List<SalesDetails> saled = new List<SalesDetails>()
            {
                new SalesDetails()
                {
                    SalesDetailsId = salesdetails.SalesDetailsId,
                    SalesDetailsPrice = salesdetails.SalesDetailsPrice,
                    SalesDetailsQuantity = salesdetails.SalesDetailsQuantity,
                    SalesDetails_SalesId = salesdetails.SalesId,
                    SalesDetails_ProductId = salesdetails.SalesDetails_ProductId
                }
            };

            _context.Entry(sale[0]).State = EntityState.Modified;
            _context.Entry(saled[0]).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //To Sale Product All the work Done is start Here
        public async Task<ActionResult> Create()
        {
            ViewBag.CustomerList = await _context.CustomerTable.ToListAsync();
            ViewBag.SalesManList = await _context.SalesManTable.ToListAsync();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SalesAndSalesDetails(Sales sale)
        {   
            await _context.SalesTable.AddAsync(sale);
            await _context.SaveChangesAsync();
            ViewBag.ProductList = await _context.ProductTable.ToListAsync();
            ViewBag.SalesDetails_SalesId = sale.SalesId;

            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SalesDetails(SalesDetails salesdetails)
        {
            await _context.SalesDetailsTable.AddAsync(salesdetails);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        //To Seal Product All the work Done is ends Here
    }
}
