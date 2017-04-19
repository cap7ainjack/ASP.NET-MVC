using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.EntityModels
{
   public class Parent
    {
       public Parent()
       {
           this.Kids = new HashSet<Student>();
       }

       public int Id { get; set; }

        public string PhoneNumber { get; set; }

       public virtual ApplicationUser User { get; set; }

       public virtual ICollection<Student> Kids { get; set; }
    }
}
