using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class ExpenseManager : IExpenseService
    {
        private readonly IExpenseDal _expenseDal;

        public ExpenseManager(IExpenseDal expenseDal)
        {
            _expenseDal = expenseDal;
        }

        public void add(ExpenseDto expenseDto)
        {
            var expense = new Expense
            {
                Id = Guid.NewGuid(),
                Title = expenseDto.Title,
                Description = expenseDto.Description,
                Amount = expenseDto.Amount,
                ExpenseDate = expenseDto.ExpenseDate,
                CategoryId = expenseDto.CategoryId
            };

            _expenseDal.Add(expense);
        }

        public void update(ExpenseDto expenseDto)
        {
            var existingExpense = _expenseDal.GetByFilter(x =>
                x.Title == expenseDto.Title &&
                x.ExpenseDate == expenseDto.ExpenseDate &&
                x.Amount == expenseDto.Amount &&
                x.CategoryId == expenseDto.CategoryId);

            if (existingExpense != null)
            {
                existingExpense.Description = expenseDto.Description;
                _expenseDal.Update(existingExpense);
            }
        }

        public void delete(ExpenseDto expenseDto)
        {
            var expense = _expenseDal.GetByFilter(x =>
                x.Title == expenseDto.Title &&
                x.ExpenseDate == expenseDto.ExpenseDate &&
                x.Amount == expenseDto.Amount &&
                x.CategoryId == expenseDto.CategoryId);

            if (expense != null)
            {
                _expenseDal.Delete(expense);
            }
        }

        public List<Expense> getAll()
        {
            return _expenseDal.GetAll();
        }

        public Expense getById(Guid id)
        {
            return _expenseDal.GetById(id);
        }
    }
}
