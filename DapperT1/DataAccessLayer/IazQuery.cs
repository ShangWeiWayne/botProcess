using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperT1.DataAccessLayer
{
    interface IazQuery
    {
        //void getStatus(string _userID)
        string getStatus(string _userID);
        void resetStatus(string _status);

    }
}
