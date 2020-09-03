using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Review
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Name { get; set; }

        [MaxLength(500)]
        [Required]
        public string Content { get; set; }

        [Column(TypeName = "tinyint")]
        [Required]
        public byte Star { get; set; }

        public DateTime AddedDate { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}