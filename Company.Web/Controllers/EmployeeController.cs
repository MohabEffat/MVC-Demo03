using Company.Data.Models;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Dto;
using Company.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }
        public IActionResult Index(string searchInp)
        {
            IEnumerable<EmployeeDto> employees = new List<EmployeeDto>();
            if (string.IsNullOrEmpty(searchInp))
                employees = _employeeService.GetAll();
            else
                employees = _employeeService.GetEmployeesByName(searchInp);
            return View(employees);

        }
        public IActionResult Add()
        {
            ViewBag.departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Add(EmployeeDto employee)
        {
            _employeeService.Add(employee);
            return RedirectToAction("Index");
        }
        public IActionResult Details(int? id, string viewName = "Details")
        {
            var emp = _employeeService.GetById(id.Value);
            if (emp is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName, emp);
        }
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        public IActionResult Update(int? id, EmployeeDto employee)
        {
            if (employee.Id != id!.Value)
                return RedirectToAction("NotFoundPage", null, "Home");

            _employeeService.Update(employee);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var emp = _employeeService.GetById(id);
            if (emp is null)
                return RedirectToAction("NotFoundPage", null, "Home");
            _employeeService.Delete(emp);

            return RedirectToAction("Index");
        }
    }
}
