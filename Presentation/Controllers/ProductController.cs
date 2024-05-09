using Application.Interfaces;
using Application.Models;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using static Application.Exceptions.Exceptions;


namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductController(IProductService service)
        {
            _service = service;
        }


        [HttpGet]
        [SwaggerResponse(200, Description = "Éxito al recuperar los productos.", Type = typeof(ProductGetResponse))]
        public async Task<IActionResult> GetAllProductFilter([FromQuery] ProductFilterOptions filter)
        {
            var result = await _service.GetProductFilter(filter);
            return Ok(result);
        }


        [HttpPost]
        [SwaggerResponse(201, Description = "Producto creado con éxito", Type = typeof(ProductResponse))]
        [SwaggerResponse(400, Description = "Solicitud incorrecta.", Type = typeof(ApiError))]
        [SwaggerResponse(409, Description = "Conflicto, el producto ya existe.", Type = typeof(ApiError))]
        public async Task<IActionResult> CreateProduct(CreateProductRequest request)
        {
           
            try
            {
                var result = await _service.CreateProduct(request);
                return new JsonResult(result) { StatusCode = 201 };
            }

            catch (ConflictProductException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 409 };
                
            }
            //catch (ConflictProductException ex)
            //{
            //    return new JsonResult(new ApiError(ex.Message)) { StatusCode = 400 };

            //}

        }


        [HttpGet("{id}")]
        [SwaggerResponse(200, Description = "Éxito al recuperar los detalles del producto.", Type = typeof(ProductResponse))]
        [SwaggerResponse(404, Description = "Producto no encontrado.", Type = typeof(ApiError))]
        public async Task<IActionResult> GetProductDetail(Guid id)
        {
            try
            {
                var result = await _service.ProductDetailService(id);
                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 404 };
            }
        }



        [HttpPut("{id}")]
        [SwaggerResponse(200, Description = "Producto actualizado con éxito.", Type = typeof(ProductResponse))]
        [SwaggerResponse(400, Description = "Solicitud incorrecta.", Type = typeof(ApiError))]
        [SwaggerResponse(404, Description = "Producto no encontrado.", Type = typeof(ApiError))]
        [SwaggerResponse(409, Description = "Conflicto al actualizar el producto.", Type = typeof(ApiError))]
        public async Task<IActionResult> UpdateProductDetail(Guid id, ProductRequest request)
        {
            try
            {
                var result = await _service.UpDateProductService(id, request);
                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 404 };
            }
            catch(ConflictProductException ex )
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 409 };
            }
            catch (BadRequestException ex)
            { 
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 400 };
            }


        }

        [HttpDelete("/api/Product/{id}")]

        [SwaggerResponse(200, Description = "Producto eliminado con éxito.", Type = typeof(ProductResponse))]
        [SwaggerResponse(404, Description = "Producto no encontrado.", Type = typeof(ApiError))]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            try
            {
                var result = await _service.DeleteProductService(id);
                return Ok(result);
            }
            catch (ProductNotFoundException ex)
            {
                return new JsonResult(new ApiError(ex.Message)) { StatusCode = 404 };
            }
        }
    }
}

