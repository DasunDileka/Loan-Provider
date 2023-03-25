using ApplicationLayer;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        public async Task<IActionResult> UpdateContact()
        {

        }
    }
}
