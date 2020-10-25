/*
 * Bill Nicholson
 * nicholdw@ucmail.uc.edu
 */
using ProducerConsumerDemo.Code;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private void btnGo_Click(object sender, EventArgs e)
        {
            StartDemo();
            lblStatus.Visible = true;
            btnStop.Visible = true;
            btnGo.Visible = false;
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
            btnGo.Visible = true;
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
                txtResults.Text += Environment.NewLine + "All widgets accounted for in the Consumers.";
            } else {
                int difference = producedItems - (consumedItems01 + consumedItems02);
                txtResults.Text += Environment.NewLine + "ERROR: producer/consumer mismatch: " + difference + " widgets not processed!";
            }
            CheckWidgets(txtResults);
        }
        private void CheckWidgets(TextBox txtResults)
        {
            // Look in the Consumers for all the produced items
            foreach (String item in lbProducer.Items) {
                if (!lbConsumer01.Items.Contains(item) && !lbConsumer02.Items.Contains(item))
                {
                    txtResults.Text += Environment.NewLine + item + " NOT found in Consumers";
                }
            }
            // Look in all the Consumers for any duplicate produced items
            foreach (String item in lbProducer.Items) {
                if (lbConsumer01.Items.Contains(item) && lbConsumer02.Items.Contains(item))
                {
                    txtResults.Text += Environment.NewLine + item + " DUPLICATED in Consumers";
                }
            }
        }
        private void killThreads()
        {
            try { producer.Abort(); } catch (Exception ex) { };
            try { consumer01.Abort(); } catch (Exception ex) { };
            try { consumer02.Abort(); } catch (Exception ex) { };
        }

        private void frmProducerConsumerDemo_Load(object sender, EventArgs e)
        {

        }
    }
}
