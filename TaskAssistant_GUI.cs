
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Timers;
using System.Windows.Forms;

//------------------------------------------------------------------------------------------------------------------//
// Name: Dylan Shortt
// Group: 1
// Student Number: ST-10438409
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// Reference: 
// GitHub Copilot. (2025). AI programming assistant. [online] Available at: https://copilot.github.com/ [Accessed: 2025].
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// These import statements are used to import the necessary libraries for the program to run.
// </summary>
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // This class represents the GUI for the Task Assistant application.
    // </summary>
    public partial class TaskAssistant_GUI : Form
    {
        //------------------------------------------------------------------------------------------------------------------//
        // Class variables
        private System.Windows.Forms.TextBox txtCustomTimeframe;
        private System.Windows.Forms.Label lblReminderDate;
        private System.Windows.Forms.Label lblOr;
        private System.Windows.Forms.Label lblCustomTimeframe;
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Constructor for the TaskAssistant_GUI class.
        // </summary>
        public TaskAssistant_GUI()
        {
            InitializeComponent();
            TaskAssistant_GUI_Style();
            ApplyRoundedCorners();
            SetDateStyle();
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method sets the date collection format, colour and location
        // </summary>
        private void SetDateStyle()
        {
            // Reminder Date label (above)
            this.lblReminderDate = new System.Windows.Forms.Label();
            this.lblReminderDate.Text = "Reminder Date (optional):";
            this.lblReminderDate.Location = new System.Drawing.Point(30, 180);
            this.lblReminderDate.Size = new System.Drawing.Size(180, 25);
            this.Controls.Add(this.lblReminderDate);

            // Custom Timeframe label (below)
            this.lblCustomTimeframe = new System.Windows.Forms.Label();
            this.lblCustomTimeframe.Text = "Custom Timeframe in days (e.g. '7'):";
            this.lblCustomTimeframe.Location = new System.Drawing.Point(560, 150);
            this.lblCustomTimeframe.Size = new System.Drawing.Size(200, 25);
            this.lblCustomTimeframe.ForeColor = Color.White;
            this.Controls.Add(this.lblCustomTimeframe);

            // Custom Timeframe TextBox (below)
            this.txtCustomTimeframe = new System.Windows.Forms.TextBox();
            this.txtCustomTimeframe.Location = new System.Drawing.Point(560, 180);
            this.txtCustomTimeframe.Size = new System.Drawing.Size(200, 25);
            this.Controls.Add(this.txtCustomTimeframe);
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method applies rounded corners to the form.
        // </summary>
        private void ApplyRoundedCorners(int radius = 20)
        {
            //-------------------------------------------------//
            // Create a GraphicsPath to define the rounded corners
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            path.CloseFigure();
            this.Region = new Region(path);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Gradient background
        // This method is responsible for painting the background of the form with a gradient.
        // </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //-------------------------------------------------//
            // Create a linear gradient brush with the specified colors and angle
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(30, 34, 45), Color.FromArgb(0, 200, 255), 135F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Drop shadow
        // This method is responsible for creating a drop shadow effect for the form.
        // </summary>
        protected override CreateParams CreateParams
        {
            //-------------------------------------------------//
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is responsible for making this form have the same format as the main form.
        // </summary>
        private void TaskAssistant_GUI_Style()
        {
            //-------------------------------------------------//
            // Set form background color
            this.BackColor = Color.FromArgb(30, 34, 45);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Style all controls to match MainWindow
            foreach (Control ctrl in this.Controls)
            {
                //-------------------------------------------------//
                // Set the font and color for various controls
                if (ctrl is TextBox || ctrl is RichTextBox)
                {
                    ctrl.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    ctrl.BackColor = Color.FromArgb(44, 47, 51);
                    ctrl.ForeColor = Color.White;
                    ctrl.Padding = new Padding(8, 4, 8, 4);
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the font and color for buttons
                if (ctrl is Label lbl)
                {
                    //-------------------------------------------------//
                    // Set the font and color for labels
                    lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    lbl.ForeColor = Color.White;
                    lbl.BackColor = Color.Transparent; 
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                if(ctrl is Button btn)
                {
                    //-------------------------------------------------//
                    // Set the font, color, and style for buttons
                    btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btn.BackColor = Color.FromArgb(0, 200, 255);
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Padding = new Padding(8, 4, 8, 4);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Change cursor to hand on hover
                    btn.Cursor = Cursors.Hand;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Darken on hover AND
                    // Reset on leave
                    btn.MouseEnter += (s, e) => btn.BackColor = Color.FromArgb(0, 150, 200); 
                    btn.MouseLeave += (s, e) => btn.BackColor = Color.FromArgb(0, 200, 255);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the button format for the Show Tasks button
                    
                    btnShowTasks.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                    btnShowTasks.BackColor = Color.FromArgb(0, 200, 255);
                    btnShowTasks.ForeColor = Color.White;
                    btnShowTasks.FlatStyle = FlatStyle.Flat;
                    btnShowTasks.FlatAppearance.BorderSize = 0;
                    btnShowTasks.Padding = new Padding(8, 4, 8, 4);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Change cursor to hand on hover
                    btnShowTasks.Cursor = Cursors.Hand;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //--------------------------------------------------//
            //set the button round edges
            SetButtonRoundEdge(btnSaveTask, 20);
            SetButtonRoundEdge(btnCancelTask, 20);
            SetButtonRoundEdge(btnShowTasks, 20);
            SetButtonRoundEdge(btnShowTasks, 20);
            //--------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Helper method to set rounded edges
        private void SetButtonRoundEdge(Button button, int radius)
        {
            //-------------------------------------------------//
            // Create a GraphicsPath to define the rounded edges
            var rect = new Rectangle(0, 0, button.Width, button.Height);
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method will be used to set the Tasks Name and Description text boxes.
        // </summary>
        public void setTaskDetails(string taskName, string taskDescription, string taskDate)
        {
            //-------------------------------------------------//
            // Set the text of the Task Name and Description text boxes
            txtTaskName.Text = taskName;
            txtTaskDescription.Text = taskDescription;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Normalize the taskDate string to handle common phrases like "tomorrow", "today", and "yesterday"
            string normalized = taskDate.Trim().ToLower();
            DateTime dateValue;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check for common phrases and set the dateValue accordingly
            if (normalized == "tomorrow")
            {
                //-------------------------------------------------//
                // Set the dateValue to tomorrow if the taskDate is "tomorrow"
                dateValue = DateTime.Today.AddDays(1);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the DateTimePicker value to the parsed dateValue
                dtpReminderDate.Value = dateValue;
                //-------------------------------------------------//
            }
            else if (normalized == "today")
            {
                //-------------------------------------------------//
                // Set the dateValue to today if the taskDate is "today"
                dateValue = DateTime.Today;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the DateTimePicker value to the parsed dateValue
                dtpReminderDate.Value = dateValue;
                //-------------------------------------------------//
            }
            else if (normalized == "yesterday")
            {
                //-------------------------------------------------//
                // Set the dateValue to yesterday if the taskDate is "yesterday"
                dateValue = DateTime.Today.AddDays(-1);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the DateTimePicker value to the parsed dateValue
                dtpReminderDate.Value = dateValue;
                //-------------------------------------------------//
            }
            // Check if_ the string is empty
            else if(string.IsNullOrEmpty(normalized))
            {
                //-------------------------------------------------//
                //do nothing, no reminder is set.
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // Fallback to standard parsing
                dateValue = DateTime.Parse(taskDate);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the DateTimePicker value to the parsed dateValue
                dtpReminderDate.Value = dateValue;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//            
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the form is loaded.
        // It initializes the form and sets up any necessary event handlers.
        // </summary>
        private void TaskAssistant_GUI_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Sets so the form cannot be closed 
            this.FormBorderStyle = FormBorderStyle.None;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Sets so the form cannot be resized
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //make it so that this window cannot be closed
            this.ControlBox = false;
            this.ResumeLayout(false);
            this.PerformLayout();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Sets the form to be centered on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //make the Error message text box invisible
            txtErrorMessage.Visible = false;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the "Cancel Task" button is clicked.
        // It is responsible for handling the cancellation of a task.
        // It will close this window and re-open the main form.
        private void btnCancelTask_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // This will open the main form and close this form
            this.Dispose();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Open the main form
            // This will create a new instance of the MainWindow class and show it as a dialog
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();            
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the "Save Task" button is clicked.
        // It is responsible for handling the saving of a task.
        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // rehide the error message text box
            txtErrorMessage.Visible = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get values from the text boxes
            string title = txtTaskName.Text.Trim();
            string description = txtTaskDescription.Text.Trim();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the title is empty
            if (string.IsNullOrEmpty(title))
            {
                //-------------------------------------------------//
                // Show error message if title is empty
                Communication.TextToSpeech("Please enter a task name.");
                txtErrorMessage.Text = "Please enter a task name.";
                txtErrorMessage.Visible = true;
                return;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the description is empty
            if (string.IsNullOrEmpty(description))
            {
                //-------------------------------------------------//
                // Show error message if description is empty
                Communication.TextToSpeech("Please enter a task description.");
                txtErrorMessage.Text = "Please enter a task description.";
                txtErrorMessage.Visible = true;
                return;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get reminder value
            string optionalReminder = "";

            //-------------------------------------------------//
            // Check if the custom timeframe text box is not empty or if the date picker is checked
            if (!string.IsNullOrWhiteSpace(txtCustomTimeframe.Text))
            {
                //-------------------------------------------------//
                //check that the custom timeframe is a valid int
                optionalReminder = txtCustomTimeframe.Text.Trim();
                if (!int.TryParse(optionalReminder, out _))
                {
                    //-------------------------------------------------//
                    // Show error message if custom timeframe is not a valid integer
                    Communication.TextToSpeech("Please enter a valid number of days for the custom timeframe.");
                    txtErrorMessage.Text = "Please enter a valid number of days for the custom timeframe.";
                    txtErrorMessage.Visible = true;
                    return;
                    //-------------------------------------------------//
                }
                else
                {
                    optionalReminder = "Remind me in " + txtCustomTimeframe.Text.Trim() + " days";

                    //-------------------------------------------------//
                    //set the reminder to 'X' days from now
                    int X = int.Parse(txtCustomTimeframe.Text.Trim());

                    var timer = new System.Timers.Timer(TimeSpan.FromDays(X).TotalMilliseconds);
                    timer.Elapsed += (s, ex) => { MessageBox.Show("Reminder: " + txtTaskName.Text + "!"); timer.Stop(); };
                    timer.Start();
                    //-------------------------------------------------//

                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // check if date is set to today
            else if (dtpReminderDate.Value.Date == DateTime.Today && dtpReminderDate.Checked)
            {
                optionalReminder = "No reminder set";
            }
            else if (dtpReminderDate.Checked)
            {
                optionalReminder = dtpReminderDate.Value.ToString("yyyy-MM-dd");

                //-------------------------------------------------//
                // Set a timer for the reminder
                DateTime reminderTime = dtpReminderDate.Value;
                double interval = (reminderTime - DateTime.Now).TotalMilliseconds;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the interval is greater than zero
                if (interval > 0)
                {
                    //-------------------------------------------------//
                    // Create a timer to show the reminder message
                    var timer = new System.Timers.Timer(interval);
                    timer.Elapsed += (s, eDate) => { MessageBox.Show("Reminder: " + txtTaskName.Text + "!"); timer.Stop(); };
                    timer.Start();
                    //-------------------------------------------------//
                }
                //------------------------------------------------//
                else
                {
                    //-------------------------------------------------//
                    // Show error message if the reminder time is in the past
                    Communication.TextToSpeech("The reminder time cannot be in the past.");
                    txtErrorMessage.Text = "The reminder time cannot be in the past.";
                    txtErrorMessage.Visible = true;
                    return;
                    //-------------------------------------------------//
                }
            }
            else
            {
                optionalReminder = "No reminder set";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Create a new TaskAssistant object with the provided values
            TaskAssistant task = new TaskAssistant(title, description, optionalReminder);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Save the task to a file in the Resources folder
            task.SaveTask();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Show success message
            Communication.TextToSpeech("Task saved successfully!");
            MessageBox.Show("Task saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Clear the text boxes after saving
            Thread.Sleep(500); 
            txtTaskName.Clear();

            Thread.Sleep(300);
            txtTaskDescription.Clear();

            Thread.Sleep(300);
            txtCustomTimeframe.Clear();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        //This method shows the tasks window
        private void button1_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Open the show tasks window
            this.Dispose();
            DisplayAllTasks displayAllTasks = new DisplayAllTasks();
            displayAllTasks.ShowDialog();            
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//