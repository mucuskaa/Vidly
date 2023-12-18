using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Chair
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Employee? Head { get; set; }
        public virtual Faculty? Faculty { get; set; }  

        public virtual ICollection<Speciality>? Specialities { get; set; }

        public Chair()
        {
            Specialities = new List<Speciality>();
        }
    }
}
