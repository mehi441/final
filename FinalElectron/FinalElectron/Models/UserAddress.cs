using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class UserAddress
    {

        public int Id { get; set; }

        [MaxLength(30)]
        [Required]
        public string Name { get; set; }

        [MaxLength(30)]
        [Required]
        public string Surname { get; set; }

        [MaxLength(150)]
        public string Company { get; set; }

        [MaxLength(250)]
        [Required]
        public string AddressFirst { get; set; }

        [MaxLength(250)]
        public string AddressSecond { get; set; }

        [MaxLength(50)]
        [Required]
        public string City { get; set; }

        [MaxLength(15)]
        [Required]
        public string PostCode { get; set; }

        [MaxLength(50)]
        [Required]
        public string Country { get; set; }

        [MaxLength(50)]
        [Required]
        public string Region { get; set; }

        [Column(TypeName = "bit")]
        public bool IsDefault { get; set; }

        public DateTime AddedDate { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public User User { get; set; }

        public List<Order> Orders { get; set; }

    }
}