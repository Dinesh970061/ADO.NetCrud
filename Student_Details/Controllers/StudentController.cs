using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Details.Models;


namespace Student_Details.Controllers
{
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        Dataaccess obstudent = new Dataaccess();
        //GET:/<controller>/
        public IActionResult Index()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] Student student1)
        {
            if(ModelState.IsValid)
            {
                obstudent.AddStudent(student1);
                return RedirectToAction("Index");
            }
            return View(student1);
        }
    
 
    }
}
