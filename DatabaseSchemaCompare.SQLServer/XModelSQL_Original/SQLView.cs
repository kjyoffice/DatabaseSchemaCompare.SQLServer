using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_Original
{
    public class SQLView
    {
        public string VIEW_NAME { get; private set; }
        public string VIEW_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLView(DataRow dr)
        {
            this.VIEW_NAME = dr["VIEW_NAME"].ToString();
            this.VIEW_DEFINITION = dr["VIEW_DEFINITION"].ToString();
        }
    }
}
