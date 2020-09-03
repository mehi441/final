using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FinalElectron.Models
{
    public class Product
    {
        public int Id { get; set; }

        [MaxLength(200)]
        [Required]
        public string Name { get; set; }

        [Column(TypeName = "ntext")]
        [Required]
        public string Content { get; set; }

        [Column(TypeName = "bit")]
        public bool IsSpecial { get; set; }

        public DateTime AddedDate { get; set; }

        [ForeignKey("SubCategory")]
        public int SubCategoryId { get; set; }
        public SubCategory SubCategory { get; set; }

        [ForeignKey("Model")]
        public int ModelId { get; set; }
        public BrandModel Model { get; set; }

        public List<ProductOption> ProductOptions { get; set; }

        public List<Review> Reviews { get; set; }

        public List<Description> Descriptions { get; set; }

        public List<ProductImage> ProductImages { get; set; }

        [NotMapped]
        public HttpPostedFileBase[] ImageFile { get; set; }
    }
}