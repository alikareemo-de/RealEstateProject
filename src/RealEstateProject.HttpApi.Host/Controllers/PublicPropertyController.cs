using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstateProject.Dtos;
using System;
using System.Threading.Tasks;

namespace RealEstateProject.Controllers
{
    [AllowAnonymous]
    [ApiVersion("1.0")]

    [Route("api/public/properties")]
    [ApiController]
    public class PublicPropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;

        public PublicPropertyController(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterAsync([FromQuery] PropertyFilterDto filter)
        {
            var result = await _propertyRepository.GetListAsync
                (filter.GovernorateId, filter.PropertyTypeId, filter.TransactionType,
                filter.MinPrice, filter.MaxPrice, filter.MinArea, filter.MaxArea);


            return Ok(result);
        }


        [HttpGet("details")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var property = await _propertyRepository.GetByIdAsync(id);
            if (property == null)
                return NotFound();

            return Ok(property);
        }

        [HttpGet("similar ")]
        public async Task<IActionResult> GetSimilar(Guid id)
        {
            var similar = await _propertyRepository.GetSimilarPropertiesAsync(id);
            return Ok(similar);
        }
    }

}
