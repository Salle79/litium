using System.Collections.Generic;
using Litium.Accelerator.Builders;
using Litium.Web.Models;

namespace Litium.Accelerator.ViewModels.Station
{
    public class StationServiceViewModel : IViewModel
    {
        public string BaseProductArticleNumber { get; set; }
        public bool DimensionDependent { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string FormattedTotalPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal Quantity { get; set; }
        public List<KeyValuePair<string, decimal>> Variants { get; set; }
        public bool IsMandatoryService { get; set; }
    }
}