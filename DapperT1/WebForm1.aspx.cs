using Dapper;
using DapperT1.BusinessLogicLayer;
using DapperT1.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DapperT1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string azConnStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void resetStatus_Click(object sender, EventArgs e)
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
                    status = "0103",
                    user_id = _userID,
                    edit_time = DateTime.Now.ToString("yyyyMMddhhmmss")
                };

                conn.Execute(strSql, parameter);
            }
        }

        protected void getEnum_Click(object sender, EventArgs e)
        {
            //Method1
            //var EnumDescriptions =
            //            from RichMenuIntent n in Enum.GetValues(typeof(RichMenuIntent))
            //            select new { ID = (int)n, Name = Utility.SearchEnumDescription(n) };
            //var Text = "";
            //foreach (var x in EnumDescriptions)
            //{
            //    Text += x.ToString() + "//";
            //}

            //Method2
            Type type = typeof(StateEnum);
            string MainState = Utility.GetEnumDescription("drugRemind", type);

            //Method3
            //RichMenuIntent getVal = RichMenuIntent.Portal;
            //var val = Utility.GetDescription(getVal);
            TextBox1.Text = "Description ="+ MainState ;
        }

        protected void SendLogToNotify_Click(object sender, EventArgs e)
        {
            Utility.SendLogToNotify(TextBox2.Text);
        }
    }
}