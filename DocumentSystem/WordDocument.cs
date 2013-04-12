using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public class WordDocument : OfficeDocuments, IEditable
    {
        public int CharactersNumber
        {
            get;
            protected set;
        }

        public override void LoadProperty(string key, string value)
        {
            if (key == "chars")
            {
                this.CharactersNumber = int.Parse(value);
            }
            else
            {
                base.LoadProperty(key, value);
            }
        }

        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            base.SaveAllProperties(output);
            output.Add(new KeyValuePair<string, object>("chars", this.CharactersNumber));
        }

        public void ChangeContent(string newContent)
        {
            this.Content = newContent;
        }
    }
 
