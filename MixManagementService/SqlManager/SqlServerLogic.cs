using System;
using System.Collections;
using System.Data.SqlClient;
using System.IO;

namespace MixManagementService.SqlManager
{
    public class SqlServerLogic : IDisposable
    {
        private SqlConnection sqlConn;
        private string connectString;

        /// <summary>
        /// 初始化sqlserver连接对象
        /// </summary>
        /// <param name="connectString"></param>
        public SqlServerLogic(string connectString)
        {
            this.connectString = connectString;
            sqlConn = new SqlConnection(connectString);
        }

        public int FromSql(string sql)
        {
            try
            {
                sqlConn.Open();
            }
            catch
            {
                MixLogHelper.Error(GetType().Name, "数据库连接异常：" + connectString);
                return -100;
            }
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = sqlConn;
                command.CommandText = sql;
                return command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MixLogHelper.Error(GetType().Name, "sql语句执行错误:" + sql, e.StackTrace);
                return -100;
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public ArrayList GetSqlFile(string varFileName, string dbname)
        {
            ArrayList alSql = new ArrayList();
            if (!File.Exists(varFileName))
            {
                return alSql;
            }
            StreamReader rs = new StreamReader(varFileName, System.Text.Encoding.Default);//注意编码
            string commandText = "";
            string varLine = "";
            while (rs.Peek() > -1)
            {
                varLine = rs.ReadLine();
                if (varLine == "")
                {
                    continue;
                }
                if (varLine != "GO" && varLine != "go")
                {
                    commandText += varLine;
                    commandText = commandText.Replace("@database_name=N'dbhr'", string.Format("@database_name=N'{0}'", dbname));
                    commandText += "\r\n";
                }
                else
                {
                    alSql.Add(commandText);
                    commandText = "";
                }
            }

            rs.Close();
            return alSql;
        }

        public bool ExecuteCommand(ArrayList varSqlList)
        {
            bool success = false;
            try
            {
                sqlConn.Open();
            }
            catch
            {
                MixLogHelper.Error(GetType().Name, "数据库连接异常：" + connectString);
                return false;
            }
            SqlTransaction varTrans = sqlConn.BeginTransaction();
            SqlCommand command = new SqlCommand();
            command.Connection = sqlConn;
            command.Transaction = varTrans;
            try
            {
                foreach (string varcommandText in varSqlList)
                {
                    command.CommandText = varcommandText;
                    command.ExecuteNonQuery();
                }
                varTrans.Commit();
                success = true;
            }
            catch (Exception ex)
            {
                varTrans.Rollback();
                MixLogHelper.Error(GetType().Name, "执行sql脚本错误", ex.StackTrace);
                success = false;
            }
            finally
            {
                sqlConn.Close();
            }
            return success;
        }

        public void Dispose()
        {
            if (sqlConn != null)
            {
                sqlConn.Close();
                sqlConn.Dispose();
                sqlConn = null;
            }
        }
    }
}
