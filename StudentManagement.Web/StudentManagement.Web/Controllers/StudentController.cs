using StudentManagement.Web.IService;
using System.Web.Mvc;

namespace StudentManagement.Web.Controllers
{
    public class StudentController : Controller
    {        
        private IStudentService _studentService;
        
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        // GET: Student
        public ActionResult GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
           // return View(students);

            return View("Students", students);
        }
    }
}