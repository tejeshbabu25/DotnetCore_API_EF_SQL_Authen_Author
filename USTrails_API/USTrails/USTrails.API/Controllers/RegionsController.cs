using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using USTrails.API.Models.Domain;

namespace USTrails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        //GET : //api/regions
        [HttpGet]
        public IActionResult GetAll()
        {
            var regions = new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Half Dome - Yosemite Region",
                    Code = "HDY",
                    RegionImageUrl = "https://images.app.goo.gl/XCfypya2UxS9bC4k7"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Angel's Landing Region",
                    Code = "ALR",
                    RegionImageUrl = "https://images.app.goo.gl/MUxaLfkCHK6xrznA9"
                }
            };
            
            return Ok(regions);
        }
    }
}
