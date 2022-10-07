using GroceryStoreManagement.Common;
using GroceryStoreManagement.Core;
using GroceryStoreManagement.DataAccess;
using GroceryStoreManagement.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
            private readonly IUser _user;
            public readonly GroceryDbContext _context;

            public UserController(IUser user, GroceryDbContext context)
            {
                _user = user;
                _context = context;
            }

            [HttpGet("")]
            public async Task<IActionResult> GetUsers()
            {
                try
                {
                    var users = await _user.GetAllUsersAsync();
                    if (users != null)
                    {
                        return Ok(users);
                    }
                    else
                    {
                        throw new EmptyItemsException("This List Is Empty");
                    }
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }


            // GET: api/User/5
            [HttpGet("{id}")]
            public async Task<ActionResult<UserModel>> GetUsersById(int id)
            {
                try
                {
                    var users = await _user.GetUsersByIdAsync(id);

                    if (users == null)
                    {
                        return NotFound();
                    }
                    return users;
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }

            [HttpPost]
           // [Authorize]
            public async Task<ActionResult<UserModel>> AddNewUser(UserModel model)
            {
                try
                {
                    await _user.Create(model);

                    return CreatedAtAction("GetUsersById", new { id = model.UserId }, model);
                }
                catch (Exception ex)
                {
                    return BadRequest("Data Insertion Failed!!");
                }
            }

            [HttpPut("{id}")]
            //[Authorize]
            public async Task<ActionResult> PutUser([FromRoute] int id, [FromBody] UserModel model)
            {
                try
                {
                    if (id != model.UserId)
                    {
                        return BadRequest();
                    }
                    await _user.update(model);

                    return Ok("Data Updated Successfully!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Data Cannot Uploaded!!");
                }

            }

            [HttpDelete("{id}")]
            //[Authorize]
            public async Task<ActionResult<UserModel>> DeleteUser([FromRoute] int id)
            {
                try
                {
                    var itemToDelete = await _user.GetUsersByIdAsync(id);
                    if (itemToDelete == null)
                    {
                        return NotFound();
                    }

                    await _user.delete(itemToDelete.UserId);
                    return Ok("Data Deleted Successfully!");
                }
                catch (Exception ex)
                {
                    return Ok("Data Deletion Failed");
                }
            }

        [HttpPost]
        [Route("Login")]
        public async Task<ActionResult> Login(UserModel model)
        {
            try
            {
                var user = _context.UserModel.Where(i => i.Email == model.Email && i.Password == model.Password).FirstOrDefault();
                if (user == null)
                {
                    return BadRequest("Invalid Credentials");
                }

                var claims = new List<Claim> { new Claim(type:ClaimTypes.Role,value:user.Role),
                    new Claim(type:ClaimTypes.Role,value:user.Role)};
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));

                return Ok("SignIn Successful!!");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

       
    }
}
