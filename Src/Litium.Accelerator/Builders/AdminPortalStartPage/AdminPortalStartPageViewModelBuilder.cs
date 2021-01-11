using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Litium.Web.Models.Websites;
using Litium.Accelerator.Constants;
using Litium.Accelerator.ViewModels.AdminPortalStartPage;
using Litium.FieldFramework.FieldTypes;
using Litium.Runtime.AutoMapper;
using Litium.Web.Models;

namespace Litium.Accelerator.Builders.AdminPortalStartPage
{
    public class AdminPortalStartPageViewModelBuilder : IViewModelBuilder<AdminPortalStartPageViewModel>
    {
        /// <summary>
        /// Build the article model
        /// </summary>
        /// <param name="pageModel">The current article page</param>
        /// <returns>Return the article model</returns>
        public virtual AdminPortalStartPageViewModel Build(PageModel pageModel)
        {
            var model = new AdminPortalStartPageViewModel
            {
                LinkList = pageModel.Fields.GetValue<IList<PointerItem>>(AdminPortalPagesFieldNameConstants.AdminPortalLinkList)?.OfType<PointerPageItem>().ToList().Select(x => x.MapTo<LinkModel>()).Where(x => x != null && x.AccessibleByUser).ToList() ?? new List<LinkModel>(),
            };

            return model;
        }
    }
}