using StudentManagement.DAL;
using StudentManagement.Domain.Entities;
using StudentManagement.Web.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentManagement.Web.Service
{
    public class SudentService : IStudentService
    {
        private IRepository<Student> _repository;

        public SudentService(IRepository<Student> repository)
        {
            _repository = repository;
        }

        public List<Student> GetAllStudents()
        {
            return _repository.Table.ToList();
        }
    }
}