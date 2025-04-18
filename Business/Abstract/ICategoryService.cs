using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        void Add(CategoryDto categoryDto);
        void Update(CategoryDto categoryDto);
        void Delete(CategoryDto categoryDto);
        Category GetById(Guid id);
        List<Category> GetAll();
    }
}
