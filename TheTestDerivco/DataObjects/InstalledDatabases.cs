using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTestDerivco.DataObjects
{
    class InstalledDatabases
    {
        private int MachineId;
        private string SqlInstanceName;
        private string DatabaseName;

        public InstalledDatabases() { }

        public InstalledDatabases(int MachineId, string SqlInstanceName, string DatabaseName)
        {
            this.MachineId = MachineId;
            this.SqlInstanceName = SqlInstanceName;
            this.DatabaseName = DatabaseName;
        }

        public int getMachineId()
        {
            return this.MachineId;
        }

        public void setMachineId(int machineId)
        {
            this.MachineId = machineId;
        }

        public string getSqlInstanceName()
        {
            return this.SqlInstanceName;
        }

        public void setSqlInstanceName(string sqlInstanceName)
        {
            this.SqlInstanceName = sqlInstanceName;
        }

        public string geDatabaseName()
        {
            return this.DatabaseName;
        }

        public void setDatabaseName(string databaseName)
        {
            this.DatabaseName = databaseName;
        }
    }
}
