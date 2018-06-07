using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Student_Details.Models;

namespace Student_Details.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        Dataaccess obstudent = new Dataaccess();
        [HttpGet]
        public List<Student> Get()
        {
            List<Student> students = obstudent.GetAllStudents();
            return students;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]Student s)
        {
            obstudent.AddStudent(s);
        }

        // PUT api/values/5
        [HttpPut]
        public void Put([FromBody]Student s)
        {
            obstudent.UpdateStudent(s);
        }

        // DELETE api/values/5
        [HttpDelete("{SID}")]
        public void Delete(int SID)
        {
            obstudent.DeleteStudent(SID);
        }
    }

}
