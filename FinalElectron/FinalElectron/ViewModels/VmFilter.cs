using FinalElectron.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalElectron.ViewModels
{
    public class VmFilter
    {
         
        public List<Product> ProFilters { get; set; }

        public List<KeyValuePair<string,int>> BrandAndCounts { get; set; }

        public KeyValuePair<int,int> StockAndOutSrock { get; set; }
    }
}