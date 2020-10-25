/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProducerConsumerDemo.Code
{
    /// <summary>
    /// Adds items to the thread-safe data structure
    /// </summary>
    class Producer : BaseThread
    {
        // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
        SynchronizedCollection<String> bagOfStuff;
        ListBox lbProducer;
        public Producer(SynchronizedCollection<String> bagOfStuff, ListBox lbProducer) : base()
        {
            this.bagOfStuff = bagOfStuff;
            this.lbProducer = lbProducer;
        }

        public override void RunThread()
        {
            Random random = new Random(42);
            while(true)
            {
                Thread.Sleep(random.Next(10,1000));
                int r = random.Next();
                String tmp = Convert.ToString(r);
                Console.WriteLine("Producer: adding " + tmp );
                bagOfStuff.Add(tmp);
                if (lbProducer != null)
                {
                    lbProducer.Invoke(new MethodInvoker(delegate { lbProducer.Items.Insert(0, tmp); }));
                    //txtProducer.Text = myWidget.ElementAt<String>(0) + Environment.NewLine + txtProducer.Text;
                }
            }
        }
    }
}
