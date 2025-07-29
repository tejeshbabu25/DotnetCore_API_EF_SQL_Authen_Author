using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using USTrails.API.Data;
using USTrails.API.Models.Domain;
using USTrails.API.Models.DTO;

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
            // Get data from database - domain models
            var regions = dbContext.Regions.ToList();

            //Map Domain Models to DTOs

            var regionsDto = new List<RegionDto>();
            foreach (var region in regions)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = region.Id,
                    Code = region.Code,
                    Name = region.Name,
                    RegionImageUrl = region.RegionImageUrl
                });
            }

            //Return DTOs
            return Ok(regionsDto);
        }

        // Get Regions by Id
        // GET : api/regions/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute]Guid id) 
        {
            // Get regions domain model from Database
            //var region = dbContext.Regions.Find(id); // Method 1
            var region = dbContext.Regions.FirstOrDefault(x=>x.Id == id); // Method 2

            //Map to region domain model to region DTOs
            var regionDto = new RegionDto
            {
                Id = region.Id,
                Code = region.Code,
                Name = region.Name,
                RegionImageUrl = region.RegionImageUrl
            };

            if (region == null) { return NotFound(); }
            return Ok(region);
        }
    }
}
