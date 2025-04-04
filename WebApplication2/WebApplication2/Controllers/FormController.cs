using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FormController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public FormController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Form
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormData>>> GetFormData()
        {
            return await _context.FormData.ToListAsync();
        }

        // GET: api/Form/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormData>> GetFormData(int id)
        {
            var formData = await _context.FormData.FindAsync(id);
            if (formData == null)
            {
                return NotFound();
            }
            return formData;
        }

        // POST: api/Form
        [HttpPost]
        public async Task<ActionResult<FormData>> PostFormData(FormData formData)
        {
            _context.FormData.Add(formData);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetFormData), new { id = formData.Id }, formData);
        }

        // PUT: api/Form/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormData(int id, FormData formData)
        {
            if (id != formData.Id)
            {
                return BadRequest();
            }
            _context.Entry(formData).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormDataExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return NoContent();
        }

        // DELETE: api/Form/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormData(int id)
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

        private bool FormDataExists(int id)
        {
            return _context.FormData.Any(e => e.Id == id);
        }
    }
} 