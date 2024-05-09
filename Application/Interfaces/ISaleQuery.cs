using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleQuery
    {
        public Task <List<Sale>> GetSaleByDate(DateTime? fromDate, DateTime? toDate);
        public Task<Sale> GetSaleById(int id);
    }
}
