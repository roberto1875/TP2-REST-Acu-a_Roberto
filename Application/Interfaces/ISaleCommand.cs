using Domain.Entities;


namespace Application.Interfaces
{
    public interface ISaleCommand
    {
        public Task AddSale(Sale sale);

    }
}
