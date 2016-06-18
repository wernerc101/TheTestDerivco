using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Management.Automation.Runspaces;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheTestDerivco.DataConnection;
using TheTestDerivco.DataObjects;
using TheTestDerivco.PowerShell;

namespace TheTestDerivco
{

    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DBConnection db = new DBConnection();
            PowerScript p = new PowerScript();
            Command cm = new Command("\\TheTestDerivco\\TheTestDerivco\\GetSQLServers.ps1");

            List<VirtualMachines> vm = new List<VirtualMachines>();
            vm = db.getVirtualMachines();
            foreach(VirtualMachines item in vm)
            {
                cm.Parameters.Add("ServerName",item.getHostname() + "" + item.getExternalIpAddress());
                cm.Parameters.Add("AdminUser", item.getAdminUsername());
                cm.Parameters.Add("AdminPasswprd", item.getAdminPassword());

                String results = p.RunScript(cm);

                InstalledDatabases installData = new InstalledDatabases();

                installData.setMachineId(Int32.Parse(results.Substring(0, results.LastIndexOf("  "))));
                results = results.Substring(0, results.LastIndexOf("  "));

                installData.setSqlInstanceName(results.Substring(0, results.LastIndexOf("  ")));
                results = results.Substring(0, results.LastIndexOf("  "));

                installData.setDatabaseName(results.Substring(0, results.LastIndexOf("  ")));

                db.insertIntoInstalledDatabases(installData);
            }
        }
    }
}
