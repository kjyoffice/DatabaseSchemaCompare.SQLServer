using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_SourceAndTarget
{
    public class SQLTableForeignKey
    {
        public List<XModelSQL.SQLTableForeignKey> Source { get; private set; }
        public List<XModelSQL.SQLTableForeignKey> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableForeignKey(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableForeignKeyList();
            this.Target = target.TableForeignKeyList();
        }
    }
}
