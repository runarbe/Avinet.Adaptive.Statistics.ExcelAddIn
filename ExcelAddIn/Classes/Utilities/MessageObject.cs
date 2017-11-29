using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Avinet.Adaptive.Statistics.ExcelAddIn
{
    public class MessageObject : Dictionary<string, int>
    {
        public void AddMessage(string pMessage) {
            if (this.Keys.Contains(pMessage)) {
                this[pMessage]++;
            } else {
                this.Add(pMessage,1);
            }
        }

        public string GetMessages()
        {
            var mMessages = new StringBuilder();

            foreach (var mKey in this.Keys)
            {
                mMessages.AppendFormat("{0} ({1} tilfelle){2}", mKey, this[mKey], Environment.NewLine); 
            }
            return mMessages.ToString();
        }
    }
}
