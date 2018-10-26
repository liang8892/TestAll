using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDBHelper
    {
        /// <summary>
        /// 执行查询，返回DataSet
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        DataSet Query(string sql);

        /// <summary>
        /// 执行单条语句，返回受影响的行数
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        int ExecuteSQL(string sql);

        /// <summary>
        /// 执行单条语句，返回受影响的行数，指定超时时长
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <param name="timeout">超时时长，毫秒</param>
        /// <returns></returns>
        int ExecuteSQLByTime(string sql, int timeout);

        /// <summary>
        ///  执行单条语句，返回由查询返回的结果集中的第一行的第一列
        /// </summary>
        /// <param name="sql"></param>
        /// <returns>由查询返回的结果集中的第一行的第一列</returns>
        object ExecuteSQLByTime(string sql);

        /// <summary>
        /// 用事务执行多条语句，返回受影响的行数
        /// </summary>
        /// <param name="sqls">SQL语句集合</param>
        /// <returns></returns>
        int DataBaseTransaction(string[] sqls);

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="storedProcName">存储过程名</param>
        /// <param name="parameters">存储过程参数</param>
        /// <param name="tableName">DataSet结果中的表名</param>
        /// <returns>DataSet</returns>
        DataSet RunProcedure(string storedProcName, IDataParameter[] parameters, string tableName);



    }
}
