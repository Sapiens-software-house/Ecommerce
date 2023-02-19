using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class ProductResponse
    {
        [JsonPropertyName("total")]
        public int total { get; set; }

        [JsonPropertyName("page")]
        public int page { get; set; }

        [JsonPropertyName("docs")]
        public Doc docs { get; set; }
    }
}
