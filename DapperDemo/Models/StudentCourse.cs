using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class StudentCourse
    {
        public StudentCourse() { }

        public StudentCourse(Guid _id,Guid _stdId,Guid _courseId)
        {
            Id = _id;
            StudentId = _stdId;
            CourseId = _courseId;
        }
        public Guid Id { get; set; }
        public Guid? StudentId { get; set; }
        public virtual Student Student { get; set; }
        public Guid? CourseId { get; set; }
        public virtual Course Course  { get; set; }
    }
}
