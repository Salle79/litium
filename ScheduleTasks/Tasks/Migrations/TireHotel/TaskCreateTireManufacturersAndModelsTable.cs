using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireManufacturersAndModelsTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_TireManufacturersAndModels')
                                     BEGIN
                                        CREATE TABLE [dbo].[TiresHotel_TireManufacturersAndModels](
	                                        [Id] [int] IDENTITY(1,1) NOT NULL,
	                                        [Manufacturer] [nvarchar](max) NOT NULL,
	                                        [Model] [nvarchar](max) NOT NULL, 
                                         CONSTRAINT [PK_TiresHotel_TireManufacturersAndModels] PRIMARY KEY CLUSTERED 
                                        (
	                                        [Id] ASC
                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                        ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
                                    End";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
