using Litium.Accelerator.Constants;
using Litium.Accelerator.Extensions;
using Litium.Accelerator.Routing;
using Litium.Accelerator.Search;
using Litium.Accelerator.Services;
using Litium.Accelerator.ViewModels.Framework;
using Litium.Accelerator.ViewModels.Search;
using Litium.Accelerator.ViewModels.Station;
using Litium.Common;
using Litium.Foundation.Modules.CMS.Search;
using Litium.Foundation.Modules.ExtensionMethods;
using Litium.Foundation.Search;
using Litium.Framework.Search;
using Litium.Runtime.AutoMapper;
using Litium.Web;
using Litium.Web.Models.Blocks;
using Litium.Web.Models.Websites;
using Litium.Web.Routing;
using Litium.Websites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;


namespace Litium.Accelerator.Builders.Station
{
    public class StationListViewModelBuilder : IViewModelBuilder<StationListViewModel>
    {
        private readonly RequestModelAccessor _requestModelAccessor;
        private readonly RouteRequestLookupInfoAccessor _routeRequestLookupInfoAccessor;
        private readonly StationService _stationService;
        private readonly UrlService _urlService;

        public StationListViewModelBuilder(RequestModelAccessor requestModelAccessor, RouteRequestLookupInfoAccessor routeRequestLookupInfoAccessor, StationService stationService, UrlService urlService)
        {
            _requestModelAccessor = requestModelAccessor;
            _routeRequestLookupInfoAccessor = routeRequestLookupInfoAccessor;
            _stationService = stationService;
            _urlService = urlService;
        }

        public virtual StationListViewModel Build(PageModel pageModel)
        {
            var model = pageModel.MapTo<StationListViewModel>();
            model.StationList = _stationService.GetAllStationPages()?.Select(x => new StationListStationViewModel
            {
                Name = x.Localizations.CurrentCulture.Name,
                StationId = x.Fields?.GetValue<string>(StationPageFieldNameConstants.StationId),
                AddressStreetAddress = x.Fields?.GetValue<string>(StationPageFieldNameConstants.AddressStreetAddress),
                AddressZipcode = x.Fields?.GetValue<string>(StationPageFieldNameConstants.AddressZipcode),
                AddressCity = x.Fields?.GetValue<string>(StationPageFieldNameConstants.AddressCity),
                CoordinatesLat = x.Fields?.GetValue<string>(StationPageFieldNameConstants.CoordinatesLat),
                CoordinatesLong = x.Fields?.GetValue<string>(StationPageFieldNameConstants.CoordinatesLong),
                StationPageUrl = _urlService.GetUrl(x),
            }).ToList();
            return model;
        }

        public virtual StationListViewModel ForPreviewGlobalBlock(Guid blockId)
        {
            var routeRequest = _routeRequestLookupInfoAccessor.RouteRequestLookupInfo;
            if (routeRequest.PreviewPageData == null)
            {
                routeRequest.PreviewPageData = new PreviewPageUrlArgs(routeRequest.Channel.SystemId);
            }
            routeRequest.PreviewPageData.SkipRenderingValidation = true;

            return new StationListViewModel()
            {
                Blocks = new Dictionary<string, List<BlockModel>>()
                {
                    {
                        BlockContainerNameConstant.Main,
                        new List<BlockModel>()
                        {
                            blockId.MapTo<BlockModel>()
                        }
                    },
                }
            };
        }
    }
}