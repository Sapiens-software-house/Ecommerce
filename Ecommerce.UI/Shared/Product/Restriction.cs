using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Restriction
    {
        public int Id { get; set; }
        public string IdProduto { get; set; }
        public Product Produto { get; set; }
        public bool? pegi_violence { get; set; } // Violence
        public bool? pegi_profanity { get; set; } // Profanity
        public bool? pegi_discrimination { get; set; } // Discrimination
        public bool? pegi_drugs { get; set; } // Drugs
        public bool? pegi_fear { get; set; } // Fear
        public bool? pegi_gambling { get; set; } // Gambling
        public bool? pegi_online { get; set; } // Online
        public bool? pegi_sex { get; set; } // Sex
    }
}
