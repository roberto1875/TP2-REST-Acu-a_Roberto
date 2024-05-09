

namespace Application.Models
{
    public class SaleGetResponse
    {
        public int Id { get; set; }
        public double TotalPay { get; set; }
        public int TotalQuantity { get; set; }
        public DateTime Date { get; set; }
    }
}
