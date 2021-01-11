using Litium.Accelerator.Builders;
using Litium.Web.Models;

namespace Litium.Accelerator.ViewModels.AdminPortalLayout
{
    public class AdminPortalLayoutViewModel : IViewModel
    {
        public string Title { get; set; }
        public EditorString Text { get; set; }
    }
}