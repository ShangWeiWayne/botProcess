using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using isRock.LineBot;

namespace DapperT1.BusinessLogicLayer.DialogProcess
{
    public class Process_Validate
    {
        public static bool Handle(Event _LineEvent , Bot bot)
        {
            if (_LineEvent.message.type != "text")
            {
                bot.ReplyMessage(_LineEvent.replyToken, $"不好意思，我只聽得懂語言");
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}