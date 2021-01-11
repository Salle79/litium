using Litium.Accelerator.Builders.AdminPortalStartPage;
using Litium.Web.Models.Websites;
using System.Web.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.AdminPortalStartPage
{
    public class AdminPortalStartPageController : ControllerBase
    {
        private readonly AdminPortalStartPageViewModelBuilder _adminPortalStartPageViewModelBuilder;

        public AdminPortalStartPageController(AdminPortalStartPageViewModelBuilder adminPortalStartPageViewModelBuilder)
        {
            _adminPortalStartPageViewModelBuilder = adminPortalStartPageViewModelBuilder;
        }

        [HttpGet]
        public ActionResult Index(PageModel currentPageModel)
        {
            var model = _adminPortalStartPageViewModelBuilder.Build(currentPageModel);
            return View("~/Views/AdminPortal/Index.cshtml", "~/Views/Shared/_AdminPortalLayout.cshtml", model);
        }
    }
}