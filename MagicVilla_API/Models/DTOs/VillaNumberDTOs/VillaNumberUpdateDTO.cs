using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
