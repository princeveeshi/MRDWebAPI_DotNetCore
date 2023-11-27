using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppliationAPI.Controllers
{
    
    [ApiController]
    public class ContactDataController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Ensure the variable name matches the one in your constructor.

        public ContactDataController(ApplicationDbContext context)
        {
            _context = context; // Ensure that the assignment matches your constructor parameter.
        }

        // GET: api/ContactData
        [HttpGet]
        [Route("api/GetAllContact")]
        public async Task<ActionResult<IEnumerable<ContactDataModel>>> Get()
        {
            try
            {
                var contactData = await _context.Contacts.ToListAsync();

                if (contactData == null || !contactData.Any())
                {
                    return NotFound(); 
                }

                return Ok(contactData);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
           
        }
        [HttpPost]
        [Route("api/PostContactData")]
        public async Task<IActionResult> PostContactData([FromBody] ContactDataModel contactData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Contacts.Add(contactData);
                    await _context.SaveChangesAsync();
                    return Ok("Contact data inserted successfully.");
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
