using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Username { get; set; }

        [MaxLength(50)]
        [Required]
        public string Fullname { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [MaxLength(250)]
        [Required]
        public string Password { get; set; }

        public DateTime AddedDate { get; set; }

        public List<Admin> Admins { get; set; }
    }
}