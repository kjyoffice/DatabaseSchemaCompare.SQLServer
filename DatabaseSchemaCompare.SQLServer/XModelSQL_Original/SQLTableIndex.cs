using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_Original
{
    public class SQLTableIndex
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string INDEX_TYPE { get; private set; }
        public string CLUSTERED_TYPE { get; private set; }
        public int KEY_ORDINAL { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string ORDERBY_TYPE { get; private set; }
        public bool IS_INCLUDED_COLUMN { get; private set; }
        public int INDEX_COLUMN_ID { get; private set; }
        public string OptionalDataX { get; private set; }

        // -----------------------------------------------------

        public SQLTableIndex(DataRow dr)
        {
            var schemaName = dr["SCHEMANAME"].ToString();
            var tableName = dr["TABLE_NAME"].ToString();
            var isDisabled = Convert.ToBoolean(dr["IS_DISABLED"]);

            this.TABLE_NAME = $"{schemaName}.{tableName}";
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.INDEX_TYPE = dr["INDEX_TYPE"].ToString();
            this.CLUSTERED_TYPE = dr["CLUSTERED_TYPE"].ToString();
            this.KEY_ORDINAL = Convert.ToInt32(dr["KEY_ORDINAL"]);
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.ORDERBY_TYPE = dr["ORDERBY_TYPE"].ToString();
            this.IS_INCLUDED_COLUMN = Convert.ToBoolean(dr["IS_INCLUDED_COLUMN"]);
            this.INDEX_COLUMN_ID = Convert.ToInt32(dr["INDEX_COLUMN_ID"]);
            this.OptionalDataX = string.Join(
                " ",
                new List<string>()
                {
                    $"[IS_DISABLED] {isDisabled}"
                }
            );
        }
    }
}

