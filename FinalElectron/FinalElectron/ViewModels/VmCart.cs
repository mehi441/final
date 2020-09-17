using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalElectron.ViewModels
{
    public class VmCart
    {
        public List<ProductOption> ProductOptions { get; set; }

        public List<KeyValuePair<int, int>> List { get; set; }
    }
}