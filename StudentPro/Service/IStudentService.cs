using StudentPro.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentPro.Service
{
    public interface IStudentService
    {
        bool CreateStudent(StudentEntity entity);
        List<StudentEntity> GetAllStudents();
        StudentEntity GetStudentById(int id);
        bool UpdateStudent(StudentEntity entity);
        bool DeleteStudent(int id);
    }
}
