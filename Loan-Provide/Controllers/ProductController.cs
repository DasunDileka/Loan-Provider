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
            return Ok(await dbContext.Product.ToListAsync());
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProduct([FromRoute] Guid id)
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
                Id = Guid.NewGuid(),
                Image = addProduct.Image,
                Name = addProduct.Name,
                Description = addProduct.Description,
                Price = addProduct.Price,
            };
            await dbContext.Product.AddAsync(productc);
            await dbContext.SaveChangesAsync();
            return Ok(productc);
        }



        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateProduct([FromRoute] Guid id, UpdateProductDto updateProductDto)
        {
            var products = await dbContext.Product.FindAsync(id);
            if (products != null)
            {
               
                products.Image = updateProductDto.Image;
                products.Name = updateProductDto.Name;
                products.Description = updateProductDto.Description;
                products.Price = updateProductDto.Price;
                await dbContext.SaveChangesAsync();
                return Ok(products);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteContact(Guid id)
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
