using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.UI.Shared.Product
{
    public class Requirement
    {
        public int Id { get; set; }
        public int IdProduto { get; set; }
        public List<Minimal> minimal { get; set; }
        public List<Recommended> recommended { get; set; }
    }
}
