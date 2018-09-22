using Dapper;
using DapperT1.Model;
using System;
using System.Transactions;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace DapperT1.DataAccessLayer
{
    public partial class azQuery
    {
        public class DrugRemind_Test
        {
            static string _connStr = WebConfigurationManager.ConnectionStrings["azConnStr"].ToString();

            public async static void SetReservation(
                //List<Table_Reservation> Res,
                //List<Table_Reserv_Event> Res_Ev, List<Table_Reserv_Event_Detail> Res_EvDe,
                //string _user_id,string _event_status,Object table1,Object table2
                )
            {
                using (var transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
                {
                    var NowTime = DateTime.Now.ToString("yyyyMMddhhmmss");
                    var Res = new Table_Reservation()
                    {
                        user_id = "test006",
                        reserv_id = string.Concat("RES", NowTime),
                        //測試用預約時間
                        reserv_time = DateTime.Now,
                        event_status = string.Concat(0, (int)Enum_Reserv_Status.Start),
                        create_time = DateTime.Now,
                        reserv_event_id = string.Concat("RES_EV", NowTime)

                    };

                    var Res_Ev = new Table_Reserv_Event()
                    {
                        event_id = string.Concat("RES_EV", NowTime),
                        event_name = "",
                        event_detail_id = string.Concat("RES_DET", NowTime)
                    };

                    var Res_Det = new Table_Reserv_Event_Detail()
                    {
                        event_detail_id = string.Concat("RES_DET", NowTime),
                        event_needed_item = "testitem",
                        amount = 4564,
                        unit = "元"
                    };

                    string sqlCommand1 = @"INSERT INTO 
                                            _Reservation
                                                (user_id, reserv_id, reserv_time,event_status,create_time,reserv_event_id) 
                                            VALUES(@user_id,
                                                    @reserv_id, @reserv_time,@event_status,@create_time,@reserv_event_id);";

                    string sqlCommand2 = @"INSERT INTO 
                                            _Reserv_Event
                                                (event_id, event_name, event_detail_id) 
                                            VALUES(@event_id, @event_name, @event_detail_id);";
                    string sqlCommand3 = @"INSERT INTO 
                                            _Reserv_Event_Detail
                                                (event_detail_id, event_needed_item, amount,unit) 
                                            VALUES(@event_detail_id, @event_needed_item, @amount,@unit);";

                    using (var conn = new SqlConnection(_connStr))
                    {
                        conn.Open();

                        await conn.ExecuteAsync(sqlCommand1, Res);
                        await conn.ExecuteAsync(sqlCommand2, Res_Ev);
                        await conn.ExecuteAsync(sqlCommand3, Res_Det);
                    }
                    transactionScope.Complete();
                }

            }
        }
    }
}