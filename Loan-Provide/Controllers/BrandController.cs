using ApplicationLayer.Dtos.Product;
using DataLayer.Model;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Provide.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class BrandController : Controller
    {

        private ContactsAPIDbContext dbContext;
        public BrandController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetBrand()
        {
            return Ok(await dbContext.Brand.ToListAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetBrand([FromRoute] int id)
        {
            var Brands = await dbContext.Brand.FindAsync(id);
            if (Brands == null)
            {
                return NotFound();
            }
            return Ok(Brands);
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(BrandDto addBrand)
        {
            var Brandc = new Brand()
            {
                Name = addBrand.Name,
                Description = addBrand.Description

            };
            await dbContext.Brand.AddAsync(Brandc);
            await dbContext.SaveChangesAsync();
            return Ok(Brandc);
        }



        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateBrand([FromRoute] int id, BrandDto BrandDto)
        {
            var Brands = await dbContext.Brand.FindAsync(id);
            if (Brands != null)
            {

                Brands.Name = BrandDto.Name;
                Brands.Description = BrandDto.Description;

                await dbContext.SaveChangesAsync();
                return Ok(Brands);
            }
            return NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            var Brands = await dbContext.Brand.FindAsync(id);
            if (Brands != null)
            {
                dbContext.Remove(Brands);
                dbContext.SaveChanges();
                return Ok(Brands);
            }
            return NotFound();
        }
    }
}
