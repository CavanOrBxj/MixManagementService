using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MixManagementService
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        static void Main()
        {
            #region 服务启动入口，正式用

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new ToolManagementService() };
            ServiceBase.Run(ServicesToRun);

            #endregion  
        }
    }
}
