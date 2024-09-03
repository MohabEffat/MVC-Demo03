using Company.Data.Models;
using Company.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService )
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var departments = _departmentService.GetAll();
            return View(departments);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("DepartmentError", "ValidationError");
                return View();

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError", ex.Message);
                return View(department);
            }
        }

        public IActionResult Details(int? id, string viewName = "Details")
        {
            var department = _departmentService.GetById(id.Value);
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            return View(viewName,department);
        }
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }

        [HttpPost]
        public IActionResult Update(int? id, Department department)
        {
            if(department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            _departmentService.Update(department);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var department = _departmentService.GetById(id);
            if (department is null)
                return RedirectToAction("NotFoundPage", null, "Home");

            _departmentService.Delete(department);

            return RedirectToAction("Index");
        }

    }
}
