using Dos.Common;
using Dos.ORM;
using MixManagementPlatform.EntityModule;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MixManagementPlatform.SqlManager
{
    public class TModuleLogic
    {
        private static List<string> fieldList = new List<string>()
        {
            "id", "name", "path", "autostart", "delay", "state", "startindex", "arguments", "temtype",
        };

        /// <summary>
        /// 数据表是否存在，true为存在，否则为不存在
        /// </summary>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static bool IsTableExist(string tableName)
        {
            try
            {
                string sql = "select count(*) from sqlite_master where type='table' and name='" + tableName + "'";
                int existCode = Convert.ToInt32(DB.Context.FromSql(sql).ToScalar());
                return existCode == 1;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 新增数据。
        /// </summary>
        public static BaseResult InsertModule(TModule module)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(module.path))
                {
                    return new BaseResult(false, null, "参数错误！");
                }
                if (string.IsNullOrWhiteSpace(module.name))
                {
                    module.name = System.IO.Path.GetFileNameWithoutExtension(module.path);
                }
                module.state = -1;
                var count = DB.Context.Insert(module);
                return new BaseResult(count > 0, module, count > 0 ? "" : "数据库受影响行数为0！", count);
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 删除数据。必须传入Id
        /// </summary>
        public static BaseResult DeletModule(int id)
        {
            try
            {
                if (id < 0)
                {
                    return new BaseResult(false, null, "参数错误！");
                }
                var count = DB.Context.Delete<TModule>(d => d.id == id);
                return new BaseResult(count > 0, null, count > 0 ? "" : "数据库受影响行数为0！", count);
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 更新数据。必须传入Id
        /// </summary>
        public static BaseResult UpdateModule(TModule module)
        {
            try
            {
                if (module.id < 0)
                {
                    return new BaseResult(false, null, "参数错误！");
                }
                var model = DB.Context.From<TModule>().Where(d => d.id == module.id).First();
                if (model == null)
                {
                    return new BaseResult(false, null, "不存在要修改的数据！");
                }
                model.name = module.name;
                model.path = module.path;
                model.autostart = module.autostart;
                model.delay = module.delay;
                model.startindex = module.startindex;
                model.arguments = module.arguments;

                var count = DB.Context.Update(model);
                return new BaseResult(count > 0, model, count > 0 ? "" : "数据库受影响行数为0！", count);
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 更新多个字段。必须传入Id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="fields"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static BaseResult UpdateModule(int id, Field[] fields, object[] values)
        {
            try
            {
                if (id < 0)
                {
                    return new BaseResult(false, null, "参数错误！");
                }
                var model = DB.Context.From<TModule>().Where(d => d.id == id).First();
                if (model == null)
                {
                    return new BaseResult(false, null, "不存在要修改的数据！");
                }
                var where = new Where();
                where.And(TModule._.id == id);
                var count = DB.Context.Update<TModule>(fields, values, where);
                return new BaseResult(count > 0, model, count > 0 ? "" : "数据库受影响行数为0！", count);
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 根据id查询模块
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static BaseResult QureyModule(int id)
        {
            try
            {
                var fs = DB.Context.From<TModule>().Where(d => d.id == id);
                return new BaseResult(fs.Count() > 0, fs.First(), "数据库受影响行数为" + fs.Count().ToString() + "！", fs.Count());
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 根据除id和state外的字段进行查询
        /// </summary>
        /// <param name="module"></param>
        /// <returns></returns>
        public static BaseResult QureyModule(TModule module)
        {
            try
            {
                var where = new Where();
                #region 模糊查询
                if (!string.IsNullOrWhiteSpace(module.name))
                {
                    where.And(TModule._.name == module.name);
                }
                if (!string.IsNullOrWhiteSpace(module.path))
                {
                    where.And(TModule._.path == module.path);
                }
                if (!string.IsNullOrWhiteSpace(module.arguments))
                {
                    where.And(TModule._.arguments == module.arguments);
                }
                if (module.autostart > -2)
                {
                    where.And(TModule._.autostart == module.autostart);
                }
                if (module.delay > -2)
                {
                    where.And(TModule._.delay == module.delay);
                }
                if (module.startindex > -2)
                {
                    where.And(TModule._.startindex == module.startindex);
                }
                #endregion
                var fs = DB.Context.From<TModule>().Where(where);
                return new BaseResult(fs.Count() > 0, fs.ToList(), fs.Count() > 0 ? "" : "数据库受影响行数为0！", fs.Count());
            }
            catch(Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 查询所有字段
        /// </summary>
        /// <returns></returns>
        public static BaseResult QureyFieds()
        {
            try
            {
                string sql = "PRAGMA table_info([moduleinfo])";
                var data = DB.Context.FromSql(sql).ToDataTable();
                List<string> fields = new List<string>();
                foreach(DataRow row in data.Rows)
                {
                    fields.Add(row.ItemArray[1].ToString());
                }
                return new BaseResult(data.Rows.Count > 0, fields);
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }

        /// <summary>
        /// 验证字段是否都匹配
        /// </summary>
        /// <returns></returns>
        public static BaseResult VerifyField()
        {
            try
            {
                string sql = "PRAGMA table_info([moduleinfo])";
                var data = DB.Context.FromSql(sql).ToDataTable();
                bool fieldExist = fieldList.Count == data.Rows.Count;
                if (fieldExist)
                {
                    foreach (DataRow row in data.Rows)
                    {
                        if (!fieldList.Contains(row.ItemArray[1]))
                        {
                            fieldExist = false;
                            break;
                        }
                    }
                }
                return new BaseResult(fieldExist, fieldExist, fieldExist ? "数据表已存在" : "数据表字段不匹配");
            }
            catch (Exception e)
            {
                return new BaseResult(false, null, e.StackTrace);
            }
        }
    }
}
