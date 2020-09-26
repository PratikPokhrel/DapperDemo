using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DapperDemo.Services;
using DapperDemo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DapperDemo.Controllers
{

    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        protected readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet("[action]")]
        public async Task<object> GetList()
        
        {
            List<StudentVm> students = await _studentService.GetStudentListDapperAsync();
            List<StudentVm> students1 = await _studentService.GetStudentListEFCoreAsync();
            return Ok(students);
        }


        [HttpGet("[action]/{id}")]
        public async Task<object> Get(Guid id)
        {
            StudentVm student = await _studentService.GetByIdAsync(id);
            return Ok(student);
        }
    }
}