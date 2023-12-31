using System.ComponentModel.DataAnnotations;

namespace Villa_Web.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberUpdateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaID { get; set; }
        public string SpecialDetails { get; set; }
    }
}
