using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPro.Entity;
using StudentPro.Service;

namespace StudentPro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private IServiceProvider service;
        private IStudentService studentService => service.GetService(typeof(IStudentService)) as IStudentService;

        public StudentController(IServiceProvider service)
        {
            this.service = service;
        }

        [Route("create-student")]
        public bool CreateStudent(StudentEntity student)
        {
            return this.studentService.CreateStudent(student);
        }

        [Route("get-student-byid")]
        public StudentEntity GetStudentsById([FromQuery(Name = "id")] int id)
        {
            return this.studentService.GetStudentById(id);
        }

        [Route("get-all-students")]
        public List<StudentEntity> GetAllStudents()
        {
            return this.studentService.GetAllStudents();
        }

        [Route("update-student")]
        public bool UpdateStudent([FromBody] StudentEntity student)
        {
            return this.studentService.UpdateStudent(student);
        }

        [Route("delete-student")]
        public bool DeleteStudent([FromQuery(Name = "id")] int id)
        {
            return this.studentService.DeleteStudent(id);
        }

    }
}