using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class BrandModel
    {
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }


        [ForeignKey("Brand")]
        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public List<Product> Products { get; set; }
    }
}