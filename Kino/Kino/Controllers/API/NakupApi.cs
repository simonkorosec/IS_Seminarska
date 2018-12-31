using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Kino.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Swashbuckle.AspNetCore.Swagger;

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