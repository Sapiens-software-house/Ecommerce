using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Model.DocModel
{
    public class priceLimit
    {
        [JsonPropertyName("max")]
        public decimal? Max { get; set; }

        [JsonPropertyName("min")]
        public decimal? Min { get; set; }
    }
}
