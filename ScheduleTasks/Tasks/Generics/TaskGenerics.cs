using System;
using Litium;
using ScheduleTasks.Tasks.Generics.User;

namespace ScheduleTasks.Tasks.Generics
{
    class TaskGenerics : TaskCollection
    {
        public override void ExecuteCollectionTask()
        {
            foreach (var item in GetGenericTasks())
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
        
        private static TaskGenericCollection[] GetGenericTasks() => new TaskGenericCollection[]
        {
            new TaskDeleteUsers(), new TaskUpdateUsers()
        };
    }
}