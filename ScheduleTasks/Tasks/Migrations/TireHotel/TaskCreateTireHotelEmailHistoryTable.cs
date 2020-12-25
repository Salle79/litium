using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireHotelEmailHistoryTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_EmailHistory')
                                        BEGIN
                                            CREATE TABLE [dbo].[TiresHotel_EmailHistory](
	                                            [Id] [uniqueidentifier] NOT NULL,
	                                            [PersonSystemId] [uniqueidentifier] NOT NULL,
	                                            [TireSetId] [uniqueidentifier] NOT NULL,
	                                            [EmailContent] [nvarchar](max) NOT NULL,
	                                            [RegistrationNumber] [nvarchar](max) NULL,
	                                            [TireType] [nvarchar](max) NULL,
	                                            [SentDate] [datetime] NOT NULL,
                                             CONSTRAINT [PK_TiresHotel_EmailHistory] PRIMARY KEY CLUSTERED 
                                            (
	                                            [Id] ASC
                                            )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                            ) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

                                            ALTER TABLE [dbo].[TiresHotel_EmailHistory]  WITH CHECK ADD  CONSTRAINT [FK_TiresHotel_EmailHistory_Person] FOREIGN KEY([PersonsystemId])
                                            REFERENCES [Customers].[Person] ([SystemId])
                                            ON UPDATE CASCADE
                                            ON DELETE CASCADE

                                            ALTER TABLE [dbo].[TiresHotel_EmailHistory] CHECK CONSTRAINT [FK_TiresHotel_EmailHistory_Person]
                                        END";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
