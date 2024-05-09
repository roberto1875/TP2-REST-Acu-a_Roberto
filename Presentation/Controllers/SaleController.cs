using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Application.Exceptions.Exceptions;

namespace Presentation.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _service;

        public SaleController(ISaleService sale)
        {
            _service = sale;

        }

        [HttpGet()]
        [SwaggerResponse(200, Description = "Éxito al recuperar las ventas.", Type = typeof(IEnumerable<SaleGetResponse>))]
        [SwaggerResponse(400, Description = "Solicitud incorrecta.", Type = typeof(ApiError))]
        public async Task<IActionResult>GetSale([FromQuery(Name = "from")] DateTime? fromDate, [FromQuery(Name = "to")] DateTime? toDate)
        {

            if (fromDate.HasValue && toDate.HasValue && fromDate > toDate)
            {
                return BadRequest(new ApiError("La fecha inicio es mayor que la fecha fin."));
            }
            
            var result = await _service.GetSaleFilter(fromDate, toDate);
                return Ok(result);
            
            
        }


        [HttpPost]
        [SwaggerResponse(201, Description = "Venta registrada con éxito.", Type = typeof(SaleResponse))]
        [SwaggerResponse(400, Description = "Solicitud incorrecta.", Type = typeof(ApiError))]
        public async Task<IActionResult> RegisterSale(SaleRequest request)
        {
            try
            {
                var result = await _service.CreateSale(request);
                return Ok(result);
            }
            catch (BadRequestException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 400 };
            }
        }


        [HttpGet("{id}")]

        [SwaggerResponse(200, Description = "Éxito al recuperar los detalles de la venta.", Type = typeof(SaleResponse))]
        [SwaggerResponse(404, Description = "Venta no encontrada.", Type = typeof(ApiError))]
        public async Task<IActionResult> GetSaleDetail(int id)
        {
            try
            {
                var result = await _service.SaleDetailService(id);
                return Ok(result);
            }
            catch(SaleNotFoundException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 404 };
            }
        }

    }



}
