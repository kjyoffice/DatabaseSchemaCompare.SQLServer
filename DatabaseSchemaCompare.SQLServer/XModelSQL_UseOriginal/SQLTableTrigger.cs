using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_UseOriginal
{
    public class SQLTableTrigger
    {
        public string TABLE_NAME { get; private set; }
        public string TRIGGER_NAME { get; private set; }
        public string TRIGGER_SCHEMA { get; private set; }

        // -----------------------------------------------------

        public SQLTableTrigger(string table_Name, string trigger_Name, List<XModelSQL_Original.SQLTableTrigger> sttList)
        {
            this.TABLE_NAME = table_Name;
            this.TRIGGER_NAME = trigger_Name;
            this.TRIGGER_SCHEMA = string.Join(string.Empty, sttList.Select(x => x.TRIGGER_SCHEMA)).Trim();
        }
    }
}
