using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Defines the base route for this controller
    public class FormController : ControllerBase
    {
        private readonly ApplicationDbContext _context; // Injected ApplicationDbContext from the Data folder to interact with the database
        
        public FormController(ApplicationDbContext context) // Constructor to inject the ApplicationDbContext, allowing interaction with the database
        {
            _context = context;
        }

        // GET: api/Form
        // Retrieves all form data from the database
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormData>>> GetFormData()
        {
            return await _context.FormData.ToListAsync();
        }

        // GET: api/Form/5
        // Retrieves a specific form data entry by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<FormData>> GetFormData(int id)
        {
            var formData = await _context.FormData.FindAsync(id);
            if (formData == null)
            {
                return NotFound(); // Returns 404 if the entry is not found
            }
            return formData; 
        }

        // POST: api/Form
         // Creates a new form data entry
        [HttpPost]
        public async Task<ActionResult<FormData>> PostFormData(FormData formData)
        {
            _context.FormData.Add(formData); // Adds new data to the DbContext
            await _context.SaveChangesAsync(); // Saves changes to the database
            return CreatedAtAction(nameof(GetFormData), new { id = formData.Id }, formData);
        }

        // PUT: api/Form/5
        // Updates an existing form data entry
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormData(int id, FormData formData)
        {
            if (id != formData.Id) // Validates if the ID matches
            {
                return BadRequest(); // Returns 400
            }
            _context.Entry(formData).State = EntityState.Modified; // Marks the entry as modified
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!FormDataExists(id)) // Checks if the form data exists before updating
                {
                    return NotFound(); // Returns 404
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Form/5
        // Deletes a form data entry
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormData(int id) // Finds the data to delete
        {
            var formData = await _context.FormData.FindAsync(id);
            if (formData == null)
            {
                return NotFound(); 
            }
            _context.FormData.Remove(formData);
            await _context.SaveChangesAsync(); 
            return NoContent();
        }
        
        private bool FormDataExists(int id)  // Private helper method to check if the form data exists by ID
        {
            return _context.FormData.Any(e => e.Id == id);
        }
    }
} 
