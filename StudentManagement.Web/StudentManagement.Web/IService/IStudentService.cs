using StudentManagement.Domain.Entities;
using System.Collections.Generic;

namespace StudentManagement.Web.IService
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
    }
}
