using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Color
    {
        public int Id { get; set; }

        [MaxLength(20)]
        [Required]
        public string Name { get; set; }

        public List<ProductOption> ProductOptions { get; set; }
    }
}