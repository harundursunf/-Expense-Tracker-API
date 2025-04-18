using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IExpenseService
    {
        void add(ExpenseDto ExpenseDto);
        void update(ExpenseDto ExpenseDto);
        void delete(ExpenseDto ExpenseDto);
        Expense getById(Guid id);
        List<Expense> getAll();

    }
}
