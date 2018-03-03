using StudentManagement.Domain.Entities;
using System.Collections.Generic;

namespace StudentManagement.Web.IService
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();

        Student GetStudentById(int id);

        void UpdateStudent(Student student);

        void DeleteStudent(Student student);

        void AddStudent(Student student);
    }
}
