using Company.Services.Interfaces.Dto;
namespace Company.Services.Interfaces
{
    public interface IDepartmentService
    {
        DepartmentDto GetById(int? id);
        IEnumerable<DepartmentDto> GetAll();
        void Add(DepartmentDto department);
        void Update(DepartmentDto department);
        void Delete(DepartmentDto department);
    }
}
