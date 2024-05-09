using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using static Application.Exceptions.Exceptions;

namespace Application.UseCase.Service
{
    public class SaleServiceUtils
    {
        private readonly ISaleQuery _query;

        public SaleServiceUtils(ISaleQuery query)
        {
            _query = query;
        }

        public void CheckQuantity(SaleProductRequest saleRequest, List<string> errors)
        {
            if (saleRequest.Quantity <= 0)
            {
                errors.Add($"La cantidad debe ser mayor a cero.");
            }

        }

        public void ErrorsList(List<string> errors)
        {

            if (errors.Any())
            {
                throw new BadRequestException(string.Join(" ", errors));
            }


        }


        public void ChekTotalPay(Sale sale, SaleRequest request, List<string> errors)
        {

            if (sale.TotalPay != request.TotalPayed)
            {
                errors.Add($"El total calculado no coincide con el total pagado.");
            }

        }

        public void ProductNotFound(Guid id, List<string> errors)
        {
            errors.Add($"Producto no encontrado {id}");
        }


        public void SaleNotFound(int id, Sale sale)
        {
            if (sale == null)
            {
                throw new SaleNotFoundException(id);
            }
        }


    }
}
