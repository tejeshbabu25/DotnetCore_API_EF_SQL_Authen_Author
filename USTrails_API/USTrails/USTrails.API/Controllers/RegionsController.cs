using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System.Reflection.Metadata.Ecma335;
using USTrails.API.Data;
using USTrails.API.Models.Domain;
using USTrails.API.Models.DTO;
using USTrails.API.Repositories;

namespace USTrails.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly USTrailsDbContext dbContext;
        private readonly IRegionRepository regionRepository;

        public RegionsController(USTrailsDbContext dbContext,IRegionRepository regionRepository)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
        }


        //GET : //api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get data from database - domain models
            var regions = await regionRepository.GetAllAsync();

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
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            // Get regions domain model from Database
           // var region = dbContext.Regions.FindAsync(id); // Method 1
            var region = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id); // Method 2

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

        // POST to create a new region
        // POST : api/regions
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {
            // Map DTO to Domain Model
            var regionDomainModel = new Region
            {
                Code = addRegionRequestDto.Code,
                Name = addRegionRequestDto.Name,
                RegionImageUrl = addRegionRequestDto.RegionImageUrl
            };

            // Use Domain model to create Region
            await dbContext.Regions.AddAsync(regionDomainModel);
            await dbContext.SaveChangesAsync(); // Actually saves the changes to SQL server;

            //Map Domain Model back to DTO since we want to send this to client to show the new entry that was created
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return CreatedAtAction(nameof(GetById), new { id = regionDomainModel.Id }, regionDto); // nameof(GetById) = this is used to call the GetById method above my passing the id that was just created and show it to the user
        }


        //Update Region
        //PUT : api/regions/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {
            // check if region exists
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null) { return NotFound(); }

            // Map DTO to Domain Model
            regionDomainModel.Code = updateRegionRequestDto.Code;
            regionDomainModel.Name = updateRegionRequestDto.Name;
            regionDomainModel.RegionImageUrl = updateRegionRequestDto.RegionImageUrl;

            await dbContext.SaveChangesAsync();

            // Map Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }

        // Delete Region
        //DELETE : api/regions/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDomainModel == null) { return NotFound(); }

            //Delete region
            dbContext.Regions.Remove(regionDomainModel);
            await dbContext.SaveChangesAsync();

            //return deleted region back
            // Map Domain Model to DTO
            var regionDto = new RegionDto
            {
                Id = regionDomainModel.Id,
                Code = regionDomainModel.Code,
                Name = regionDomainModel.Name,
                RegionImageUrl = regionDomainModel.RegionImageUrl
            };

            return Ok(regionDto);
        }
    }
}
