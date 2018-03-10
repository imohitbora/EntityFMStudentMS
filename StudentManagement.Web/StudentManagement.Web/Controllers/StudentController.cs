using StudentManagement.Domain.Entities;
using StudentManagement.Web.IService;
using System.Web.Mvc;
using System.Linq;

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
            var studentToUpdate = _studentService.GetStudentById(student.Id);

            studentToUpdate.FirstName = student.FirstName;
            studentToUpdate.LastName = studentToUpdate.LastName;
            studentToUpdate.DOB = studentToUpdate.DOB;
            studentToUpdate.Address.City = student.Address.City;
            studentToUpdate.Address.Line1 = student.Address.Line1;
            studentToUpdate.Address.Line2 = student.Address.Line2;
            studentToUpdate.Address.PinCode = student.Address.PinCode;

            _studentService.UpdateStudent(studentToUpdate);
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