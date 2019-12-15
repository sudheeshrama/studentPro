﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentPro.DatabaseContext;
using StudentPro.Entity;

namespace StudentPro.Service
{
    public class StudentService : IStudentService
    {
        private IServiceProvider serviceProvider { get; }
        private ApplicationDbContext context => serviceProvider.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
        
        public StudentService(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        
        public bool CreateStudent(StudentEntity entity)
        {
            context.students.Add(entity);
            return context.SaveChanges() > 0 ? true : false;
        }

        public bool DeleteStudent(int id)
        {
            var s = context.students.Where(x => x.Id == id).FirstOrDefault();
            context.students.Remove(s);
            return context.SaveChanges() == 1 ? true : false;
        }

        public List<StudentEntity> GetAllStudents()
        {
            return context.students.ToList();
        }

        public StudentEntity GetStudentById(int id)
        {
            return context.students.Where(x => x.Id == id).FirstOrDefault();
        }

        public bool UpdateStudent(StudentEntity entity)
        {
            StudentEntity existingStudent = context.students.Where(x => x.Id == entity.Id).FirstOrDefault();
            if (existingStudent.Id > 0)
            {
                existingStudent.City = entity.City;
                existingStudent.Email = entity.Email;
                existingStudent.LastName = entity.LastName;
                existingStudent.FirstName = entity.FirstName;
                existingStudent.PhoneNumber = entity.PhoneNumber;
                existingStudent.EnrolledDate = entity.EnrolledDate;
            }
            context.Entry(existingStudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return context.SaveChanges() > 0 ? true : false;
        }
    }
}
