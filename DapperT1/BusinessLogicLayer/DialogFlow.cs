using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DapperT1.BusinessLogicLayer.DialogProcess;
using DapperT1.DataAccessLayer;
using DapperT1.Model;
using isRock.LineBot;

namespace DapperT1.BusinessLogicLayer
{
    public class DialogFlow
    {
        private string _status = null;
        private int _state ;
        private int _subState;
        private string _user_id = null;
        private ReceievedMessage _ReceivedMessage;

        public DialogFlow(ReceievedMessage ReceivedMessage)
        {
            this._ReceivedMessage = ReceivedMessage;
            this._user_id = ReceivedMessage.events.FirstOrDefault().source.userId;
            StatusInit();
        }

        public void Process()
        {
            
            if (this._state == (int)StateEnum.Portal)
            {
                Portal_Process.Handle(_subState, _ReceivedMessage);
            }
            else if (this._state == (int)StateEnum.DrugRemind)
            {
                DrugRemind_Process.Handle(_subState, _ReceivedMessage);
            }
        }

        private void StatusInit()
        {
            var _LineEvent = _ReceivedMessage.events.FirstOrDefault();
            
            if (_LineEvent.type == "message" && _LineEvent.message.type == "text" )
            {
                string Text = _LineEvent.message.text;
                string hasIntent = Text.Substring(0,1);
                if (hasIntent == "@") {

                    string RichMenuIntent = Text.Substring(1, Text.Length-1);
                    string MainState = Utility.GetEnumValueFromDescription<StateEnum>(RichMenuIntent).ToString();
                    
                    if (MainState == StateEnum.Portal.ToString())
                    {
                        string newStatus = string.Concat(0, (int)StateEnum.Portal, 0, (int)SubStateEnum.StepReset);

                        azQuery.resetStatus(newStatus);
                        settingStatus(newStatus);
                    }
                    else if(MainState == StateEnum.DrugRemind.ToString())
                    {
                        string newStatus = string.Concat(0, (int)StateEnum.DrugRemind, 0, (int)SubStateEnum.StepReset);
                        azQuery.resetStatus(newStatus);
                        settingStatus(newStatus);
                    }
                }
                else
                {
                    settingStatus(null);
                }
            }
        }

        private void settingStatus(string resetStatus)
        {
            if (resetStatus == null)
            {
                //正式連DB版本要給user_id
                //this._status = CRUD.getStatus(_user_id);
                _status = azQuery.getStatus(); //使用假資料(userID)撈取
                _state = Convert.ToInt32(_status.Substring(0, 2));
                _subState = Convert.ToInt32(_status.Substring(2, 2));
            }
            else 
            {
                _status = resetStatus;
                _state = Convert.ToInt32(_status.Substring(0, 2));
                _subState = Convert.ToInt32(_status.Substring(2, 2));
            }            
        }

        public string GetStatus()
        {
            return this._status;
        }

    }
}