
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Timers;

namespace TimesheetRecorder
{
    public partial class Form1 : Form
    {

        private const double ACTIVE_OPACITY = 1.0;       // Opacity when active or hovered
        private const double INACTIVE_OPACITY = 0.7;    // Opacity when inactive
        private const double ANIMATION_DURATION = 150; // Duration of opacity transition in ms
        private const int TIMER_INTERVAL = 10;


        private System.Windows.Forms.Timer opacityTimer;
        private double targetOpacity;
        private double opacityStep;

        private string oldTask;
        private string currentTask;
        private string newTask;
        private System.Timers.Timer changeTimer;

        public Form1()
        {
            InitializeComponent();

            // Initialize the timer
            opacityTimer = new System.Windows.Forms.Timer
            {
                Interval = TIMER_INTERVAL
            };
            opacityTimer.Tick += OpacityTimer_Tick;

            changeTimer = new System.Timers.Timer(30000); // 30 seconds
            changeTimer.Elapsed += ChangeTimer_Elapsed;
            changeTimer.AutoReset = false; // Prevent the timer from resetting automatically

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            TopMost = true;
            //FormBorderStyle = FormBorderStyle.None;

            // Get the screen where the cursor is located
            Screen currentScreen = Screen.FromPoint(Cursor.Position);

            // Get the working area of the screen
            Rectangle workingArea = currentScreen.WorkingArea;

            // Calculate the bottom-right position
            int x = workingArea.Right - Width;
            int y = workingArea.Bottom - Height;

            // Set the form's location
            Location = new Point(x, y);


            Opacity = INACTIVE_OPACITY;

            // Subscribe to relevant events
            Activated += (s, e) => SetOpacity(ACTIVE_OPACITY);
            Deactivate += (s, e) => SetOpacity(INACTIVE_OPACITY);
            AttachMouseEvents(this);
        }

        private void AttachMouseEvents(Control control)
        {
            // Attach mouse events to the control
            control.MouseEnter += (s, e) => SetOpacity(ACTIVE_OPACITY);
            control.MouseLeave += (s, e) => CheckMousePosition();

            // Recursively handle child controls
            foreach (Control child in control.Controls)
            {
                AttachMouseEvents(child);
            }
        }

        private void CheckMousePosition()
        {
            // Check if the mouse is actually outside the form
            Point mousePosition = Control.MousePosition;
            Rectangle formBounds = RectangleToScreen(ClientRectangle);

            if (!formBounds.Contains(mousePosition))
            {
                SetOpacity(INACTIVE_OPACITY);
            }
        }

        private void SetOpacity(double opacity)
        {
            targetOpacity = opacity;

            // Calculate step based on difference (for a smooth transition over ANIMATION_DURATION)
            double steps = ANIMATION_DURATION / TIMER_INTERVAL; // Number of steps
            opacityStep = (targetOpacity - Opacity) / steps;

            // Start the timer if not already running
            if (!opacityTimer.Enabled)
            {
                opacityTimer.Start();
            }
        }

        private void OpacityTimer_Tick(object sender, EventArgs e)
        {
            // Update opacity incrementally
            double newOpacity = Opacity + opacityStep;

            if ((opacityStep > 0 && newOpacity >= targetOpacity) ||
                (opacityStep < 0 && newOpacity <= targetOpacity))
            {
                // Stop the timer when target is reached
                Opacity = targetOpacity;
                opacityTimer.Stop();
            }
            else
            {
                // Apply incremental opacity change
                Opacity = newOpacity;
            }
        }



        public void RecordTask(string task, bool start)
        {
            if (string.IsNullOrEmpty(task)) return;
            if ((start && task != currentTask)||!start) {
                oldTask = currentTask;
                currentTask = start?task:"";
                this.textBox1.Text = start ? task : "";
            }
            
            // Get the current date and time
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Define the file path using the current date
            string filePath = Path.Combine(@"C:\temp", $"TimesheetRecorderHistory_{currentDate}.txt");

            // Prepare the log entry
            string logEntry = $"{currentTimeStamp}: {task} [{(start ? "start" : "stop")}]";

            // Write to the file, creating it if necessary
            try
            {
                // If the file does not exist, create it; otherwise, append to it
                using StreamWriter sw = new StreamWriter(filePath, true);
                sw.WriteLine(logEntry);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error writing to file: {ex.Message}");
            }
        }

        private void btnTaskStart_Click(object sender, EventArgs e)
        {
            RecordTask(textBox1.Text, true);
        }

        private void btnStopTask_Click(object sender, EventArgs e)
        {

            RecordTask(textBox1.Text, false);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RecordTask(textBox1.Text, true);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                RecordTask(textBox1.Text, true);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            this.newTask = textBox1.Text;

            if (this.newTask != currentTask)
            {
                // Restart the timer
                changeTimer.Stop();
                changeTimer.Start();
            }
        }

        private void ChangeTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // Trigger FUNC1 when the timer elapses (i.e., after 30 seconds of inactivity)
            RecordTask(textBox1.Text, true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(oldTask))
            {
                RecordTask(oldTask, true);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RecordTask("Meeting", true);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(new System.Diagnostics.ProcessStartInfo()
            {
                FileName = @"C:\temp",
                UseShellExecute = true,
                Verb = "open"
            });
        }

        public static List<string> GetUniqueTasks()
        {
            string directoryPath = @"C:\\temp";
            string filePattern = "TimesheetRecorderHistory_*.txt";
            int maxFilesToProcess = 5;

            try
            {
                // Get all files matching the pattern
                var files = Directory.GetFiles(directoryPath, filePattern)
                                     .OrderByDescending(File.GetLastWriteTime)
                                     .Take(maxFilesToProcess);

                HashSet<string> uniqueTasks = new HashSet<string>();
                HashSet<string> excludedTasks = new HashSet<string> { "Meeting", "Peer Support", "Training", "Admin" };

                foreach (var file in files)
                {
                    // Read all lines from the file
                    var lines = File.ReadAllLines(file);

                    foreach (var line in lines)
                    {
                        // Match the task pattern
                        var match = Regex.Match(line, @"\d{4}-\d{2}-\d{2} \d{2}:\d{2}: (.+?) \[start\]");
                        if (match.Success)
                        {
                            string task = match.Groups[1].Value;
                            if (!excludedTasks.Contains(task))
                            {
                                uniqueTasks.Add(task);
                            }
                        }
                    }
                }

                return uniqueTasks.ToList();
            }
            catch (Exception ex)
            {
                return new List<string>();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Items.Clear();
            foreach (var item in GetUniqueTasks())
            {
                contextMenuStrip1.Items.Add(item, null, MenuItem_Click);
            }
            contextMenuStrip1.Show(button6, 0, button6.Height);
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem)
            {
                RecordTask(menuItem.Text ?? "", true);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

            RecordTask("Peer Support", true);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            RecordTask("Training", true);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            RecordTask("Admin", true);
        }

        public static void GenerateTimesheetFile()
        {
            string directoryPath = @"C:\\temp";
            string filePattern = "TimesheetRecorderHistory_*.txt";
            string outputFilePath = $"{directoryPath}\\GeneratedTimesheet_{DateTime.Now:yyyyMMddHHmmss}.txt";

            try
            {
                var files = Directory.GetFiles(directoryPath, filePattern)
                                     .OrderByDescending(File.GetLastWriteTime);

                using (StreamWriter writer = new StreamWriter(outputFilePath))
                {
                    foreach (var file in files)
                    {
                        var lines = File.ReadAllLines(file);
                        var tasks = new Dictionary<string, TimeSpan>();
                        DateTime? lastTimestamp = null;
                        string lastTask = null;

                        foreach (var line in lines)
                        {
                            var match = Regex.Match(line, @"(\d{4}-\d{2}-\d{2} \d{2}:\d{2}): (.+?) \[(start|stop)\]");
                            if (match.Success)
                            {
                                DateTime timestamp = DateTime.Parse(match.Groups[1].Value);
                                string task = match.Groups[2].Value;
                                string action = match.Groups[3].Value;

                                if (lastTimestamp.HasValue && lastTask != null)
                                {
                                    if (action == "start" && task != lastTask || action == "stop")
                                    {
                                        TimeSpan duration = timestamp - lastTimestamp.Value;
                                        if (!tasks.ContainsKey(lastTask))
                                            tasks[lastTask] = TimeSpan.Zero;
                                        tasks[lastTask] += duration;

                                        lastTask = action == "start" ? task : null;
                                        lastTimestamp = action == "start" ? (DateTime?)timestamp : null;
                                    }
                                }
                                else if (action == "start")
                                {
                                    lastTask = task;
                                    lastTimestamp = timestamp;
                                }
                            }
                        }

                        // Add time until end of day if last task is still running
                        if (lastTimestamp.HasValue && lastTask != null)
                        {
                            DateTime endOfDay = lastTimestamp.Value.Date.AddHours(17.5); // 5:30 PM
                            if (!tasks.ContainsKey(lastTask))
                                tasks[lastTask] = TimeSpan.Zero;
                            tasks[lastTask] += endOfDay - lastTimestamp.Value;
                        }

                        writer.WriteLine($"{Path.GetFileNameWithoutExtension(file)}:");
                        foreach (var task in tasks)
                        {
                            double hours = Math.Ceiling(task.Value.TotalHours * 4) / 4; // Round up to nearest 0.25
                            writer.WriteLine($"- [{task.Key}] {hours} Hour(s)");
                        }
                        writer.WriteLine();
                    }
                }

                // Open the generated file
                System.Diagnostics.Process.Start("notepad.exe", outputFilePath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GenerateTimesheetFile();
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }
    }
}
