using GroceryStoreManagement.Common;
using GroceryStoreManagement.Core;
using GroceryStoreManagement.DataAccess;
using GroceryStoreManagement.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryStoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroceryController : ControllerBase
    {
            private readonly IGrocery _shop;
            

            public GroceryController(IGrocery grocery)
            {
                _shop = grocery;
                
            }

            [HttpGet("")]
            public async Task<IActionResult> GetGroceries()
            {
                try
                {
                    var groceries = await _shop.GetAllGroceryAsync();
                    if (groceries != null)
                    {
                        return Ok(groceries);
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


            // GET: api/Grocery/5
            [HttpGet("{id}")]
            public async Task<ActionResult<GroceryModel>> GetGroceryById(int id)
            {
                try
                {
                    var grocery = await _shop.GetGroceryByIdAsync(id);

                    if (grocery == null)
                    {
                        return NotFound();
                    }
                    return grocery;
                }
                catch (Exception ex)
                {
                    return Ok(ex.Message);
                }
            }

            [HttpPost]
           // [Authorize]
            public async Task<ActionResult<GroceryModel>> AddNewGrocery(GroceryModel model)
            {
                try
                {
                    await _shop.Create(model);

                    return CreatedAtAction("GetGroceryById", new { id = model.GroceryId }, model);
                }
                catch (Exception ex)
                {
                    return BadRequest("Data Insertion Failed!!");
                }
            }

            [HttpPut("{id}")]
            //[Authorize]
            public async Task<ActionResult> PutGrocery([FromRoute] int id, [FromBody] GroceryModel model)
            {
                try
                {
                    if (id != model.GroceryId)
                    {
                        return BadRequest();
                    }
                    await _shop.update(model);

                    return Ok("Data Updated Successfully!");
                }
                catch (Exception ex)
                {
                    return BadRequest("Data Cannot Uploaded!!");
                }

            }

            [HttpDelete("{id}")]
            //api/Grocery/1
            public async Task<ActionResult<GroceryModel>> DeleteGrocery([FromRoute] int id)
            {
                try
                {
                    var itemToDelete = await _shop.GetGroceryByIdAsync(id);
                    if (itemToDelete == null)
                    {
                        return NotFound();
                    }

                    await _shop.delete(itemToDelete.GroceryId);
                    return Ok("Data Deleted Successfully!");
                }
                catch (Exception ex)
                {
                    return Ok("Data Deletion Failed");
                }
            }

            
        
    }
}

