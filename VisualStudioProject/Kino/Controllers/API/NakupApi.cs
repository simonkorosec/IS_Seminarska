using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Mvc;

namespace Kino.Controllers.API {
    [Route("api/[controller]")]
    [ApiController]
    public class NakupApiController : ControllerBase {
        private readonly KinoDatabaseContext _context;

        public NakupApiController(KinoDatabaseContext context) {
            _context = context;
        }

        // POST: api/NakupApi
        [HttpPost]
        public async Task<StatusCodeResult> PostNakup([FromBody] Karta karta) {
            if (!ModelState.IsValid) 
                return BadRequest();
            
            _context.Add(karta);
            await _context.SaveChangesAsync();
            return Ok();

        }
    }
}