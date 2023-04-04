using ApplicationLayer.Dtos.Product;
using DataLayer.Model;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Provide.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class CategoryController : Controller
    {

        private ContactsAPIDbContext dbContext;
        public CategoryController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategory()
        {
            return Ok(await dbContext.Category.ToListAsync());
        }


        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategory([FromRoute] int id)
        {
            var Categories = await dbContext.Category.FindAsync(id);
            if (Categories == null)
            {
                return NotFound();
            }
            return Ok(Categories);
        }


        [HttpPost]
        public async Task<IActionResult> AddCategory(CategoryDto addCategory)
        {
            var Categoryc = new Category()
            {
                Name = addCategory.Name,
                
              
            };
            await dbContext.Category.AddAsync(Categoryc);
            await dbContext.SaveChangesAsync();
            return Ok(Categoryc);
        }



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromRoute] int id, CategoryDto CategoryDto)
        {
            var Categories = await dbContext.Category.FindAsync(id);
            if (Categories != null)
            {

                Categories.Name = CategoryDto.Name;
                
                await dbContext.SaveChangesAsync();
                return Ok(Categories);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var Categories = await dbContext.Category.FindAsync(id);
            if (Categories != null)
            {
                dbContext.Remove(Categories);
                dbContext.SaveChanges();
                return Ok(Categories);
            }
            return NotFound();
        }
    }
}
