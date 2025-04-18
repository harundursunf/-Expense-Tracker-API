using Business.Abstract;
using DataAccess.Abstract;
using Entities.Dto;
using Entities.Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(CategoryDto categoryDto)
        {
            _categoryDal.Add(new Category
            {
                Id = Guid.NewGuid(),
                CategoryName = categoryDto.CategoryName,
                UserId = categoryDto.UserId,
                CreatedAt = DateTime.UtcNow
            });
        }

        public void Update(CategoryDto categoryDto)
        {
            var category = _categoryDal.GetById(categoryDto.Id);
            if (category != null)
            {
                category.CategoryName = categoryDto.CategoryName;
                category.UpdatedAt = DateTime.UtcNow;
                _categoryDal.Update(category);
            }
        }

        public void Delete(CategoryDto categoryDto)
        {
            var category = _categoryDal.GetById(categoryDto.Id);
            if (category != null)
            {
                _categoryDal.Delete(category);
            }
        }

        public Category GetById(Guid id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetAll();
        }
    }
}
