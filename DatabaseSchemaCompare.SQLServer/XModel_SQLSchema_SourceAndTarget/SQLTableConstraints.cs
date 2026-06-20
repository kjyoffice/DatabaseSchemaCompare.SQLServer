using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModel_SQLSchema_SourceAndTarget
{
    public class SQLTableConstraints
    {
        public List<XModelSQL.SQLTableConstraints> Source { get; private set; }
        public List<XModelSQL.SQLTableConstraints> Target { get; private set; }

        // ----------------------------------------------------

        public SQLTableConstraints(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.TableConstraintsList();
            this.Target = target.TableConstraintsList();
        }
    }
}
