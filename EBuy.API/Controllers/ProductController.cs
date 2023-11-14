using AutoMapper;
using EBuyAPI_DTO.Product;
using EBuy.API.Validators.Product;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductService _productService;
        public ProductController(IMapper mapper, IProductService productService)
        {
            _mapper = mapper;
            _productService = productService;
        }

        // GET: api/product
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productes = await _productService.GetAllProducts();
            var productesDTO = _mapper.Map<IEnumerable<Product>, IEnumerable<ProductDTO>>(productes);
            return Ok(productesDTO);
        }

        // GET api/product/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();

            var product = await _productService.GetProductById(id);

            if (product == null) return NotFound();

            var productDTO = _mapper.Map<Product, ProductDTO>(product);
            return Ok(productDTO);

        }

        // POST api/product
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductDTO createProductDTO)
        {
            var validator = new CreateProductDTOValidator();
            var validationResult = await validator.ValidateAsync(createProductDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var productToBeCreated = _mapper.Map<CreateProductDTO, Product>(createProductDTO);
            var newProduct = await _productService.CreateProduct(productToBeCreated);

            var product = await _productService.GetProductById(newProduct.Id);
            var productDTO = _mapper.Map<Product, ProductDTO>(product);

            return Ok();
        }

        // PUT api/product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductDTO updateProductDTO)
        {
            if (id == 0) return BadRequest();

            // validate
            var validator = new UpdateProductDTOValidator();
            var validationResult = await validator.ValidateAsync(updateProductDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            // check Product
            Product productToBeUpdated = await _productService.GetProductById(id);

            if (productToBeUpdated == null) return NotFound();

            // update Product
            Product newProduct = _mapper.Map<UpdateProductDTO, Product>(updateProductDTO);
            await _productService.UpdateProduct(productToBeUpdated, newProduct);

            //return updated Product data
            Product updatedProduct = await _productService.GetProductById(id);
            ProductDTO productDTO = _mapper.Map<Product, ProductDTO>(updatedProduct);

            return Ok(productDTO);
        }

        // DELETE api/product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var product = await _productService.GetProductById(id);

            if (product == null) return NotFound();

            await _productService.DeleteProduct(product);

            return Ok();
        }
    }
}
