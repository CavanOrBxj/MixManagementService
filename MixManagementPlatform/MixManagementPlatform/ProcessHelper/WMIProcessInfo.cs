using System;
using System.Data;
using System.Diagnostics;
using System.Management;

namespace MixManagementPlatform.ProcessHelper
{
    /// <summary>
    /// ProcessInfo class.
    /// </summary>
    public class WMIProcessInfo
    {
        // defenition of the delegates
        public delegate void StartedEventHandler(object sender, EventArgs e);
        public delegate void TerminatedEventHandler(object sender, EventArgs e);

        // events to subscribe
        public StartedEventHandler Started = null;
        public TerminatedEventHandler Terminated = null;

        // WMI event watcher
        private ManagementEventWatcher watcher;

        /// <summary>
        /// Construction that binds specific application with event declared
        /// </summary>
        /// <param name="LocalServerName"></param>
        /// <param name="appName"></param>
        public WMIProcessInfo(string appName)
        {
            // querry every 2 seconds
            string pol = "2";

            string queryString =
                "SELECT *" +
                "  FROM __InstanceOperationEvent " +
                "WITHIN  " + pol +
                " WHERE TargetInstance ISA 'Win32_Process' " +
                "   AND TargetInstance.Name = '" + appName + "'";

            string scope = @"//127.0.0.1/root/CIMV2";

            // create the watcher and start to listen
            watcher = new ManagementEventWatcher(scope, queryString);
            watcher.EventArrived += new EventArrivedEventHandler(this.OnEventArrived);
            watcher.Start();
        }

        /// <summary>
        /// Destruction function
        /// </summary>
        public void Dispose()
        {
            watcher.Stop();
            watcher.Dispose();
        }

        /// <summary>
        /// Get all processes that running in local machine
        /// </summary>
        /// <returns></returns>
        public static DataTable RunningProcesses()
        {
            // The second way of constructing a query
            string queryString =
                "SELECT Name, ProcessId, Caption, ExecutablePath" +
                "  FROM Win32_Process";

            SelectQuery query = new SelectQuery(queryString);
            ManagementScope scope = new ManagementScope(@"//127.0.0.1/root/CIMV2");

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection processes = searcher.Get();

            DataTable result = new DataTable();
            result.Columns.Add("Name", Type.GetType("System.String"));
            result.Columns.Add("ProcessId", Type.GetType("System.Int32"));
            result.Columns.Add("Caption", Type.GetType("System.String"));
            result.Columns.Add("Path", Type.GetType("System.String"));

            foreach (ManagementObject mo in processes)
            {
                DataRow row = result.NewRow();
                row["Name"] = mo["Name"].ToString();
                row["ProcessId"] = Convert.ToInt32(mo["ProcessId"]);
                if (mo["Caption"] != null)
                    row["Caption"] = mo["Caption"].ToString();
                if (mo["ExecutablePath"] != null)
                    row["Path"] = mo["ExecutablePath"].ToString();
                result.Rows.Add(row);
            }
            return result;
        }

        /// <summary>
        /// Get all processes that running in specific server
        /// </summary>
        /// <param name="sServerName"></param>
        /// <param name="sUserName"></param>
        /// <param name="sPassword"></param>
        /// <returns></returns>
        public static DataTable RunningProcesses(
            string sServerName,
            string sUserName,
            string sPassword)
        {
            // The second way of constructing a query
            string queryString =
                "SELECT Name, ProcessId, Caption, ExecutablePath" +
                "  FROM Win32_Process";

            SelectQuery query = new SelectQuery(queryString);

            //Set connection parameters
            ConnectionOptions options = new ConnectionOptions();
            options.Username = sUserName;
            options.Password = sPassword;

            //Create management scope
            ManagementScope scope = new ManagementScope(
                string.Format(@"//{0}/root/CIMV2", sServerName),
                options);

            //To connect
            try
            {
                scope.Connect();
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
            //catch
            //{
            //    return null;
            //}

            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectCollection processes = searcher.Get();

            DataTable result = new DataTable();
            result.Columns.Add("Name", Type.GetType("System.String"));
            result.Columns.Add("ProcessId", Type.GetType("System.Int32"));
            result.Columns.Add("Caption", Type.GetType("System.String"));
            result.Columns.Add("Path", Type.GetType("System.String"));

            foreach (ManagementObject mo in processes)
            {
                DataRow row = result.NewRow();
                row["Name"] = mo["Name"].ToString();
                row["ProcessId"] = Convert.ToInt32(mo["ProcessId"]);
                if (mo["Caption"] != null)
                    row["Caption"] = mo["Caption"].ToString();
                if (mo["ExecutablePath"] != null)
                    row["Path"] = mo["ExecutablePath"].ToString();
                result.Rows.Add(row);
            }
            return result;
        }

        /// <summary>
        /// Event handle function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnEventArrived(object sender, System.Management.EventArrivedEventArgs e)
        {
            try
            {
                string eventName = e.NewEvent.ClassPath.ClassName;
                Debug.WriteLine(eventName);

                if (eventName.CompareTo("__InstanceCreationEvent") == 0)
                {
                    // Started
                    if (Started != null)
                        Started(this, e);
                }
                else if (eventName.CompareTo("__InstanceDeletionEvent") == 0)
                {
                    // Terminated
                    if (Terminated != null)
                        Terminated(this, e);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

    }
}
