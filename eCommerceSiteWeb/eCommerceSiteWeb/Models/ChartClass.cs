using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSiteWeb.Models
{
    public class ChartClass
    {
        public string IDProduct { get; set; }
        public int Quantity { get; set; }
        public Double PriceSingProduct { get; set; }
        public Double TotPriceSingProduct { get; set; }
        public Double TotPriceAllProduct { get; set; }
        public string category { get; set; }
        public int numerPiece { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        
    }
}