using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace DL.Util
{
    public class DALHelper
    {
        /// <summary>
        /// This method replaces the ' with '' to fix the sql injection problems in sqlexec method
        /// </summary>
        /// <param name="Param"></param>
        /// <returns>Fixed Parameter</returns>
        public static string FixInjection(string Param)
        {
            if (!string.IsNullOrEmpty(Param))
            {
                Param = Param.Replace("[", "[[]");
                Param = Param.Replace("'", "");
                Param = Param.Replace("<", "");
                Param = Param.Replace(">", "");
            }
            return Param;
        }

        public static string FixUnderScore(string Param)
        {
            if (Param.Length == 1 && Param == "_")
                Param = Param.Replace("_", "-");
            return Param;
        }
        /// <summary>
        /// This method replaces the ' with \' to escape the single quote in the javascript function calls
        /// </summary>
        /// <param name="Param"></param>
        /// <returns>Fixed Parameter</returns>
        public static string FixInjectionJavaScript(string Param)
        {
            return Param.Replace("'", "\\'");
        }

        public static string FixHTMLEncoding(string param)
        {
            return param.Replace(" ", "&nbsp;");
        }

        public static DataSet ExecStrAsDS(string ControlSqlStatement)
        {
            DataSet functionReturnValue = default(DataSet);
            SqlConnection conn = new SqlConnection(Global.ConnectionString);
            dynamic cmd = new SqlCommand(ControlSqlStatement, conn) { CommandTimeout = 120 };
            DataSet DSet = new DataSet();
            SqlDataAdapter ParrAdd = new SqlDataAdapter(cmd);
            try
            {
                conn.Open();
                ParrAdd.Fill(DSet, "info");
                functionReturnValue = DSet;

            }
            catch (Exception ex)
            {
                return DSet;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
                cmd.Dispose();
                DSet.Dispose();
            }
            return functionReturnValue;
        }

        public static DataTable CopyGenericToDataTable(IEnumerable varlist)
        {
            DataTable dtReturn = new DataTable();

            // column names
            PropertyInfo[] oProps = null;

            if (varlist == null) return dtReturn;

            foreach (var rec in varlist)
            {
                // Use reflection to get property names, to create table, Only first time, others will follow
                if (oProps == null)
                {
                    oProps = ((Type)rec.GetType()).GetProperties();
                    foreach (PropertyInfo pi in oProps)
                    {
                        Type colType = pi.PropertyType;

                        if ((colType.IsGenericType) && (colType.GetGenericTypeDefinition() == typeof(Nullable<>)))
                        {
                            colType = colType.GetGenericArguments()[0];
                        }

                        dtReturn.Columns.Add(new DataColumn(pi.Name, colType));
                    }
                }
                DataRow dr = dtReturn.NewRow();

                foreach (PropertyInfo pi in oProps)
                {
                    dr[pi.Name] = pi.GetValue(rec, null) == null ? DBNull.Value : pi.GetValue(rec, null);
                }

                dtReturn.Rows.Add(dr);
            }
            return dtReturn;
        }

        public static DataTable getDataTableFromStoredProcedure(string StoredProcedureName, SqlParameter[] ParametersList)
        {
            DataTable dt = new DataTable();

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                try
                {
                    con.Open();
                    cmd.CommandTimeout = 1000;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcedureName;

                    SqlDataAdapter da = new SqlDataAdapter();
                    if (ParametersList != null)
                        for (int i = 0; i < ParametersList.Length; i++)
                        {
                            cmd.Parameters.Add(ParametersList[i]);
                        }

                    da.SelectCommand = cmd;
                    da.Fill(dt);
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return dt;
        }

        public static DataSet getDataSetFromStoredProcedure(string StoredProcedureName, SqlParameter[] ParametersList)
        {
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con.Open();
                    cmd.CommandTimeout = 1000;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcedureName;

                    SqlDataAdapter da = new SqlDataAdapter();
                    if (ParametersList != null)
                        for (int i = 0; i < ParametersList.Length; i++)
                        {
                            cmd.Parameters.Add(ParametersList[i]);
                        }

                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return ds;
        }

        public static int ExecuteNonQuerySQL(string SQL)
        {
            DataTable dt = new DataTable();
            int returnValue = 0;

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();

                try
                {
                    con.Open();
                    cmd.CommandTimeout = 1000;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = SQL;

                    returnValue = cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return returnValue;
        }

        public static object ExecuteScalarProcedure(string StoredProcedureName, SqlParameter[] ParametersList)
        {
            object _return;

            using (SqlConnection con = new SqlConnection(Global.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand();
                try
                {
                    con.Open();
                    cmd.CommandTimeout = 1000;
                    cmd.Connection = con;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = StoredProcedureName;

                    if (ParametersList != null)
                        for (int i = 0; i < ParametersList.Length; i++)
                        {
                            cmd.Parameters.Add(ParametersList[i]);
                        }

                    _return = cmd.ExecuteScalar();
                    con.Close();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return _return;
        }
    }
}
