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
        TextBox txtProducer;
        public Producer(SynchronizedCollection<String> bagOfStuff, TextBox txtProducer) : base()
        {
            this.bagOfStuff = bagOfStuff;
            this.txtProducer = txtProducer;
        }

        public override void RunThread()
        {
            Random random = new Random(42);
            while(true)
            {
                Thread.Sleep(random.Next(100,5000));
                int r = random.Next();
                String tmp = Convert.ToString(r);
                Console.WriteLine("Producer: adding " + tmp );
                bagOfStuff.Add(tmp);
                if (txtProducer != null)
                {
                    txtProducer.Invoke(new MethodInvoker(delegate { txtProducer.Text = tmp + Environment.NewLine + txtProducer.Text; }));
                    //txtProducer.Text = myWidget.ElementAt<String>(0) + Environment.NewLine + txtProducer.Text;
                }

            }
        }
    }
}
