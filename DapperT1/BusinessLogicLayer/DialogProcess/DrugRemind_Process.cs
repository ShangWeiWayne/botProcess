using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using DapperT1.DataAccessLayer;
using isRock.LineBot;

namespace DapperT1.BusinessLogicLayer.DialogProcess
{
    public static class DrugRemind_Process
    {
        public static void Handle(int _subState, ReceievedMessage _ReceivedMessage)
        {
            var _LineEvent = _ReceivedMessage.events.FirstOrDefault();
            var _userId = _LineEvent.source.userId;
            var ChannelToken = ConfigurationManager.AppSettings["ChannelAccessToken"];
            isRock.LineBot.Bot bot = new isRock.LineBot.Bot(ChannelToken);
            var userInfo = bot.GetUserInfo(_userId);
            
            switch (_subState)
            {
                case (int)SubStateEnum.Step0:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;
                   
                    bot.ReplyMessage(_LineEvent.replyToken, $"哈，'{userInfo.displayName}' 你來了...歡迎，現在開始用藥流程對話");
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.DrugRemind, 0, (int)SubStateEnum.Step1));
                   
                    break;

                case (int)SubStateEnum.Step1:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;

                    bot.ReplyMessage(_LineEvent.replyToken, $"哈，'{userInfo.displayName}' 現在是第一階段對話");
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.DrugRemind, 0, (int)SubStateEnum.Step2));
                    
                    break;

                case (int)SubStateEnum.Step2:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;

                    bot.ReplyMessage(_LineEvent.replyToken, $"哈，'{userInfo.displayName}' 現在是第二階段對話");
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.DrugRemind, 0, (int)SubStateEnum.Step3));
                    
                    break;

                case (int)SubStateEnum.Step3:

                    if (!Process_Validate.Handle(_LineEvent, bot)) return;

                    bot.ReplyMessage(_LineEvent.replyToken, $"哈囉，'{userInfo.displayName}' 現在是最後階段對話");
                    azQuery.resetStatus(string.Concat(0, (int)StateEnum.DrugRemind, 0, (int)SubStateEnum.StepReset));

                    break;

                case (int)SubStateEnum.Step4:

                    
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