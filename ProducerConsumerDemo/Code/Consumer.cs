/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */ 
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using System.Windows.Forms;

namespace ProducerConsumerDemo.Code
{

    /// <summary>
    /// Consumes items placed in a thread-safe data structure.
    /// </summary>
    class Consumer : BaseThread
    {
        static readonly object _myLock = new object();

        // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
        private SynchronizedCollection<String> widgets;
        private String id;
        private ListBox lbConsumer;
        public Consumer(String id, SynchronizedCollection<String> bagOfStuff, ListBox lbConsumer) : base()
        {
            this.widgets = bagOfStuff;
            this.id = id;
            this.lbConsumer = lbConsumer;
        }

#if YOU_WANT_THIS_TO_FAIL
        public override void RunThread()
        {
            while (true)
            {
                Thread.Sleep(500);  // Just to make it seem real
                // This code will evrntually FAIL if >1 consumer threads are running. 
                if (widgets.Count > 0)
                {
                    // There's a widget in the collection
                    String myWidget = widgets.ElementAt<String>(0); // Could fail here
                    widgets.Remove(widgets.ElementAt<String>(0));   // Could fail here
                    Console.WriteLine("Consumer " + id + ": Widget  = " + myWidget);
                    if (txtConsumer != null)
                    {
                        txtConsumer.Invoke(new MethodInvoker(delegate { txtConsumer.Text = myWidget + Environment.NewLine + txtConsumer.Text; }));

                        //txtConsumer.Text = myWidget.ElementAt<String>(0) + Environment.NewLine + txtConsumer.Text;
                    }
                }
            }
        }
#else
        public override void RunThread()
        {
            String myWidget = null;
            while (true)
            {
                Thread.Sleep(500);  // Just to make it seem real
                lock (_myLock)  // Keep the single-threaded code as small as possible.
                {
                    if (widgets.Count > 0)
                    {
                        // There's a widget in the collection
                        myWidget = widgets.ElementAt<String>(0); // Could fail here
                        widgets.Remove(widgets.ElementAt<String>(0));   // Could fail here
                    }
                }
                if (myWidget != null) {
                    Console.WriteLine("Consumer " + id + ": Widget  = " + myWidget);
                    if (lbConsumer != null)
                    {
                        lbConsumer.Invoke(new MethodInvoker(delegate { lbConsumer.Items.Insert(0, myWidget); }));
                        myWidget = null;
                    }    
                }
                
            }
        }

#endif
    }
}
