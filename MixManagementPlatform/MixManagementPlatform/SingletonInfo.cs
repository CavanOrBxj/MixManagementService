using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Collections.Concurrent;

namespace MixManagementPlatform
{
    public class SingletonInfo
    {
        private static SingletonInfo _singleton;

        public string  SqlServerIP;
        public string SqlServerUser;
        public string SqlServerPWD;
    
     

        private SingletonInfo()                                                                 
        {
            SqlServerIP = "";
            SqlServerUser = "";
            SqlServerPWD = ""; 

        }

   
        public static SingletonInfo GetInstance()
        {
            if (_singleton == null)
            {
                Interlocked.CompareExchange(ref _singleton, new SingletonInfo(), null);
            }
            return _singleton;
        }
    }
}