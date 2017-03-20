using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarDealer.Models.BindingModels
{
    public class NewCarBindingModel
    {
        public string Make { get; set; }

        public long TravelledDistance { get; set; }

        public string Model { get; set; }

        public int Part1 { get; set; }

        public int Part2 { get; set; }

        public int Part3 { get; set; }
    }
}