using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public abstract class Document : IDocument
    {
        public string Name
        {
            get; private set; 
        }

        public string Content
        {
            get; protected set;
        }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }
            if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            //TextDocument[charset=utf-8;content=new content;name=example.txt]
            List<KeyValuePair<string, object>> properties = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(properties);
            StringBuilder result = new StringBuilder();

            // order by key
            var orderedProperties =
                from property in properties
                orderby property.Key
                select property;
                 
            result.Append(this.GetType().Name);
            result.Append("[");
            foreach (var property in orderedProperties)
            {
                if (property.Value != null)
                {
                    result.Append(property.Key);
                    result.Append("=");
                    result.Append(property.Value);
                    result.Append(';');
                }
            }
            result.Length--;
            result.Append("]");
            return result.ToString();
        }
    }
 