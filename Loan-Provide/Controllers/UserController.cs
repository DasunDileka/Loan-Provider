using ApplicationLayer.Dtos.Product;
using DataLayer;
using DataLayer.Model;
using Microsoft.AspNetCore.Mvc;

namespace Loan_Provide.Controllers
{

    [ApiController]
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private ContactsAPIDbContext dbContext;
        public UserController(ContactsAPIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        [Route("{email}")]
        public async Task<IActionResult> GetUser([FromRoute] string email)
        {
            var Users = await dbContext.User.FindAsync(email);
            if (Users == null)
            {
                return NotFound();
            }
            return Ok(Users);
        }


        [HttpPost]
        public async Task<IActionResult> AddUser(UserDto addUser)
        {
            var Userc = new User()
            {

                Name = addUser.Name,
                Email = addUser.Email,
                Password = addUser.Password,
                Contact = addUser.Contact,
             
            };
            await dbContext.User.AddAsync(Userc);
            await dbContext.SaveChangesAsync();
            return Ok(Userc);
        }

    }
}
