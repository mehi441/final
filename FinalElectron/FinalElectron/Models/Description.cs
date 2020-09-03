using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Description
    {
        public int Id { get; set; }

        [MaxLength(150)]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}