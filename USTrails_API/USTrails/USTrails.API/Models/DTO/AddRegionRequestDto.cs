using System.ComponentModel.DataAnnotations;

namespace USTrails.API.Models.DTO
{
    public class AddRegionRequestDto
    {
        [Required]
        [Length(0,3,ErrorMessage = "Code has to be a between 0 to 3 characters")]
        public string Code { get; set; }
        [Required]
        public string Name { get; set; }
        public string? RegionImageUrl { get; set; }
    }
}
