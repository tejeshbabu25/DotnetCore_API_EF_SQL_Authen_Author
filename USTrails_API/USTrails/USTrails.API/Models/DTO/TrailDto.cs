namespace USTrails.API.Models.DTO
{
    public class TrailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double LengthInMiles { get; set; }
        public string? TrailImageUrl { get; set; }
        public RegionDto Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
    }
}
