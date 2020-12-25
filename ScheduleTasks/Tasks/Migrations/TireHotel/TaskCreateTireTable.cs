using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_Tire')
                                     BEGIN
                                        CREATE TABLE [dbo].[TiresHotel_Tire](
	                                        [Id] [uniqueidentifier] NOT NULL,
	                                        [TireSetId] [uniqueidentifier] NOT NULL,
	                                        [Position] [nvarchar](50) NULL,
	                                        [GrooveDepth] [decimal](16, 2) NULL,
	                                        [TireBrand] [nvarchar](max) NULL,
                                            [TireModel] [nvarchar](max) NULL,
	                                        [Diameter] [nvarchar](50) NULL,
                                            [SpeedAndLoadIndex] [nvarchar](50) NULL,
	                                        [DotDate] [nvarchar](10) NULL,
                                            [CreatedDate] [datetime] default getdate(),
                                         CONSTRAINT [PK_TiresHotel_Tire] PRIMARY KEY CLUSTERED 
                                        (
	                                        [Id] ASC
                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                        
                                        ALTER TABLE [dbo].[TiresHotel_Tire]  WITH CHECK ADD  CONSTRAINT [FK_TiresHotel_Tire_TiresHotel_TireSet] FOREIGN KEY([TireSetId])
                                        REFERENCES [dbo].[TiresHotel_TireSet] ([Id])
                                        ON DELETE CASCADE
                                        
                                        ALTER TABLE [dbo].[TiresHotel_Tire] CHECK CONSTRAINT [FK_TiresHotel_Tire_TiresHotel_TireSet]
                                    END";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
