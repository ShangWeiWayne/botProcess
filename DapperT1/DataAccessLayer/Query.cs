using Dapper;
using System;
using System.Dynamic;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using DapperT1.Model;

namespace DapperT1.DataAccessLayer
{
    public class Query 
    {
        static string _connStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();

        public static async Task<IEnumerable<dynamic>> QueryAsync(string sqlCommand)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = await conn.QueryAsync<dynamic>(sqlCommand);
                return result;
            }
        }
        public static IEnumerable<dynamic> QuerySync(string sqlCommand, object parameter)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = conn.Query<dynamic>(sqlCommand, parameter);

                return result;
            }
        }
        public static async Task<IEnumerable<dynamic>> QueryAsync(string sqlCommand, object parameter)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = await conn.QueryAsync<dynamic>(sqlCommand,parameter);
                return result;
            }
        }
        public static async Task<IEnumerable<dynamic>> MultiQueryAsync(string sqlCommand, Array parameter)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = await conn.QueryAsync<dynamic>(sqlCommand, parameter);
                return result;
            }
        }

        public static async Task<int> CommandAsync(string sqlCommand, object parameter)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(sqlCommand, parameter);
                return result;
            }
        }

        public static async Task<int> MultiCommandAsync(string sqlCommand, Array parameter)
        {
            using (var conn = new SqlConnection(_connStr))
            {
                conn.Open();
                var result = await conn.ExecuteAsync(sqlCommand, parameter);
                return result;
            }
        }
    }
}