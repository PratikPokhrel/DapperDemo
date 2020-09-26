using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ViewModels
{
    public class StudentVm
    {

        public StudentVm()
        {
            StudentCourse = new List<StudentCourserVm>();
        }
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ClassId { get; set; }
        public virtual ClassVm Classs { get; set; }
        public virtual List<StudentCourserVm> StudentCourse { get; set; }

    }
}
