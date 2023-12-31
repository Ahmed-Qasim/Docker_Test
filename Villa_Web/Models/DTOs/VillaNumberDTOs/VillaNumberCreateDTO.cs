using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Villa_Web.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberCreateDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaID { get; set; }
        [DisplayName("Special Details")]
        public string SpecialDetails { get; set; }
    }
}
