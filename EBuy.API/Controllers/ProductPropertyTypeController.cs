using AutoMapper;
using EBuy.API.DTO.ProductPropertyType;
using EBuy.API.Validators.ProductPropertyType;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPropertyTypeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IProductPropertyTypeService _productPropertyService;
        public ProductPropertyTypeController(IMapper mapper, IProductPropertyTypeService productPropertyService)
        {
            _mapper = mapper;
            _productPropertyService = productPropertyService;
        }

        // GET: api/productProperty
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var productPropertyes = await _productPropertyService.GetAllProductPropertyTypes();
            var productPropertyesDTO = _mapper.Map<IEnumerable<ProductPropertyType>, IEnumerable<ProductPropertyTypeDTO>>(productPropertyes);
            return Ok(productPropertyesDTO);
        }

        // GET api/productProperty/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();

            var productProperty = await _productPropertyService.GetProductPropertyTypeById(id);

            if (productProperty == null) return NotFound();

            var productPropertyDTO = _mapper.Map<ProductPropertyType, ProductPropertyTypeDTO>(productProperty);
            return Ok(productPropertyDTO);

        }

        // POST api/productProperty
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProductPropertyTypeDTO createProductPropertyTypeDTO)
        {
            var validator = new CreateProductPropertyTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(createProductPropertyTypeDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var productPropertyToBeCreated = _mapper.Map<CreateProductPropertyTypeDTO, ProductPropertyType>(createProductPropertyTypeDTO);
            var newProductPropertyType = await _productPropertyService.CreateProductPropertyType(productPropertyToBeCreated);

            var productProperty = await _productPropertyService.GetProductPropertyTypeById(newProductPropertyType.Id);
            var productPropertyDTO = _mapper.Map<ProductPropertyType, ProductPropertyTypeDTO>(productProperty);

            return Ok();
        }

        // PUT api/productProperty/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProductPropertyTypeDTO updateProductPropertyTypeDTO)
        {
            if (id == 0) return BadRequest();

            // validate
            var validator = new UpdateProductPropertyTypeDTOValidator();
            var validationResult = await validator.ValidateAsync(updateProductPropertyTypeDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            // check ProductPropertyType
            ProductPropertyType productPropertyToBeUpdated = await _productPropertyService.GetProductPropertyTypeById(id);

            if (productPropertyToBeUpdated == null) return NotFound();

            // update ProductPropertyType
            ProductPropertyType newProductPropertyType = _mapper.Map<UpdateProductPropertyTypeDTO, ProductPropertyType>(updateProductPropertyTypeDTO);
            await _productPropertyService.UpdateProductPropertyType(productPropertyToBeUpdated, newProductPropertyType);

            //return updated ProductPropertyType data
            ProductPropertyType updatedProductPropertyType = await _productPropertyService.GetProductPropertyTypeById(id);
            ProductPropertyTypeDTO productPropertyDTO = _mapper.Map<ProductPropertyType, ProductPropertyTypeDTO>(updatedProductPropertyType);

            return Ok(productPropertyDTO);
        }

        // DELETE api/productProperty/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var productProperty = await _productPropertyService.GetProductPropertyTypeById(id);

            if (productProperty == null) return NotFound();

            await _productPropertyService.DeleteProductPropertyType(productProperty);

            return Ok();
        }
    }
}
