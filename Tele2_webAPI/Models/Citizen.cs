using System.ComponentModel.DataAnnotations;
namespace Tele2_webAPI.Models
{
    public class Citizen
    {
        [Key]
        public int Index { get; set; }
        [Required]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Sex { get; set; }

        public int? Age { get; set; } = 0;
    }
}
