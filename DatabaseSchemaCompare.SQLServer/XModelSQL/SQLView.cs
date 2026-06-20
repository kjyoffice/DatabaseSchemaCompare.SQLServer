using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DatabaseSchemaCompare.SQLServer.XModelSQL
{
    public class SQLView
    {
        public XModelSQL_UseOriginal.SQLView Original { get; private set; }
        public string VIEW_NAME { get; private set; }
        public string VIEW_DEFINITION { get; private set; }
        public string CheckSource { get; private set; }

        // -----------------------------------------------------

        public SQLView(List<XModelSQL_Original.SQLView> spList)
        {
            var original = new XModelSQL_UseOriginal.SQLView(spList);
            var view_Definition = original.VIEW_DEFINITION.ToUpper();

            this.Original = original;
            this.VIEW_NAME = original.VIEW_NAME.ToUpper();
            this.VIEW_DEFINITION = view_Definition;
            this.CheckSource = XValue.ProcessValue.SHA512Hash(view_Definition);
        }
    }
}

