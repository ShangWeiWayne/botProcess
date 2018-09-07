//using Dapper;
//using System.Data.SqlClient;
//using System.Threading.Tasks;
//using System.Collections.Generic;
//using System;

//namespace DapperT1.DataAccessLayer
//{
    
//    public class OrderQueries 
//    {
//        private string _connectionString;

//        public async Task<IEnumerable<OrderSummary>> GetOrdersAsync()
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                connection.Open();
//                var r =connection.QueryAsync<dynamic>(
//                      @"SELECT o.[Id] as ordernumber, 
//                  o.[OrderDate] as [date],os.[Name] as [status], 
//                  SUM(oi.units*oi.unitprice) as total
//                  FROM [ordering].[Orders] o
//                  LEFT JOIN[ordering].[orderitems] oi ON  o.Id = oi.orderid 
//                  LEFT JOIN[ordering].[orderstatus] os on o.OrderStatusId = os.Id
//                  GROUP BY o.[Id], o.[OrderDate], os.[Name]
//                  ORDER BY o.[Id]");
//            }
//        }
//    }
//    public class OrderSummary
//    {
//        public int ordernumber { get; set; }
//        public DateTime date { get; set; }
//        public string status { get; set; }
//        public double total { get; set; }
//    }
//}