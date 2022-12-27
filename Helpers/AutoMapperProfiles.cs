
using AutoMapper;
using RRHHApi.Entities;

namespace API.Helpers
{
  public class AutoMapperProfiles : Profile
  {
    public AutoMapperProfiles()
    {
   
        CreateMap<Candidato,Candidato>();
  
    
    }
  }
}