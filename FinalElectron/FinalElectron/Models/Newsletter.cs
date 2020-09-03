using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Newsletter
    {
        public int Id { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        public DateTime AddedDate { get; set; }
    }
}