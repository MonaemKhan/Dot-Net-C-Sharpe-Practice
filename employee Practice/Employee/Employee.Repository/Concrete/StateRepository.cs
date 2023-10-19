using AutoMapper;
using Employee.Infrastructure.Presistance;
using Employee.Model;
using Employee.Repository.Interface;
using Employee.Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repository.Concrete;

public class StateRepository:RepositoryBase<States,StateVM,int>,IStateRepository
{
    public StateRepository(EmployeeDbContext employeeDbContext,IMapper mapper):base(employeeDbContext,mapper)
    {
        
    }
}
