using MVC.Models;

namespace MVC.Services
{
    public class ProductService : List<ProductModel>
    {

        public ProductService()
        {
            this.AddRange(new ProductModel[]
            {
                new ProductModel() {Id = 1, Name = "Iphone", Price = 1000},
                new ProductModel() {Id = 2, Name = "Iphone 2", Price = 2000},
                new ProductModel() {Id = 3, Name = "Iphone 3", Price = 3000},
                new ProductModel() {Id = 4, Name = "Iphone 4", Price = 4000}
            });
        }
    }
}
