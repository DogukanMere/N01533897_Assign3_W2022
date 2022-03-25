using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using N01533897_Assign3_W2022.Models;

namespace N01533897_Assign3_W2022.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        public ActionResult Index()
        {
            return View();
        }

        //GET: /Student/StudentList
        public ActionResult StudentList()
        {
            StudentDataController studentController = new StudentDataController();
            IEnumerable<Student> Students = studentController.ListStudents();

            return View(Students);
        }

        //GET: /Student/ShowStudent/{id}
        public ActionResult ShowStudent(int id)
        {
            StudentDataController studentController = new StudentDataController();
            Student NewStudent = studentController.FindStudent(id);

            return View(NewStudent);
        }
    }
}