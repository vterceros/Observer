using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Message : ICloneable, IEnumerable
    {
        string text;

        public Message(string newText)
        {
            this.text = newText;
        }

        public string Text
        {
            get
            {
                return this.text;
            }
        }
        public Message CloneShallow()
        {
            return (Message)this.MemberwiseClone();
        }

        public object Clone()
        {
            return new Message(this.text);
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
