using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using DapperT1.Model;
using Dapper;


namespace DapperT1.DataAccessLayer
{
    public partial class azQuery 
    {
        private static string azConnStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();
        
        public static string getStatus()
        {
            var _userID = "test001";

            List<DialogStatus> _results = null;
            string _status = null;

            using (SqlConnection conn = new SqlConnection(azConnStr))
            {
                string strSql = @"Select * from  
                                    _DialogStatus 
                                  Where 
                                    user_id = @user_id";
                _results = conn.Query<DialogStatus>(strSql, new { user_id = _userID }).ToList();
            }

            _results.ForEach((x) => { _status = x.status; });

            return _status;
        }

        public  static void resetStatus(string _status)
        {
            var _userID = "test001";
            
            using (SqlConnection conn = new SqlConnection(azConnStr))
            {
                string strSql = @"UPDATE  
                                    _DialogStatus 
                                  SET 
                                    edit_time=@edit_time,
                                    status = @status
                                  Where 
                                    user_id = @user_id";

                var parameter = new DialogStatus() {
                    status = _status,
                    edit_time = DateTime.Now.ToString("yyyyMMddhhmmss"),
                    user_id = _userID
                };
                conn.Execute(strSql, parameter);
            }
        }
        

    }
}