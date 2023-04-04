using DataLayer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Loan_Provide.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class LoanDetailsController : Controller
    {
        private ContactsAPIDbContext dbContext;
        public LoanDetailsController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public async Task<IActionResult> GetLoan()
        {
            return Ok(await dbContext.Loan.ToListAsync());
        }


        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteLoan(int id)
        {
            var Loans = await dbContext.Loan.FindAsync(id);
            if (Loans != null)
            {
                dbContext.Remove(Loans);
                dbContext.SaveChanges();
                return Ok(Loans);
            }
            return NotFound();
        }

    }
}
