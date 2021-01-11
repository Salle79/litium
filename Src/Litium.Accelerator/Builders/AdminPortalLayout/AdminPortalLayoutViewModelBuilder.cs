using System.Globalization;
using Litium.Web.Models.Websites;
using Litium.Accelerator.Constants;
using Litium.Accelerator.ViewModels.AdminPortalLayout;

namespace Litium.Accelerator.Builders.AdminPortalLayout
{
    public class AdminPortalLayoutViewModelBuilder : IViewModelBuilder<AdminPortalLayoutViewModel>
    {
        /// <summary>
        /// Build the article model
        /// </summary>
        /// <param name="pageModel">The current article page</param>
        /// <returns>Return the article model</returns>
        public virtual AdminPortalLayoutViewModel Build(PageModel pageModel)
        {
            return new AdminPortalLayoutViewModel
            {
                Title = pageModel.Page.Fields.GetValue< string>(PageFieldNameConstants.Title, CultureInfo.CurrentUICulture),
                Text = pageModel.Page.Fields.GetValue< string>(PageFieldNameConstants.Text, CultureInfo.CurrentUICulture)
            };
        }
    }
}