using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class TaskCreateTireHotelBookingHistoryTable : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText = @"IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE='BASE TABLE' AND TABLE_NAME='TiresHotel_BookingHistory')
                                        BEGIN
                                            CREATE TABLE [dbo].[TiresHotel_BookingHistory](
                                            [Id][uniqueidentifier] NOT NULL,
                                            [StationId] [nvarchar] (50) NOT NULL,
                                            [CreateDate] [datetime] NOT NULL,
                                            [TireType] [nvarchar] (50) NOT NULL,
                                            [StartDate] [date] NOT NULL,
                                            [EndDate] [date] NOT NULL,
                                            [NumOfBookings] [int] NOT NULL,
                                            CONSTRAINT[PK_TiresHotel_BookingHistory] PRIMARY KEY CLUSTERED
                                                ([Id] ASC)
                                            WITH(PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON[PRIMARY]) 
                                                ON[PRIMARY]
                                        END";
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
