using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EComm.API.Infrastructure.Interfaces
{
    public interface IDbMigrator
    {
        public void MigrateDatabase();
    }
}
