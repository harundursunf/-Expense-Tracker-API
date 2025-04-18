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
    public class CategoryLimtsController : ControllerBase
    {
        private readonly ICategoryLimitService _categoryLimitService;

        public CategoryLimtsController(ICategoryLimitService categoryLimitService)
        {
            _categoryLimitService = categoryLimitService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CategoryLimitDto dto)
        {
            _categoryLimitService.Add(dto);
            return Ok("Kategori limiti eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CategoryLimitDto dto)
        {
            _categoryLimitService.Update(dto);
            return Ok("Kategori limiti güncellendi.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete(Guid id)
        {
            _categoryLimitService.Delete(id);
            return Ok("Kategori limiti silindi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryLimitService.GetAll();
            return Ok(result);
        }

        [HttpGet("getbyid/{id}")]
        public IActionResult GetById(Guid id)
        {
            var result = _categoryLimitService.GetById(id);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
    }
}
