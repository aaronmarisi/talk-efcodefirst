using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealTracker.DataAccess.Configuration
{
    public class EntityFrameworkConfig: DbConfiguration
    {
        public EntityFrameworkConfig()
        {
            //SetExecutionStrategy("System.Data.SqlClient", () => new DefaultExecutionStrategy());
            //SetDefaultConnectionFactory(new LocalDbConnectionFactory("mssqllocaldb"));

            SetDatabaseInitializer<MealContext>(new MigrateDatabaseToLatestVersion<MealContext, Migrations.Configuration>());
        }
    }
}
