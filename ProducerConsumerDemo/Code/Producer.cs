using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProducerConsumerDemo.Code
{
    class Producer : BaseThread
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
        ConcurrentBag<IEnumerable<String>> bagOfStuff;
        public Producer(ConcurrentBag<IEnumerable<String>> bagOfStuff) : base()
        {
            this.bagOfStuff = bagOfStuff;
        }

        public override void RunThread()
        {
            Random random = new Random(42);
            while(true)
            {
                Thread.Sleep(20);
                int r = random.Next();
                String tmp = Convert.ToString(r);
                IEnumerable<String> rString = new[] { tmp };
                Console.WriteLine("Producer: adding " + tmp + " : " + rString.ElementAt<String>(0));
                bagOfStuff.Add(rString);
            }
        }
    }
}
