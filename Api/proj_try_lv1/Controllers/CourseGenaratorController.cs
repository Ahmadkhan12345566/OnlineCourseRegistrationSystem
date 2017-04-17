using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using proj_try_lv1.Models;
namespace proj_try_lv1.Controllers
{
    public class CourseGenaratorController : ApiController
    {
        Online_regEntities crs_db = new Online_regEntities();//dbconnection
        List<Registerd_courses_Table> reg_crs = new List<Registerd_courses_Table>();//for collecting all registerd courses
        List<Registerd_courses_Table> reg_crs_full_detail = new List<Registerd_courses_Table>();//list to mantain full table recorad of student regtrd course
        List<Student_courses> reg_crs_list = new List<Student_courses>();//getting the list of courses if a specific student
        List<Students_Table> students_record = new List<Students_Table>();//getting record of all students
        Studentdetail student_detail = new Studentdetail();//for collecting the detail of a specfic student
        List<Student_courses> fail_reg_crs_list = new List<Student_courses>();//collecting fail courses of a student 
        List<status_Table> status_list = new List<status_Table>();//list of status in database
        List<Offerd_course_table> offer_crs_list = new List<Offerd_course_table>();//list for collecting all offerd courses
        List<Offerd_course_table> offer_crs_list_of_session = new List<Offerd_course_table>();//lsit of specific session courses
        List<Offerd_course_table> genrated_offer_crs_list = new List<Offerd_course_table>();//generated list of offer course for student


        //Getting student detail of the given student  id
        Studentdetail student_detal(string id)
        {
            students_record = crs_db.Students_Table.ToList();
            foreach ( var item in students_record)
            {
                if (id == item.registration_id)
                {
                    student_detail.student_name = item.name_;
                    student_detail.student_departmnt = item.degree_programs.Department_Table.department_name_;
                    student_detail.student_program = item.degree_programs.degree_title_;
                    
                }
            }
            return student_detail;
        }
       
       //getting all registerd courses of the student of the given student id
        void registerd_coursea(string id)
        {
            reg_crs = crs_db.Registerd_courses_Table.ToList();
            foreach (var iteam in reg_crs) {
                Student_courses course = new Student_courses();
                if (id==iteam.Students_Table.registration_id) {
                 
                    course.Courses_Id = iteam.Offerd_course_table.Courses_Id;
                    course.Course_Code = iteam.Offerd_course_table.Courses_Table.Course_Code;
                    course.Course_Title = iteam.Offerd_course_table.Courses_Table.Course_Title_;
                    course.Cr_Hrs = iteam.Offerd_course_table.Courses_Table.Cr_Hrs;
                    course.Remark = iteam.Remarks_Table.Remark_title;
                    course.status = iteam.status_Table.status_title;
                    reg_crs_full_detail.Add(iteam);
                    reg_crs_list.Add(course);
                }
              
                    }
            //return reg_crs_list;
        }



       
        //generating offered courses of a student
        void  genrate_offer_course(string id)
        {

            //check fail couses and offer if possible 

            offer_fail_course(id);

            //genrate courses from offerd courses 

            gen_new_offerd_courses(id);

        }

        List<S_Courses_Table> semester_course_limit = new List<S_Courses_Table>();
        //genrate courses from offerd courses 

        List<Registerd_courses_Table> reg_semester_course = new List<Registerd_courses_Table>();
        List<Offerd_course_table> offer_semster_course = new List<Offerd_course_table>();
        void gen_new_offerd_courses(string id)
        {
            semester_course_limit = crs_db.S_Courses_Table.ToList();
            foreach (var limt_iteam in semester_course_limit)
            {
                int count_semester_courses=0;
               foreach(var reg_crs in reg_crs_full_detail)
                {
                    if (reg_crs.Offerd_course_table.Courses_Table.Semester_Number.Trim() == limt_iteam.S_courses_Id.ToString())
                    {
                        count_semester_courses++;
                    }
                }
                if (count_semester_courses < limt_iteam.S_courses)
                {
                    //calling function to offer remaning courses of a semester
                    //
                  reg_semester_course.Clear();
                    offer_semster_course.Clear();
                    offer_remning_crs_semester(id,limt_iteam.S_courses_Id.ToString());
                    if (genrate_offer_crs_list.Count() == 6)
                    {
                        return;
                    }


                }
            }

        }



        //completing remaning course of semester
   
        void offer_remning_crs_semester(string id, string semsester)
        {
            //find courses of this semester from reg course of student
            semser_course_from_regcourses(id, semsester);
            //find courses of this semester from offerd course
            semser_course_from_offercourses(id, semsester);
            foreach (var offer_s_crs in offer_semster_course)
            {
                int check = 1;
                //check function of finding register semester course
                foreach (var reg_s_crs in reg_semester_course)
                {
                    //check this condition
                    if (offer_s_crs.Courses_Table.Course_Code == reg_s_crs.Offerd_course_table.Courses_Table.Course_Code)
                    {
                        check++;
                        break;
                    }
                }
                if (check == 1)
                {
                    if (genrate_offer_crs_list.Count() < 7)
                    {
                        //check pre rack cleard and offer
                        if (offer_s_crs.Courses_Table.Pre_requisite_id == null)
                        {
                            //
                            Student_courses course = new Student_courses();


                            course.Courses_Id = offer_s_crs.Courses_Id;
                            course.Course_Code = offer_s_crs.Courses_Table.Course_Code;
                            course.Course_Title = offer_s_crs.Courses_Table.Course_Title_;
                            course.Cr_Hrs = offer_s_crs.Courses_Table.Cr_Hrs;
                            //course.Remark = itm_crs.Remark_title;
                            // course.status = iteam.status_Table.status_title;
                            genrate_offer_crs_list.Add(course);
                            genrated_offer_crs_list.Add(offer_s_crs);


                        }
                        else
                        {
                            foreach (var cours in reg_crs_full_detail)
                            {
                                if (offer_s_crs.Courses_Table.Pre_requisite_id == cours.Offerd_course_table.Courses_Table.Courses_Id && cours.status_Id == 1)
                                {
                                    Student_courses course = new Student_courses();


                                    course.Courses_Id = offer_s_crs.Courses_Id;
                                    course.Course_Code = offer_s_crs.Courses_Table.Course_Code;
                                    course.Course_Title = offer_s_crs.Courses_Table.Course_Title_;
                                    course.Cr_Hrs = offer_s_crs.Courses_Table.Cr_Hrs;
                                    //course.Remark = itm_crs.Remark_title;
                                    // course.status = iteam.status_Table.status_title;
                                    genrate_offer_crs_list.Add(course);
                                    genrated_offer_crs_list.Add(offer_s_crs);

                                    break;

                                }
                            }
                            //check_pre_rack(id, offer_s_crs.Courses_Table.Course_Code);
                        }


                    }
                    //not valid place for this return 
                    //check combined condation
                    else
                    {
                     return;
                    }

                }
            }
        }

        //check pre _rack
/*
void  check_pre_rack(string id,string Cours)
        {


        }

    */


        //find semseter course from reg course
        void semser_course_from_regcourses(string id, string semsester)
        {
            foreach(var reg_itea in reg_crs_full_detail)
            {
                if (reg_itea.Offerd_course_table.Courses_Table.Semester_Number.Trim() == semsester)
                {
                    reg_semester_course.Add(reg_itea);
                }
            }

        }

        //find semseter course from offer course
        void semser_course_from_offercourses(string id, string semsester)
        {
            foreach (var reg_itea in offer_crs_list_of_session)
            {
                if (reg_itea.Courses_Table.Semester_Number.Trim() == semsester)
                {
                    offer_semster_course.Add(reg_itea);
                }
            }

        }




        List<Student_courses> genrate_offer_crs_list = new List<Student_courses>();
        void offer_fail_course(string id)
        {
            //get fail courses
            chk_f_frm_reg_crs(id);

            string session = "summer2016";

            //getting course of a specific session and department 
            offer_crs_of_session(session,id);

            foreach (var iteam_f_c in fail_reg_crs_list)
            {
                foreach (var itm_crs in offer_crs_list_of_session)
                {
                    if (iteam_f_c.Course_Code == itm_crs.Courses_Table.Course_Code)
                    {

                        Student_courses course = new Student_courses();
                       

                            course.Courses_Id = itm_crs.Courses_Id;
                            course.Course_Code = itm_crs.Courses_Table.Course_Code;
                            course.Course_Title = itm_crs.Courses_Table.Course_Title_;
                            course.Cr_Hrs = itm_crs.Courses_Table.Cr_Hrs;
                        //course.Remark = itm_crs.Remark_title;
                        // course.status = iteam.status_Table.status_title;
                            genrate_offer_crs_list.Add(course);
                            genrated_offer_crs_list.Add(itm_crs);
                        break;
                    }
                }
               
            } 


        }

        //despers all offered courses of this session and department
        void offer_crs_of_session(string session,string id)
        {
            student_detail = student_detal(id);
            offer_crs_list = crs_db.Offerd_course_table.ToList();
            foreach (var iteam in offer_crs_list)
            {
                if (iteam.Session == session && student_detail.student_program==iteam.Courses_Table.degree_programs.degree_title_)
                {
                    offer_crs_list_of_session.Add(iteam);
                }
            }

        }

        //despers fail couses in a new list
        void chk_f_frm_reg_crs(string id)
        {

            registerd_coursea(id);

            foreach(var iteam in reg_crs_list)
            {
                if (iteam.status == "Fail")
                {
                    fail_reg_crs_list.Add(iteam);
                }
            }

        }
















        // Section 
        //Data return to WPF application 


        //return list of registerd courses of a specific student to wpfapp
        [Route("api/regcrs_list/{id}")]
        [HttpGet]
        public IHttpActionResult GetCourse(string id)
        {
            registerd_coursea(id);
            //offer_fail_course(id);
            if (reg_crs_list == null)
                return NotFound();
            else
                return Ok(reg_crs_list);

        }


        //return list of  student of a specific student to wpfapp
        [Route("api/Student_detail/{id}")]
        [HttpGet]
        public IHttpActionResult GetStudent_detail(string id)
        {

            student_detail = student_detal(id);
            if (student_detail == null)
                return NotFound();
            else
                return Ok(student_detail);

        }





        // return list of generated offer to student courses to wpf
        [Route("api/offercourse/{id}")]
        [HttpGet]
        public IHttpActionResult Getoffercourse(string id)
        {
            
            genrate_offer_course(id);
            if (genrate_offer_crs_list == null)
                return NotFound();
            else
                return Ok(genrate_offer_crs_list);

        }









    }
}
