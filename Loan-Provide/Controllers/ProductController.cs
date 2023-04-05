using ApplicationLayer.Dtos.Product;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace Loan_Provide.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {

        private ContactsAPIDbContext dbContext;
        public ProductController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {

            var result = from a in dbContext.Product
                         join b in dbContext.Brand on a.BrandId equals b.Id
                         join c in dbContext.Category on a.CategoryId equals c.Id
                         join d in dbContext.User on a.UserId equals d.Id
                         select new 
                         {
                             Id= a.Id,
                             Name = a.Name,
                             Description = a.Description,
                             Price = a.Price,
                             Quantity = a.Quantity,
                             Customer = d.Name,
                             Category = c.Name,
                             Brand = b.Name
                         };
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var products = await dbContext.Product.FindAsync(id);
            if (products==null)
            {
                return NotFound();
            }
            return Ok(products);
        }


        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductDto addProduct)
        {
            var productc = new Product()
            {
                
              
                Name = addProduct.Name,
                Description = addProduct.Description,
                Price = addProduct.Price,
                Quantity=addProduct.Quantity,
                UserId=addProduct.UserId,
                CategoryId=addProduct.CategoryId,
                BrandId=addProduct.BrandId
            };
            await dbContext.Product.AddAsync(productc);
            await dbContext.SaveChangesAsync();
            return Ok(productc);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] int id, ProductDto ProductDto)
        {
            var products = await dbContext.Product.FindAsync(id);
            if (products != null)
            { 
                products.Name = ProductDto.Name;
                products.Description = ProductDto.Description;
                products.Price = ProductDto.Price;
                products.Quantity = ProductDto.Quantity;
                products.UserId = ProductDto.UserId;
                products.CategoryId = ProductDto.CategoryId;
                products.BrandId = ProductDto.BrandId;
                await dbContext.SaveChangesAsync();
                return Ok(products);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteContact(int id)
        {
            var products = await dbContext.Product.FindAsync(id);
            if (products != null)
            {
                dbContext.Remove(products);
                dbContext.SaveChanges();
                return Ok(products);
            }
            return NotFound();
        }
    }
}
