using isRock.LineBot;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DapperT1.DataAccessLayer;
using DapperT1.BusinessLogicLayer;

namespace DapperT1.BusinessLogicLayer.DialogProcess
{
    public static class Portal_Process
    {
        //設定ChannelAccessToken
        readonly static string ChannelToken = ConfigurationManager.AppSettings["ChannelAccessToken"];
        
        public static void Handle(int _subState, ReceievedMessage _ReceivedMessage)
        {
            //取得Line Event
            var _LineEvent = _ReceivedMessage.events.FirstOrDefault();
            Bot bot = new Bot(ChannelToken);
            var userInfo = bot.GetUserInfo(_LineEvent.source.userId);

            switch (_subState)
            {
                case (int)SubStateEnum.Step0:

                    if(!Process_Validate.Handle(_LineEvent,bot)) return;

                    //replyToken只能使用一次，可以塞Button Template和Flex Message
                    bot.ReplyMessage(_LineEvent.replyToken, $"哈，'{userInfo.displayName}' 你來了...歡迎，現在開始首頁對話");
                    //轉為字串存取進DB狀態欄
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.Portal, 0, (int)SubStateEnum.Step1));
                    
                    break;

                case (int)SubStateEnum.Step1:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;

                    
                    bot.ReplyMessage(_LineEvent.replyToken, $"哈囉，'{userInfo.displayName}' 現在是第一階段對話");
                    azQuery.resetStatus(string.Concat(0,(int)StateEnum.Portal,0,(int)SubStateEnum.Step2));
                    
                    break;

                case (int)SubStateEnum.Step2:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;

                    bot.ReplyMessage(_LineEvent.replyToken, $"哈囉，'{userInfo.displayName}' 現在是第二階段對話");
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.Portal,0, (int)SubStateEnum.Step3));
                   
                    break;

                case (int)SubStateEnum.Step3:

                    if (_LineEvent.type == "message" && _LineEvent.message.type == "text")
                    {

                        bot.ReplyMessage(_LineEvent.replyToken, $"哈囉，'{userInfo.displayName}' 現在是第三階段對話");

                        //轉為字串存取進DB狀態欄
                        azQuery.resetStatus(string.Concat(0, (int)StateEnum.Portal, 0, (int)SubStateEnum.Step4));
                    }
                    else
                    {
                        bot.ReplyMessage(_LineEvent.replyToken, $"不好意思，我只聽得懂語言");
                    }

                    break;

                case (int)SubStateEnum.Step4:

                    if (_LineEvent.type == "message" && _LineEvent.message.type == "text")
                    {

                        bot.ReplyMessage(_LineEvent.replyToken, $"哈囉，'{userInfo.displayName}' 現在是最後階段對話");
                        azQuery.resetStatus(string.Concat(0, (int)StateEnum.Portal,0, (int)SubStateEnum.StepReset));
                    }
                    else
                    {
                        bot.ReplyMessage(_LineEvent.replyToken, $"不好意思，我只聽得懂語言");
                    }
                    break;

                case (int)SubStateEnum.Step5:

                    break;

                case (int)SubStateEnum.Step6:

                    break;

                default:
                    break;
            }

          

        }
    }
}