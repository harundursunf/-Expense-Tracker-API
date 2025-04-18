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
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var expenses = _expenseService.getAll();
            return Ok(expenses);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var expense = _expenseService.getById(id);
            if (expense == null)
            {
                return NotFound();
            }
            return Ok(expense);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ExpenseDto expenseDto)
        {
            _expenseService.add(expenseDto);
            return Ok("Expense added.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] ExpenseDto expenseDto)
        {
            _expenseService.update(expenseDto);
            return Ok("Expense updated.");
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] ExpenseDto expenseDto)
        {
            _expenseService.delete(expenseDto);
            return Ok("Expense deleted.");
        }
    }
}
