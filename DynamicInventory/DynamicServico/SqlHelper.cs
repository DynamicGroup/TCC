using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;

namespace DynamicService
{
    class SqlHelper
    {
        public static bool SqlSnapshot(object obj, string sql, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                var fields = obj.GetType().GetFields();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Connection = conn;
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = GenerateScript(obj.GetType().Name, conn, trans);

                    foreach (FieldInfo field in fields)
                    {
                        if ((!field.FieldType.Namespace.Contains("System.Collections.Generic")) && (!field.FieldType.IsArray))
                            cmd.Parameters.AddWithValue(field.Name, field.GetValue(obj.GetDataValue()));
                    }

                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return false;
            }
        }

        private static string GenerateScript(string table, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                DataTable dt = ExecuteQuery(string.Format(Singleton.Instance.columnInfoQuery, table), conn, trans);

                string columns = String.Empty;
                string values = String.Empty;

                columns = string.Format(" INSERT INTO {0}(", table);
                values = " VALUES (";
                foreach (DataRow row in dt.Rows)
                {
                    columns += row["ColumnName"].ToString() + ",";
                    values += "@" + row["ColumnName"].ToString() + ",";
                }

                return columns.TrimEnd(',') + ")" + values.TrimEnd(',') + ");";
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return String.Empty;
            }
        }

        private static DataTable ExecuteQuery(string commandText, SqlConnection conn, SqlTransaction trans)
        {
            DataTable resultDataTable = new DataTable();
            try
            {

                using (SqlCommand cmd = new SqlCommand(commandText, conn))
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(resultDataTable);
                    }
                }

                return resultDataTable;
            }
            catch (Exception e)
            {
                Singleton.Instance.registraLog(e.Message + e.StackTrace);
                return resultDataTable;
            }
        }
    }
}
