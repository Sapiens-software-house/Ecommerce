using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.User
{
    public class ResponseIdentity
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
}
