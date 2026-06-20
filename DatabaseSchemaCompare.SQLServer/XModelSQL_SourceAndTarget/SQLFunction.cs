using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_SourceAndTarget
{
    public class SQLFunction
    {
        public List<XModelSQL.SQLFunction> Source { get; private set; }
        public List<XModelSQL.SQLFunction> Target { get; private set; }

        // ----------------------------------------------------

        public SQLFunction(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.FunctionList();
            this.Target = target.FunctionList();
        }
    }
}
