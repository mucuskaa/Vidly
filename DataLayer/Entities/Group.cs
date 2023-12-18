using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Speciality? Speciality { get; set; }
        public virtual Employee? Supervisor { get; set; } 
        public virtual ICollection<Student>? Students { get; set; } 

        public Group()
        {
            Students = new List<Student>();
        }
    }
}
