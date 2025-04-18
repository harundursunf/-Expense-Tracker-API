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
    public class CategorysController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("add")]
        public IActionResult Add([FromBody] CategoryDto categoryDto)
        {
            _categoryService.Add(categoryDto);
            return Ok("Kategori başarıyla eklendi.");
        }

        [HttpPut("update")]
        public IActionResult Update([FromBody] CategoryDto categoryDto)
        {
            _categoryService.Update(categoryDto);
            return Ok("Kategori güncellendi.");
        }

        [HttpDelete("delete")]
        public IActionResult Delete([FromBody] CategoryDto categoryDto)
        {
            _categoryService.Delete(categoryDto);
            return Ok("Kategori silindi.");
        }

        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _categoryService.GetAll();
            return Ok(result);
        }

        [HttpGet("get/{id}")]
        public IActionResult GetById(Guid id)
        {
            var category = _categoryService.GetById(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }
    }
}
