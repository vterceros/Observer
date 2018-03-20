using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    public class Provider : IObservable<Message>
    {
        private List<IObserver<Message>> listOfObservers;
        public Provider()
        {
            this.listOfObservers = new List<IObserver<Message>>();
        }
        public IDisposable Subscribe(IObserver<Message> observer)
        {
            if (!listOfObservers.Contains(observer))
                listOfObservers.Add(observer);
            return new Unsubscriber(listOfObservers, observer);
        }
        public void SendMessage(Message loc)
        {
            foreach (var observer in this.listOfObservers)
            {
                if (loc == null)
                    observer.OnError(new Exception("Null Message"));
                else
                    observer.OnNext(loc);
            }
        }

        public void EndTransmission()
        {
            foreach (var observer in this.listOfObservers.ToArray())
                if (this.listOfObservers.Contains(observer))
                    observer.OnCompleted();

            this.listOfObservers.Clear();
        }
    }

    internal class Unsubscriber : IDisposable
    {
        private List<IObserver<Message>> listOfObservers;
        private IObserver<Message> observer;

        public Unsubscriber(List<IObserver<Message>> listOfObservers, IObserver<Message> observer)
        {
            this.listOfObservers = listOfObservers;
            this.observer = observer;
        }

        public void Dispose()
        {
            if (!(observer == null)) listOfObservers.Remove(observer);
        }
    }
    
}
