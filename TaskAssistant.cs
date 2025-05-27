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
using System;
using System.IO;
//------------------------------------------------------------------------------------------------------------------//
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // This class will be used to assist with task management in the application.
    // It is responsible for creating, saving and loading tasks, as well as managing the task list.
    // </summary>
    internal class TaskAssistant
    {
        //-------------------------------------------------//
        // Class variables 
        private string title;
        private string description;
        private string optionalReminder;
        private string status;
        //-------------------------------------------------//

        //-------------------------------------------------//
        //create getter and setter methods
        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public string OptionalReminder
        {
            get { return optionalReminder; }
            set { optionalReminder = value; }
        }
        public string Status
        {
            get { return status; }
            set { status = value; }
        }
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Defualt constructor that initializes the TaskAssistant class.
        // </summary>
        public TaskAssistant()
        {
            this.title = string.Empty;
            this.description = string.Empty;
            this.optionalReminder = string.Empty;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Constructor set to receive the base constructors parameters plus status
        // </summary>
        public TaskAssistant(string title, string description, string optionalReminder, string status)
        {
            this.title = title;
            this.description = description;
            this.optionalReminder = optionalReminder;
            this.status = status;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Create constructor that recieves parameters for title, description, and optional reminder.
        // </summary>
        public TaskAssistant(string title, string description, string optionalReminder)
        {
            this.title = title;
            this.description = description;
            this.optionalReminder = optionalReminder;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method will be used to permanetly save these tasks to a file in the Resource Folder.
        // </summary>
        public void SaveTask()
        {
            //-------------------------------------------------//
            // Ensure the Resources directory exists
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Tasks.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Open the file in append mode and write the task details
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                //-------------------------------------------------//
                // Write the task details to the file
                writer.WriteLine("Title: " + title);
                writer.WriteLine("Description: " + description);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // If an optional reminder is provided, write it to the file
                if (!string.IsNullOrEmpty(optionalReminder))
                {
                    writer.WriteLine("Reminder: " + optionalReminder);
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the Status line to "Not Started" by default
                writer.WriteLine("Status: Not Started");

                //-------------------------------------------------//
                // Write a separator line for better readability
                writer.WriteLine("-------------------------------\n");
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method will open the DisplayAllTasks form to display all tasks.
        // </summary>
        public void DisplayAllTasks()
        {
            //-------------------------------------------------//
            // Create an instance of the DisplayAllTasks form
            DisplayAllTasks displayForm = new DisplayAllTasks();
            //-------------------------------------------------//
            //-------------------------------------------------//
            // Show the form as a dialog
            displayForm.ShowDialog();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//