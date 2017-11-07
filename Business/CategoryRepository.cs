using System;
using System.Collections.Generic;
using System.Linq;
using Data.Domain.Entities;
using Data.Domain.Interfaces;
using Data.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _databaseContext;

        public CategoryRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IReadOnlyList<Category> GetAll() => _databaseContext.Categories.ToList();

        public Category GetById(Guid id) => _databaseContext.Categories.FirstOrDefault(c => c.Id == id);

        public void Add(Category category)
        {
            _databaseContext.Categories.Add(category);
            _databaseContext.SaveChanges();
        }

        public void Edit(Category category)
        {
            _databaseContext.Categories.Update(category);
            _databaseContext.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var category = GetById(id);
            if (category != null)
            {
                _databaseContext.Categories.Remove(category);
                _databaseContext.SaveChanges();
            }
        }


        //Eager / Explicit Loading
        public IReadOnlyList<Category> GetAllEagerLoading()
        {
            var query = _databaseContext.Categories.Include("Products");
            foreach(var item in query)
            {
                var products = _databaseContext.Entry(item).Collection(c => c.Products);
                if(!products.IsLoaded) products.Load();
            }
            return query.ToList();
        }

        public IReadOnlyList<Category> GetAllExplicitLoading()
        {
            var query = _databaseContext.Categories.Include("Products");
            return query.ToList();
        }

        public Category GetCategoryEagerLoading(Guid categoryId)
        {
            var query = _databaseContext.Categories.Include("Products");
            foreach (var item in query)
            {
                var products = _databaseContext.Entry(item).Collection(c => c.Products);
                if (!products.IsLoaded) products.Load();
            }
            return query.FirstOrDefault(c => c.Id == categoryId);
        }

        public Category GetCategoryExplicitLoading(Guid categoryId)
        {
            var query = _databaseContext.Categories.Include("Products");
            return query.FirstOrDefault(c => c.Id == categoryId); ;
        }
    }
}
