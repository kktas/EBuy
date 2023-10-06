using AutoMapper;
using EBuy.API.DTO.User;
using EBuy.API.Validators.User;
using EBuy.Core.Models;
using EBuy.Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Web.Http.Results;

namespace EBuy.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            this._userService = userService;
            this._mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<User> users = await _userService.GetAllUsers();
            IEnumerable<UserDTO> usersDTO = _mapper.Map<IEnumerable<User>, IEnumerable<UserDTO>>(users);
            return Ok(usersDTO);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (id == 0) return BadRequest();

            User user = await _userService.GetUserById(id);
            if (user == null) return NotFound();

            var userDto = _mapper.Map<UserDTO>(user);
            return Ok(userDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUserDTO createUserDTO)
        {
            var validator = new CreateUserDTOValidator();
            var validationResult = await validator.ValidateAsync(createUserDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            User userToBeCreated = _mapper.Map<CreateUserDTO, User>(createUserDTO);
            User newUser = await _userService.CreateUser(userToBeCreated);

            User user = await _userService.GetUserById(newUser.Id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(user);
            return Ok(userDTO);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateUserDTO updateUserDTO)
        {
            if (id == 0) return BadRequest();

            // validate
            var validator = new UpdateUserDTOValidator();
            var validationResult = await validator.ValidateAsync(updateUserDTO);

            if (!validationResult.IsValid) return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));

            // check user
            User userToBeUpdated = await _userService.GetUserById(id);

            if (userToBeUpdated == null) return NotFound();

            // update user
            User newUser = _mapper.Map<UpdateUserDTO, User>(updateUserDTO);
            await _userService.UpdateUserInfo(userToBeUpdated, newUser);

            // return updated user data
            User updatedUser = await _userService.GetUserById(id);
            UserDTO userDTO = _mapper.Map<User, UserDTO>(updatedUser);

            return Ok(userDTO);
        }


        [HttpPut("{id}/change-password")]
        public async Task<IActionResult> ChangeUserPassword(int id, [FromBody] string password)
        {
            if (id == 0) return BadRequest();

            User userToBeUpdated = await _userService.GetUserById(id);

            if (userToBeUpdated == null) return NotFound();

            await _userService.UpdateUserPassword(userToBeUpdated, password);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest();

            var userToBeDeleted = await _userService.GetUserById(id);

            if (userToBeDeleted == null) return NotFound();

            await _userService.DeleteUser(userToBeDeleted);
            return Ok();
        }
    }
}
