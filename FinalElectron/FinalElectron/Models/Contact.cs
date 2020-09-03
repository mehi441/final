using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [MaxLength(70)]
        [Required]
        public string Name { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [MaxLength(1000)]
        [Required]
        public string Enquiry { get; set; }

        public DateTime AddedDate { get; set; }
    }
}