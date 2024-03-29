﻿using Ecommerce.UI.Shared.Cart;
using Ecommerce.UI.Shared.Orders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int priceLimitId { get; set; } // Price value possible to set while adding/updating offer. Higher than max or lower than min are not possible to use.            
        public PriceLimit priceLimit { get; set; } // Price value possible to set while adding/updating offer. Higher than max or lower than min are not possible to use.            
        public int restrictionsId { get; set; } // Price value possible to set while adding/updating offer. Higher than max or lower than min are not possible to use.  
        public Restriction restrictions { get; set; } // PEGI restrictions
                                                      // 
        public int requirementsId { get; set; }
        public Requirement requirements { get; set; } // Requirements
        public List<Video> videos { get; set; } // Videos            
        public List<Categories> categories { get; set; } // Categories
        [NotMapped]
        public List<CartItem> CartItem { get; set; } // Categories

        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
    }
}
