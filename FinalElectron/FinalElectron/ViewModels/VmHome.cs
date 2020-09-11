using System;
using System.Collections.Generic;
using System.Linq;
using FinalElectron.Models;
using System.Web;

namespace FinalElectron.ViewModels
{
    public class VmHome
    {
        public List<Product> ProductsForCategories { get; set; }

        public List<Product> ProductsSpecial { get; set; }

        public List<Product> ProductsLatest { get; set; }






        //public List<Teacher> Teachers { get; set; }

        //public List<Course> Courses { get; set; }

        //public VmNotice VmNotice { get; set; }

        //public List<Event> Events { get; set; }

        //public List<Blog> Blogs { get; set; }

        //public VmAboutSlider VmAboutSlider { get; set; }
    }
}