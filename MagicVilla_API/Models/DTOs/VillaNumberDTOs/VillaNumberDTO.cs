using MagicVilla_API.Models.DTOs.VillaDTOs;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_API.Models.DTOs.VillaNumberDTOs
{
    public class VillaNumberDTO
    {
        [Required]
        public int VillaNo { get; set; }
        public int VillaID { get; set; }

        public string SpecialDetails { get; set; }

        public VillaDTO Villa { get; set; }
    }
}
