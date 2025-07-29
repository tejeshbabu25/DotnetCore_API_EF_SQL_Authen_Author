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

        // Get Regions by Id
        // GET : api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id) 
        {
            //var region = dbContext.Regions.Find(id); // Method 1

            var region = dbContext.Regions.FirstOrDefault(x=>x.Id == id); // Method 2

            if (region == null) { return NotFound(); }
            return Ok(region);
        }
    }
}
