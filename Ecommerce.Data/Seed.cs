using Ecommerce.Core.Brands.Models;
using Ecommerce.Core.Categories.Models;
using Ecommerce.Core.Products.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ecommerce.Data
{
    public static class Seed
    {
        public static void SeedDatabase(EcommerceDbContext dbContext)
        {
            var brandOneId = Guid.NewGuid();
            var brandTwoId = Guid.NewGuid();
            var brandThreeId = Guid.NewGuid();

            var categoryOneId = Guid.NewGuid();
            var categoryTwoId = Guid.NewGuid();
            var categoryThreeId = Guid.NewGuid();

            if (!dbContext.Brands.Any())
            {
                dbContext.Brands.AddRange(new List<Brand>
                    {
                        new Brand { Id = brandOneId, Name= "Brand 1", Description = "Brand 1 Description"},
                        new Brand { Id = brandTwoId, Name= "Brand 2", Description = "Brand 2 Description"},
                        new Brand { Id = brandThreeId, Name= "Brand 3", Description = "Brand 3 Description"},
                    });
            }

            if (!dbContext.Categories.Any())
            {
                dbContext.Categories.AddRange(new List<Category>
                    {
                        new Category { Id = categoryOneId, Name = "Category 1"},
                        new Category { Id = categoryTwoId, Name = "Category 2"},
                        new Category { Id = categoryThreeId, Name = "Category 3"}
                    });
            }

            if (!dbContext.Products.Any())
            {
                dbContext.Products.AddRange(new List<Product>
                    {
                        new Product { Id = Guid.NewGuid(), Name = "Product 1", Description = "Product 1 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandOneId, CategoryId = categoryOneId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 2", Description = "Product 2 Description", Quantity = 10, UnitPrice = 150.00M, BrandId = brandTwoId, CategoryId = categoryTwoId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 3", Description = "Product 3 Description", Quantity = 30, UnitPrice = 100.00M, BrandId = brandThreeId, CategoryId = categoryThreeId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 4", Description = "Product 4 Description", Quantity = 100, UnitPrice = 200.00M, BrandId = brandOneId, CategoryId = categoryOneId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 5", Description = "Product 5 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandTwoId, CategoryId = categoryTwoId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 6", Description = "Product 6 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandThreeId, CategoryId = categoryThreeId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 7", Description = "Product 7 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandOneId, CategoryId = categoryOneId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 8", Description = "Product 8 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandTwoId, CategoryId = categoryTwoId },
                        new Product { Id = Guid.NewGuid(), Name = "Product 9", Description = "Product 9 Description", Quantity = 20, UnitPrice = 200.00M, BrandId = brandThreeId, CategoryId = categoryThreeId },

                    });
            }

            dbContext.SaveChanges();
        }
    }
}
