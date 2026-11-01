using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_Original
{
    public class SQLTableForeignKey
    {
        public string TABLE_NAME { get; private set; }
        public string CONSTRAINT_NAME { get; private set; }
        public string COLUMN_NAME { get; private set; }
        public string REFERENCE_TABLE_NAME { get; private set; }
        public string REFERENCE_COLUMN_NAME { get; private set; }
        public string OptionalDataX { get; private set; }

        // -----------------------------------------------------

        public SQLTableForeignKey(DataRow dr)
        {
            var schemaName = dr["SCHEMANAME"].ToString();
            var tableName = dr["TABLE_NAME"].ToString();
            var deleteReferentialActionDesc = dr["DELETE_REFERENTIAL_ACTION_DESC"].ToString();
            var updateReferentialActionDesc = dr["UPDATE_REFERENTIAL_ACTION_DESC"].ToString();
            var isDisabled = dr["IS_DISABLED"].ToString();
            var isNotTrusted = dr["IS_NOT_TRUSTED"].ToString();
            var refSchemaName = dr["REFERENCE_SCHEMANAME"].ToString();
            var refTableName = dr["REFERENCE_TABLE_NAME"].ToString();

            this.TABLE_NAME = $"{schemaName}.{tableName}";
            this.CONSTRAINT_NAME = dr["CONSTRAINT_NAME"].ToString();
            this.COLUMN_NAME = dr["COLUMN_NAME"].ToString();
            this.REFERENCE_TABLE_NAME = $"{refSchemaName}.{refTableName}";
            this.REFERENCE_COLUMN_NAME = dr["REFERENCE_COLUMN_NAME"].ToString();
            this.OptionalDataX = string.Join(
                " ", 
                new List<string>()
                {
                    $"[DELETE_REFERENTIAL_ACTION_DESC] {deleteReferentialActionDesc}",
                    $"[UPDATE_REFERENTIAL_ACTION_DESC] {updateReferentialActionDesc}",
                    $"[IS_DISABLED] {isDisabled}",
                    $"[IS_NOT_TRUSTED] {isNotTrusted}"
                }
            );
        }
    }
}

