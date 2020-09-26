using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalElectron.ViewModels
{
    public class LoginAdmin
    {
        [Required]
        public string Username { get; set; }
         
        [Required]
        public string Password { get; set; }
    }
}