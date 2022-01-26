using AutoMapper;
using EquipmentRental.Extensions;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SportEquipmentController : ControllerBase
    {
        private readonly ISportEquipmentService _sportEquipmentService;
        private readonly IMapper _mapper;
        public SportEquipmentController(ISportEquipmentService sportEquipmentService, IMapper mapper)
        {
            _sportEquipmentService = sportEquipmentService;
            _mapper = mapper;
        }
        // GET: api/<RentController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<SportEquipmentResource>> GetAsync()
        {
            var sportsEquipment = await _sportEquipmentService.GetAllAsync();
            var sportsEquipmentResource = _mapper.Map<IEnumerable<SportEquipment>, IEnumerable<SportEquipmentResource>>(sportsEquipment);
            return sportsEquipmentResource;
        }

        // GET api/<RentController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _sportEquipmentService.GetById(id);
            if (!result.Success)
                return BadRequest(result.Message);

            var sportEquipmentResource = _mapper.Map<SportEquipment, SportEquipmentResource>(result.Resource);
            return Ok(sportEquipmentResource);
        }

        // POST api/<RentController>
        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUpdateSportEquipmentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sportsEquipment = _mapper.Map<SaveUpdateSportEquipmentResource, SportEquipment>(value);

            var result = await _sportEquipmentService.InsertAsync(sportsEquipment);

            if (!result.Success)
                return BadRequest(result.Message);

            var sportEquipmentResource = _mapper.Map<SportEquipment, SportEquipmentResource>(result.Resource);
            return Ok(sportEquipmentResource);
        }

        // PUT api/<RentController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveUpdateSportEquipmentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var sportsEquipment = _mapper.Map<SaveUpdateSportEquipmentResource, SportEquipment>(value);
            var result = await _sportEquipmentService.UpdateAsync(id, sportsEquipment);

            if (!result.Success)
                return BadRequest(result.Message);

            var sportEquipmentResource = _mapper.Map<SportEquipment, SportEquipmentResource>(result.Resource);
            return Ok(sportEquipmentResource);
        }

        // DELETE api/<RentController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _sportEquipmentService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var sportEquipmentResource = _mapper.Map<SportEquipment, SportEquipmentResource>(result.Resource);
            return Ok(sportEquipmentResource);
        }
    }
}
