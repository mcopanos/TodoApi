using System;
using Npgsql;


namespace TodoApi.Data
{
    public class DbConfiguration
    {
        private NpgsqlConnectionStringBuilder _connectionStringBuilder;

        public string ConnectionString => _connectionStringBuilder.ConnectionString;

        public DbConfiguration()
        {
            _connectionStringBuilder = new NpgsqlConnectionStringBuilder
            {
                Host = Environment.GetEnvironmentVariable("DB_SERVER"),
                Username = Environment.GetEnvironmentVariable("DB_USER"),
                Password = Environment.GetEnvironmentVariable("DB_PASSWORD"),
                Database = Environment.GetEnvironmentVariable("DB_NAME"),
            };

            var port = Environment.GetEnvironmentVariable("DB_PORT");

            if (port != null)
            {
                _connectionStringBuilder.Port = int.Parse(port);
            }
        }

    }
}
