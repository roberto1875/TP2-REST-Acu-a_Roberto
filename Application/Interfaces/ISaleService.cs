using Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface ISaleService
    {
        public Task <List<SaleGetResponse>> GetSaleFilter(DateTime? fromDate, DateTime? toDate);
        public Task<SaleResponse> CreateSale(SaleRequest request);
        public Task<SaleResponse> SaleDetailService(int id);
       
    }
}
