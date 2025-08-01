using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using USTrails.API.Models.Domain;
using USTrails.API.Models.DTO;
using USTrails.API.Repositories;

namespace USTrails.API.Controllers
{
    // /api/trails
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ITrailRepository trailRepository;

        public TrailsController(IMapper mapper,ITrailRepository trailRepository)
        {
            this.mapper = mapper;
            this.trailRepository = trailRepository;
        }
        // Create Trail
        // POST : /api/trails
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddTrailRequestDto addTrailRequestDto)
        {
            // Map Dto to Domain Model
            var trailDomainModel = mapper.Map<Trail>(addTrailRequestDto);
            await trailRepository.CreateAsync(trailDomainModel);

            // Map Domain model to Dto

            return Ok(mapper.Map<TrailDto>(trailDomainModel));
        }

        // Get Trails
        // GET : /api/trails
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //
            var trailsDomainModel = await trailRepository.GetAllAsync();
            // Map Domain model to DTO and return
            return Ok(mapper.Map<List<TrailDto>>(trailsDomainModel));
        }

        // Get Trails by Id
        // GET : /api/Trails/
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var trailDomainModel = await trailRepository.GetByIdAsync(id);
            if (trailDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<TrailDto>(trailDomainModel));

        }

        // Update Trail by Id
        // PUT : /api/Trail/{id}
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute] Guid id,UpdateTrailRequestDto updateTrailRequestDto)
        {
            // Map DTO to Domain Model
            var trailDomainModel = mapper.Map<Trail>(updateTrailRequestDto);
            trailDomainModel = await trailRepository.UpdateAsync(id, trailDomainModel);

            if(trailDomainModel == null) { return NotFound(); };

            return Ok(mapper.Map<TrailDto>(trailDomainModel));
        }

        // Delete Trail by Id
        // DELETE : /api/Trail/{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var deletedTrailDomainModel = await trailRepository.DeleteAsync(id);
            if (deletedTrailDomainModel == null) { return NotFound(); }

            return Ok(mapper.Map<TrailDto>(deletedTrailDomainModel));
        }
    }
}
