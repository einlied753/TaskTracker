using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker.DAL
{
    internal class TaskTrackerInit : MigrateDatabaseToLatestVersion
        <Context, Migrations.Configuration>
    {
    }
}
