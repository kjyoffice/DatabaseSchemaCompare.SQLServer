using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_Original
{
    public class SQLTable
    {
        public string TABLE_NAME { get; private set; }

        // ---------------------------------------------------

        public SQLTable(DataRow dr)
        {
            var schemaName = dr["SCHEMANAME"].ToString();
            var tableName = dr["TABLE_NAME"].ToString();

            this.TABLE_NAME = $"{schemaName}.{tableName}";
        }
    }
}
