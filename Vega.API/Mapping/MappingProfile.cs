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
            CreateMap<Make, KeyValuePairResource>();
            CreateMap<Model, KeyValuePairResource>();
            CreateMap<Vehicle, SaveVehicleResource>()
                .ForMember(v => v.Contact, opt => opt.MapFrom(vr => new ContactResource {Name= vr.ContactName, Phone = vr.ContactPhone, Email = vr.ContactEmail}))
                .ForMember(v => v.Features, opt => opt.MapFrom(vr => vr.Features.Select(x => x.FeatureId)));
            CreateMap<Vehicle, VehicleResource>()
                .ForMember(v => v.Make, opt => opt.MapFrom(v => v.Model.Make))
                .ForMember(v => v.Contact, opt => opt.MapFrom(vr => new ContactResource {Name= vr.ContactName, Phone = vr.ContactPhone, Email = vr.ContactEmail}))
                .ForMember(v => v.Features, opt => opt.MapFrom( v => v.Features.Select(vf => new KeyValuePairResource {Id=vf.Feature.Id,Name=vf.Feature.name}))) ;

            CreateMap<SaveVehicleResource, Vehicle>()
                .ForMember(v => v.Id , opt => opt.Ignore())
                .ForMember(v => v.ContactName, opt => opt.MapFrom(vr => vr.Contact.Name))
                .ForMember(v => v.ContactPhone, opt => opt.MapFrom(vr => vr.Contact.Phone))
                .ForMember(v => v.ContactEmail, opt => opt.MapFrom(vr => vr.Contact.Email))
                .ForMember(v => v.Features, opt => opt.Ignore())
                .AfterMap((vr, v) => {
                // Remove unselected features
                //var removedFeatures = v.Features.Where(f => !vr.Features.Contains(f.FeatureId)).ToList();
                //foreach (var f in removedFeatures)
                //  v.Features.Remove(f);

                // Add new features
                //var addedFeatures = vr.Features.Where(id => !v.Features.Any(f => f.FeatureId == id)).Select(id => new VehicleFeature { FeatureId = id }).ToList();   
                //foreach (var f in addedFeatures)
                //    v.Features.Add(f);
            });
        }
        
    }
}