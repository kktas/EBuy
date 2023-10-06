using AutoMapper;
using EBuy.API.DTO.Business;
using EBuy.API.Validators.Business;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusinessController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBusinessService _businessService;
        public BusinessController(IMapper mapper, IBusinessService businessService)
        {
            this._mapper = mapper;
            this._businessService = businessService;
        }

        // GET: api/business
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var businesses = await _businessService.GetBusinesses();
            var businessesDTO = _mapper.Map<IEnumerable<Business>, IEnumerable<BusinessDTO>>(businesses);
            return Ok(businessesDTO);
        }

        // GET api/business/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();
            var business = await _businessService.GetBusinessById(id);

            if (business == null) return NotFound();
            var businessDTO = _mapper.Map<Business, BusinessDTO>(business);
            return Ok(businessDTO);
        }

        // POST api/business
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateBusinessDTO createBusinessDTO)
        {
            var validator = new CreateBusinessDTOValidator();
            var validationResult = await validator.ValidateAsync(createBusinessDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            var businessToBeCreated = _mapper.Map<CreateBusinessDTO, Business>(createBusinessDTO);
            var newBusiness = await _businessService.CreateBusiness(businessToBeCreated);

            var business = await _businessService.GetBusinessById(newBusiness.Id);
            var businessDTO = _mapper.Map<Business, BusinessDTO>(business);

            return Ok();
        }

        // PUT api/business/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateBusinessDTO updateBusinessDTO)
        {
            if (id == 0) return BadRequest();

            // validate
            var validator = new UpdateBusinessDTOValidator();
            var validationResult = await validator.ValidateAsync(updateBusinessDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            // check Business
            Business businessToBeUpdated = await _businessService.GetBusinessById(id);

            if (businessToBeUpdated == null) return NotFound();

            // update Business
            Business newBusiness = _mapper.Map<UpdateBusinessDTO, Business>(updateBusinessDTO);
            await _businessService.UpdateBusiness(businessToBeUpdated, newBusiness);

            //return updated Business data
            Business updatedBusiness = await _businessService.GetBusinessById(id);
            BusinessDTO businessDTO = _mapper.Map<Business, BusinessDTO>(updatedBusiness);

            return Ok(businessDTO);
        }

        // DELETE api/business/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var business = await _businessService.GetBusinessById(id);

            if (business == null) return NotFound();

            await _businessService.DeleteBusiness(business);

            return Ok();
        }
    }
}
