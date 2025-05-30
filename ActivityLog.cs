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
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // This class is used to hold and manage the activity log for the application.
    // </summary>
    public static class ActivityLog
    {
        //-------------------------------------------------//
        //Declare the list to hold activity log entries
        private static List<string> activityLogEntries = new List<string>();
        private static int number = 1;
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Static constructor to initialize the activity log entries list.
        // </summary>
        static ActivityLog()
        {
            // Initialization logic if needed
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Create a method to add an entry to the activity log when the Quiz is started,
        // it will save the total number of Questions.
        // </summary>
        public static void addEntry(string entry)
        {
            //-------------------------------------------------//
            // Add the entry to the list
            activityLogEntries.Add($"{number}. {entry}\n");
            number++;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Return method that returns the last 5 activity log entries as a string.
        // </summary>
        public static string getLastFiveEntries()
        {
            //-------------------------------------------------//
            // Check if the activity log entries list is null or empty
            if (activityLogEntries == null || activityLogEntries.Count == 0)
            {
                return "No activity log entries available.";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // if_ more than 5 logs, return only last five logs
            if (activityLogEntries.Count <= 5)
            {
                return string.Join("", activityLogEntries);
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get the last 5 entries from the activity log
            int startIndex = Math.Max(0, activityLogEntries.Count - 5);
            List<string> lastFiveEntries = activityLogEntries
                .Cast<string>()
                .Skip(startIndex)
                .ToList();
            //-------------------------------------------------//
            // Join the entries into a single string and return it
            return string.Join("", lastFiveEntries);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//