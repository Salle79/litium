using System.Collections.Generic;
using Litium.Accelerator.Constants;
using Litium.FieldFramework;
using Litium.Websites;

namespace Litium.Accelerator.Definitions.Pages
{
    internal class StationListPageTemplateSetup : FieldTemplateSetup
    {
        public override IEnumerable<FieldTemplate> GetTemplates()
        {
            var templates = new List<FieldTemplate>
            {
                new PageFieldTemplate(PageTemplateNameConstants.StationList)
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
                                SystemFieldDefinitionConstants.Name,
                                SystemFieldDefinitionConstants.Url,
                                PageFieldNameConstants.Title,
                                PageFieldNameConstants.Image,
                                StationListPageFieldNameConstants.PageImageText,
                                StationListPageFieldNameConstants.PageImageTextColor,
                                StationListPageFieldNameConstants.StationFallbackImage,
                                StationListPageFieldNameConstants.BoxIcon,
                                StationListPageFieldNameConstants.MapPinColor,
                                StationListPageFieldNameConstants.MapInfoWindowLinkColor,
                            }
                        },
                        new FieldTemplateFieldGroup()
                        {
                            Id = "Information pop-up",
                            Collapsed = false,
                            Fields =
                            {
                                StationListPageFieldNameConstants.PopUpBackgroundImage,
                                StationListPageFieldNameConstants.PopUpInformationText,
                                StationListPageFieldNameConstants.PopUpCookieExpiryTime,
                            },
                        }
                    },
                    Containers = new List<BlockContainerDefinition>
                    {
                        new BlockContainerDefinition()
                        {
                            Id = BlockContainerNameConstant.Main,
                            Name =
                            {
                                ["sv-SE"] = "Main",
                                ["en-US"] = "Main",
                            }
                        }
                    }
                },
            };
            return templates;
        }
    }
}