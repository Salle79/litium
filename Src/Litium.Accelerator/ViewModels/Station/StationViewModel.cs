using System;
using System.Collections.Generic;
using AutoMapper;
using Litium.Accelerator.Builders;
using Litium.Accelerator.Constants;
using Litium.Accelerator.Extensions;
using Litium.FieldFramework;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models;
using Litium.Web.Models.Blocks;
using Litium.Web.Models.Websites;

namespace Litium.Accelerator.ViewModels.Station
{
    public class StationViewModel : IAutoMapperConfiguration, IViewModel
    {
        public string Title { get; set; }
        public EditorString Textie { get; set; }
        public Dictionary<string, List<BlockModel>> Blocks { get; set; }
        public string Name { get; set; }
        public string StationId { get; set; }
        public string Text { get; set; }
        public ImageModel Image { get; set; }
        public ImageModel FallbackImage { get; set; }
        public string AddressStreetAddress { get; set; }
        public string AddressZipcode { get; set; }
        public string AddressCity { get; set; }
        public string CitiesNearby { get; set; }
        public string LocationDescription { get; set; }
        public string CoordinatesLat { get; set; }
        public string CoordinatesLong { get; set; }
        public string MapPinColor { get; set; }
        public string LocalManagerName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string OpeningHours { get; set; }
        public string DeviantOpeningHours { get; set; }
        public string InformationTextOnRight { get; set; }
        public string InformationTextOnLeft { get; set; }
        public string ServiceText { get; set; }
        public string Url { get; set; }
        public DateTime WinterSeasonStartDate { get; set; }
        public DateTime WinterSeasonEndDate { get; set; }
        public DateTime SummerSeasonStartDate { get; set; }
        public DateTime SummerSeasonEndDate { get; set; }

        public List<ServiceGroupViewModel> Services { get; set; }

        void IAutoMapperConfiguration.Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PageModel, StationViewModel>()
               .ForMember(x => x.Name, m => m.MapFromField(SystemFieldDefinitionConstants.Name))
               .ForMember(x => x.StationId, m => m.MapFromField(StationPageFieldNameConstants.StationId))
               .ForMember(x => x.Text, m => m.MapFromField(PageFieldNameConstants.Text))
               .ForMember(x => x.Image, m => m.MapFrom(pm => pm.GetValue<Guid>(PageFieldNameConstants.Image).MapTo<ImageModel>()))
               .ForMember(x => x.AddressStreetAddress, m => m.MapFromField(StationPageFieldNameConstants.AddressStreetAddress))
               .ForMember(x => x.AddressZipcode, m => m.MapFromField(StationPageFieldNameConstants.AddressZipcode))
               .ForMember(x => x.AddressCity, m => m.MapFromField(StationPageFieldNameConstants.AddressCity))
               .ForMember(x => x.CitiesNearby, m => m.MapFromField(StationPageFieldNameConstants.CitiesNearby))
               .ForMember(x => x.LocationDescription, m => m.MapFromField(StationPageFieldNameConstants.LocationDescription))
               .ForMember(x => x.CoordinatesLat, m => m.MapFromField(StationPageFieldNameConstants.CoordinatesLat))
               .ForMember(x => x.CoordinatesLong, m => m.MapFromField(StationPageFieldNameConstants.CoordinatesLong))
               .ForMember(x => x.LocalManagerName, m => m.MapFromField(StationPageFieldNameConstants.LocalManagerName))
               .ForMember(x => x.Phone, m => m.MapFromField(StationPageFieldNameConstants.Phone))
               .ForMember(x => x.Email, m => m.MapFromField(StationPageFieldNameConstants.Email))
               .ForMember(x => x.OpeningHours, m => m.MapFromField(StationPageFieldNameConstants.OpeningHours))
               .ForMember(x => x.DeviantOpeningHours, m => m.MapFromField(StationPageFieldNameConstants.DeviantOpeningHours))
               .ForMember(x => x.InformationTextOnRight, m => m.MapFromField(StationPageFieldNameConstants.InformationTextOnRight))
               .ForMember(x => x.InformationTextOnLeft, m => m.MapFromField(StationPageFieldNameConstants.InformationTextOnLeft))
               .ForMember(x => x.ServiceText, m => m.MapFromField(StationPageFieldNameConstants.ServiceText));
        }

        public class ServiceGroupViewModel : IViewModel
        {
            public string Name { get; set; }
            public List<ServiceVariantViewModel> Variants { get; set; }
            public ImageModel Icon { get; set; }
        }

        public class ServiceVariantViewModel : IViewModel
        {
            public string VariantName { get; set; }
            public decimal Price { get; set; }
            public string PerUnitText { get; set; }
        }
    }
}