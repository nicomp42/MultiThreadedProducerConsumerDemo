using ProducerConsumerDemo.Code;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProducerConsumerDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartDemo();
        }
        /// <summary>
        /// Demonstrate Producer/Consumer design pattern
        /// </summary>
        private void StartDemo()
        {
            ConcurrentBag<IEnumerable<String>> widgets = new ConcurrentBag<IEnumerable<string>>();
            Producer producer = new Producer(widgets);
            Consumer consumer = new Consumer("001", widgets);
            producer.Start();
            consumer.Start();
        }
    }
}
