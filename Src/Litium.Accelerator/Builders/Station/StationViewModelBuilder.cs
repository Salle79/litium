using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Litium.Web.Models.Websites;
using Litium.Accelerator.Constants;
using Litium.Accelerator.Extensions;
using Litium.Accelerator.ViewModels.Station;
using Litium.FieldFramework;
using Litium.Runtime.AutoMapper;
using Litium.Web;
using Litium.Web.Models;
using Litium.Websites;
using static Litium.Accelerator.ViewModels.Station.StationViewModel;

namespace Litium.Accelerator.Builders.Station
{
    public class StationViewModelBuilder : IViewModelBuilder<StationViewModel>
    {
        /// <summary>
        /// Build the article model
        /// </summary>
        /// <param name="pageModel">The current article page</param>
        /// <returns>Return the article model</returns>
        ///
        private readonly FieldDefinitionService _fieldDefinitionService;
        private readonly PageService _pageService;
        private readonly UrlService _urlService;

        public StationViewModelBuilder(FieldDefinitionService fieldDefinitionService, PageService pageService, UrlService urlService)
        {
            _fieldDefinitionService = fieldDefinitionService;
            _pageService = pageService;
            _urlService = urlService;
        }

        public virtual StationViewModel Build(PageModel pageModel)
        {

            var model = pageModel.MapTo<StationViewModel>();
            model.SummerSeasonStartDate = pageModel.Fields.GetValue<DateTime>(StationPageFieldNameConstants.SummerSeasonStartDate).Date;
            model.SummerSeasonEndDate = pageModel.Fields.GetValue<DateTime>(StationPageFieldNameConstants.SummerSeasonEndDate).Date;
            model.WinterSeasonStartDate = pageModel.Fields.GetValue<DateTime>(StationPageFieldNameConstants.WinterSeasonStartDate).Date;
            model.WinterSeasonEndDate = pageModel.Fields.GetValue<DateTime>(StationPageFieldNameConstants.WinterSeasonEndDate).Date;

            model.Services = BuildServices(pageModel.Fields.GetValue<IList<MultiFieldItem>>(StationPageFieldNameConstants.Services));

            var fallbackImage = _pageService.Get(pageModel.Page.ParentPageSystemId)?.Fields.GetValue<Guid>(StationListPageFieldNameConstants.StationFallbackImage);
            if (fallbackImage != null)
            {
                model.FallbackImage = fallbackImage.MapTo<ImageModel>();
            }

            model.MapPinColor = _pageService.Get(pageModel.Page.ParentPageSystemId)?.Fields.GetValue<string>(StationListPageFieldNameConstants.MapPinColor);
            model.Url = _urlService.GetUrl(pageModel.Page);

            return model;
        }

        private List<ServiceGroupViewModel> BuildServices(IList<MultiFieldItem> multiFieldItems)
        {
            var services = new List<ServiceGroupViewModel>();

            if (multiFieldItems != null)
            {
                foreach (var item in multiFieldItems)
                {
                    var groupName = _fieldDefinitionService.Get<WebsiteArea>(StationPageFieldNameConstants.ServiceName)?.GetTranslation(item.Fields.GetValue<string>(StationPageFieldNameConstants.ServiceName, CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    var variant = _fieldDefinitionService.Get<WebsiteArea>(StationPageFieldNameConstants.ServiceVariant)?.GetTranslation(item.Fields.GetValue<string>(StationPageFieldNameConstants.ServiceVariant, CultureInfo.CurrentCulture), CultureInfo.CurrentCulture);
                    var price = item.Fields.GetValue<decimal>(StationPageFieldNameConstants.ServicePrice, CultureInfo.CurrentCulture);
                    var perUnitText = item.Fields.GetValue<string>(StationPageFieldNameConstants.ServicePerUnitText, CultureInfo.CurrentCulture);
                    var groupIcon = item.Fields.GetValue<Guid>(StationPageFieldNameConstants.ServiceIcon).MapTo<ImageModel>();

                    var group = services.FirstOrDefault(s => s.Name == groupName);

                    if (group != null)
                    {
                        group.Variants.Add(new ServiceVariantViewModel
                        {
                            VariantName = variant,
                            Price = price,
                            PerUnitText = perUnitText,
                        });
                    }
                    else
                    {
                        services.Add(new ServiceGroupViewModel
                        {
                            Name = groupName,
                            Icon = groupIcon,
                            Variants = new List<ServiceVariantViewModel>
                            {
                                new ServiceVariantViewModel
                                {
                                    VariantName = variant,
                                    Price = price,
                                    PerUnitText = perUnitText,
                                }
                            }
                        });
                    }
                }

                foreach (var group in services)
                {
                    group.Variants = group.Variants.OrderBy(v => v.Price).ToList();
                }
            }

            return services;
        }
    }
}