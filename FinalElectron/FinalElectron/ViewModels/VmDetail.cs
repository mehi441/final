using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalElectron.Models;

namespace FinalElectron.ViewModels
{
    public class VmDetail
    {

        public ProductOption ProOption { get; set; }

        public Product Product { get; set; }

        public Color Color { get; set; }

        public ProductImage ProductImage { get; set; }

        public string Code { get; set; }

        public List<ProductOption> ProductOptions { get; set; }

        public List<Specification> Specifications { get; set; }



        //public List<HomeSlide> HomeSlides { get; set; }

        //public List<Teacher> Teachers { get; set; }

        //public List<Course> Courses { get; set; }

        //public VmNotice VmNotice { get; set; }

        //public List<Event> Events { get; set; }

        //public List<Blog> Blogs { get; set; }

        //public VmAboutSlider VmAboutSlider { get; set; }

    }
}