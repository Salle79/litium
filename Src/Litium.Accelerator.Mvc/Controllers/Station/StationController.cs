using Litium.Accelerator.Builders.Station;
using Litium.Security;
using Litium.Web.Models.Websites;
using System;
using System.Web.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.Station
{
    public class StationController : ControllerBase
    {
        private readonly StationViewModelBuilder _stationViewModelBuilder;
        private readonly StationListViewModelBuilder _stationListViewModelBuilder;
        private readonly AuthorizationService _authorizationService;

        public StationController(StationViewModelBuilder stationViewModelBuilder, StationListViewModelBuilder stationListViewModelBuilder, AuthorizationService authorizationService)
        {
            _stationViewModelBuilder = stationViewModelBuilder;
            _stationListViewModelBuilder = stationListViewModelBuilder;
            _authorizationService = authorizationService;
        }

        [HttpGet]
        public ActionResult Station(PageModel pageModel)
        {
            var model = _stationViewModelBuilder.Build(pageModel);
            return View(model);
        }

        [HttpGet]
        public ActionResult StationList(PageModel pageModel)
        {
            var previewBlockId = Request.QueryString["previewGlobalBlock"];
            if (!string.IsNullOrEmpty(previewBlockId) && Guid.TryParse(previewBlockId, out var blockId) && _authorizationService.HasOperation(Operations.Function.Websites.UI))
            {
                return View("Index", _stationListViewModelBuilder.ForPreviewGlobalBlock(blockId));
            }
            var model = _stationListViewModelBuilder.Build(pageModel);
            return View(model);
        }
    }
}