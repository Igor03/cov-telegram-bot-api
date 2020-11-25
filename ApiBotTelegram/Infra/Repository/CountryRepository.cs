using ApiBotTelegram.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace ApiBotTelegram.Infra.Repository
{
    public class CountryRepository
    {
        private readonly string _connectionString;
        private DatabaseConnections _dbConnections;

        public CountryRepository()
        {
            _dbConnections = new DatabaseConnections();
            _connectionString = @_dbConnections.con.ConnectionString;
        }

        public IDbConnection Connection {
            get {
                return new SqlConnection(_connectionString);
            }
        }

        public IEnumerable<Country> GetAvailableCountries()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sqlStatement = Scripts.SELECT_AVAILABLE_COUNTRIES;
                dbConnection.Open();
                return dbConnection.Query<Country>(sqlStatement);
            }
        }
        public IEnumerable<Country> GetCountryByName(string CountryName)
        {
            var parameters = new DynamicParameters();
            parameters.Add("CountryName", CountryName, DbType.String, ParameterDirection.Input);

            using (IDbConnection dbConnection = Connection)
            {
                var sqlStatement = Scripts.SELECT_COUNTRY_BY_NAME;
                dbConnection.Open();
                return dbConnection.Query<Country>(sqlStatement, parameters);
            }
        }

    }
}
