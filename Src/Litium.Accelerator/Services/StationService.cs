using Litium.Accelerator.ViewModels.Station;
using Litium.Runtime.DependencyInjection;
using Litium.Websites;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Litium.Accelerator.Services
{
    [Service(ServiceType = typeof(StationService))]
    [RequireServiceImplementation]
    public abstract class StationService
    {
        public abstract IEnumerable<Page> GetAllStationPages(bool includeDraftPages = false);
        public abstract IEnumerable<SelectListItem> GetStationsByPermissionGroups(IEnumerable<string> groupIds);
        public abstract IEnumerable<string> GetStationIdsByPermissionGroups(IEnumerable<string> groupIds);
        public abstract Page GetStationPage(string stationId);
        public abstract IEnumerable<StationServiceViewModel> GetStationServices(string stationId);
        public abstract Guid? GetStationDeliveryMethodId();
    }
}