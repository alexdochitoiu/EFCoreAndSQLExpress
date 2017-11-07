using System;
using System.Collections.Generic;
using Data.Domain.Entities;

namespace Data.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        IReadOnlyList<Category> GetAll();
        Category GetById(Guid id);
        void Add(Category todo);
        void Edit(Category todo);
        void Delete(Guid id);
    }
}
