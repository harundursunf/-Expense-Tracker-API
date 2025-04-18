using Business.Abstract;
using Entities.Dto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;

namespace UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] UserDto userDto)
        {
            _userService.Add(userDto);
            return Ok("Kullanıcı başarıyla eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] UserDto userDto)
        {
            _userService.Update(userDto);
            return Ok("Kullanıcı güncellendi.");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] UserDto userDto)
        {
            _userService.Delete(userDto);
            return Ok("Kullanıcı silindi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetList();
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            return Ok(user);
        }
    }
}
