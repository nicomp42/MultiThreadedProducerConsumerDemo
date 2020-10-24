using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerDemo.Code
{
    class Consumer : BaseThread
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
        private ConcurrentBag<IEnumerable<string>> widgets;
        private String id;
        public Consumer(String id, ConcurrentBag<IEnumerable<string>> bagOfStuff) : base()
        {
            this.widgets = bagOfStuff;
            this.id = id;
        }

        public override void RunThread()
        {
            while (true)
            {
                Thread.Sleep(50);
                if (widgets.Count > 0)
                {
                    // There's a widget in the bag
                    IEnumerable<IEnumerable<string>> myWidgets = widgets.Take(1);
                    IEnumerable<String> myWidget = myWidgets.First();
                    Console.WriteLine("Consumer " + id + ": Widget  = " + myWidget.ElementAt<String>(0));
                }
            }
        }
    }
}
