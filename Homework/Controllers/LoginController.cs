using Azure;
using Homework.Data;
using Homework.Models.Domain;
using Homework.Models.Dtos.Request;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using static Homework.Models.Dtos.Request.LoginDtosResponse;

namespace Homework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ApplicationDbContext DbContext;
        public LoginController(ApplicationDbContext DbContext)
        {
            this.DbContext = DbContext;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> CreateAccount(RegisterDtoRequest registerrequest)
        {
            var register = new Register
            {
                username = registerrequest.userName,
                password = registerrequest.password
            };
            await DbContext.Registers.AddAsync(register);
            await DbContext.SaveChangesAsync();

            return Ok();
            //return NoContent();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(LoginDtoRequest loginrequest)
        {
            var username = loginrequest.userName;
            var password = loginrequest.password;

            var response = new LoginDtosResponse();

            if (username != "" && password != "")
            {
                var checkuser = await DbContext.Registers.FirstOrDefaultAsync(u => u.username == username);

                if (checkuser != null)
                {
                    var user = await DbContext.Registers.FirstOrDefaultAsync(u => u.username == username && u.password == password);
                    if (user != null)
                    {
                        return Ok(new { status = new { code = "200", description = "Success" } });
                    }
                    else
                    {
                        return BadRequest("Invalid username or password.");
                    }

                }
                else
                {
                    return BadRequest("User not found in the database.");
                }
            }
            else
            {
                return BadRequest("Please fill in all fields.");
            }
        }

     
    }
}
