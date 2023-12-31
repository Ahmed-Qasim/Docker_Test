﻿using AutoMapper;
using Villa_Web.Models.DTOs.VillaDTOs;
using Villa_Web.Models.DTOs.VillaNumberDTOs;

namespace Villa_Web
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {

            CreateMap<VillaDTO, VillaCreateDTO>().ReverseMap();
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();
            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();

        }
    }
}
