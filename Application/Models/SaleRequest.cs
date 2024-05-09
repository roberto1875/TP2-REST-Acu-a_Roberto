using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class SaleRequest
    {
        public List<SaleProductRequest> Products { get; set; }
        public decimal TotalPayed { get; set; }
    }
}
