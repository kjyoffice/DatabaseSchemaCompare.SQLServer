using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_SourceAndTarget
{
    public class SQLTableIndex
    {
        public List<XModelSQL.SQLTableIndex> Source { get; private set; }
        public List<XModelSQL.SQLTableIndex> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableIndex(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableIndexList();
            this.Target = target.TableIndexList();
        }
    }
}
