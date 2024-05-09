using Application.Interfaces;
using Application.Models;
using Domain.Entities;
using static Application.Exceptions.Exceptions;

namespace Application.UseCase.Service
{
    public class SaleService : ISaleService
    {

        private readonly ISaleQuery _querySale;
        private readonly IProductQuery _productQuery;
        private readonly ISaleCommand _saleCommand;


        public SaleService(ISaleQuery querySale, IProductQuery productQuery, ISaleCommand saleCommand)
        {
            _querySale = querySale;
            _productQuery = productQuery;
            _saleCommand = saleCommand;
        }


        public async Task<List<SaleGetResponse>> GetSaleFilter(DateTime? fromDate, DateTime? toDate)
        {
            List<Sale> sales = await _querySale.GetSaleByDate(fromDate, toDate);

            List<SaleGetResponse> response = sales.Select(sale => new SaleGetResponse
            {
                Id = sale.SaleId,
                TotalPay = (double)sale.TotalPay,
                TotalQuantity = (int)sale.Subtotal,
                Date = sale.Date

            }).ToList();
            return response;
        }


        public async Task<SaleResponse> CreateSale(SaleRequest request)
        {
            var sale = new Sale
            {
                Taxes = 1.21m,
                Date = DateTime.Now,
                SalesProducts = new List<SaleProduct>()
            };

            decimal subtotal = 0;
            decimal totalDiscount = 0;

            List<string> errors = new List<string>();

            foreach (var s in request.Products)
            {
                if (s.Quantity <= 0)
                {
                    errors.Add($"La cantidad debe ser mayor a cero."); //sacar 
                    continue;
                }

                var product = await _productQuery.GetProductById(s.ProductId);

                if (product != null) //sacar
                {


                    subtotal += product.Price * s.Quantity;
                    decimal discountProducts = product.Price - (product.Price * (product.Discount / 100.0m));
                    totalDiscount += (product.Price * s.Quantity) - (discountProducts * s.Quantity);


                    var newSaleProduct = new SaleProduct
                    {
                        Product = product.ProductId,
                        Quantity = s.Quantity,
                        Price = product.Price,
                        Discount = product.Discount
                    };



                    sale.SalesProducts.Add(newSaleProduct);

                }

                else
                {
                    errors.Add($"Producto con ID no encontrado.");
                }
            }


            sale.Subtotal = subtotal;
            sale.TotalDiscount=totalDiscount;
            sale.TotalPay = (subtotal - totalDiscount) * 1.21m;

            if (sale.TotalPay != request.TotalPayed)
            {
                errors.Add($"El total calculado no coincide con el total pagado.");
            }                                                                       //sacar

            if (errors.Any())
            {
                throw new BadRequestException(string.Join(" ", errors));
            }
           

            await _saleCommand.AddSale(sale);

            SaleResponse response = new SaleResponse
            {
                Id = sale.SaleId,
                TotalPay = sale.TotalPay,
                TotalQuantity = sale.SalesProducts.Sum(sp => sp.Quantity),
                Subtotal = sale.Subtotal,
                TotalDiscount = sale.TotalDiscount,
                Taxes = sale.Taxes,
                Date = sale.Date,
                Products = sale.SalesProducts.Select(sp => new SaleProductReponse
                {

                    Id = sp.ShoppingCartId,
                    ProductId = sp.ProductTable.ProductId,
                    Quantity = sp.Quantity,
                    Price = sp.Price,
                    Discount = sp.Discount

                }).ToList()
            };
                 return  response;
        }


        public async Task<SaleResponse> SaleDetailService(int id)
        {
            var sale = await _querySale.GetSaleById(id);

            if (sale == null)
            {                                                           //sacar afuera
                throw new SaleNotFoundException(id);
            }

            SaleResponse response = new SaleResponse
            {
                Id = sale.SaleId,
                TotalPay = sale.TotalPay,
                TotalQuantity =sale.SalesProducts.Sum(sp => sp.Quantity),
                Subtotal = sale.Subtotal,
                TotalDiscount = sale.TotalDiscount,
                Taxes = sale.Taxes,
                Date = sale.Date,
                Products = sale.SalesProducts.Select(sp => new SaleProductReponse
                {
                     Id = sp.ShoppingCartId,
                     ProductId = sp.Product,
                     Quantity= sp.Quantity,
                     Price = sp.Price,
                     Discount =sp.Discount
                }).ToList()
            };

            return response;
        }


    }



}
