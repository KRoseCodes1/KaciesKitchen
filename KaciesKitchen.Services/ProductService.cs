using KaciesKitchen.Data;
using KaciesKitchen.Models.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaciesKitchen.Services
{
    public class ProductService
    {
        private readonly Guid _userId;
        public ProductService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateProduct(ProductCreate model)
        {
            var entity =
                new Product()
                {
                    Price = model.Price,
                    Description = model.Description,
                    RecipeID = model.RecipeID
                };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Products.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }
    }
}
