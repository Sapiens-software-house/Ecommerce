using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Filter
    {
        public string id { get; set; } // Id of product
        public int? minPriceFrom { get; set; } // Minimal product's price start 
        public int? minPriceTo { get; set; } // Minimal product's price end 
        public string includeOutOfStock { get; set; } // Include out of stock and retail products. Default value: false, allowed values: true, false    
        public string updatedAtFrom { get; set; } // Filter by updated at from(yyyy-mm-dd hh:mm:ss) 
        public string updatedAtTo { get; set; } // Filter by updated at to (yyyy-mm-dd hh:mm:ss)    
        public int? page { get; set; } // 	Number of page to get.Page size is fixed 20.Default value: 1, allowed values: 1 - 500 
    }
}
