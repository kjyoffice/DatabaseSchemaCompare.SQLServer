using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModel_SQLSchema_UseSupport
{
    public class SQLTableResult
    {
        public List<XModelSQL.SQLTable> ExistTableList { get; private set; }
        public List<XModelSQL.SQLTable> NotExistTableList { get; private set; }

        // -----------------------------------

        public SQLTableResult(List<XModelSQL.SQLTable> existTableList, List<XModelSQL.SQLTable> notExistTableList)
        {
            this.ExistTableList = existTableList;
            this.NotExistTableList = notExistTableList;
        }
    }
}
