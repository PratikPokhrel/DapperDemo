using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class Student : BaseEntity
    {
        public Student()
        {
            StudentCourse = new HashSet<StudentCourse>();
        }

        public Student(Guid _id,string _firstName,string _lastName,string _email,Guid _classId)
        {
            Id = _id;
            FirstName = _firstName;
            LastName = _lastName;
            Email = _email;
            ClassId = _classId;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid ClassId { get; set; }
        public virtual Class Classs { get; set; }


        public virtual ICollection<StudentCourse> StudentCourse { get; set; }
    }
}
