using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sales.API.Data;
using Sales.Shared.Entities;

namespace Sales.API.Controllers
{
    [ApiController]
    [Route("/api/states")]
    public class StatesController : ControllerBase
    {
        private readonly DataContext _context;

        public StatesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            return Ok(await _context.States.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync(State state)
        {
            _context.States.Add(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> GetAsync(int id)
        {
            var state = await _context.States.FirstOrDefaultAsync(x => x.Id == id);
            if (state is null)
            {
                return NotFound();
            }
            else
            {
                return Ok(state);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutAsync(State state)
        {
            _context.States.Update(state);
            await _context.SaveChangesAsync();
            return Ok(state);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> DeleteAsync(int id)
        {
            var state = await _context.States.FirstOrDefaultAsync(x => x.Id == id);
            if (state is null)
            {
                return NotFound();
            }
            _context.States.Remove(state);
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
