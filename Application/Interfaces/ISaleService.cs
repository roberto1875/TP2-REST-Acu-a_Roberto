using Application.Models;


namespace Application.Interfaces
{
    public interface ISaleService
    {
        public Task <List<SaleGetResponse>> GetSaleFilter(DateTime? fromDate, DateTime? toDate);
        public Task<SaleResponse> CreateSale(SaleRequest request);
        public Task<SaleResponse> SaleDetailService(int id);
       
    }
}
