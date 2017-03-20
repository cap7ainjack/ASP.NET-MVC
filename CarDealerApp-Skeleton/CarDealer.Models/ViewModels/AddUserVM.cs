using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarDealer.Models.ViewModels
{
    public class AddUserVM
    {
        public string Username { get; set; }

        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}