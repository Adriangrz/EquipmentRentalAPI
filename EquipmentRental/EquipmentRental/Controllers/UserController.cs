using AutoMapper;
using EquipmentRental.Extensions;
using EquipmentRental.Models;
using EquipmentRental.Models.ApiModels;
using EquipmentRental.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EquipmentRental.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IRentService _rentService;
        private readonly IMapper _mapper;
        private readonly IJwtAuthService _jwtAuthService;
        public UserController(IUserService userService, IMapper mapper, IJwtAuthService jwtAuthService, IRentService rentService)
        {
            _userService = userService;
            _mapper = mapper;
            _jwtAuthService = jwtAuthService;
            _rentService = rentService;
        }

        // POST api/<UserController>/Login
        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] AuthUserResource userCredential)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<AuthUserResource, User>(userCredential);
            var result = await _jwtAuthService.AuthenticationAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var token = _jwtAuthService.GenerateJWT(result.Resource);

            return Ok(new
            {
                token = token,
                id = result.Resource.Id,
                email = result.Resource.Email
            });
        }
        // POST api/<UserController>/Register
        [HttpPost("Register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] AuthUserResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<AuthUserResource, User>(value);

            user.UserType = Policies.User;

            var result = await _userService.InsertAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var token = _jwtAuthService.GenerateJWT(result.Resource);

            return Ok(new
            {
                token = token,
                id = result.Resource.Id,
                email = result.Resource.Email
            });
        }


        // GET: api/<UserController>
        [HttpGet]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IEnumerable<ReturnedUserResource>> GetAsync()
        {
            var user = await _userService.GetAllAsync();
            var userResource = _mapper.Map<IEnumerable<User>, IEnumerable<ReturnedUserResource>>(user);
            return userResource;
        }

        // POST api/<UserController>
        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PostAsync([FromBody] SaveUpdateUserResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUpdateUserResource, User>(value);

            var result = await _userService.InsertAsync(user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, ReturnedUserResource>(result.Resource);
            return Ok(userResource);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> PutAsync(Guid id, [FromBody] SaveUpdateUserResource value)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState.GetErrorMessages());

            var user = _mapper.Map<SaveUpdateUserResource, User>(value);
            var result = await _userService.UpdateAsync(id, user);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, ReturnedUserResource>(result.Resource);
            return Ok(userResource);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var result = await _userService.DeleteAsync(id);

            if (!result.Success)
                return BadRequest(result.Message);

            var userResource = _mapper.Map<User, ReturnedUserResource>(result.Resource);
            return Ok(userResource);
        }

        // GET: api/<UserController>
        [HttpGet("{id}/Rent")]
        [Authorize(Policy = Policies.User)]
        public async Task<IActionResult> GetRentsAsync(Guid id)
        {
            var userIdFromToken = User.Claims.First(x => x.Type == "id").Value;
            var userId = _jwtAuthService.CheckUserId(id, userIdFromToken);
            if(userId is null)
                return Unauthorized();
            var result = await _rentService.GetByUserIdAsync((Guid)userId);
            if (!result.Success)
                return BadRequest(result.Message);
            var rentsResource = _mapper.Map<IEnumerable<Rent>, IEnumerable<RentResource>>(result.Resource);
            return Ok(rentsResource);
        }
    }
}
