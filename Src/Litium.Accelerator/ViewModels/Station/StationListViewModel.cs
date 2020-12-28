using System;
using System.Collections.Generic;
using AutoMapper;
using JetBrains.Annotations;
using Litium.Accelerator.Builders;
using Litium.Accelerator.Constants;
using Litium.Accelerator.Extensions;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models;
using Litium.Web.Models.Blocks;
using Litium.Web.Models.Websites;

namespace Litium.Accelerator.ViewModels.Station
{
    public class StationListViewModel : IAutoMapperConfiguration, IViewModel
    {
        public const string TagName = "Station";

        public string Title { get; set; }
        public ImageModel PageImage { get; set; }
        public string PageImageText { get; set; }
        public string PageImageTextColor { get; set; }
        public List<StationListStationViewModel> StationList { get; set; }
        public ImageModel BoxIcon { get; set; }
        public string MapPinColor { get; set; }
        public string MapInfoWindowLinkColor { get; set; }
        public Dictionary<string, List<BlockModel>> Blocks { get; set; }
        public ImageModel PopUpBackgroundImage { get; set; }
        public string PopUpInformationText { get; set; }
        public decimal PopUpCookieExpiryTime { get; set; }

        [UsedImplicitly]
        void IAutoMapperConfiguration.Configure(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<PageModel, StationListViewModel>()
               .ForMember(x => x.Title, m => m.MapFromField(PageFieldNameConstants.Title))
               .ForMember(x => x.BoxIcon, m => m.MapFrom(stationListPage => stationListPage.GetValue<Guid>(StationListPageFieldNameConstants.BoxIcon).MapTo<ImageModel>()))
               .ForMember(x => x.PageImage, m => m.MapFrom(stationListPage => stationListPage.GetValue<Guid>(PageFieldNameConstants.Image).MapTo<ImageModel>()))
               .ForMember(x => x.PageImageText, m => m.MapFrom(stationListPage => stationListPage.GetValue<string>(StationListPageFieldNameConstants.PageImageText)))
               .ForMember(x => x.PageImageTextColor, m => m.MapFrom(stationListPage => stationListPage.GetValue<string>(StationListPageFieldNameConstants.PageImageTextColor)))
               .ForMember(x => x.MapPinColor, m => m.MapFrom(stationListPage => stationListPage.GetValue<string>(StationListPageFieldNameConstants.MapPinColor)))
               .ForMember(x => x.MapInfoWindowLinkColor, m => m.MapFrom(stationListPage => stationListPage.GetValue<string>(StationListPageFieldNameConstants.MapInfoWindowLinkColor)))
               .ForMember(x => x.PopUpBackgroundImage, m => m.MapFrom(stationListPage => stationListPage.GetValue<Guid>(StationListPageFieldNameConstants.PopUpBackgroundImage).MapTo<ImageModel>()))
               .ForMember(x => x.PopUpInformationText, m => m.MapFrom(stationListPage => stationListPage.GetValue<string>(StationListPageFieldNameConstants.PopUpInformationText)))
               .ForMember(x => x.PopUpCookieExpiryTime, m => m.MapFrom(stationListPage => stationListPage.GetValue<decimal>(StationListPageFieldNameConstants.PopUpCookieExpiryTime)));
        }
    }

    public class StationListStationViewModel : IViewModel
    {
        public string Name { get; set; }
        public string StationId { get; set; }
        public string AddressStreetAddress { get; set; }
        public string AddressZipcode { get; set; }
        public string AddressCity { get; set; }
        public string CoordinatesLat { get; set; }
        public string CoordinatesLong { get; set; }
        public string StationPageUrl { get; set; }
    }
}