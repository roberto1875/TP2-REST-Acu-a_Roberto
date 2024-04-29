using Application.Interfaces;
using Application.Models;
using Azure.Core;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task <IActionResult>GetAll()
        {
            var result = await _service.GetAllProducts();
            return Ok (result);
        }


        [HttpPost]
        public async Task <IActionResult> CreateProduct(CreateProductRequest request)
        {
            var result = await _service.CreateProduct(request);
            return new JsonResult(result) { StatusCode = 201};

        }
    }
}
