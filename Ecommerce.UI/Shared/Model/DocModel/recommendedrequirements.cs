using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Model.DocModel
{
    public class recommendedRequirements
    {
        [JsonPropertyName("reqprocessor")]
        public string Processor { get; set; }

        [JsonPropertyName("reqgraphics")]
        public string Graphics { get; set; }

        [JsonPropertyName("reqmemory")]
        public string Memory { get; set; }

        [JsonPropertyName("reqdiskspace")]
        public string DiskSpace { get; set; }

        [JsonPropertyName("reqsystem")]
        public string System { get; set; }

        [JsonPropertyName("reqother")]
        public string Other { get; set; }
    }
}
