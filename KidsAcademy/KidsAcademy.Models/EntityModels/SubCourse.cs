using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KidsAcademy.Models.EntityModels
{
    public class SubCourse
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int HoursPerWeek { get; set; }

        public virtual Course Course { get; set; }


    }
}
