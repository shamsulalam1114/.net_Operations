using BLL.Services;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class StudentController : Controller
    {
        StudentService service;
        public StudentController(StudentService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get()
        {
            //
            //

            var data = service.Get();
            return View(data);
        }
        public IActionResult Create()
        {

            var res = service.Create();
            return View();
        }
    }
}