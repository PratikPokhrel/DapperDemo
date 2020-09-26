using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ViewModels
{
    public class CourserVm
    {
        public CourserVm()
        {
            StudentCourse = new List<StudentCourserVm>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual List<StudentCourserVm> StudentCourse { get; set; }

    }
}
