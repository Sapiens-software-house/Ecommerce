using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Model.DocModel
{
    public class requirements
    {
        [JsonPropertyName("minimal")]
        public minimalRequirements Minimal { get; set; }

        [JsonPropertyName("recommended")]
        public recommendedRequirements Recommended { get; set; }
    }
}
