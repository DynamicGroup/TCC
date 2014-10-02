using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DynamicService
{
    public static class Query
    {
        public static string ColumnInfoQuery = "SELECT c.name ColumnName,t.name as TypeName,c.max_Length as Max_Length,c.is_nullable as Is_Nullable  FROM sys.columns c "
        + "JOIN sys.types AS t ON c.user_type_id=t.user_type_id where object_id=Object_Id('{0}')";

        public static string GetConstraints = "SELECT B.COLUMN_NAME" +
        " FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS A, INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE B" +
        " WHERE CONSTRAINT_TYPE = '{0}' AND A.CONSTRAINT_NAME = B.CONSTRAINT_NAME" +
        " AND A.TABLE_NAME='{1}'";
    }
}
