using AutoMapperExample.Entities;

namespace AutoMapperExample.Repository
{
    public class CategoryRepository
    {
        public List<Category> GetAll()
        {
            return new List<Category>
            {
                new Category{Id = 1, Name = "Electronica", Description = "Me"},
                new Category{Id = 2, Name = "Cocina", Description = "Ma"},

            };
        }

        public Category GetById(int id)
        {
            return new Category { Id = 1, Name = "Electronica", Description = "Me" };
        }
    }
}
