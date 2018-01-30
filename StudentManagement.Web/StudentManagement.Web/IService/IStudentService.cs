using StudentManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Web.IService
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
    }
}
