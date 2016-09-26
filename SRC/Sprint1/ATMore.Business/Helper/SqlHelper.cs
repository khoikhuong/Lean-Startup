using System.Text;
using System.Collections.Generic;

namespace ATMore.Business.Helper
{
    public class SqlHelper
    {
        public static string SQL_PARAM_FORMAT = "P{0}";

        public static string GetParamName(int IndexParm)
        {
            return string.Format(SQL_PARAM_FORMAT, IndexParm);
        }

        public static string Select(string tbName, string[] aColumn, string[] WhereColumns, params string[] orderStm)
        {
            string sql = "SELECT {0} FROM [dbo].[{1}]";
            if (aColumn != null && aColumn.Length > 0)
            {
                string columns = string.Join(",", aColumn);
                sql = string.Format(sql, columns, tbName);
            }
            else
            {
                sql = string.Format(sql, "*", tbName);
            }

            StringBuilder sqlSelect = new StringBuilder(sql);
            if (WhereColumns != null && WhereColumns.Length > 0)
            {
                sqlSelect.Append(" WHERE ");

                int p = 0;
                foreach (string column in WhereColumns)
                {
                    sqlSelect.AppendFormat(" {0} = @{1} ", column, GetParamName(p));
                    p++;
                }
            }

            if (orderStm != null && orderStm.Length > 0) sqlSelect.AppendFormat(" ORDER BY {0}", string.Join(",", orderStm));

            return sqlSelect.ToString();
        }
        
        public static string Insert(string tbName, params string[] Columns)
        {
            StringBuilder sqlInsert = new StringBuilder();
            if (Columns == null) return sqlInsert.ToString();
            string columns = string.Join(",", Columns);
            
            IList<string> values = new List<string>();
            for (int i = 0; i < Columns.Length; i++) values.Add("@" + GetParamName(i));

            sqlInsert.AppendFormat("INSERT INTO [dbo].[{0}] ({1}) VALUES ({2}) ", tbName, columns, string.Join(",", values));

            return sqlInsert.ToString();
        }

        public static string Update(string tbName, params string[] Columns)
        {
            StringBuilder sqlUpdate = new StringBuilder();
            if (Columns == null) return sqlUpdate.ToString();
            sqlUpdate.AppendFormat("UPDATE [dbo].[{0}] ", tbName);

            IList<string> values = new List<string>();
            int p = 0;
            foreach (string column in Columns)
            {
                values.Add(string.Format("{0} = @{1}", column, GetParamName(p)));
                p++;
            }

            sqlUpdate.Append(" SET ");
            sqlUpdate.Append(string.Join(",", values));

            return sqlUpdate.ToString();
        }

        public static string Update(string tbName, string[] Columns, string[] WhereColumns)
        {
            StringBuilder sqlUpdate = new StringBuilder(Update(tbName, Columns));
            if (WhereColumns != null && WhereColumns.Length > 0)
            {
                sqlUpdate.Append(" WHERE ");
                int p = Columns.Length;
                foreach (string column in WhereColumns)
                {
                    sqlUpdate.AppendFormat(" {0} = @{1} ", column, GetParamName(p));
                    p++;
                }
            }
            return sqlUpdate.ToString();
        }

        public static string Delete(string tbName, params string[] WhereColumns)
        {
            StringBuilder sqlDelete = new StringBuilder();
            sqlDelete.AppendFormat("DELETE FROM [dbo].[{0}] ", tbName);

            if (WhereColumns != null && WhereColumns.Length > 0)
            {
                sqlDelete.Append(" WHERE ");
                int p = 0;
                foreach (string column in WhereColumns)
                {
                    sqlDelete.AppendFormat(" {0} = @{1} ", column, GetParamName(p));
                    p++;
                }
            }

            return sqlDelete.ToString();
        }

        public static void Main()
        {
            
        }
    }
}
