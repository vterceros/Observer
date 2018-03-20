using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Task<int> task = MyAsyncTask();
            Consumer cons1 = new Consumer("Cons 1");
            Consumer cons2 = new Consumer("Cons 2");

            Provider provider = new Provider();

            cons1.Subscribe(provider);
            cons2.Subscribe(provider);
            Message msg = new Message("Hello baby");
            Message msg2 = msg.Clone() as Message;
            Message msg3 = msg.CloneShallow();
            provider.SendMessage(msg2);
            provider.SendMessage(msg3);
            provider.EndTransmission();
            Console.ReadKey();
        }

       static async Task<int> MyAsyncTask()
        {
            throw new NotImplementedException();
        }
    }
}
