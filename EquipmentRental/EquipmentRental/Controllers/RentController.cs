using AutoMapper;
using EquipmentRental.Extensions;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private readonly IRentService _rentServicee;
        private readonly IMapper _mapper;
        public RentController(IRentService rentService, IMapper mapper)
        {
            _rentServicee = rentService;
            _mapper = mapper;
        }
        // GET: api/<RentController>
        [HttpGet]
        public async Task<IEnumerable<RentResource>> Get()
        {
            var rents = await _rentServicee.GetAllAsync();
            var rentResource = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(rents);
            return rentResource;
        }

        // POST api/<RentController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SaveUpdateRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rent = _mapper.Map<SaveUpdateRentResource, Rent>(value);

            var result = await _rentServicee.InsertAsync(rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }

        // PUT api/<RentController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] SaveUpdateRentResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var rent = _mapper.Map<SaveUpdateRentResource, Rent>(value);
            var result = await _rentServicee.UpdateAsync(id, rent);

            if (!result.Success)
                return BadRequest(result.Message);

            var rentResource = _mapper.Map<Rent, SaveUpdateRentResource>(result.Resource);
            return Ok(rentResource);
        }
    }
}
