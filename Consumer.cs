using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Consumer : IObserver<Message>
    {
        private IDisposable unsubscriber;
        private string myName;
        public Consumer(string Name)
        {
            this.myName = Name;
        }
        public virtual void Subscribe(IObservable<Message> provider)
        {
            if (provider != null)
                this.unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        public void OnCompleted()
        {
            Console.WriteLine("Bye {0}.", this.myName);
            this.Unsubscribe();
        }

        public void OnError(Exception error)
        {
            Console.WriteLine("{0}: Cannot get message", this.myName);
        }

        public void OnNext(Message value)
        {
            Console.WriteLine("{1}: sent this message: {0}", value.Text, this.myName);
        }
    }
}
