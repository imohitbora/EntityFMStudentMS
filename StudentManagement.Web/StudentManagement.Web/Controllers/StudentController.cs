using StudentManagement.Domain.Entities;
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
            return View("Students", students);
        }

        public ActionResult EditStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult EditStudent(Student student)
        {
            _studentService.UpdateStudent(student);
            return RedirectToAction("GetAllStudents");
        }

        public ActionResult AddStudent()
        {
            var student = new Student();
            return View(student);
        }

        [HttpPost]
        public ActionResult AddStudent(Student student)
        {
            _studentService.AddStudent(student);
            return RedirectToAction("GetAllStudents");
        }

        public ActionResult DeleteStudent(int id)
        {
            var student = _studentService.GetStudentById(id);
            _studentService.DeleteStudent(student);

            return RedirectToAction("GetAllStudents");
        }
    }
}