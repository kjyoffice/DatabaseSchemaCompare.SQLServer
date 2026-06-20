using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_SourceAndTarget
{
    public class SQLView
    {
        public List<XModelSQL.SQLView> Source { get; private set; }
        public List<XModelSQL.SQLView> Target { get; private set; }

        // ----------------------------------------------------

        public SQLView(XData.SQLWork source, XData.SQLWork target)
        {
            this.Source = source.ViewList();
            this.Target = target.ViewList();
        }
    }
}
