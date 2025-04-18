using Business.Abstract;
using Entities.Dto;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _rolesService;

        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _rolesService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _rolesService.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] RolesDto rolesDto)
        {
            _rolesService.Add(rolesDto);
            return Ok("Rol eklendi");
        }

        [HttpPut]
        public IActionResult Update([FromBody] RolesDto rolesDto)
        {
            _rolesService.Update(rolesDto);
            return Ok("Rol güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] RolesDto rolesDto)
        {
            _rolesService.Delete(rolesDto);
            return Ok("Rol silindi");
        }
    }
}
