using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableTrigger
    {
        public List<XModelSQL.SQLTableTrigger> Source { get; private set; }
        public List<XModelSQL.SQLTableTrigger> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableTrigger(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableTriggerList();
            this.Target = target.TableTriggerList();
        }
    }
}
