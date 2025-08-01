namespace USTrails.API.Models.DTO
{
    public class AddTrailRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInMiles { get; set; }
        public string? TrailImageUrl { get; set; }
        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }
    }
}
