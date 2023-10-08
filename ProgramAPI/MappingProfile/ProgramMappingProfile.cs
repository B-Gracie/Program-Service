using AutoMapper;
using DataAccessLayer.DTOs;
using DataAccessLayer.Model;

namespace ProgramAPI.MappingProfile;

public class ProgramMappingProfile : Profile

{
    public ProgramMappingProfile()
    {
            
        CreateMap<ProgramModel, ProgramDto>().ReverseMap();

    }
    
}