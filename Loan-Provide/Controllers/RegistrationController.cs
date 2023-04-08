using ApplicationLayer.Dtos.Product;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Loan_Provide.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class RegistrationController : Controller
    {
        private ContactsAPIDbContext dbContext;
        public RegistrationController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost]
        public async Task<IActionResult> Registration(UserDto addUser)
        {
            var Userc = new User()
            {
                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
                Contact = addUser.Contact,
                UserType = addUser.UserType

            };
            await dbContext.User.AddAsync(Userc);
            await dbContext.SaveChangesAsync();
            return Ok(Userc);
        }

        [HttpPost("Login")]
       
        public IActionResult Login([Required] string Name,[Required] string password)
        {
            var display = dbContext.User.Where(m => m.Name == Name && m.Password == password).FirstOrDefault();
            if (display != null)
            {
                return Ok(display);
            }
            else
            
                return NotFound();
            

      
        }
    }
}