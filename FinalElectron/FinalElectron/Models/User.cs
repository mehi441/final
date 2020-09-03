using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class User
    {
        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(40)]
        [Required]
        public string Email { get; set; }

        [MaxLength(20)]
        [Required]
        public string Phone { get; set; }

        [MaxLength(250)]
        [Required]
        public string Password { get; set; }

        [Column(TypeName = "bit")]
        public bool IsNewsletter { get; set; }

        public DateTime AddedDate { get; set; }

        public List<UserAddress> UserAddresses { get; set; }
    }
}