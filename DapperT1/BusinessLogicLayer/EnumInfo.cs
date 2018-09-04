using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace DapperT1.BusinessLogicLayer
{

    public enum StateEnum:int
    {
        [Description("首頁")]
        Portal = 00,
        [Description("用藥提醒")]
        DrugRemind = 01
    }

    public enum SubStateEnum : int
    {
        StepReset = 00,
        Step0 = 00,
        Step1 = 01,
        Step2 = 02,
        Step3 = 03,
        Step4 = 04,
        Step5 = 05,
        Step6 = 06,
        Step7 = 07,
        Step8 = 08,
        Step9 = 09,
        Step10 = 10
    }
}