using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Video
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }

        public string type { get; set; } // Type of video eg. YOUTUBE -- tirar o s do types 
        public string url { get; set; } // Url to video
    }
}
