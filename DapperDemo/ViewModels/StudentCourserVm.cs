using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.ViewModels
{
    public class StudentCourserVm
    {
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public virtual StudentVm Student { get; set; }
        public Guid? CourseId { get; set; }
        public virtual CourserVm Course { get; set; }
    }
}
