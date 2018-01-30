using System;
using System.Collections.Generic;

namespace StudentManagement.Domain.Entities
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }

        public virtual List<Address> Address { get; set; }
    }
}
