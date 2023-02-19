using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Model.DocModel
{
    public class restrictions
    {
        [JsonPropertyName("pegi_violence")]
        public bool PegiViolence { get; set; }

        [JsonPropertyName("pegi_profanity")]
        public bool PegiProfanity { get; set; }

        [JsonPropertyName("pegi_discrimination")]
        public bool PegiDiscrimination { get; set; }

        [JsonPropertyName("pegi_drugs")]
        public bool PegiDrugs { get; set; }

        [JsonPropertyName("pegi_fear")]
        public bool PegiFear { get; set; }

        [JsonPropertyName("pegi_gambling")]
        public bool PegiGambling { get; set; }

        [JsonPropertyName("pegi_online")]
        public bool PegiOnline { get; set; }

        [JsonPropertyName("pegi_sex")]
        public bool PegiSex { get; set; }
    }
}
