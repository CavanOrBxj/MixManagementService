using System.Threading;
using System.Collections.Generic;
using System.Data;
using System.Collections.Concurrent;

namespace MixManagementService
{
    public class SingletonInfo
    {
        private static SingletonInfo _singleton;

        public string  SqlServerIP;
        public string SqlServerUser;
        public string SqlServerPWD;
        public bool IsFirstLogin;//表示重启或者断电后第一次登录
        public bool LoginFlag;//表示系统当前有没有用户登录

        private SingletonInfo()                                                                 
        {
            SqlServerIP = "";
            SqlServerUser = "";
            SqlServerPWD = "";
            IsFirstLogin = true;
            LoginFlag = true;

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