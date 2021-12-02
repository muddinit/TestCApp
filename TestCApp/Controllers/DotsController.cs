using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace TestCApp.Controllers
{
    [Route("api/[controller]")]
    public class DotsController : Controller
    {
        private readonly ApiContext _context;

        public DotsController(ApiContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Get()
        {
            var dots = await _context.Dots
                .Include(u => u.Posts)
                .ToArrayAsync();

            var response = dots.Select(u => new
            {
                Id = u.Id,
                PositionX = u.PositionX,
                PositionY = u.PositionY,
                Radius = u.Radius,
                Color = u.Color,
                posts = u.Posts.Select(u => new
                {
                    Text = u.Text,
                    BackgroundColor = u.BackgroundColor
                })
            });

            return Ok(response);
        }

        [HttpDelete("Delete/{id:int}")]
        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var Dot = _context.Dots.FirstOrDefault(p => p.Id == id);
            if (Dot != null)
            {
                _context.Remove(Dot);
                _context.SaveChanges();
            }

            return Ok();
        }

    }
}