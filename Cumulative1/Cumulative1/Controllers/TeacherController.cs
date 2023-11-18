using Cumulative1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Cumulative1.Controllers
{
    public class TeacherController : Controller
    {
        //GET : /Teacher/List
        public ActionResult List()
        {
            TeacherDataController controller = new TeacherDataController();
            IEnumerable<Teacher> Teachers = controller.ListTeachers();
            return View(Teachers);
        }

        //GET : /Teacher/Show/{id}
        public ActionResult Show(int id)
        {
            TeacherDataController controller = new TeacherDataController();
            Teacher NewTeacher = controller.FindTeacher(id);


            return View(NewTeacher);
        }
        //GET : /Teacher/ShowByName/{id}
        public ActionResult ShowByName(String name)
        {
            FindTeacherDataController controller = new FindTeacherDataController();
            Teacher NewTeacher = controller.FindTeacherByFName(name);


            return View(NewTeacher);
        }

    }
}