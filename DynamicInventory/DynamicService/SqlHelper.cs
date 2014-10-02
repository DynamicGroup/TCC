using System;
using System.Data.SqlClient;
using System.Reflection;
using System.Data;
using System.Collections;

namespace DynamicService
{
    public enum Acao { I, UI, D };
    class SqlHelper
    {
        public static bool SqlSnapshot(object obj, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                var fields = obj.GetType().GetFields();

                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.Transaction = trans;
                    cmd.CommandType = CommandType.Text;
<<<<<<< HEAD:DynamicInventory/DynamicService/SqlHelper.cs
                    cmd.CommandText = GenerateScript(obj.GetType().Name, Acao.UI, conn, trans);
=======
                    cmd.CommandText = GenerateScript(obj.GetType().Name, conn, trans);
>>>>>>> parent of a543d9c... Agente, Banco e Ferramentas:DynamicInventory/DynamicServico/SqlHelper.cs

                    foreach (FieldInfo field in fields)
                    {
                        if ((!field.FieldType.Namespace.Contains("System.Collections.Generic")))
                            cmd.Parameters.AddWithValue("@"+field.Name, (field.FieldType.IsArray) ? DataValue.GetDataValue(null) : field.GetValue(obj).GetDataValue());
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

        public static string GenerateScript(string table, Acao acao, SqlConnection conn, SqlTransaction trans)
        {
            try
            {
                DataTable dt = ExecuteQuery(string.Format(Query.ColumnInfoQuery, table), conn, trans);

                string columns = String.Empty;
                string values = String.Empty;
                string update = String.Empty;

                foreach (DataRow row in dt.Rows)
                {
                    columns += row["ColumnName"].ToString() + ",";
                    values += "@" + row["ColumnName"].ToString() + ",";
                    update += row["ColumnName"].ToString() + " = " + "@" + row["ColumnName"].ToString() + ",";
                }

                IEnumerable Constraints = GetConstraints(string.Format(Query.GetConstraints, ((acao == Acao.UI) ? "PRIMARY KEY" : "FOREIGN KEY") , table), conn, trans);

                string condicao = String.Empty;

                foreach (string constraint in Constraints)
                {
                    condicao += constraint + " = " + "@" + constraint + " AND ";
                }

                string script = String.Empty;

                string updateInsert = "UPDATE {0} SET {1} WHERE {2} IF @@ROWCOUNT=0 INSERT INTO {0} ({3}) VALUES ({4});";

                string insert = "INSERT INTO {0} ({1}) VALUES ({2});";

                string delete = "DELETE FROM {0} WHERE {1}";

                switch (acao)
                {
                    case Acao.I: script = string.Format(insert, table, columns.TrimEnd(','), values.TrimEnd(',')); 
                        break;
                    case Acao.UI: script = string.Format(updateInsert, table, update.TrimEnd(','), condicao.Trim().Substring(0, condicao.Length - 5), columns.TrimEnd(','), values.TrimEnd(','));
                        break;
                    case Acao.D: script = string.Format(delete, table, condicao.Trim().Substring(0, condicao.Length - 5));
                        break;
                }

                return script;
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

        private static IEnumerable GetConstraints(string commandText, SqlConnection conn, SqlTransaction trans)
        {
            return from r in ExecuteQuery(commandText, conn, trans).AsEnumerable() select r.Field<string>("COLUMN_NAME");
        }
    }
}
