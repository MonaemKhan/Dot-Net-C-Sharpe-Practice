﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MiniInventoryManagementSystem.Models.SupportClass
{
    public class Sales_and_SalesDetails
    {
        [Key]
        [DisplayName("Sales Details Id")]
        public int SalesDetailsId { get; set; }

        [DisplayName("Sales Price")]
        public double SalesDetailsPrice { get; set; }

        [DisplayName("Sales Quantity")]
        public int SalesDetailsQuantity { get; set; }

        [DisplayName("Product Id")]
        public int SalesDetails_ProductId { get; set; }

        [DisplayName("Product's Name")]
        public string SalesDetails_ProductName { get; set; }

        [DisplayName("Catagory Name")]
        public string catagoryName { get; set; }

        //sales
        [DisplayName("Sales Id")]
        public int SalesId { get; set; }

        [DisplayName("SalesMan's Id")]
        public int Sales_SalesManId { get; set; }

        [DisplayName("SalesMan's Name")]
        public string Sales_SalesManName { get; set; }

        [DisplayName("Customer's Id")]
        public int Sales_CustomerId { get; set; }

        [DisplayName("Customer's Name")]
        public string Sales_CustomerName { get; set; }

        [DisplayName("Sales Date")]
        public string SalesDate { get; set; }

        [DisplayName("Total Price")]
        public double TotalPrice { get; set; }
    }
}
