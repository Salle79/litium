using System.Collections.Generic;
using Litium.Accelerator.Constants;
using Litium.FieldFramework;
using Litium.FieldFramework.FieldTypes;
using Litium.Websites;

namespace Litium.Accelerator.Definitions.Pages
{
    public class AdminPortalFieldDefinitionSetup : FieldDefinitionSetup
    {
        public override IEnumerable<FieldDefinition> GetFieldDefinitions()
        {
            var fields = new List<FieldDefinition>
            {
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.AdminPortalLinkList, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption
                    {
                        EntityType = PointerTypeConstants.WebsitesPage,
                        MultiSelect = true,
                    },
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.CustomerPageLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption
                    {
                        EntityType = PointerTypeConstants.WebsitesPage,
                        MultiSelect = false,
                    },
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.TireHotelStartPageLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption
                    {
                        EntityType = PointerTypeConstants.WebsitesPage,
                        MultiSelect = false,
                    },
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.PrintStickerLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption
                    {
                        EntityType = PointerTypeConstants.WebsitesPage,
                        MultiSelect = false,
                    },
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.EmailLogEntityLink, SystemFieldTypeConstants.Pointer)
                {
                    Option = new PointerOption
                    {
                        EntityType = PointerTypeConstants.WebsitesPage,
                        MultiSelect = false,
                    },
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.TireTypes, SystemFieldTypeConstants.TextOption)
                {
                    Option = new TextOption
                    {
                        MultiSelect = true,
                        Items = new List<TextOption.Item>
                        {
                            new TextOption.Item
                            {
                                Value = "SummerTire",
                                Name = new Dictionary<string, string> { { "en-US", "Summer tire" }, { "sv-SE", "Sommardäck" } }
                            },
                            new TextOption.Item
                            {
                                Value = "Studded",
                                Name = new Dictionary<string, string> { { "en-US", "Studded" }, { "sv-SE", "Dubbdäck" } }
                            },
                            new TextOption.Item
                            {
                                Value = "Friction",
                                Name = new Dictionary<string, string> { { "en-US", "Friction" }, { "sv-SE", "Friktionsdäck" } }
                            },
                        }
                    }
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.Statuses, SystemFieldTypeConstants.TextOption)
                {
                    Editable = false,
                    Option = new TextOption
                    {
                        MultiSelect = true,
                        Items = new List<TextOption.Item>
                        {
                            new TextOption.Item
                            {
                                Value = "CheckedIn",
                                Name = new Dictionary<string, string> { { "en-US", "Checked in" }, { "sv-SE", "Däck inlämnade" } }
                            },
                            new TextOption.Item
                            {
                                Value = "CheckedOut",
                                Name = new Dictionary<string, string> { { "en-US", "Checked out" }, { "sv-SE", "Däck utlämnade" } }
                            },
                            new TextOption.Item
                            {
                                Value = "CheckOutBooked",
                                Name = new Dictionary<string, string> { { "en-US", "Check out booked" }, { "sv-SE", "Dag bokad för däckskifte" } }
                            },
                        }
                    }
                },
                new FieldDefinition<WebsiteArea>(AdminPortalPagesFieldNameConstants.RimMaterials, SystemFieldTypeConstants.TextOption)
                {
                    Option = new TextOption
                    {
                        MultiSelect = true,
                        Items = new List<TextOption.Item>
                        {
                            new TextOption.Item
                            {
                                Value = "Aluminium",
                                Name = new Dictionary<string, string> { { "en-US", "Aluminium" }, { "sv-SE", "Aluminium" } }
                            },
                            new TextOption.Item
                            {
                                Value = "Steel",
                                Name = new Dictionary<string, string> { { "en-US", "Steel" }, { "sv-SE", "Stål" } }
                            },
                        }
                    }
                },
            };

            return fields;
        }
    }
}