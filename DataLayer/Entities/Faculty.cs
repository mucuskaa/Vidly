using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Entities
{
    public class Faculty
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Employee? Dean { get; set; }  

        public virtual ICollection<Chair>? Chairs { get; set; }  

        public Faculty()
        {
            Chairs = new List<Chair>();
        }
    }
}
