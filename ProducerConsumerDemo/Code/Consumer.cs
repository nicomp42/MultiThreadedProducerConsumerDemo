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
        // https://docs.microsoft.com/en-us/dotnet/standard/collections/thread-safe/
        private SynchronizedCollection<String> widgets;
        private String id;
        private TextBox txtConsumer;
        public Consumer(String id, SynchronizedCollection<String> bagOfStuff, TextBox txtConsumer) : base()
        {
            this.widgets = bagOfStuff;
            this.id = id;
            this.txtConsumer = txtConsumer;
        }

        public override void RunThread()
        {
            while (true)
            {
                Thread.Sleep(500);  // Just to make it look real
                if (widgets.Count > 0)
                {
                    // There's a widget in the collection
                    String myWidget = widgets.ElementAt<String>(0);
                    widgets.Remove(widgets.ElementAt<String>(0));
                    Console.WriteLine("Consumer " + id + ": Widget  = " + myWidget);
                    if (txtConsumer != null)
                    {
                        txtConsumer.Invoke(new MethodInvoker(delegate { txtConsumer.Text = myWidget + Environment.NewLine + txtConsumer.Text; }));

                        //txtConsumer.Text = myWidget.ElementAt<String>(0) + Environment.NewLine + txtConsumer.Text;
                    }
                }
            }
        }
    }
}
