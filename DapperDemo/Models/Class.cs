using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace DapperDemo.Models
{
    public class Class:BaseEntity
    {
        public Class() { }

        public Class(Guid _id,string _name,string _description)
        {
            Id = _id;
            Name = _name;
            Description = _description;
        }
        public string Name { get; set; }
        public string Description { get; set; }
       
    }
}
