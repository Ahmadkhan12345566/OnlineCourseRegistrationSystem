using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationPaper.Models;

namespace WebApplicationPaper.Controllers
{
    public class RegistercourseController : ApiController
    {

        Course_reg_DatabaseEntities db_record = new Course_reg_DatabaseEntities();
        [Route("api/stdent/{id}")]
        [HttpGet]
        public IHttpActionResult GetCourse(int id)
        {
            List<studentsTable> crs = new List<studentsTable>();
            studentsTable crss = null;
            List<studentsTable> courseslist = new List<studentsTable>();

            courseslist = db_record.studentsTables.ToList();
            //nw.SaveChanges();


            foreach (var item in courseslist)
            {
                if (item.std_Id == id)
                {
                    crs.Add(item);
                    crss = item;
                    break;

                }
            } // end of foreach 


            if (crss == null)
                return NotFound();
            else
                return Ok(crss);

        }



        [Route("api/student/{id}")]
        [HttpGet]
        public IHttpActionResult GetCours(int id)
        {
            List<registerd_crs_Table> crs = new List<registerd_crs_Table>();
              registerd_crs_Table crss = null;
            List<registerd_crs_Table> courseslist = new List<registerd_crs_Table>();

            courseslist = db_record.registerd_crs_Table.ToList();
            //nw.SaveChanges();


            foreach (var item in courseslist)
            {
                if (item.std_id == id)
                {
                    crs.Add(item);
                    crss = item;
                    
                   
                }
            } // end of foreach 


            if (crss == null)
                return NotFound();
            else
                return Ok(crs);

        }

    }
}
