using AutoMapper;
using Vega.API.Models;
using Vega.API.Resources;

namespace Vega.API.Mapping
{
    public class MappingProfile : Profile 
    {
        public MappingProfile()
        {
            CreateMap<Make, MakeResource>();
            CreateMap<Model, ModelResource>();
        }
        
    }
}