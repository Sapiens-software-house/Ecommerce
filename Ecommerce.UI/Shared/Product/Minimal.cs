using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Minimal
    {
        public int Id { get; set; }
        public int IdRequirement { get; set; }
        public Requirement Requirement { get; set; }
        public string reqprocessor { get; set; } // Processor
        public string reqgraphics { get; set; } // Graphics
        public string reqmemory { get; set; } // Memory
        public string reqdiskspace { get; set; } // Disk space
        public string reqsystem { get; set; } // Operating system
        public string reqother { get; set; } // Other
    }
}
