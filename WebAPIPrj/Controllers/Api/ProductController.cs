using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIPrj.Models;

namespace WebAPIPrj.Controllers.Api {
    public class ProductController : ApiController {
        Product[] products = new Product[]{
			new Product{ProductId=1,ProductName="Tomato Soup",ProductCategory="Croceries",ProductPrice=1},
			new Product{ProductId=2,ProductName="Yo-yo",ProductCategory="Toys",ProductPrice=3.75M},
			new Product{ProductId=3,ProductName="Hammer",ProductCategory="Hardware",ProductPrice=16.99M}
		};

        //http://localhost:53404/api/Product/
        public IEnumerable<Product> GetAllProducts() {
            return products;
        }

        //http://localhost:53404/api/Product/1
        public Product GetProductById(int id) {
            Product product = products.FirstOrDefault(p => p.ProductId == id);
            if (product == null) {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return product;
        }

        //http://localhost:53404/api/Product/?category=Toys
        public IEnumerable<Product> GetAllProducts(string category) {
            return products.Where(p => string.Equals(p.ProductCategory, category, StringComparison.OrdinalIgnoreCase));
        }

    }
}
