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
            btnOpenLogs = new Button();
            SuspendLayout();
            // 
            // btnTaskStart
            // 
            btnTaskStart.Location = new Point(572, 1);
            btnTaskStart.Name = "btnTaskStart";
            btnTaskStart.Size = new Size(89, 33);
            btnTaskStart.TabIndex = 0;
            btnTaskStart.Text = "Start";
            btnTaskStart.UseVisualStyleBackColor = true;
            btnTaskStart.Click += btnTaskStart_Click;
            // 
            // btnStopTask
            // 
            btnStopTask.Location = new Point(572, 40);
            btnStopTask.Name = "btnStopTask";
            btnStopTask.Size = new Size(89, 33);
            btnStopTask.TabIndex = 1;
            btnStopTask.Text = "Stop";
            btnStopTask.UseVisualStyleBackColor = true;
            btnStopTask.Click += btnStopTask_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(3, 1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(563, 33);
            textBox1.TabIndex = 2;
            textBox1.TextAlign = HorizontalAlignment.Center;
            textBox1.TextChanged += textBox1_TextChanged;
            textBox1.KeyDown += textBox1_KeyDown;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(108, 47);
            label1.Name = "label1";
            label1.Size = new Size(144, 19);
            label1.TabIndex = 3;
            label1.Text = "What am I doing ATM";
            // 
            // btnOpenLogs
            // 
            btnOpenLogs.Location = new Point(3, 40);
            btnOpenLogs.Name = "btnOpenLogs";
            btnOpenLogs.Size = new Size(99, 33);
            btnOpenLogs.TabIndex = 4;
            btnOpenLogs.Text = "Open Logs";
            btnOpenLogs.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 19F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(662, 76);
            Controls.Add(btnOpenLogs);
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
        private Button btnOpenLogs;
    }
}
