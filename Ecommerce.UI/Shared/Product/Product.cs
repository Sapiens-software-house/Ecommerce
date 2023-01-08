using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Product
    {
        public string id { get; set; } // Id of product
        public string name { get; set; } // Name of product
        public string type { get; set; } // Type of product, currently it is always key
        public string slug { get; set; } // Slug of product
        public string qty { get; set; } // Qty of product available to buy        
        public int? minQty { get; set; } // Minimum product quantity available to buy
        public int? retail_min_price { get; set; } // minimal product price for retail users in EUR with fees.
        public int? retailMinBasePrice { get; set; } // minimal product price for retail users in EUR without fees. Price set by seller while adding offer.
        public string thumbnail { get; set; } // Url to image
        public string smallImage { get; set; } // Url to thumbnail image
        public string coverImage { get; set; } // Url to cover image
        public List<Image> images { get; set; } // Url list to all images in full resolution
        public string updated_at { get; set; } // 	date of last update
        public string release_date { get; set; } // Product release date
        public string region { get; set; } // Region of product eg. GLOBAL, EUROPE, AMERICA, NORTH AMERICA, RU/CIS, SOUTH EASTERN ASIA, WESTERN ASIA, GERMANY, INDIA, POLAND, UNITED KINGDOM etc.
        public string developer { get; set; } // Developer name of product
        public string publisher { get; set; } // Publisher name of product
        public string platform { get; set; } // Platform eg. Steam, Origin, Uplay, GOG, Xbox, Apple, Gameforge, Oculus Rift, HTC Vive, PSN, Blizzard
        public PriceLimit priceLimit { get; set; } // Price value possible to set while adding/updating offer. Higher than max or lower than min are not possible to use.            
        public Restriction restrictions { get; set; } // PEGI restrictions            
        public Requirement requirements { get; set; } // Requirements
        public Video[] videos { get; set; } // Videos            
        public Categories[] categories { get; set; } // Categories  
        public int? minPriceFrom { get; set; } // Minimal product's price start 
        public int? minPriceTo { get; set; } // Minimal product's price end 
        public string includeOutOfStock { get; set; } // Include out of stock and retail products. Default value: false, allowed values: true, false    
        public string updatedAtFrom { get; set; } // Filter by updated at from(yyyy-mm-dd hh:mm:ss) 
        public string updatedAtTo { get; set; } // Filter by updated at to (yyyy-mm-dd hh:mm:ss)    
        public int? page { get; set; } // 	Number of page to get.Page size is fixed 20.Default value: 1, allowed values: 1 - 500   
    }
}
