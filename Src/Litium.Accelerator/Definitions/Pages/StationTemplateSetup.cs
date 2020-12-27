using Litium.Accelerator.Constants;
using Litium.FieldFramework;
using Litium.Websites;
using System.Collections.Generic;

namespace Litium.Accelerator.Definitions.Pages
{
    internal class StationPageTemplateSetup : FieldTemplateSetup
    {
        public override IEnumerable<FieldTemplate> GetTemplates()
        {
            var templates = new List<FieldTemplate>
            {
                new PageFieldTemplate(PageTemplateNameConstants.Station)
                {
                    TemplatePath = "",
                    FieldGroups = new []
                    {
                        new FieldTemplateFieldGroup()
                        {
                            Id = "General",
                            Collapsed = false,
                            Fields =
                            {
                                SystemFieldDefinitionConstants.Url,
                                SystemFieldDefinitionConstants.Name,
                                StationPageFieldNameConstants.StationId,
                                StationPageFieldNameConstants.HasExternalStorageSupplier,
                                PageFieldNameConstants.InternalSearchTerms,
                            }
                        },
                        new FieldTemplateFieldGroup()
                        {
                            Id = "Contents",
                            Collapsed = false,
                            Fields =
                            {
                                PageFieldNameConstants.Text,
                                PageFieldNameConstants.Image
                            }
                        },
                        new FieldTemplateFieldGroup()
                        {
                            Id = "Location",
                            Collapsed = false,
                            Fields =
                            {
                                StationPageFieldNameConstants.DeliveryName1,
                                StationPageFieldNameConstants.DeliveryName2,
                                StationPageFieldNameConstants.AddressStreetAddress,
                                StationPageFieldNameConstants.AddressZipcode,
                                StationPageFieldNameConstants.AddressCity,
                                StationPageFieldNameConstants.CitiesNearby,
                                StationPageFieldNameConstants.LocationDescription,
                                StationPageFieldNameConstants.CoordinatesLat,
                                StationPageFieldNameConstants.CoordinatesLong,
                            }
                        },
                        new FieldTemplateFieldGroup()
                        {
                            Id = "Information",
                            Collapsed = false,
                            Fields =
                            {
                                StationPageFieldNameConstants.LocalManagerName,
                                StationPageFieldNameConstants.Phone,
                                StationPageFieldNameConstants.Email,
                                StationPageFieldNameConstants.OpeningHours,
                                StationPageFieldNameConstants.DeviantOpeningHours,
                                StationPageFieldNameConstants.SummerSeasonStartDate,
                                StationPageFieldNameConstants.SummerSeasonEndDate,
                                StationPageFieldNameConstants.WinterSeasonStartDate,
                                StationPageFieldNameConstants.WinterSeasonEndDate,
                                StationPageFieldNameConstants.InformationTextOnRight,
                                StationPageFieldNameConstants.InformationTextOnLeft,
                                StationPageFieldNameConstants.ServiceText,
                                StationPageFieldNameConstants.Services
                            }
                        },

                    },
                    Containers = new List<BlockContainerDefinition>
                    {
                        new BlockContainerDefinition()
                        {
                            Id = BlockContainerNameConstant.Header,
                            Name =
                            {
                                ["sv-SE"] = "Huvud",
                                ["en-US"] = "Header",
                            }
                        }
                    }
                },
            };
            return templates;
        }
    }
}