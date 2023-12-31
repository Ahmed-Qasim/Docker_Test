using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Villa_Web.Models.DTOs.VillaDTOs;

namespace Villa_Web.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaID { get; set; }
        [DisplayName("Special Details")]
        public string SpecialDetails { get; set; }

        public VillaDTO Villa { get; set; }
    }
}
