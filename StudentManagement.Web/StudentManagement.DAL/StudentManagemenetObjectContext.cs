﻿using StudentManagement.Domain.Entities;
using StudentManagement.Domain.EntityMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.DAL
{
    public class StudentManagemenetObjectContext : DbContext, IDbContext
    {
        public StudentManagemenetObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressMap());
            modelBuilder.Configurations.Add(new StudentMap());
            base.OnModelCreating(modelBuilder);
        }
        

        public new IDbSet<T> Set<T>() where T : BaseEntity
        {
            return base.Set<T>();
        }
    }
}