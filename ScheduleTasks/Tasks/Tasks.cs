using System;
using Litium;
using Litium.Foundation.Security;
using Litium.Foundation.Tasks;
using Litium.Products;
using Litium.Security;
using ScheduleTasks.Tasks.Generics;
using ScheduleTasks.Tasks.Migrations;

namespace ScheduleTasks.Tasks
{
    class Tasks : ITask
    {
        private readonly VariantService _variantService;
        private readonly SecurityContextService _securityContextService;

        public Tasks(VariantService variantService, SecurityContextService securityContextService)
        {
            _variantService = variantService;
            _securityContextService = securityContextService;
        }

        public void ExecuteTask(SecurityToken token, string parameters)
        {
            ExecuteTaskCollection();
        }

        
        private void ExecuteTaskCollection()
        {
            foreach (var item in GetTaskCollection())
            {
                try
                {
                    item.ExecuteCollectionTask();
                }
                catch (Exception e)
                {
                    this.Log().Error($"Unhandled exception  {e}");
                }
            }
        }

        
        private static TaskCollection[] GetTaskCollection() =>
            new TaskCollection[]
            {
                new TaskGenerics(),
                new TasksMigrations()
            };
    }
}