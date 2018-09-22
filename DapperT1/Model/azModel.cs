using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DapperT1.Model
{
    public class DialogStatus
    {
        public string user_id { get; set; }

        public string status { get; set; }

        public string edit_time { get; set; }
    }

    public class Table_Reservation
    {
        public string user_id { get; set; }
        public string reserv_id { get; set; }
        public DateTime reserv_time { get; set; }
        public DateTime create_time { get; set; }
        public string event_status { get; set; }
        public string reserv_event_id { get; set; }
    }
    
    public class Table_Reserv_Event
    {
        public string event_id { get; set; }
        public string event_name { get; set; }
        public string event_detail_id { get; set; }
    }

    public class Table_Reserv_Event_Detail
    {
        public string event_detail_id { get; set; }
        public string event_needed_item { get; set; }
        public int amount { get; set; }
        public string unit { get; set; }
    }

}