using StudentManagement.DAL;
using StudentManagement.Domain.Entities;
using StudentManagement.Web.IService;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentManagement.Web.Service
{
    public class SudentService : IStudentService
    {
        private IRepository<Student> _studentRepository;
        private IRepository<Address> _addressRepository;

        public SudentService(IRepository<Student> studentRepository,
            IRepository<Address> addressRepository)
        {
            _studentRepository = studentRepository;
            _addressRepository = addressRepository;
        }

        public List<Student> GetAllStudents()
        {
            var address = new Address
            {
                City = "Delhi",
                Line1 = "B-53, 2nd Floor, DK Road",
                Line2 = "Mohan Garden, Nawada",
                PinCode = 110059
            };

            _addressRepository.Insert(address);

            var student = new Student
            {
                Address = _addressRepository.Table.ToList(),
                DOB = new DateTime(1993, 09, 16),
                FirstName = "Mohit",
                LastName = "Singh Bora"
            };

            _studentRepository.Insert(student);

            return _studentRepository.Table?.ToList();
        }
    }
}