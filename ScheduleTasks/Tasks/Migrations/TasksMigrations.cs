using System;
using Litium;
using ScheduleTasks.Tasks.Migrations.TireHotel;

namespace ScheduleTasks.Tasks.Migrations
{
    class TasksMigrations : TaskCollection
    {

        public override void ExecuteCollectionTask()
        {
            ExecuteTaskMigrations();
        }

        private void ExecuteTaskMigrations()
        {
            foreach (var item in GetMigrationTasks())
            {
                try
                {
                    item.ExecuteTask();
                }
                catch (Exception e)
                {
                    this.Log().Error($"Unhandled exception  {e}");
                }
            }
        }
        
        private static TaskMigrationCollection[] GetMigrationTasks() =>
            new TaskMigrationCollection[]
            {
                new TaskCreateTireSetTable(),
                new TaskCreateTireTable(),
                new TaskCreateTireSetImageTable(),
                new ModifyTireHotelTables(),
                new TaskCreateTireManufacturersAndModelsTable(),
                new TaskCreateTireHotelEmailHistoryTable(),
                new TaskCreateTireHotelBookingHistoryTable(),
            };
    }
}