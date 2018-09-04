using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using isRock.LineBot;
using DapperT1.BusinessLogicLayer;

namespace DapperT1.Controllers
{
    public class LineWebHookController : LineWebHookControllerBase
    {
        //設定 AdminUserID 
        private string AdminUserID = ConfigurationManager.AppSettings["AdminUserID"];
        
        [Route("api/LineWebHook")]
        [HttpPost]
        public IHttpActionResult POST()
        {
            try
            {
                //取得 http Post RawData(should be JSON)
                string postData = Request.Content.ReadAsStringAsync().Result;
                //剖析JSON
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                
                DialogFlow _df = new DialogFlow(ReceivedMessage);
                _df.Process();
                
                return Ok();
            }
            catch (Exception ex)
            {
                //回覆訊息
                this.PushMessage(AdminUserID, "發生錯誤:\n" + ex.Message);

                return Ok();
            }
        }
    }
}