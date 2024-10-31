using BuyWave.Catalog.Dtos.ProductDetailDtos;
using BuyWave.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BuyWave.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            var values = _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayları Başarıyla Eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayları Başarıyla Silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayları Başarıyla Güncellendi");
        }

    }
}
