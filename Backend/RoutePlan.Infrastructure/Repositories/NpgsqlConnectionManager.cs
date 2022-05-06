using System;
using System.Data;
using System.Threading.Tasks;
using Npgsql;
using RoutePlan.Domain.Interfaces;

namespace RoutePlan.Infrastructure.Repositories
{
    public class NpgsqlConnectionManager : IConnectionManager
    {
        private string _connectionString;
        private string _database;

        public NpgsqlConnectionManager(string connectionString, string database)
        {
            _connectionString = connectionString;
            _database = database;
        }

        public async Task<IDbConnection> GetConnectionAsync(string database = null)
        {
            try
            {
                NpgsqlConnection connection = new NpgsqlConnection(_connectionString);

                await connection.OpenAsync();

                if (!string.IsNullOrEmpty(database))
                {
                    connection.ChangeDatabase(database.ToLower());
                }
                else if (!string.IsNullOrEmpty(_database))
                {
                    connection.ChangeDatabase(_database.ToLower());
                }

                return connection;
            }
            catch (NpgsqlException ex)
            {
                var dataEx = new Exception("Exeception NpgsqlConnection:GetConnectionAsync",
                    ex);

                throw dataEx;
            }
        }
    }
}