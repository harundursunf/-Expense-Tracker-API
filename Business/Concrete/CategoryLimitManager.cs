using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryLimitManager : ICategoryLimitService
    {
        private readonly ICategoryLimitDal _categoryLimitDal;

        public CategoryLimitManager(ICategoryLimitDal categoryLimitDal)
        {
            _categoryLimitDal = categoryLimitDal;
        }

        public void Add(CategoryLimitDto dto)
        {
            var entity = new CategoryLimit
            {
                Id = Guid.NewGuid(),
                CategoryId = dto.CategoryId,
                LimitAmount = dto.LimitAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };

            _categoryLimitDal.Add(entity);
        }

        public void Update(CategoryLimitDto dto)
        {
            var entity = _categoryLimitDal.GetByFilter(x => x.CategoryId == dto.CategoryId && x.StartDate == dto.StartDate);
            if (entity != null)
            {
                entity.LimitAmount = dto.LimitAmount;
                entity.EndDate = dto.EndDate;

                _categoryLimitDal.Update(entity);
            }
        }

        public void Delete(Guid id)
        {
            var entity = _categoryLimitDal.GetById(id);
            if (entity != null)
                _categoryLimitDal.Delete(entity);
        }

        public List<CategoryLimit> GetAll()
        {
            return _categoryLimitDal.GetAll();
        }

        public CategoryLimit GetById(Guid id)
        {
            return _categoryLimitDal.GetById(id);
        }
    }
}
