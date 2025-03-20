using IKEA.BLL.Models.Departments;
using IKEA.BLL.Services;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IWebHostEnvironment _environment;

        public DepartmentController(IDepartmentServices departmentServices, ILogger<DepartmentController> logger, IWebHostEnvironment environment)
        {
            _departmentServices = departmentServices;
            _logger = logger;
            _environment = environment;
        }

        #region Index
        [HttpGet]
        public IActionResult Index()
        {
            var departments = _departmentServices.GetALLDepartment();
            return View(departments);
        }
        #endregion

        #region Create

        #region Get
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        #endregion

        #region Post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatedDepartmentDTO department)
        {
            if (!ModelState.IsValid)
            {
                return View(department);
            }

            try
            {
                var result = _departmentServices.CreatedDepartment(department);

                if (result > 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                ModelState.AddModelError(string.Empty, "Department was not created.");
                return View(department);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error creating department");

                ViewBag.ErrorMessage = _environment.IsDevelopment() ? ex.Message : "An error occurred while creating the department.";
                return View(department);
            }
        }
        #endregion

        #endregion
    }
}
