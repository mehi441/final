using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Specification
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }

        [MaxLength(100)]
        [Required]
        public string Content { get; set; }

        [ForeignKey("ProductOption")]
        public int ProductOptionId { get; set; }
        public ProductOption ProductOption { get; set; }
    }
}