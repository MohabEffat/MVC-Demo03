using Company.Services.Interfaces.Dto;
namespace Company.Services.Interfaces
{
    public interface IEmployeeService
    {
        EmployeeDto GetById(int? id);
        IEnumerable<EmployeeDto> GetAll();
        void Add(EmployeeDto employee);
        void Update(EmployeeDto employee);
        void Delete(EmployeeDto employee);
        IEnumerable<EmployeeDto> GetEmployeesByName(string name);
        IEnumerable<EmployeeDto> GetEmployeesByAddress(string address);

    }
}
