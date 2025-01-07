namespace TimesheetRecorder
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
            components = new System.ComponentModel.Container();
            btnTaskStart = new Button();
            btnStopTask = new Button();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            button3 = new Button();
            button4 = new Button();
            linkLabel2 = new LinkLabel();
            button5 = new Button();
            button6 = new Button();
            contextMenuStrip1 = new ContextMenuStrip(components);
            linkLabel3 = new LinkLabel();
            SuspendLayout();
            // 
            // btnTaskStart
            // 
            btnTaskStart.BackColor = Color.PaleGreen;
            btnTaskStart.Font = new Font("Segoe UI", 8.25F);
            btnTaskStart.Location = new Point(333, 2);
            btnTaskStart.Name = "btnTaskStart";
            btnTaskStart.Size = new Size(44, 38);
            btnTaskStart.TabIndex = 0;
            btnTaskStart.Text = "Start";
            btnTaskStart.UseVisualStyleBackColor = false;
            btnTaskStart.Click += btnTaskStart_Click;
            // 
            // btnStopTask
            // 
            btnStopTask.BackColor = Color.MistyRose;
            btnStopTask.Font = new Font("Segoe UI", 8.25F);
            btnStopTask.Location = new Point(333, 41);
            btnStopTask.Name = "btnStopTask";
            btnStopTask.Size = new Size(44, 30);
            btnStopTask.TabIndex = 1;
            btnStopTask.Text = "Stop";
            btnStopTask.UseVisualStyleBackColor = false;
            btnStopTask.Click += btnStopTask_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 8.25F);
            textBox1.Location = new Point(1, 17);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(219, 22);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 8.25F);
            button1.Location = new Point(68, 41);
            button1.Name = "button1";
            button1.Size = new Size(66, 30);
            button1.TabIndex = 5;
            button1.Text = "Meeting";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Bisque;
            button2.Font = new Font("Segoe UI", 8.25F);
            button2.Location = new Point(1, 41);
            button2.Name = "button2";
            button2.Size = new Size(67, 30);
            button2.TabIndex = 6;
            button2.Text = "Last Task";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Segoe UI", 8.25F);
            linkLabel1.LinkColor = Color.DarkGray;
            linkLabel1.Location = new Point(201, 2);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(63, 13);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Open Logs";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // button3
            // 
            button3.Font = new Font("Segoe UI", 8.25F);
            button3.Location = new Point(134, 41);
            button3.Name = "button3";
            button3.Size = new Size(86, 30);
            button3.TabIndex = 8;
            button3.Text = "Peer Support";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 8.25F);
            button4.Location = new Point(220, 41);
            button4.Name = "button4";
            button4.Size = new Size(61, 30);
            button4.TabIndex = 9;
            button4.Text = "Training";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Font = new Font("Segoe UI", 8.25F);
            linkLabel2.LinkColor = Color.Magenta;
            linkLabel2.Location = new Point(1, 1);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(108, 13);
            linkLabel2.TabIndex = 10;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Generate Timesheet";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 8.25F);
            button5.Location = new Point(281, 41);
            button5.Name = "button5";
            button5.Size = new Size(52, 30);
            button5.TabIndex = 12;
            button5.Text = "Admin";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.Font = new Font("Segoe UI", 8.25F);
            button6.Location = new Point(220, 17);
            button6.Name = "button6";
            button6.Size = new Size(113, 23);
            button6.TabIndex = 13;
            button6.Text = "Latest Tasks";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // linkLabel3
            // 
            linkLabel3.AutoSize = true;
            linkLabel3.Font = new Font("Segoe UI", 8.25F);
            linkLabel3.LinkColor = Color.DarkGray;
            linkLabel3.Location = new Point(270, 2);
            linkLabel3.Name = "linkLabel3";
            linkLabel3.Size = new Size(60, 13);
            linkLabel3.TabIndex = 14;
            linkLabel3.TabStop = true;
            linkLabel3.Text = "Clear Logs";
            linkLabel3.LinkClicked += linkLabel3_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(379, 72);
            Controls.Add(linkLabel3);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(linkLabel2);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(linkLabel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(btnStopTask);
            Controls.Add(btnTaskStart);
            Name = "Form1";
            Text = "Timesheet Recorder";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaskStart;
        private Button btnStopTask;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private LinkLabel linkLabel1;
        private Button button3;
        private Button button4;
        private LinkLabel linkLabel2;
        private Button button5;
        private Button button6;
        private ContextMenuStrip contextMenuStrip1;
        private LinkLabel linkLabel3;
    }
}
