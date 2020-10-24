/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
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
        private Producer producer;
        private Consumer consumer;

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
            SynchronizedCollection<String> widgets = new SynchronizedCollection<String>();
            producer = new Producer(widgets, txtProducer);
            consumer = new Consumer("001", widgets, txtConsumer);
            producer.Start();
            consumer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {producer.Abort(); } catch (Exception ex) { };
            try {consumer.Abort();  } catch (Exception ex) { };
}
    }
}
