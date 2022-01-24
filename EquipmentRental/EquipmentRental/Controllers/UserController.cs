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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<UserResource>> GetAsync()
        {
            var user = await _userService.GetAllAsync();
            var userResource = _mapper.Map<IEnumerable<User>, IEnumerable<UserResource>>(user);
            return userResource;
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] SaveUpdateUserResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUpdateUserResource, User>(value);

            var result = await _userService.InsertAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, SaveUpdateUserResource>(result.Resource);
            return Ok(userResource);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveUpdateUserResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUpdateUserResource, User>(value);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, SaveUpdateUserResource>(result.Resource);
            return Ok(userResource);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, SaveUpdateUserResource>(result.Resource);
            return Ok(userResource);
        }
    }
}
