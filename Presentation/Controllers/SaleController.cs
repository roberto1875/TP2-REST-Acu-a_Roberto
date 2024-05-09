using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
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
            var result = await _service.GetSaleFilter(fromDate, toDate );
            return Ok(result);
        }

        [HttpOptions]
        public async Task<IActionResult> RegisterSale(SaleRequest request)
        {
            var result = await _service.CreateSale(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSaleDetail(int id)
        {
           
            var result = await _service.SaleDetailService(id);
            return Ok(result);
        }

    }



}


//[SwaggerOperation(Summary = "Crea un nuevo producto.",
//            Description = "Permite la creación de un nuevo producto en el sistema.")]
//[SwaggerResponse(StatusCodes.Status201Created, "Producto creado con éxito", Type = typeof(ProductRequest))]
//[SwaggerResponse(StatusCodes.Status400BadRequest, "Solicitud incorrecta.", Type = typeof(ApiError))]
//[SwaggerResponse(StatusCodes.Status409Conflict, "Conflicto, el producto ya existe.", Type = typeof(ApiError))]
//services.AddSwaggerGen(c =>
//{
//    c.SwaggerDoc("v1", new OpenApiInfo
//    {
//        Title = "DemoSwaggerAnnotation",
//        Version = "v1",
//    });
//    // Configuración de la descripción de los parametros
//    // c.ParameterFilter<CustomParameterFilter>();
//    c.EnableAnnotations();
//});
