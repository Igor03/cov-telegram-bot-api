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
    public class CountrySituationRepository
    {
        private readonly string _connectionString;
        private DatabaseConnections _dbConnections;

        public CountrySituationRepository()
        {
            _dbConnections = new DatabaseConnections();
            _connectionString = @_dbConnections.con.ConnectionString;
        }

        public IDbConnection Connection {
            get {
                return new SqlConnection(_connectionString);
            }
        }

        public IEnumerable<CountrySituation> GetAllCountriesSituation()
        {
            using (IDbConnection dbConnection = Connection)
            {
                var sqlStatement = Scripts.SELECT_COUNTRIES_SITUATION;
                dbConnection.Open();
                return dbConnection.Query<CountrySituation, Country, CountrySituation>(
                    sqlStatement,
                    (countrySituation, country) =>
                    {
                        countrySituation.Country = country;
                        return countrySituation;
                    }, splitOn: "id");
            }
        }


        public IEnumerable<CountrySituation> GetCountryDataByName(string CountryName)
        {
            //var parameters = new DynamicParameters();
            //parameters.Add("CountryName", CountryName, DbType.String, ParameterDirection.Input);

            using (IDbConnection dbConnection = Connection)
            {
                var sqlStatement = Scripts.SELECT_COUNTRIES_SITUATION;
                dbConnection.Open();
                return dbConnection.Query<CountrySituation, Country, CountrySituation>(
                    Scripts.GetCountrySituationQuery(CountryName), 
                    (countrySituation, country) =>
                    {
                        countrySituation.Country = country;
                        return countrySituation;
                    }, splitOn: "id");
            }
        }        
    }
}