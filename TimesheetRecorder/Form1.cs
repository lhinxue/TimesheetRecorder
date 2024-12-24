
using System.Timers;

namespace TimesheetRecorder
{
    public partial class Form1 : Form
    {

        private const double ACTIVE_OPACITY = 1.0;       // Opacity when active or hovered
        private const double INACTIVE_OPACITY = 0.5;    // Opacity when inactive
        private const double ANIMATION_DURATION = 200; // Duration of opacity transition in ms
        private const int TIMER_INTERVAL = 10;


        private System.Windows.Forms.Timer opacityTimer;
        private double targetOpacity;
        private double opacityStep;

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
            FormBorderStyle = FormBorderStyle.None;

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
            if (task == currentTask) return;
            currentTask = task;
            // Get the current date and time
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd");
            string currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm");

            // Define the file path using the current date
            string filePath = Path.Combine(@"C:\temp", $"{currentDate}.txt");

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
    }
}
