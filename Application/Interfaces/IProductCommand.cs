using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
   public interface IProductCommand
    {
        public Task InsertProduct(Product product);
        public Task UpDateProductComand(Product product);
        public Task DeleteProduct(Product product);
    }
}
