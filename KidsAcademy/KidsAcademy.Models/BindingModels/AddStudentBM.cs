using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.BindingModels
{
   public class AddStudentBM
    {
        public DateTime Birthdate { get; set; }

        public string Adress { get; set; }

      //  public StudentShift StudentShift { get; set; }

       public int Course { get; set; }
    }
}
