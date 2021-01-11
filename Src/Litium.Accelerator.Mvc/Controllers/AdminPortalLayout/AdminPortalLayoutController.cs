using Litium.Accelerator.Builders.AdminPortalLayout;
using Litium.Web.Models.Websites;
using System.Web.Mvc;

namespace Litium.Accelerator.Mvc.Controllers.AdminPortalLayout
{
    public class AdminPortalLayoutController : ControllerBase
    {
        private readonly AdminPortalLayoutViewModelBuilder _adminPortalLayoutViewModelBuilder;

        public AdminPortalLayoutController(AdminPortalLayoutViewModelBuilder adminPortalLayoutViewModelBuilder)
        {
            _adminPortalLayoutViewModelBuilder = adminPortalLayoutViewModelBuilder;
        }

        [HttpGet]
        public ActionResult Index(PageModel currentPageModel)
        {
            var model = _adminPortalLayoutViewModelBuilder.Build(currentPageModel);
            return View(model);
        }
    }
}