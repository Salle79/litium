using System.Collections.Generic;
using Litium.Accelerator.Builders;
using Litium.Web.Models;

namespace Litium.Accelerator.ViewModels.AdminPortalStartPage
{
    public class AdminPortalStartPageViewModel : IViewModel
    {
        // TODO -- this will probably be renamed since it is a bit unclear how StartPage will be used.
        public IList<LinkModel> LinkList { get; set; }
    }
}