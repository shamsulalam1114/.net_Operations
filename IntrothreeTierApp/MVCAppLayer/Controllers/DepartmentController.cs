using BLL.DTOs;
using BLL.Services;
using DAL.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MVCAppLayer.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentService service;
        public DepartmentController(DepartmentService service) { 
            this.service = service;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Get() {

            var data = service.Get();   
            return View(data);
        }
        [HttpGet]
        public IActionResult Create() { 
            return View(new DepartmentDTO());
        }
        [HttpPost]
        public IActionResult Create(DepartmentDTO d) {
            if (ModelState.IsValid) { 
                var rs = service.Create(d);
                if (rs == true)
                {
                    return RedirectToAction("Get");
                }
                else {
                    TempData["Msg"] = "Something Error Occured";
                    
                }
            }
            return View(d);
        }

        
    }
}
