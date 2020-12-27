using Litium.Accelerator.Builders.Station;
using Litium.Web.Models.Websites;
using System.Web.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.Station
{
    public class StationController : ControllerBase
    {
        private readonly StationViewModelBuilder _stationViewModelBuilder;

        public StationController(StationViewModelBuilder stationViewModelBuilder)
        {
            _stationViewModelBuilder = stationViewModelBuilder;
        }

        [HttpGet]
        public ActionResult Index(PageModel currentPageModel)
        {
            var model = _stationViewModelBuilder.Build(currentPageModel);
            return View(model);
        }
    }
}