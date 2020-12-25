using Litium;
using System;
using System.Configuration;
using System.Data.SqlClient;

namespace ScheduleTasks.Tasks.Migrations.TireHotel
{
    public class ModifyTireHotelTables : TaskMigrationCollection
    {
        public override void ExecuteTask()
        { var cs = ConfigurationManager.ConnectionStrings["FoundationConnectionString"].ConnectionString;

            var con = new SqlConnection(cs);
            con.Open();

            var cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.Prepare();
            cmd.CommandText =
                @"IF EXISTS (SELECT 1 FROM [TiresHotel_TireSet] WHERE StationId IS NULL)
		                                BEGIN
			                                UPDATE TiresHotel_TireSet SET StationId = '' WHERE StationId IS NULL
		                              END

	                                declare @DateColType nvarchar(50)
	                                SELECT @DateColType = DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS
		                                WHERE 
			                                TABLE_NAME = 'TiresHotel_TireSet' AND 
			                                COLUMN_NAME = 'Date'

	                                IF EXISTS (select @DateColType as 'nvarchar')
		                                BEGIN
			                                ALTER TABLE TiresHotel_TireSet
			                                ALTER COLUMN [Date] Date;
		                                END

                                    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
		                                WHERE 
                                                    TABLE_NAME = 'TiresHotel_Tire' AND 
			                                        COLUMN_NAME = 'RimBrand')
                                        BEGIN
                                            ALTER TABLE TiresHotel_Tire
                                            DROP COLUMN RimBrand
		                                END

                                    IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
		                                WHERE 
                                                    TABLE_NAME = 'TiresHotel_Tire' AND 
			                                        COLUMN_NAME = 'RimMaterial')
                                        BEGIN
                                            ALTER TABLE TiresHotel_Tire
                                            DROP COLUMN RimMaterial
		                                END

                                    IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
		                                WHERE 
                                                    TABLE_NAME = 'TiresHotel_TireSet' AND 
			                                        COLUMN_NAME = 'RimBrand')
                                        BEGIN
                                            ALTER TABLE TiresHotel_TireSet
                                            ADD RimBrand nvarchar(max) NULL
		                                END

                                    IF NOT EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS 
		                                WHERE 
                                                    TABLE_NAME = 'TiresHotel_TireSet' AND 
			                                        COLUMN_NAME = 'RimMaterial')
                                        BEGIN
                                            ALTER TABLE TiresHotel_TireSet
                                            ADD RimMaterial nvarchar(max) NULL
                                        END

                                    IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                                       WHERE
                                                    TABLE_NAME = 'TiresHotel_Tire' AND
                                                    COLUMN_NAME = 'SpeedAndLoadIndex')
                                        BEGIN
                                            ALTER TABLE TiresHotel_Tire
                                            ADD SpeedAndLoadIndex nvarchar(50) NULL
                                        END

                                    IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                                       WHERE
                                                    TABLE_NAME = 'TiresHotel_Tire' AND
                                                    COLUMN_NAME = 'SortOrder')
                                        BEGIN
                                            ALTER TABLE TiresHotel_Tire
                                            ADD SortOrder int NULL
                                        END

                                    IF EXISTS (SELECT 1 FROM [TiresHotel_TireSet] WHERE TiresType IS NULL)
		                                BEGIN
			                                UPDATE TiresHotel_TireSet SET TiresType = 'SummerTire' WHERE TiresType IS NULL
		                              END

                                    IF NOT EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.COLUMNS
                                       WHERE
                                            TABLE_NAME = 'TiresHotel_TireSet' AND
                                            COLUMN_NAME = 'ReminderSent')
                                        BEGIN
                                            ALTER TABLE TiresHotel_TireSet
                                                ADD ReminderSent bit NOT NULL
                                            CONSTRAINT [D_TiresHotel_TireSet_ReminderSent]  
                                                DEFAULT (0)
                                        END";
            
            cmd.ExecuteNonQuery();
            this.Log().Debug($"this is running");
        }
    }
}
