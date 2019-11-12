namespace kafkaTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbx_brokerList = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbx_topicName = new System.Windows.Forms.TextBox();
            this.btn_Send = new System.Windows.Forms.Button();
            this.btn_SetProducer = new System.Windows.Forms.Button();
            this.tbx_Msg = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rtbx_log = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbx_brokerListConsumer = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbx_topicNameConsumer = new System.Windows.Forms.TextBox();
            this.btn_SetConsumer = new System.Windows.Forms.Button();
            this.rtbx_logConsumer = new System.Windows.Forms.RichTextBox();
            this.btn_StopConsume = new System.Windows.Forms.Button();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "brokerList:";
            // 
            // tbx_brokerList
            // 
            this.tbx_brokerList.Location = new System.Drawing.Point(101, 15);
            this.tbx_brokerList.Name = "tbx_brokerList";
            this.tbx_brokerList.Size = new System.Drawing.Size(243, 23);
            this.tbx_brokerList.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-442, -101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Msg:";
            // 
            // tbx_topicName
            // 
            this.tbx_topicName.Location = new System.Drawing.Point(101, 53);
            this.tbx_topicName.Name = "tbx_topicName";
            this.tbx_topicName.Size = new System.Drawing.Size(243, 23);
            this.tbx_topicName.TabIndex = 1;
            // 
            // btn_Send
            // 
            this.btn_Send.Location = new System.Drawing.Point(101, 150);
            this.btn_Send.Name = "btn_Send";
            this.btn_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_Send.TabIndex = 3;
            this.btn_Send.Text = "Send";
            this.btn_Send.UseVisualStyleBackColor = true;
            this.btn_Send.Click += new System.EventHandler(this.btn_Send_Click);
            // 
            // btn_SetProducer
            // 
            this.btn_SetProducer.Location = new System.Drawing.Point(101, 82);
            this.btn_SetProducer.Name = "btn_SetProducer";
            this.btn_SetProducer.Size = new System.Drawing.Size(90, 23);
            this.btn_SetProducer.TabIndex = 4;
            this.btn_SetProducer.Text = "创建生产者";
            this.btn_SetProducer.UseVisualStyleBackColor = true;
            this.btn_SetProducer.Click += new System.EventHandler(this.btn_SetProducer_Click);
            // 
            // tbx_Msg
            // 
            this.tbx_Msg.Location = new System.Drawing.Point(101, 121);
            this.tbx_Msg.Name = "tbx_Msg";
            this.tbx_Msg.Size = new System.Drawing.Size(243, 23);
            this.tbx_Msg.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Msg:";
            // 
            // rtbx_log
            // 
            this.rtbx_log.Location = new System.Drawing.Point(25, 192);
            this.rtbx_log.Name = "rtbx_log";
            this.rtbx_log.Size = new System.Drawing.Size(466, 354);
            this.rtbx_log.TabIndex = 6;
            this.rtbx_log.Text = "";
            this.rtbx_log.TextChanged += new System.EventHandler(this.rtbx_log_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 59);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "topicName:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(657, 62);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(75, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "topicName:";
            // 
            // tbx_brokerListConsumer
            // 
            this.tbx_brokerListConsumer.Location = new System.Drawing.Point(733, 18);
            this.tbx_brokerListConsumer.Name = "tbx_brokerListConsumer";
            this.tbx_brokerListConsumer.Size = new System.Drawing.Size(243, 23);
            this.tbx_brokerListConsumer.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(657, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 17);
            this.label6.TabIndex = 0;
            this.label6.Text = "brokerList:";
            // 
            // tbx_topicNameConsumer
            // 
            this.tbx_topicNameConsumer.Location = new System.Drawing.Point(733, 56);
            this.tbx_topicNameConsumer.Name = "tbx_topicNameConsumer";
            this.tbx_topicNameConsumer.Size = new System.Drawing.Size(243, 23);
            this.tbx_topicNameConsumer.TabIndex = 1;
            // 
            // btn_SetConsumer
            // 
            this.btn_SetConsumer.Location = new System.Drawing.Point(733, 85);
            this.btn_SetConsumer.Name = "btn_SetConsumer";
            this.btn_SetConsumer.Size = new System.Drawing.Size(90, 23);
            this.btn_SetConsumer.TabIndex = 4;
            this.btn_SetConsumer.Text = "创建消费者";
            this.btn_SetConsumer.UseVisualStyleBackColor = true;
            this.btn_SetConsumer.Click += new System.EventHandler(this.btn_SetConsumer_Click);
            // 
            // rtbx_logConsumer
            // 
            this.rtbx_logConsumer.Location = new System.Drawing.Point(549, 192);
            this.rtbx_logConsumer.Name = "rtbx_logConsumer";
            this.rtbx_logConsumer.Size = new System.Drawing.Size(497, 354);
            this.rtbx_logConsumer.TabIndex = 8;
            this.rtbx_logConsumer.Text = "";
            this.rtbx_logConsumer.TextChanged += new System.EventHandler(this.rtbx_logConsumer_TextChanged);
            // 
            // btn_StopConsume
            // 
            this.btn_StopConsume.Location = new System.Drawing.Point(849, 85);
            this.btn_StopConsume.Name = "btn_StopConsume";
            this.btn_StopConsume.Size = new System.Drawing.Size(75, 23);
            this.btn_StopConsume.TabIndex = 9;
            this.btn_StopConsume.Text = "停止消费";
            this.btn_StopConsume.UseVisualStyleBackColor = true;
            this.btn_StopConsume.Click += new System.EventHandler(this.btn_StopConsume_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(1058, 572);
            this.Controls.Add(this.btn_StopConsume);
            this.Controls.Add(this.rtbx_logConsumer);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rtbx_log);
            this.Controls.Add(this.tbx_Msg);
            this.Controls.Add(this.btn_SetProducer);
            this.Controls.Add(this.btn_Send);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbx_brokerList);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbx_topicName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbx_brokerListConsumer);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbx_topicNameConsumer);
            this.Controls.Add(this.btn_SetConsumer);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbx_brokerList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbx_topicName;
        private System.Windows.Forms.Button btn_Send;
        private System.Windows.Forms.Button btn_SetProducer;
        private System.Windows.Forms.TextBox tbx_Msg;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox rtbx_log;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbx_brokerListConsumer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbx_topicNameConsumer;
        private System.Windows.Forms.Button btn_SetConsumer;
        private System.Windows.Forms.RichTextBox rtbx_logConsumer;
        private System.Windows.Forms.Button btn_StopConsume;
    }
}

