using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL_UseOriginal
{
    public class SQLView
    {
        public string VIEW_NAME { get; private set; }
        public string VIEW_DEFINITION { get; private set; }

        // -----------------------------------------------------

        public SQLView(List<XModelSQL_Original.SQLView> spList)
        {
            var sp1 = spList[0];

            this.VIEW_NAME = sp1.VIEW_NAME;
            this.VIEW_DEFINITION = string.Join(string.Empty, spList.Select(x => x.VIEW_DEFINITION)).Trim();
        }
    }
}
