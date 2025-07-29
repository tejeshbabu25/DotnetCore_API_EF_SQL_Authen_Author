using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using USTrails.API.Data;
using USTrails.API.Models.Domain;

namespace USTrails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly USTrailsDbContext dbContext;

        public RegionsController(USTrailsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //GET : //api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }
    }
}
