namespace ProducerConsumerDemo
{
    partial class frmProducerConsumerDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.txtResults = new System.Windows.Forms.TextBox();
            this.lbProducer = new System.Windows.Forms.ListBox();
            this.lbConsumer01 = new System.Windows.Forms.ListBox();
            this.lbConsumer02 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(953, 511);
            this.btnGo.Margin = new System.Windows.Forms.Padding(4);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(100, 28);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(117, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Producer";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(461, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Consumer 1";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(114, 361);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(250, 17);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Producer/Consumer threads running...";
            this.lblStatus.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(694, 26);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Consumer 2";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(117, 387);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 38);
            this.btnStop.TabIndex = 8;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // txtResults
            // 
            this.txtResults.Location = new System.Drawing.Point(117, 431);
            this.txtResults.Multiline = true;
            this.txtResults.Name = "txtResults";
            this.txtResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtResults.Size = new System.Drawing.Size(787, 92);
            this.txtResults.TabIndex = 9;
            this.txtResults.Visible = false;
            // 
            // lbProducer
            // 
            this.lbProducer.FormattingEnabled = true;
            this.lbProducer.ItemHeight = 16;
            this.lbProducer.Location = new System.Drawing.Point(120, 55);
            this.lbProducer.Name = "lbProducer";
            this.lbProducer.Size = new System.Drawing.Size(198, 292);
            this.lbProducer.TabIndex = 10;
            // 
            // lbConsumer01
            // 
            this.lbConsumer01.FormattingEnabled = true;
            this.lbConsumer01.ItemHeight = 16;
            this.lbConsumer01.Location = new System.Drawing.Point(464, 55);
            this.lbConsumer01.Name = "lbConsumer01";
            this.lbConsumer01.Size = new System.Drawing.Size(198, 292);
            this.lbConsumer01.TabIndex = 11;
            // 
            // lbConsumer02
            // 
            this.lbConsumer02.FormattingEnabled = true;
            this.lbConsumer02.ItemHeight = 16;
            this.lbConsumer02.Location = new System.Drawing.Point(679, 55);
            this.lbConsumer02.Name = "lbConsumer02";
            this.lbConsumer02.Size = new System.Drawing.Size(198, 292);
            this.lbConsumer02.TabIndex = 12;
            // 
            // frmProducerConsumerDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.lbConsumer02);
            this.Controls.Add(this.lbConsumer01);
            this.Controls.Add(this.lbProducer);
            this.Controls.Add(this.txtResults);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmProducerConsumerDemo";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.TextBox txtResults;
        private System.Windows.Forms.ListBox lbProducer;
        private System.Windows.Forms.ListBox lbConsumer01;
        private System.Windows.Forms.ListBox lbConsumer02;
    }
}

