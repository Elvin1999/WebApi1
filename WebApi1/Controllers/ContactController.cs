using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi1.Models;

namespace WebApi1.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ContactController:Controller
    {
        [HttpGet("")]
        [Authorize(Roles = "Admin")]
        public List<ContactModel> Get()
        {
            return new List<ContactModel>()
            {
                new ContactModel
                {
                     Id = 1,
                     FirstName ="Elvin",
                     LastName ="Camalzade"
                }
            };
        }
    }
}
