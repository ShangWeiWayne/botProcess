using Dapper;
using System.Linq;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Dynamic;
using System.Collections.Generic;
using System;
using DapperT1.Model;
using System.Web.Configuration;

namespace DapperT1.DataAccessLayer
{
    public partial class azQuery
    {
        public async static Task<IEnumerable<dynamic>> GetOrder()
        {
            string Sql_GetOrder = @"";
            var result = await Query.QueryAsync(Sql_GetOrder);
            return result;
        }

        //public static async Task<IEnumerable<DialogStatus>> GetUserStatusAsync(string _id)
        //{
        //    string sqlCommand = @"Select * from  
        //                            _DialogStatus 
        //                        Where 
        //                            user_id = @user_id";
        //    var parameter = new { user_id = _id };

        //    var result = await Query.QueryAsync(sqlCommand, parameter);
        //    var list = result.ToList();

        //    return list;
        //}

      
        public static IEnumerable<dynamic> GetUserStatusByID(string _id)
        {
            string sqlCommand = @"Select * from  
                                    _DialogStatus 
                                Where 
                                    user_id = @user_id";
            var parameter = new {
                user_id = _id };
            
            var result =Query.QuerySync(sqlCommand, parameter);
            
            return result;
        }

        public async static void UpdateData(string _id)
        {
            string sqlCommand = @"";
            var parameter = new
            {
                id = _id
            };
            await Query.CommandAsync(sqlCommand, parameter);
        }

        public async static void InsertData(string _id)
        {
            string sqlCommand = @"INSERT INTO 
                                        _DialogStatus(
                                            user_id,
                                            status,
                                            edit_time) 
                                    VALUES  (
                                        @user_id,
                                        @status,
                                        @edit_time );";
            var parameter = new 
            {
                status = "0000",
                edit_time = DateTime.Now.ToString("yyyyMMddhhmmss"),
                user_id = _id
            };

            await Query.CommandAsync(sqlCommand, parameter);
        }

    }
}
