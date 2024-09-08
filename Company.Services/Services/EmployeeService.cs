using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Services.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IUnitOfWork _unitOfWork;

        public EmployeeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void Add(Employee employee)
        {
            var mappedEmp = new Employee
            {
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary  = employee.Salary,
                HiringDate = DateTime.Now,
                DepartmentId = employee.DepartmentId,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
            };
            _unitOfWork.EmployeeRepository.Add(mappedEmp);
            _unitOfWork.Complete();
        }

        public void Delete(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Delete(employee);
            _unitOfWork.Complete();
        }

        public IEnumerable<Employee> GetAll()
        {
            return _unitOfWork.EmployeeRepository.GetAll();
        }

        public Employee GetById(int? id)
        {
            if (id is null)
                return null;
            var emp = _unitOfWork.EmployeeRepository.GetById(id.Value);
            if (emp is null)
                return null;
            return emp;

        }

        public IEnumerable<Employee> GetEmployeesByName(string name)
            => _unitOfWork.EmployeeRepository.GetEmployeesByAddress(name);

        public void Update(Employee employee)
        {
            _unitOfWork.EmployeeRepository.Update(employee);
            _unitOfWork.Complete();
        }
    }
}
