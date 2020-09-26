using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class Course:BaseEntity
    {

        public Course()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public Course(Guid _id,string _name,string _description)
        {
            Id = _id;
            Name = _name;
            Description = _description;
        }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<StudentCourse> StudentCourse { get; set; }

    }
}
