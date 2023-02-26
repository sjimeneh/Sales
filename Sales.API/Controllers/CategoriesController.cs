using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly DataContext _context;

        public CategoriesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.Categories.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(Category category)
        {
            try
            {
                _context.Categories.Add(category);
                await _context.SaveChangesAsync();
                return Ok(category);
            }
            catch (DbUpdateException UpdateException)
            {

                if (UpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe una Categoría con el mismo Nombre");
                }
                return BadRequest(UpdateException.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (category is null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return NoContent();

            //var afectedRow = await _context.Countries.Where(x => x.Id == id).ExecuteDeleteAsync();
            //if (afectedRow == 0)
            //{
            //    return NotFound();
            //}
            //return NoContent();
        }
    }
}
