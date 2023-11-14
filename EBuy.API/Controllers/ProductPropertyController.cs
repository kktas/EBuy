using AutoMapper;
using EBuyAPI_DTO.ProductProperty;
using EBuy.API.Validators.ProductProperty;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertyController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductPropertyService _productPropertyService;
        public ProductPropertyController(IMapper mapper, IProductPropertyService productPropertyService)
        {
            _mapper = mapper;
            _productPropertyService = productPropertyService;
        }

        // GET: api/productProperty
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productPropertyes = await _productPropertyService.GetAllProductProperties();
            var productPropertyesDTO = _mapper.Map<IEnumerable<ProductProperty>, IEnumerable<ProductPropertyDTO>>(productPropertyes);
            return Ok(productPropertyesDTO);
        }

        // GET api/productProperty/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();

            var productProperty = await _productPropertyService.GetProductPropertyById(id);

            if (productProperty == null) return NotFound();

            var productPropertyDTO = _mapper.Map<ProductProperty, ProductPropertyDTO>(productProperty);
            return Ok(productPropertyDTO);

        }

        // POST api/productProperty
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductPropertyDTO createProductPropertyDTO)
        {
            var validator = new CreateProductPropertyDTOValidator();
            var validationResult = await validator.ValidateAsync(createProductPropertyDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var productPropertyToBeCreated = _mapper.Map<CreateProductPropertyDTO, ProductProperty>(createProductPropertyDTO);
            var newProductProperty = await _productPropertyService.CreateProductProperty(productPropertyToBeCreated);

            var productProperty = await _productPropertyService.GetProductPropertyById(newProductProperty.Id);
            var productPropertyDTO = _mapper.Map<ProductProperty, ProductPropertyDTO>(productProperty);

            return Ok();
        }

        // PUT api/productProperty/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductPropertyDTO updateProductPropertyDTO)
        {
            if (id == 0) return BadRequest();

            // validate
            var validator = new UpdateProductPropertyDTOValidator();
            var validationResult = await validator.ValidateAsync(updateProductPropertyDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            // check ProductProperty
            ProductProperty productPropertyToBeUpdated = await _productPropertyService.GetProductPropertyById(id);

            if (productPropertyToBeUpdated == null) return NotFound();

            // update ProductProperty
            ProductProperty newProductProperty = _mapper.Map<UpdateProductPropertyDTO, ProductProperty>(updateProductPropertyDTO);
            await _productPropertyService.UpdateProductProperty(productPropertyToBeUpdated, newProductProperty);

            //return updated ProductProperty data
            ProductProperty updatedProductProperty = await _productPropertyService.GetProductPropertyById(id);
            ProductPropertyDTO productPropertyDTO = _mapper.Map<ProductProperty, ProductPropertyDTO>(updatedProductProperty);

            return Ok(productPropertyDTO);
        }

        // DELETE api/productProperty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var productProperty = await _productPropertyService.GetProductPropertyById(id);

            if (productProperty == null) return NotFound();

            await _productPropertyService.DeleteProductProperty(productProperty);

            return Ok();
        }
    }
}
