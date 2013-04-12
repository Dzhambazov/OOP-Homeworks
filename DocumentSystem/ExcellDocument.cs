using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public class ExcelDocument : OfficeDocuments
    {
        public int RowsNumber
        {
            get;
            protected set;
        }

        public int ColsNumber
        {
            get;
            protected set;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "rows")
            {
                this.RowsNumber = int.Parse(value);
            }
            else if(key == "cols")
            {
                this.ColsNumber = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("rows", this.RowsNumber));
            output.Add(new KeyValuePair<string, object>("cols", this.ColsNumber));
        }
    }
 