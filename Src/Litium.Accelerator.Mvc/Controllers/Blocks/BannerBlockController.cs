using System;
using System.Web.Mvc;
using Litium.Accelerator.Builders.Block;
using Litium.Web.Models.Blocks;
using Litium.Websites;

namespace Litium.Accelerator.Mvc.Controllers.Blocks
{
    public class BannerBlockController : ControllerBase
    {
        private readonly BannersBlockViewModelBuilder _builder;

        public BannerBlockController(BannersBlockViewModelBuilder builder)
        {
            _builder = builder;
        }

        [HttpGet]
        public ActionResult Index(BlockModel currentBlockModel)
        {
            if (currentBlockModel.Block.Global == false)
            {
                Console.Write(true);
                
            }

            else
            {
                Console.Write(false);
                var pageService = $"null {currentBlockModel.ToString()}";
                 Console.WriteLine(pageService);
            }
            var model = _builder.Build(currentBlockModel);
            return PartialView("~/Views/Block/Banners.cshtml", model);
        }
    }
}