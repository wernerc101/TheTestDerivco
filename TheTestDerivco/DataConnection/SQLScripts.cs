using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTestDerivco.DataConnection
{
    class SQLScripts
    {
        public const string getInstalledDatabases = "Select * from tb_InstalledDatabases";

        public const string insertInstalledDatabases = "INSERT INTO tb_InstalledDatabases (MachineId , SqlInstanceName , DatabaseName ) VALUES(@MachineId, @SqlInstanceName, @DatabaseName)";

        public const string insertIntoVirtualMachines = "INSERT INTO dbo.tb_VirtualMachines (Hostname, ExternalIpAddress, AdminUsername, AdminPassword) VALUES(@Hostname, @ExternalIpAddress, @AdminUsername, @AdminPassword)";

        public const string getVirtualMachines= "Select * from VirtualMachines";



    }
}
