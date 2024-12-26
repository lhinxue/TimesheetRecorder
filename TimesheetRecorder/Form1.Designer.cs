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
            btnTaskStart = new Button();
            btnStopTask = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            button1 = new Button();
            button2 = new Button();
            linkLabel1 = new LinkLabel();
            SuspendLayout();
            // 
            // btnTaskStart
            // 
            btnTaskStart.Font = new Font("Microsoft YaHei", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnTaskStart.Location = new Point(280, 27);
            btnTaskStart.Name = "btnTaskStart";
            btnTaskStart.Size = new Size(89, 33);
            btnTaskStart.TabIndex = 0;
            btnTaskStart.Text = "Start / 开始";
            btnTaskStart.UseVisualStyleBackColor = true;
            btnTaskStart.Click += btnTaskStart_Click;
            // 
            // btnStopTask
            // 
            btnStopTask.Font = new Font("Microsoft YaHei", 9.75F);
            btnStopTask.Location = new Point(280, 63);
            btnStopTask.Name = "btnStopTask";
            btnStopTask.Size = new Size(89, 33);
            btnStopTask.TabIndex = 1;
            btnStopTask.Text = "Stop / 停止";
            btnStopTask.UseVisualStyleBackColor = true;
            btnStopTask.Click += btnStopTask_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(1, 29);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(276, 29);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Century Gothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(215, 3);
            label1.Name = "label1";
            label1.Size = new Size(154, 18);
            label1.TabIndex = 3;
            label1.Text = "Timesheet Recorder";
            // 
            // button1
            // 
            button1.Font = new Font("Microsoft YaHei", 9.75F);
            button1.Location = new Point(163, 63);
            button1.Name = "button1";
            button1.Size = new Size(114, 33);
            button1.TabIndex = 5;
            button1.Text = "Meeting / 会议";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Font = new Font("Microsoft YaHei", 9.75F);
            button2.Location = new Point(1, 63);
            button2.Name = "button2";
            button2.Size = new Size(159, 33);
            button2.TabIndex = 6;
            button2.Text = "Last Task / 上一个任务";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Font = new Font("Microsoft YaHei", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            linkLabel1.LinkColor = Color.Gray;
            linkLabel1.Location = new Point(1, 5);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(119, 16);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Open Logs / 历史记录";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(373, 98);
            Controls.Add(linkLabel1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(btnStopTask);
            Controls.Add(btnTaskStart);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            KeyDown += Form1_KeyDown;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnTaskStart;
        private Button btnStopTask;
        private TextBox textBox1;
        private Label label1;
        private Button button1;
        private Button button2;
        private LinkLabel linkLabel1;
    }
}
