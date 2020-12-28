using Litium.Accelerator.Constants;
using Litium.Accelerator.Routing;
using Litium.Accelerator.Search;
using Litium.Accelerator.ViewModels.Station;
using Litium.Common;
using Litium.FieldFramework;
using Litium.Foundation.Modules.CMS.Search;
using Litium.Foundation.Modules.ECommerce;
using Litium.Foundation.Search;
using Litium.Foundation.Security;
using Litium.Framework.Search;
using Litium.Products;
using Litium.Web;
using Litium.Web.Models.Products;
using Litium.Websites;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel;
using System.Linq;
using System.Web.Mvc;
using Litium.Auditing;
using Litium.Blobs;
using Litium.Blocks;
using Litium.Customers;
using Litium.Data;
using Litium.GDPR;
using Litium.Media;
using Litium.Sales;

namespace Litium.Accelerator.Services
{
    internal class StationServiceImpl : StationService
    {
        private readonly RequestModelAccessor _requestModelAccessor;
        private readonly PageService _pageService;
        private readonly UrlService _urlService;
        private readonly SearchQueryBuilderFactory _searchQueryBuilderFactory;
        private readonly SearchService _searchService;
        private readonly VariantService _variantService;
        private readonly BaseProductService _baseProductService;
        private readonly FieldTemplateService _fieldTemplateService;
        private readonly ProductPriceModelBuilder _productPriceModelBuilder;
        private readonly CartService _cartService;
        private readonly ModuleECommerce _moduleECommerce;

        public StationServiceImpl(RequestModelAccessor requestModelAccessor,
            PageService pageService,
            UrlService urlService,
            SearchQueryBuilderFactory searchQueryBuilderFactory,
            SearchService searchService,
            VariantService variantService,
            BaseProductService baseProductService,
            FieldTemplateService fieldTemplateService,
            ProductPriceModelBuilder productPriceModelBuilder,
            CartService cartService,
            ModuleECommerce moduleECommerce)
        {
            _requestModelAccessor = requestModelAccessor;
            _pageService = pageService;
            _urlService = urlService;
            _searchQueryBuilderFactory = searchQueryBuilderFactory;
            _searchService = searchService;
            _variantService = variantService;
            _baseProductService = baseProductService;
            _fieldTemplateService = fieldTemplateService;
            _productPriceModelBuilder = productPriceModelBuilder;
            _cartService = cartService;
            _moduleECommerce = moduleECommerce;
        }

        public override IEnumerable<Page> GetAllStationPages(bool includeDraftPages = false)
        {
                
            var searchQuery = _requestModelAccessor.RequestModel?.SearchQuery?.Clone() ?? new SearchQuery();
            searchQuery.PageSize = 999;
            searchQuery.PageNumber = 1;
            var searchQueryBuilder = _searchQueryBuilderFactory.Create(CultureInfo.CurrentUICulture, CmsSearchDomains.Pages, searchQuery);
            var request = searchQueryBuilder.Build();
            if (includeDraftPages)
            {
                request.ExcludeTags.Add(new Tag(TagNames.Status, (int)ContentStatus.InTrashCan)); //if true, exclude pages in Trashcan so that we will get Published & NotPublished(draft) pages.
            }
            else
            {
                request.FilterTags.Add(new Tag(TagNames.Status, (int)ContentStatus.Published)); //if false, only select pages that are published.
            }
            request.FilterTags.Add(new Tag(TagNames.TemplateId, PageTemplateNameConstants.Station));

            var result = _searchService.Search(request);
             var findings = _pageService.Get(result.Hits.Select(x => new Guid(x.Id)))
                 ?.OrderBy(x => x.Localizations.CurrentCulture.Name);
             return findings;
        }

        public override Guid? GetStationDeliveryMethodId()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<string> GetStationIdsByPermissionGroups(IEnumerable<string> groupIds)
        {
            throw new NotImplementedException();
        }

        public override Page GetStationPage(string stationId)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<SelectListItem> GetStationsByPermissionGroups(IEnumerable<string> groupIds)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<StationServiceViewModel> GetStationServices(string stationId)
        {
            throw new NotImplementedException();
        }
    }
}