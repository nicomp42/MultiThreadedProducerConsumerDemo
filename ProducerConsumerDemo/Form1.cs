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
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProducerConsumerDemo
{
    public partial class frmProducerConsumerDemo : Form
    {
        private Producer producer;
        private Consumer consumer01;
        private Consumer consumer02;
        private Stopwatch stopWatch;

        public frmProducerConsumerDemo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartDemo();
            lblStatus.Visible = true;
            btnStop.Visible = true;
        }
        /// <summary>
        /// Demonstrate Producer/Consumer design pattern
        /// </summary>
        private void StartDemo()
        {
            SynchronizedCollection<String> widgets = new SynchronizedCollection<String>();
            lbProducer.Items.Clear();
            lbConsumer01.Items.Clear();
            lbConsumer02.Items.Clear();
            txtResults.Text = "";
            txtResults.Visible = false;
            btnStop.Visible = true;
            producer = new Producer(widgets, lbProducer);
            consumer01 = new Consumer("01", widgets, lbConsumer01);
            consumer02 = new Consumer("02", widgets, lbConsumer02);
            stopWatch = new Stopwatch();
            stopWatch.Start();
            producer.Start();
            consumer01.Start();
            consumer02.Start();
            stopWatch.Start();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            killThreads();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopWatch.Stop();
            btnStop.Visible = false;
            lblStatus.Visible = false;
            txtResults.Visible = true;
            killThreads();
            ComputeResults();
        }
        private void ComputeResults()
        {
            int producedItems, consumedItems01, consumedItems02;
            producedItems = lbProducer.Items.Count;
            consumedItems01 = lbConsumer01.Items.Count;
            consumedItems02 = lbConsumer02.Items.Count;
            txtResults.Text = "Demo ran for " + ((double)stopWatch.ElapsedMilliseconds / 1000) + " seconds";
            txtResults.Text += Environment.NewLine + producedItems + " widgets were produced.";
            txtResults.Text += Environment.NewLine + consumedItems01 + " widgets were consumed by Consumer thread 01.";
            txtResults.Text += Environment.NewLine + consumedItems02 + " widgets were consumed by Consumer thread 02.";
            if (producedItems == (consumedItems01 + consumedItems02)) {
                txtResults.Text += Environment.NewLine + "All items accounted for.";
            } else {
                int difference = producedItems - (consumedItems01 + consumedItems02);
                txtResults.Text += Environment.NewLine + "ERROR: producer/consumer mismatch: " + difference + " widgets were not processed!";
            }
        }
        private void killThreads()
        {
            try { producer.Abort(); } catch (Exception ex) { };
            try { consumer01.Abort(); } catch (Exception ex) { };
            try { consumer02.Abort(); } catch (Exception ex) { };
        }
    }
}
