﻿using AutoMapper;
using MagicVilla_Web.Models.Dto;

namespace MagicVilla_VillaAPI
{
    public class MappingConfig :Profile
    {
        public MappingConfig()
        {
            CreateMap <VillaDTO,VillaCreateDTO> ().ReverseMap();
           
            CreateMap<VillaDTO, VillaUpdateDTO>().ReverseMap();




            CreateMap<VillaNumberDTO, VillaNumberCreateDTO>().ReverseMap();

            CreateMap<VillaNumberDTO, VillaNumberUpdateDTO>().ReverseMap();
            
        }
    }
}
