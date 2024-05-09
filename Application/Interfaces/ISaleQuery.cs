using Domain.Entities;


namespace Application.Interfaces
{
    public interface ISaleQuery
    {
        public Task <List<Sale>> GetSaleByDate(DateTime? fromDate, DateTime? toDate);
        public Task<Sale> GetSaleById(int id);
    }
}
