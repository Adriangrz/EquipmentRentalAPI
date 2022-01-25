using AutoMapper;
using EquipmentRental.Extensions;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;
        private readonly IMapper _mapper;
        public RentController(IRentService rentService, IMapper mapper)
        {
            _rentService = rentService;
            _mapper = mapper;
        }
        // GET: api/<RentController>
        [HttpGet]
        public async Task<IEnumerable<RentResource>> GetAsync()
        {
            var rents = await _rentService.GetAllAsync();
            var rentResource = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(rents);
            return rentResource;
        }

        // POST api/<RentController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUpdateRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rent = _mapper.Map<SaveUpdateRentResource, Rent>(value);

            var result = await _rentService.InsertAsync(rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveUpdateRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rent = _mapper.Map<SaveUpdateRentResource, Rent>(value);
            var result = await _rentService.UpdateAsync(id, rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5/Issued
        [HttpPut("{id}/Issued")]
        public async Task<IActionResult> PutIssuedAsync(Guid id, [FromBody] bool isIssued)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _rentService.UpdateIssuedAsync(id, isIssued);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5/Returned
        [HttpPut("{id}/Returned")]
        public async Task<IActionResult> PutReturnedAsync(Guid id, [FromBody] bool isReturned)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _rentService.UpdateReturnedAsync(id, isReturned);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }
    }
}
