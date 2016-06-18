using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheTestDerivco.DataObjects;

namespace TheTestDerivco.DataConnection
{
    class DBConnection
    {
        SqlConnection connection;
        SqlCommand command;
        SQLScripts sql = new SQLScripts();

        public DBConnection()
        {
            connection = new SqlConnection();
            //Struggled to make a database connection
            connection.ConnectionString = @"Data Source=.     \SQLEXPRESS;AttachDbFilename=|DataDirectory|DatabaseName.mdf;Integrated Security=True;User Instance=True";
            command = new SqlCommand();
            command.Connection = connection;
            command.CommandType = CommandType.Text;
        }

        public List<InstalledDatabases> getInstalledDatabased()
        {
            
            List<InstalledDatabases> databaseNames = new List<InstalledDatabases>();
            try
            {
                command.CommandText = SQLScripts.getInstalledDatabases;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        InstalledDatabases databaseName = new InstalledDatabases();
                        databaseName.setMachineId(reader.GetInt32(1));
                        databaseName.setSqlInstanceName(reader.GetString(2));
                        databaseName.setDatabaseName(reader.GetString(3));

                        databaseNames.Add(databaseName);


                    }
                }
            }
            catch(InvalidCastException e)
            { Console.Write(e.StackTrace); }
            finally
            {
                connection.Close();
            }

            return databaseNames;
                       
        }

        public List<VirtualMachines> getVirtualMachines()
        {
            List<VirtualMachines> virtualMachines = new List<VirtualMachines>();
            try
            {
                command.CommandText = SQLScripts.getVirtualMachines;
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        VirtualMachines virtualMachine = new VirtualMachines();
                        virtualMachine.setHostname(reader.GetString(1));
                        virtualMachine.setExternalIpAddress(reader.GetString(2));
                        virtualMachine.setAdminUsername(reader.GetString(3));
                        virtualMachine.setAdminPassword(reader.GetString(4));

                        virtualMachines.Add(virtualMachine);


                    }
                }
            }
            catch (InvalidCastException e)
            { Console.Write(e.StackTrace); }
            finally
            {
                connection.Close();
            }

            return virtualMachines;
        }

        public bool insertIntoVirtualMachines(VirtualMachines machine)
        {

            int success = 1;
            bool returntype = false;
            try
            {
                command = new SqlCommand(SQLScripts.insertIntoVirtualMachines, connection);

                command.Parameters.AddWithValue("@Hostname", machine.getHostname());
                command.Parameters.AddWithValue("@ExternalIpAddress", machine.getExternalIpAddress());
                command.Parameters.AddWithValue("@AdminUsername", machine.getAdminUsername());
                command.Parameters.AddWithValue("@AdminPassword", machine.getAdminPassword());

                success = command.ExecuteNonQuery();
                if(success >= 1)
                {
                    returntype = true;
                }
                else
                {
                    returntype = false;
                }

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return returntype;
        }

        public bool insertIntoInstalledDatabases(InstalledDatabases database)
        {

            int success = 1;
            bool returntype = false;
            try
            {
                command = new SqlCommand(SQLScripts.insertInstalledDatabases, connection);

                command.Parameters.AddWithValue("@MachineId", database.getMachineId());
                command.Parameters.AddWithValue("@SqlInstanceName", database.getSqlInstanceName());
                command.Parameters.AddWithValue("@geDatabaseName", database.geDatabaseName());

                success = command.ExecuteNonQuery();
                if (success >= 1)
                {
                    returntype = true;
                }
                else
                {
                    returntype = false;
                }

            }
            catch (Exception e)
            {
                Console.Write(e.StackTrace);
            }
            finally
            {
                connection.Close();
            }

            return returntype;
        }
    }

}

