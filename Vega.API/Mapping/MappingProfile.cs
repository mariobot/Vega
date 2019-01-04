using System.Linq;
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
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(v => v.Contact, opt => opt.MapFrom(vr => new ContactResource {Name= vr.ContactName, Phone = vr.ContactPhone, Email = vr.ContactEmail}))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(x => x.FeatureId)));

            CreateMap<VehicleResource, Vehicle>()
                .ForMember(v => v.Id , opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                    var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId));
                    foreach(var f in removedFeatures)
                        v.Features.Remove(f);
                    
                    var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature {FeatureId=id});
                    foreach (var f in addedFeatures)
                        v.Features.Add(f);

                });
        }
        
    }
}