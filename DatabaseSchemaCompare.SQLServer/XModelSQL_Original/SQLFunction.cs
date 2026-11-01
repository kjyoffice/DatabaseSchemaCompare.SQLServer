using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_Original
{
    public class SQLFunction
    {
        public string FUNCTION_NAME { get; private set; }
        public string FUNCTION_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLFunction(DataRow dr)
        {
            var schemaName = dr["SCHEMANAME"].ToString();
            var functionName = dr["FUNCTION_NAME"].ToString();

            this.FUNCTION_NAME = $"{schemaName}.{functionName}";
            this.FUNCTION_DEFINITION = dr["FUNCTION_DEFINITION"].ToString();
        }
    }
}
