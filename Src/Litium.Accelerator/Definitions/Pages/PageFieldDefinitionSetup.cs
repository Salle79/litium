using Litium.Accelerator.Constants;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Websites;
using System.Collections.Generic;

namespace Litium.Accelerator.Definitions.Pages
{
    internal class PageFieldDefinitionSetup : FieldDefinitionSetup
    {
        public override IEnumerable<FieldDefinition> GetFieldDefinitions()
        {
            var fields = new List<FieldDefinition>();

            fields.AddRange(GeneralFields());
            fields.AddRange(LoginPageFields());
            fields.AddRange(MegaMenuPageFields());
            fields.AddRange(StationPageFields());
            fields.AddRange(StationListPageFields());

            return fields;
        }

        private IEnumerable<FieldDefinition> GeneralFields()
        {
            var fields = new List<FieldDefinition>
            {
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Title, SystemFieldTypeConstants.Text)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Introduction, SystemFieldTypeConstants.MultirowText)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Text, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Links, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage, MultiSelect = true }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Image, SystemFieldTypeConstants.MediaPointerImage),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.Files, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.MediaFile, MultiSelect = true }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.PageSize, SystemFieldTypeConstants.Int),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.TitleFilterSelector, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.ErrorMessage, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.NumberOfNewsPerPage, SystemFieldTypeConstants.Int),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.NewsDate, SystemFieldTypeConstants.DateTime),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.CategoryPointer, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.ProductsCategory, MultiSelect = false }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.AlternativeImageDescription, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(WelcomeEmailPageFieldNameConstants.Subject, SystemFieldTypeConstants.Text)
                { 
                    MultiCulture = true
                },
                new FieldDefinition<WebsiteArea>(WelcomeEmailPageFieldNameConstants.WelcomeEmailText, SystemFieldTypeConstants.Editor)
                { 
                    MultiCulture = true
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.NumberOfOrdersPerPage, SystemFieldTypeConstants.Int),
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.OrderLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage, MultiSelect = false }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.OrderHistoryLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage, MultiSelect = false }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.ProductListPointer, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.ProductsProductList, MultiSelect = false }
                },
                new FieldDefinition<WebsiteArea>(PageFieldNameConstants.MayUserEditLogin, SystemFieldTypeConstants.Boolean)
            };
            return fields;
        }

        private IEnumerable<FieldDefinition> LoginPageFields()
        {
            var fields = new List<FieldDefinition>
            {
                new FieldDefinition<WebsiteArea>(LoginPageFieldNameConstants.ForgottenPasswordLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage }
                },
                new FieldDefinition<WebsiteArea>(LoginPageFieldNameConstants.RedirectLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage, MultiSelect = false }
                }
            };
            return fields;
        }

        private IEnumerable<FieldDefinition> MegaMenuPageFields()
        {
            var fields = new List<FieldDefinition<WebsiteArea>>
            {
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuCategory, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.ProductsCategory }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuPage, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuShowContent, SystemFieldTypeConstants.Boolean),
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuShowSubCategories, SystemFieldTypeConstants.Boolean),
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuColumnHeader, SystemFieldTypeConstants.LimitedText)
                { 
                    MultiCulture = true
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuCategories, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.ProductsCategory, MultiSelect = true }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuPages, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage, MultiSelect = true }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuFilters, FieldTypeConstants.Filters),
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuEditor, SystemFieldTypeConstants.Editor),
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuAdditionalLink, SystemFieldTypeConstants.LimitedText),
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuLinkToCategory, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.ProductsCategory }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuLinkToPage, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption { EntityType = PointerTypeConstants.WebsitesPage }
                },
                new FieldDefinition<WebsiteArea>(MegaMenuPageFieldNameConstants.MegaMenuColumn, SystemFieldTypeConstants.MultiField)
                {
                     Option = new MultiFieldOption { IsArray = true, Fields = new List<string>(){ MegaMenuPageFieldNameConstants.MegaMenuColumnHeader,
                        MegaMenuPageFieldNameConstants.MegaMenuCategories, MegaMenuPageFieldNameConstants.MegaMenuPages, MegaMenuPageFieldNameConstants.MegaMenuFilters, MegaMenuPageFieldNameConstants.MegaMenuEditor,
                        MegaMenuPageFieldNameConstants.MegaMenuAdditionalLink, MegaMenuPageFieldNameConstants.MegaMenuLinkToCategory, MegaMenuPageFieldNameConstants.MegaMenuLinkToPage} }
                },
            };

            return fields;
        }
        private IEnumerable<FieldDefinition> StationPageFields()
        {
            var fields = new List<FieldDefinition>
            {
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.StationId, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.HasExternalStorageSupplier, SystemFieldTypeConstants.Boolean)
                {
                    MultiCulture = false,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.DeliveryName1, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.DeliveryName2, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.AddressStreetAddress, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.AddressZipcode, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.AddressCity, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.CitiesNearby, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.LocationDescription, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.CoordinatesLat, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.CoordinatesLong, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.LocalManagerName, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.Email, SystemFieldTypeConstants.Text),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.Phone, SystemFieldTypeConstants.Text)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.OpeningHours, SystemFieldTypeConstants.MultirowText)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.DeviantOpeningHours, SystemFieldTypeConstants.MultirowText)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.InformationTextOnLeft, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.InformationTextOnRight, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServiceText, SystemFieldTypeConstants.MultirowText)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.Services, SystemFieldTypeConstants.MultiField)
                {
                    Option = new MultiFieldOption
                    {
                        IsArray = true,
                        Fields = new List<string>()
                        {
                            StationPageFieldNameConstants.ServiceName,
                            StationPageFieldNameConstants.ServiceVariant,
                            StationPageFieldNameConstants.ServicePrice,
                            StationPageFieldNameConstants.ServicePerUnitText,
                            StationPageFieldNameConstants.ServiceIcon,
                        }
                    },
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServiceName, SystemFieldTypeConstants.TextOption)
                {
                    MultiCulture = true,
                    Option = new TextOption
                    {
                        MultiSelect = false,
                        Items = new List<TextOption.Item>
                        {
                            new TextOption.Item
                            {
                                Value = "tireChange",
                                Name = new Dictionary<string, string> { { "en-US", "Tire Change" }, { "sv-SE", "Däckskifte" } }
                            },
                            new TextOption.Item
                            {
                                Value = "tireBalancing",
                                Name = new Dictionary<string, string> { { "en-US", "Tire Balancing" }, { "sv-SE", "Balansering" } }
                            },
                            new TextOption.Item
                            {
                                Value = "tireMounting",
                                Name = new Dictionary<string, string> { { "en-US", "Tire Mounting" }, { "sv-SE", "Omläggning" } }
                            },
                            new TextOption.Item
                            {
                                Value = "tireStorage",
                                Name = new Dictionary<string, string> { { "en-US", "Tire Storage" }, { "sv-SE", "Däckförvaring" } }
                            },
                            new TextOption.Item
                            {
                                Value = "repair",
                                Name = new Dictionary<string, string> { { "en-US", "Repair" }, { "sv-SE", "Lagning" } }
                            },
                            new TextOption.Item
                            {
                                Value = "tpmsProgramming",
                                Name = new Dictionary<string, string> { { "en-US", "TPMS Programming / Valve Replacement" }, { "sv-SE", "TPMS-programmering / Ventilbyte" } }
                            }
                        }
                    }
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServiceVariant, SystemFieldTypeConstants.TextOption)
                {
                    MultiCulture = true,
                    Option = new TextOption
                    {
                        MultiSelect = false,
                        Items = new List<TextOption.Item>
                        {
                            new TextOption.Item
                            {
                                Value = "privateCar-trailer",
                                Name = new Dictionary<string, string> { { "en-US", "Private Car / Trailer" }, { "sv-SE", "Personbil / Släp" } }
                            },
                            new TextOption.Item
                            {
                                Value = "suv-truck",
                                Name = new Dictionary<string, string> { { "en-US", "SUV / Light Truck" }, { "sv-SE", "SUV / Lätt lastbil" } }
                            },
                            new TextOption.Item
                            {
                                Value = "manualJack",
                                Name = new Dictionary<string, string> { { "en-US", "Manual Jack" }, { "sv-SE", "Manuell domkraft" } }
                            },
                            new TextOption.Item
                            {
                                Value = "13-16",
                                Name = new Dictionary<string, string> { { "en-US", "13-16\"" }, { "sv-SE", "13-16\"" } }
                            },
                            new TextOption.Item
                            {
                                Value = "17-18",
                                Name = new Dictionary<string, string> { { "en-US", "17-18\"" }, { "sv-SE", "17-18\"" } }
                            },
                            new TextOption.Item
                            {
                                Value = "19-22",
                                Name = new Dictionary<string, string> { { "en-US", "19-22\"" }, { "sv-SE", "19-22\"" } }
                            },
                            new TextOption.Item
                            {
                                Value = "privateCar",
                                Name = new Dictionary<string, string> { { "en-US", "Private Car" }, { "sv-SE", "Personbil" } }
                            },
                            new TextOption.Item
                            {
                                Value = "suv",
                                Name = new Dictionary<string, string> { { "en-US", "SUV" }, { "sv-SE", "SUV" } }
                            },
                            new TextOption.Item
                            {
                                Value = "inside",
                                Name = new Dictionary<string, string> { { "en-US", "Inside" }, { "sv-SE", "Invändig" } }
                            },
                            new TextOption.Item
                            {
                                Value = "outside-valveReplacement",
                                Name = new Dictionary<string, string> { { "en-US", "Outside / Valve Replacement" }, { "sv-SE", "Utvändig / Ventilbyte" } }
                            },
                            new TextOption.Item
                            {
                                Value = "rimSealing-sanding",
                                Name = new Dictionary<string, string> { { "en-US", "Rim Sealing / Sandning" }, { "sv-SE", "Fälgtätning / Slipning" } }
                            }
                        }
                    }
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServicePrice, SystemFieldTypeConstants.Decimal)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServicePerUnitText, SystemFieldTypeConstants.Text)
                {
                    MultiCulture = true
                },
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.SummerSeasonStartDate, SystemFieldTypeConstants.Date),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.SummerSeasonEndDate, SystemFieldTypeConstants.Date),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.WinterSeasonStartDate, SystemFieldTypeConstants.Date),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.WinterSeasonEndDate, SystemFieldTypeConstants.Date),
                new FieldDefinition<WebsiteArea>(StationPageFieldNameConstants.ServiceIcon, SystemFieldTypeConstants.MediaPointerImage),
            };

            return fields;
        }
        private IEnumerable<FieldDefinition> StationListPageFields()
        {
            var fields = new List<FieldDefinition>
            {
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.StationFallbackImage, SystemFieldTypeConstants.MediaPointerImage),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.BoxIcon, SystemFieldTypeConstants.MediaPointerImage),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.PageImageText, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.PageImageTextColor, SystemFieldTypeConstants.LimitedText),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.MapPinColor, SystemFieldTypeConstants.LimitedText),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.MapInfoWindowLinkColor, SystemFieldTypeConstants.LimitedText),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.PopUpBackgroundImage, SystemFieldTypeConstants.MediaPointerImage),
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.PopUpInformationText, SystemFieldTypeConstants.Editor)
                {
                    MultiCulture = true,
                },
                new FieldDefinition<WebsiteArea>(StationListPageFieldNameConstants.PopUpCookieExpiryTime, SystemFieldTypeConstants.Decimal),
            };

            return fields;
        }
    }
}
