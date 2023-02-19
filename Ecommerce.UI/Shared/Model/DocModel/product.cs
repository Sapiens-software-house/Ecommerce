using Ecommerce.UI.Shared.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Model.DocModel
{
    public class product
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("slug")]
        public string Slug { get; set; }

        [JsonPropertyName("qty")]
        public int Quantity { get; set; }

        [JsonPropertyName("minPrice")]
        public double MinPrice { get; set; }

        [JsonPropertyName("retail_min_price")]
        public double RetailMinPrice { get; set; }

        [JsonPropertyName("retailMinBasePrice")]
        public double RetailMinBasePrice { get; set; }

        [JsonPropertyName("thumbnail")]
        public string Thumbnail { get; set; }

        [JsonPropertyName("smallImage")]
        public string SmallImage { get; set; }

        [JsonPropertyName("coverImage")]
        public string CoverImage { get; set; }

        [JsonPropertyName("images")]
        public List<string> Images { get; set; }

        [JsonPropertyName("updated_at")]
        public string UpdatedAt { get; set; }

        [JsonPropertyName("release_date")]
        public string ReleaseDate { get; set; }

        [JsonPropertyName("region")]
        public string Region { get; set; }

        [JsonPropertyName("developer")]
        public string Developer { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("platform")]
        public string Platform { get; set; }

        [JsonPropertyName("priceLimit")]
        public priceLimit PriceLimit { get; set; }

        [JsonPropertyName("restrictions")]
        public restrictions Restrictions { get; set; }

        [JsonPropertyName("requirements")]
        public requirements Requirements { get; set; }

        [JsonPropertyName("videos")]
        public List<videos> Videos { get; set; }

        [JsonPropertyName("categories")]
        public List<category> Categories { get; set; }
    }
}
