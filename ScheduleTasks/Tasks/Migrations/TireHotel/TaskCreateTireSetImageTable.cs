using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireSetImageTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_TireSet_Image')
                                        BEGIN
                                            CREATE TABLE [dbo].[TiresHotel_TireSet_Image](
	                                        [Id] [uniqueidentifier] NOT NULL,
	                                        [TireSetId] [uniqueidentifier] NOT NULL,
	                                        [Image] [varbinary](max) NULL,
	                                        [ImageTitle] [varchar](50) NULL,
                                             CONSTRAINT [PK_TiresHotel_TireSet_Image] PRIMARY KEY CLUSTERED 
                                            (
	                                            [Id] ASC
                                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

                                            ALTER TABLE [dbo].[TiresHotel_TireSet_Image]  WITH CHECK ADD  CONSTRAINT [FK_TiresHotel_TireSet_Image_TiresHotel_TireSet] FOREIGN KEY([TireSetId])
                                            REFERENCES [dbo].[TiresHotel_TireSet] ([Id])
                                            ON UPDATE CASCADE
                                            ON DELETE CASCADE

                                            ALTER TABLE [dbo].[TiresHotel_TireSet_Image] CHECK CONSTRAINT [FK_TiresHotel_TireSet_Image_TiresHotel_TireSet]
                                        END";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
