//using Dapper;
//using System;
//using System.Collections.Generic;
//using System.Data.SqlClient;
//using System.Linq;
//using System.Web;

//namespace DapperT1.DataAccessLayer
//{
//    public partial class azQuery
//    {
//        static string _connStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();
//        public async  static void SetUserInfo(string user_id)
//        {

//            using (var conn = new SqlConnection(_connStr))
//            {
//                conn.Open();
//                string sqlCommand = @"Select * from  
//                                    _DialogStatus 
//                                Where 
//                                    user_id = @user_id";
//                var parameter = new
//                {
//                    user_id = _id
//                };
//                var result = await conn.ExecuteAsync(sqlCommand, parameter);
                
//            }
//        }
//    }
//}