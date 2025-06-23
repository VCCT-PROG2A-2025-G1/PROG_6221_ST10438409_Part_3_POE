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
using Microsoft.VisualBasic;
using Newtonsoft.Json.Linq;
using PROG_6221_ST10438409_Part_1;
using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    // This class is responsible for displaying all tasks in a form.
    // </summary>
    public partial class DisplayAllTasks : Form
    {
        //-------------------------------------------------//
        // Class variables
        private ArrayList taskArrayList = new ArrayList();
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Constructor for the DisplayAllTasks class.
        // </summary>
        public DisplayAllTasks()
        {
            InitializeComponent();
            ApplyStyling();
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the form is loaded.
        // </summary>
        private void DisplayAllTasks_Load(object sender, EventArgs e)
        {

            //-------------------------------------------------//
            // Set the title of the form
            this.Text = "Display All Tasks";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // prevent this form from being closed by the user
            this.ControlBox = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // prevent this window from being resized, maximized, or minimized
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Load all tasks from the file and display them in the RichTextBox
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tasks.txt");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Clear the RichTextBox and the ArrayList before loading tasks
            txtListOfTasks.Clear();
            taskArrayList.Clear();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the file exists and read tasks from it
            if (System.IO.File.Exists(filePath))
            {
                //-------------------------------------------------//
                // Read the file content and split it into task blocks
                string fileContent = System.IO.File.ReadAllText(filePath);
                string[] taskBlocks = fileContent.Split(new[] { "-------------------------------" }, StringSplitOptions.RemoveEmptyEntries);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Iterate through each task block and extract details
                foreach (string block in taskBlocks)
                {
                    //-------------------------------------------------//
                    // Split the block into lines and extract task details
                    string title = "";
                    string description = "";
                    string reminder = "";
                    string status = "";
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Split the block into lines and extract task details
                    foreach (string line in block.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries))
                    {
                        //-------------------------------------------------//
                        // Check for specific task details and assign them to variables
                        if (line.StartsWith("Title:"))
                            title = line.Substring("Title:".Length).Trim();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Check for specific task details and assign them to variables
                        else if (line.StartsWith("Description:"))
                            description = line.Substring("Description:".Length).Trim();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Check for specific task details and assign them to variables
                        else if (line.StartsWith("Reminder:"))
                            reminder = line.Substring("Reminder:".Length).Trim();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Check for specific task details and assign them to variables
                        else if (line.StartsWith("Status:"))
                            status = line.Substring("Status:".Length).Trim();
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Only add if at least a title is present
                    if (!string.IsNullOrEmpty(title))
                    {
                        //-------------------------------------------------//
                        // Create a new TaskAssistant object and add it to the ArrayList
                        TaskAssistant taskObj = new TaskAssistant(title, description, reminder, status);
                        taskArrayList.Add(taskObj);
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Display in the RichTextBox
                        txtListOfTasks.AppendText(
                            $"Title: {title}{Environment.NewLine}" +
                            (!string.IsNullOrEmpty(description) ? $"Description: {description}{Environment.NewLine}" : "") +
                            (!string.IsNullOrEmpty(reminder) ? $"Reminder: {reminder}{Environment.NewLine}" : "") +
                            (!string.IsNullOrEmpty(status) ? $"Status: {status}{Environment.NewLine}" : "") +
                            "-------------------------------" + Environment.NewLine
                        );
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // If the file does not exist, display a message in the RichTextBox
                txtListOfTasks.Text = "No tasks found.";
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Applies custom styling to the DisplayAllTasks form and its controls.
        // </summary>
        private void ApplyStyling()
        {
            //-------------------------------------------------//
            // Form background
            this.BackColor = Color.FromArgb(30, 34, 45);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // RichTextBox styling
            txtListOfTasks.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtListOfTasks.BackColor = Color.FromArgb(44, 47, 51);
            txtListOfTasks.ForeColor = Color.White;
            txtListOfTasks.BorderStyle = BorderStyle.None;
            txtListOfTasks.ReadOnly = true;
            txtListOfTasks.Padding = new Padding(8, 4, 8, 4);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Button styling
            btnReturn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnReturn.BackColor = Color.FromArgb(0, 200, 255);
            btnReturn.ForeColor = Color.White;
            btnReturn.FlatStyle = FlatStyle.Flat;
            btnReturn.FlatAppearance.BorderSize = 0;
            btnReturn.Cursor = Cursors.Hand;
            btnReturn.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnReturn.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);

            btnDelete.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnDelete.BackColor = Color.FromArgb(0, 200, 255);
            btnDelete.ForeColor = Color.White;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnDelete.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);

            btnCompleteTask.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnCompleteTask.BackColor = Color.FromArgb(0, 200, 255);
            btnCompleteTask.ForeColor = Color.White;
            btnCompleteTask.FlatStyle = FlatStyle.Flat;
            btnCompleteTask.FlatAppearance.BorderSize = 0;
            btnCompleteTask.Cursor = Cursors.Hand;
            btnCompleteTask.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnCompleteTask.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);

            btnEditTask.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEditTask.BackColor = Color.FromArgb(0, 200, 255);
            btnEditTask.ForeColor = Color.White;
            btnEditTask.FlatStyle = FlatStyle.Flat;
            btnEditTask.FlatAppearance.BorderSize = 0;
            btnEditTask.Cursor = Cursors.Hand;
            btnEditTask.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnEditTask.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make every button have round edges 
            SetButtonRoundEdge(btnReturn, 20);
            SetButtonRoundEdge(btnDelete, 20);
            SetButtonRoundEdge(btnCompleteTask, 20);
            SetButtonRoundEdge(btnEditTask, 20);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Helper method to set rounded edges
        private void SetButtonRoundEdge(Button button, int radius)
        {
            var rect = new Rectangle(0, 0, button.Width, button.Height);
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the "Return" button is clicked.
        // </summary>
        private void btnReturn_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // dispose this method and return to the main window
            this.Dispose();
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            //-------------------------------------------------//
        }

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This button will read the tasks from the textbox and create task objects in an array
        // It will then show a popup message asking the user to search for a task by its task name
        // if it finds the task, the user can delete it from the list
        // It will then delete the task from the text file and update the RichTextBox to reflect the changes

        // Copilot Helped with the Visual Basic display
        // </summary>
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Check if there are any tasks to delete
            if (taskArrayList.Count == 0)
            {
                Communication.TextToSpeech("No tasks to delete.");
                MessageBox.Show("No tasks to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Prompt the user to enter the task title they want to delete
            string taskToDelete = Interaction.InputBox("Enter the title of the task you want to delete:", "Delete Task", "", -1, -1);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user entered a task title
            if (string.IsNullOrWhiteSpace(taskToDelete))
            {
                Communication.TextToSpeech("No task title entered.");
                MessageBox.Show("No task title entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Find the task in the ArrayList
            TaskAssistant taskToRemove = null;
            foreach (TaskAssistant task in taskArrayList)
            {
                if (task.Title.Equals(taskToDelete, StringComparison.OrdinalIgnoreCase))
                {
                    taskToRemove = task;
                    break;
                }
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // If the task was found, remove it from the ArrayList and update the file
            if (taskToRemove != null)
            {
                //-------------------------------------------------//
                // Create a activity log entry for the deleted task
                string activityLog = $"Task '{taskToRemove.Title}' deleted on {DateTime.Now}.";
                ActivityLog.addEntry(activityLog);
                //-------------------------------------------------//

                taskArrayList.Remove(taskToRemove);

                //-------------------------------------------------//
                // Save the updated tasks back to the file
                string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tasks.txt");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false))
                {
                    //-------------------------------------------------//
                    // Write each task in the ArrayList to the file
                    foreach (TaskAssistant task in taskArrayList)
                    {
                        writer.WriteLine("Title: " + task.Title);
                        if (!string.IsNullOrEmpty(task.Description))
                            writer.WriteLine("Description: " + task.Description);
                        if (!string.IsNullOrEmpty(task.OptionalReminder))
                            writer.WriteLine("Reminder: " + task.OptionalReminder);
                        writer.WriteLine("Status: " + (string.IsNullOrEmpty(task.Status) ? "Not Started" : task.Status));
                        writer.WriteLine("-------------------------------");
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Refresh the RichTextBox
                txtListOfTasks.Clear();
                foreach (TaskAssistant task in taskArrayList)
                {
                    txtListOfTasks.AppendText(
                        $"Title: {task.Title}{Environment.NewLine}" +
                        (!string.IsNullOrEmpty(task.Description) ? $"Description: {task.Description}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.OptionalReminder) ? $"Reminder: {task.OptionalReminder}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.Status) ? $"Status: {task.Status}{Environment.NewLine}" : "") +
                        "-------------------------------" + Environment.NewLine
                    );
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Show a success message
                Communication.TextToSpeech("Task deleted successfully.");
                MessageBox.Show("Task deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // If the task was not found, show an error message
                Communication.TextToSpeech("Task not found.");
                MessageBox.Show("Task not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method will search for a task by its title and mark it as completed.
        // </summary>
        private void btnCompleteTask_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Ask the user to search for the task title
            string taskToComplete = Interaction.InputBox("Enter the title of the task you want to mark as completed:", "Complete Task", "", -1, -1);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user entered a task title
            if (string.IsNullOrWhiteSpace(taskToComplete))
            {
                Communication.TextToSpeech("No task title entered.");
                MessageBox.Show("No task title entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Find the task in the ArrayList
            TaskAssistant taskToCompleteObj = null;
            if (taskToCompleteObj == null)
            {
                //-------------------------------------------------//
                // Iterate through the ArrayList to find the task
                foreach (TaskAssistant task in taskArrayList)
                {
                    //-------------------------------------------------//
                    // Check if the task title matches the user input
                    if (task.Title.Equals(taskToComplete, StringComparison.OrdinalIgnoreCase))
                    {
                        taskToCompleteObj = task;
                        break;
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // If the task was found, mark it as completed
            if (taskToCompleteObj == null)
            {
                //-------------------------------------------------//
                // Task not found
                Communication.TextToSpeech("Task not found.");
                MessageBox.Show("Task not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // Create a activity log entry for the completed task
                string activityLog = $"Task '{taskToCompleteObj.Title}' marked as completed on {DateTime.Now}.";
                ActivityLog.addEntry(activityLog);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Update the task status to "Completed"
                taskToCompleteObj.Status = "Completed";
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Save the updated tasks back to the file
                string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tasks.txt");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false))
                {
                    //-------------------------------------------------//
                    // Write each task in the ArrayList to the file
                    foreach (TaskAssistant task in taskArrayList)
                    {
                        writer.WriteLine("Title: " + task.Title);
                        if (!string.IsNullOrEmpty(task.Description))
                            writer.WriteLine("Description: " + task.Description);
                        if (!string.IsNullOrEmpty(task.OptionalReminder))
                            writer.WriteLine("Reminder: " + task.OptionalReminder);
                        writer.WriteLine("Status: " + (string.IsNullOrEmpty(task.Status) ? "Not Started" : task.Status));
                        writer.WriteLine("-------------------------------");
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Refresh the RichTextBox
                txtListOfTasks.Clear();
                foreach (TaskAssistant task in taskArrayList)
                {
                    txtListOfTasks.AppendText(
                        $"Title: {task.Title}{Environment.NewLine}" +
                        (!string.IsNullOrEmpty(task.Description) ? $"Description: {task.Description}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.OptionalReminder) ? $"Reminder: {task.OptionalReminder}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.Status) ? $"Status: {task.Status}{Environment.NewLine}" : "") +
                        "-------------------------------" + Environment.NewLine
                    );
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Show a success message
                Communication.TextToSpeech("Task marked as completed successfully.");
                MessageBox.Show("Task marked as completed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Edit a task method
        private void btnEditTask_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Ask the user to enter the task title they want to edit
            string taskToEdit = Interaction.InputBox("Enter the title of the task you want to edit:", "Edit Task", "", -1, -1);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user entered a task title
            if (string.IsNullOrWhiteSpace(taskToEdit))
            {
                Communication.TextToSpeech("No task title entered.");
                MessageBox.Show("No task title entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Find the task in the ArrayList
            TaskAssistant taskToEditObj = null;
            foreach (TaskAssistant task in taskArrayList)
            {
                if (task.Title.Equals(taskToEdit, StringComparison.OrdinalIgnoreCase))
                {
                    taskToEditObj = task;
                    break;
                }
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // If the task was found, prompt the user to edit its details
            if (taskToEditObj != null)
            {
                //-------------------------------------------------//
                // Prompt the user to edit the task details
                string newTitle = Interaction.InputBox("Edit Task Title:", "Edit Task", taskToEditObj.Title, -1, -1);
                string newDescription = Interaction.InputBox("Edit Task Description:", "Edit Task", taskToEditObj.Description, -1, -1);
                string newReminder = Interaction.InputBox("Edit Task Reminder:", "Edit Task", taskToEditObj.OptionalReminder, -1, -1);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Update the task details
                taskToEditObj.Title = newTitle;
                taskToEditObj.Description = newDescription;
                taskToEditObj.OptionalReminder = newReminder;
                //-------------------------------------------------//
                // Save the updated tasks back to the file
                string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tasks.txt");
                using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath, false))
                {
                    //-------------------------------------------------//
                    // Write each task in the ArrayList to the file
                    foreach (TaskAssistant task in taskArrayList)
                    {
                        writer.WriteLine("Title: " + task.Title);
                        if (!string.IsNullOrEmpty(task.Description))
                            writer.WriteLine("Description: " + task.Description);
                        if (!string.IsNullOrEmpty(task.OptionalReminder))
                            writer.WriteLine("Reminder: " + task.OptionalReminder);
                        writer.WriteLine("Status: " + (string.IsNullOrEmpty(task.Status) ? "Not Started" : task.Status));
                        writer.WriteLine("-------------------------------");
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Refresh the RichTextBox
                txtListOfTasks.Clear();
                foreach (TaskAssistant task in taskArrayList)
                {
                    txtListOfTasks.AppendText(
                        $"Title: {task.Title}{Environment.NewLine}" +
                        (!string.IsNullOrEmpty(task.Description) ? $"Description: {task.Description}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.OptionalReminder) ? $"Reminder: {task.OptionalReminder}{Environment.NewLine}" : "") +
                        (!string.IsNullOrEmpty(task.Status) ? $"Status: {task.Status}{Environment.NewLine}" : "") +
                        "-------------------------------" + Environment.NewLine
                    );
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Show a success message
                Communication.TextToSpeech("Task edited successfully.");
                MessageBox.Show("Task edited successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //-------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//