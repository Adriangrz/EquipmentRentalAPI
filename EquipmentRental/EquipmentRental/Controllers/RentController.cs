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
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentService;
        private readonly IMapper _mapper;
        private readonly IJwtAuthService _jwtAuthService;
        public RentController(IRentService rentService, IMapper mapper, IJwtAuthService jwtAuthService)
        {
            _rentService = rentService;
            _mapper = mapper;
            _jwtAuthService = jwtAuthService;
        }
        // GET: api/<RentController>
        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IEnumerable<RentResource>> GetAsync()
        {
            var rents = await _rentService.GetAllAsync();
            var rentResource = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(rents);
            return rentResource;
        }

        // POST api/<RentController>
        [HttpPost]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> PostAsync([FromBody] SaveRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var userIdFromToken = User.Claims.First(x => x.Type == "id").Value;
            var id = _jwtAuthService.CheckUserId(value.UserId, userIdFromToken);
            if (id is null)
                return Unauthorized();

            var rent = _mapper.Map<SaveRentResource, Rent>(value);

            var result = await _rentService.InsertAsync(rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, RentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] UpdateRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rent = _mapper.Map<UpdateRentResource, Rent>(value);
            var result = await _rentService.UpdateAsync(id, rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, RentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5/Issued
        [HttpPut("{id}/Issued")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutIssuedAsync(Guid id, [FromBody] bool isIssued)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _rentService.UpdateIssuedAsync(id, isIssued);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, RentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5/Returned
        [HttpPut("{id}/Returned")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutReturnedAsync(Guid id, [FromBody] bool isReturned)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var result = await _rentService.UpdateReturnedAsync(id, isReturned);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, RentResource>(result.Resource);
            return Ok(rentResource);
        }
    }
}
