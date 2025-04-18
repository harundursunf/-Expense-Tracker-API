using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryLimitService
    {
        void Add(CategoryLimitDto dto);
        void Update(CategoryLimitDto dto);
        void Delete(Guid id);
        CategoryLimit GetById(Guid id);
        List<CategoryLimit> GetAll();
    }
}
