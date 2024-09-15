using Company.Data.Models;
using Company.Services.Interfaces;
using Company.Services.Interfaces.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
		private readonly IWebHostEnvironment _env;

		public DepartmentController(IDepartmentService departmentService, IWebHostEnvironment env)
        {
            _departmentService = departmentService;
			_env = env;
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
        public IActionResult Create(DepartmentDto department)
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

        public IActionResult Details([FromRoute]int? id, string viewName = "Details")
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
        public IActionResult Update([FromRoute] int? id, DepartmentDto department)
        {
            if(department.Id != id.Value)
                return RedirectToAction("NotFoundPage", null, "Home");
            if (!ModelState.IsValid)
                return View(department);
            try
            {
				_departmentService.Update(department);
				return RedirectToAction("Index");
			}
            catch (Exception ex)
            {

                if (_env.IsDevelopment())
                    ModelState.AddModelError(string.Empty, ex.Message);
                else
					ModelState.AddModelError(string.Empty, "An Error Has Occured");
                return View(department);
			}

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
