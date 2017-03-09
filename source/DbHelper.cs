using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using System.Configuration;
using System.IO;
using MySoft.Common.DataBase;

namespace My.Tools.InstallDB
{
    //test
    public class DbHelper
    {
        private static IDBHelper fCS;

        public static List<string> ErrorLog = new List<string>();

        public static IDBHelper CS
        {
            get
            {
                if (fCS == null)
                {
                    fCS = DBHelperFactory.CreateHelper(DBEngineType.MSSQL,
                        ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString);
                    fCS.CommandTimeout = 3600;
                }
                return fCS;
            }
        }
   
        public static bool RunBat(IDBHelper db, string sql, bool throwException, DbTransaction trans)
        {
            db.CommandTimeout = 60 * 30;
            string[] arr = sql.Split(
                new string[] { " go ", Environment.NewLine + "go ", " go" + Environment.NewLine, Environment.NewLine + "go" + Environment.NewLine,
                " GO ", Environment.NewLine + "GO ", " GO" + Environment.NewLine, Environment.NewLine + "GO" + Environment.NewLine,
                " Go ", Environment.NewLine + "Go ", " Go" + Environment.NewLine, Environment.NewLine + "Go" + Environment.NewLine,
                " gO ", Environment.NewLine + "gO ", " gO" + Environment.NewLine, Environment.NewLine + "gO" + Environment.NewLine}
                , StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in arr)
            {
                if (string.IsNullOrEmpty(s) || s.Trim().Length == 0)
                    continue;
                if (throwException)
                    db.ExecuteNonQuery(db.GetSqlCommand(s), trans);
                else
                {
                    try
                    {
                        db.ExecuteNonQuery(db.GetSqlCommand(s), trans);
                    }
                    catch (Exception e)
                    {
                        ErrorLog.Add(e.Message + "=========>" + s);
                    }
                }
            }
            return true;
        }
        public static bool RunBat(IDBHelper db, string sql, DbTransaction trans)
        {
            return RunBat(db, sql, true, trans);
        }
        public static bool RunBat(IDBHelper db, string sql)
        {
            return RunBat(db, sql, true, null);
        }

        public static DataSet Run(IDBHelper db, string sql)
        {
            using(DbConnection conn = db.CreateConnection())
            {
                conn.Open();
                DbCommand cmd = conn.CreateCommand();
                cmd.CommandText = sql;
                using (DbDataAdapter adapter = db.CreateDataAdapter())
                {
                    DataSet ds = new DataSet();
                    adapter.SelectCommand = cmd;
                    adapter.Fill(ds);
                    return ds;
                }
            }
        }
    }
}
