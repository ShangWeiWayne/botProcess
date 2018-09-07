using Dapper;
using DapperT1.BusinessLogicLayer;
using DapperT1.DataAccessLayer;
using DapperT1.Model;
using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

namespace DapperT1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private static string azConnStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();
        string channelAccessToken = ConfigurationManager.AppSettings["ChannelAccessToken"];
        string AdminUserId = ConfigurationManager.AppSettings["AdminUserId"];
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

        //protected void DynamicObjForCrud_Click(object sender, EventArgs e)
        //{

        //}

        protected void Button1_Click(object sender, EventArgs e)
        {

            //var _userID = "test001";

            //dynamic dynClass = new DialogStatus();
            //List<DialogStatus> _results = null;
            //string _status = null;

            //using (SqlConnection conn = new SqlConnection(azConnStr))
            //{
            //    string strSql = @"Select * from  
            //                        _DialogStatus 
            //                      Where 
            //                        user_id = @user_id";
            //    _results = conn.Query<>(strSql, new { user_id = _userID }).ToList();
            //}

            //_results.ForEach((x) =>
            //{
            //    _status = x.status;
            //});

            //TextBox3.Text = _status;

        }

        protected void flexMessage_Click(object sender, EventArgs e)
        {
            var Flex = @"
[
    {
      ""type"": ""flex"",
      ""altText"": ""This is a Flex Message"",
      ""contents"": 
            {
                {
  ""type"": ""bubble"",
  ""body"": {
                ""type"": ""box"",
    ""layout"": ""vertical"",
    ""spacing"": ""md"",
    ""contents"": [
      {
        ""type"": ""box"",
        ""layout"": ""vertical"",
        ""margin"": ""xxl"",
        ""contents"": [
          {
            ""type"": ""spacer""
          },
          {
            ""type"": ""image"",
            ""url"": ""https://scdn.line-apps.com/n/channel_devcenter/img/fx/linecorp_code_withborder.png"",
            ""aspectMode"": ""cover"",
            ""size"": ""xl""
          },
          {
            ""type"": ""text"",
            ""text"": ""使用Flex_Message"",
            ""color"": ""#aaaaaa"",
            ""wrap"": true,
            ""margin"": ""xxl"",
            ""size"": ""xs""
          }
        ]
      }
    ]
  }
}
            }
    }
  ]
";
            //define bot instance
            Bot bot = new Bot(channelAccessToken);

            //Push Flex Message
            bot.PushMessageWithJSON(AdminUserId, Flex);
        }

        protected void imagemap_Click(object sender, EventArgs e)
        {
            var bot = new Bot(channelAccessToken);
            isRock.LineBot.ImagemapMessage imagemapMessage = new ImagemapMessage();
            imagemapMessage.altText = "imagemapMessage test";
            imagemapMessage.baseSize = new System.Drawing.Size(1040, 1040);
            imagemapMessage.baseUrl = new Uri($"https://scdn.line-apps.com/n/channel_devcenter/img/fx/01_4_news.png#");
            imagemapMessage.actions = new List<ImagemapActionBase>();
            imagemapMessage.actions.Add(new isRock.LineBot.ImagemapMessageAction()
            {
                area = new ImagemapArea() { x = 0, y = 0, height = 500, width = 500 },
                text = "點選了(0,0) - (500,500)"
            });
            imagemapMessage.actions.Add(new isRock.LineBot.ImagemapUriAction()
            {
                area = new ImagemapArea() { x = 500, y = 500, height = 1040, width = 1040 },
                linkUri = new Uri("line://app/1587126793-1loqMRnz")
            });
            bot.PushMessage(AdminUserId, imagemapMessage.baseUrl.ToString());
            bot.PushMessage(AdminUserId, imagemapMessage);
        }

        protected async void QueryAsync_Click(object sender, EventArgs e)
        {
            try
            {
                string status = null;
                ////azQuery.InsertData(TextBox6.Text);
                //var res = azQuery.GetUserStatusByID("test002");
                //var r = JsonConvert.SerializeObject(res);
                //res.ToList().ForEach((x) => status = x.status);
                

                //var async = await azQuery.GetUserStatusAsync("test002");
                //var posts ;
                //async.ToList().ForEach((x) => { status = x.status; });
                //foreach (var post in async)
                //{
                //    TextBox6.Text = post.status;
                ////}
                //var r = JsonConvert.SerializeObject(async);
                //TextBox6.Text = r;
            }
            catch (AggregateException ex)
            {
                TXT_Result.Text = ex.Message;
            }
            
        }
    }
}