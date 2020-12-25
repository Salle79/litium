using Litium;

namespace ScheduleTasks.Tasks.Generics.User
{
    public class TaskUpdateUsers : TaskGenericCollection
    {  
        public override void ExecuteTask()
        {
            this.Log().Debug($"this is running");
        }
    }
}
