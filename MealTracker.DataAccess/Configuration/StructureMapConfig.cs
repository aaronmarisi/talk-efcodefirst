using StructureMap.Configuration.DSL;
using StructureMap.Pipeline;
using System.Data.Entity;
using System.Data.Entity.Core.Common;
using System.Data.Entity.Infrastructure;

namespace MealTracker.DataAccess.Configuration
{
    public class StructureMapConfig: Registry
    {
        public StructureMapConfig()
        {
            For<MealContext>().Use<MealContext>().SetLifecycleTo(new UniquePerRequestLifecycle());
        }        
    }
}
