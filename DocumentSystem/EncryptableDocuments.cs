using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

 
    public abstract class EncryptableDocuments : BinaryDocument, IEncryptable
    {
        private bool isEncrypted = false;
        public bool IsEncrypted
        {
            get { return this.isEncrypted; }
            protected set { this.isEncrypted = value; }
        }

        public void Encrypt()
        {
            this.IsEncrypted = true;
        }

        public void Decrypt()
        {
            this.IsEncrypted = false;
        }
        public override string ToString()
        {
            if (this.isEncrypted)
            {
                return String.Format("{0}[encrypted]", this.GetType().Name);
            }
            else
            {
                return base.ToString();
            }
        }
    }
 