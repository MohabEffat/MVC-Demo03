﻿using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repositories
{
    internal class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        private readonly CompanyDbContext _context;

        public EmployeeRepository(CompanyDbContext context) : base(context) 
        {
            _context = context;
        }

        public Employee GetEmployeeByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetEmployeesByAddress(string Address)
        {
            throw new NotImplementedException();
        }
    }
}
