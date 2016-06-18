using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheTestDerivco.DataObjects
{

    class VirtualMachines
    {
        private string Hostname;
        private string ExternalIpAddress;
        private string AdminUsername;
        private string AdminPassword;

        public VirtualMachines() { }

        public VirtualMachines(string Hostname, string ExternalIpAddress, string AdminUsername, string AdminPassword)
        {
            this.Hostname = Hostname;
            this.ExternalIpAddress = ExternalIpAddress;
            this.AdminUsername = AdminUsername;
            this.AdminPassword = AdminPassword;
        }

        public string getHostname()
        {
            return this.Hostname;
        }

        public void setHostname(string hostname)
        {
            this.Hostname = hostname;
        }

        public string getExternalIpAddress()
        {
            return this.ExternalIpAddress;
        }

        public void setExternalIpAddress(string externalIpAddress)
        {
            this.ExternalIpAddress = externalIpAddress;
        }

        public string getAdminUsername()
        {
            return this.AdminUsername;
        }

        public void setAdminUsername(string adminUsername)
        {
            this.AdminUsername = adminUsername;
        }

        public string getAdminPassword()
        {
            return this.AdminPassword;
        }

        public void setAdminPassword(string adminPassword)
        {
            this.AdminPassword = adminPassword;
        }
    } 
}
