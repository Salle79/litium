using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireSetTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText =
                @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_TireSet')
                                     BEGIN
                                        CREATE TABLE [dbo].[TiresHotel_TireSet](
	                                        [Id] [uniqueidentifier] NOT NULL,
	                                        [PersonSystemId] [uniqueidentifier] NOT NULL,
	                                        [StationId] [nvarchar](50) NOT NULL,
	                                        [ContractSigned] [bit] NOT NULL,
	                                        [StorageLocation] [nvarchar](max) NULL,
	                                        [RegistrationNumber] [nvarchar](50) NULL,
	                                        [TiresType] [nvarchar](50) NULL,
	                                        [RimBrand] [nvarchar](max) NULL,
	                                        [RimMaterial] [nvarchar](max) NULL,
	                                        [Status] [nvarchar](max) NULL,
	                                        [Date] [nvarchar](10) NULL,
                                            [NeedsNewTires] [bit] NOT NULL,
	                                        [TextForInternalUse] [nvarchar](max) NULL,
	                                        [TextForExternalUse] [nvarchar](max) NULL,
                                            [CreatedDate] [datetime] default getdate(),
                                         CONSTRAINT [PK_TiresHotel_TireSet] PRIMARY KEY CLUSTERED 
                                        (
	                                        [Id] ASC
                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                        
                                        ALTER TABLE [dbo].[TiresHotel_TireSet] ADD  CONSTRAINT [D_TiresHotel_TireSet_StationId]  DEFAULT (('')) FOR [StationId]

                                        ALTER TABLE [dbo].[TiresHotel_TireSet] ADD  CONSTRAINT [D_TiresHotel_TireSet_ContractSigned]  DEFAULT ((0)) FOR [ContractSigned]

                                        ALTER TABLE [dbo].[TiresHotel_TireSet] ADD  CONSTRAINT [D_TiresHotel_TireSet_NeedsNewTires]  DEFAULT ((0)) FOR [NeedsNewTires]
                                    
                                        ALTER TABLE [dbo].[TiresHotel_TireSet]  WITH CHECK ADD  CONSTRAINT [FK_TiresHotel_TireSet_Person] FOREIGN KEY([PersonSystemId])
                                        REFERENCES [Customers].[Person] ([SystemId])
                                        ON DELETE CASCADE
                                    
                                        ALTER TABLE [dbo].[TiresHotel_TireSet] CHECK CONSTRAINT [FK_TiresHotel_TireSet_Person]
                                    END";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
