using Microsoft.Data.SqlClient;
using System;
using System.Linq;

namespace DoctorsOffice.Data.Install
{
    public class SqlConnectionBuilder
    {
        private readonly FindServers _servers;

        public SqlConnectionBuilder(string databaseName = null)
        {
            _servers = new FindServers();
            var sqlServerName = SearchSqlServers();

            DatabaseName = !string.IsNullOrEmpty(databaseName) ? databaseName : "DoctorsOffice";
            ServerName = sqlServerName;
        }

        public string ServerName { get; private set; }
        public string DatabaseName { get; set; }

        public DefaultConnectionString BuildConnectionString()
        {
            SqlConnectionStringBuilder connection = new SqlConnectionStringBuilder();
            connection.DataSource = ServerName;
            connection.InitialCatalog = DatabaseName;
            connection.IntegratedSecurity = true;

            return new DefaultConnectionString(connection.ConnectionString);
        }

        private string SearchSqlServers()
        {
            var servers = _servers.GetSqlServersName();

            if (servers == null || !servers.Any())
                throw new Exception("Nenhum SQL server encontrado na máquina");

            return servers.FirstOrDefault();
        }
    }
}
