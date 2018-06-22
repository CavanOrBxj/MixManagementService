
using MixManagementService.EntityModule;
using System;
using System.Data;
using System.Data.SQLite;

namespace MixManagementService.SqlManager
{
    public class SqliteLogic : IDisposable
    {
        private SQLiteConnection sqliteConn;
        private string connectString;

        public SqliteLogic(string connectString)
        {
            this.connectString = connectString;
            //string sql = System.Configuration.ConfigurationManager.ConnectionStrings["SqliteConn"].ConnectionString;
            sqliteConn = new SQLiteConnection(connectString);
            sqliteConn.Open();
        }

        public bool IsTableExist(string tableName)
        {
            using (SQLiteCommand cmd = sqliteConn.CreateCommand())
            {
                //判断表是否存在
                cmd.CommandText = "select count(*) from sqlite_master where type='table' and name='" + tableName + "'";
                int existCode = Convert.ToInt32(cmd.ExecuteScalar());
                return existCode == 1;
            }
        }

        public int InsertModule(TModule module)
        {
            string sql = string.Format("insert into moduleinfo (name, path, autostart, delay, state, startindex, arguments) values ('{0}', '{1}', {2}, {3}, {4}, {5}, '{6}')",
                new object[] { module.name, module.path, module.autostart, module.delay, -1, module.startindex, module.arguments });
            SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
            return command.ExecuteNonQuery();
        }

        public DataTable GetModules(string orderByName)
        {
            string sql;
            if (string.IsNullOrWhiteSpace(orderByName))
            {
                sql = "select * from moduleinfo";
            }
            else
            {
                sql = "select * from moduleinfo order by " + orderByName;
            }
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, sqliteConn);
            DataTable ds = new DataTable("module");
            adapter.Fill(ds);
            return ds;
        }

        /// <summary>
        /// 更新模块信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="module"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="FormatException"/>
        public int UpdateModule(int id, TModule module)
        {
            string sql = string.Format("update moduleinfo set name='{0}', path='{1}', autostart={2}, delay={3}, startindex={4}, arguments='{5}' where id={6}",
                new object[] { module.name, module.path, module.autostart, module.delay, module.startindex, module.arguments, id });
            SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
            return command.ExecuteNonQuery();
        }

        public int UpdateModuleState(int id)
        {
            string sql = string.Format("update moduleinfo set state={0} where id={1}",
                new object[] { -1, id });
            SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
            return command.ExecuteNonQuery();
        }

        public int FromSql(string sql)
        {
            try
            {
                SQLiteCommand command = new SQLiteCommand(sql, sqliteConn);
                return command.ExecuteNonQuery();
            }
            catch
            {
                return -1;
            }
        }

        public DataSet FromSqlForReader(string sql)
        {
            try
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(sql, sqliteConn);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                return ds;
            }
            catch
            {
                return null;
            }
        }

        public void Dispose()
        {
            if (sqliteConn != null)
            {
                sqliteConn.Close();
                sqliteConn.Dispose();
                sqliteConn = null;
            }
        }
    }
}
