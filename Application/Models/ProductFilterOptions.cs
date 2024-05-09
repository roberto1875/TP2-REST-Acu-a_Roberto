using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    public class ProductFilterOptions
    {
        public int[]? Categories { get; set; }
        public string? Name { get; set; }
        public int Limit { get; set; } = 0;
        public int Offset { get; set; } = 0;
    }
}
