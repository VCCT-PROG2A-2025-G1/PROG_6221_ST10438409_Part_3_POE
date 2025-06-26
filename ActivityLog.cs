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
using Newtonsoft.Json.Linq;
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
        private static int currentIndex = 0;
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
        // If there are fewer than 5 entries, it returns all available entries.
        // If there are no entries, it returns a message indicating that there are no entries.
        // The method also updates the current index to keep track of which entries have been returned.
        // This method had assistance from GitHub Copilot.
        // </summary>
        public static string GetNextEntries(int count = 5)
        {
            //-------------------------------------------------//
            // Check if the activity log entries list is null or empty
            if (activityLogEntries == null || activityLogEntries.Count == 0)
            {
                return "No activity log entries available.";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // If this is the first call, set the currentIndex to the end
            if (currentIndex == 0)
            {
                //-------------------------------------------------//
                // Set the currentIndex to the end of the list
                return "No activity log entries available.";
                //-------------------------------------------------//
            }
            //--------------------------------------------------//

            //-------------------------------------------------//
            // Determine how many entries to fetch
            int fetchCount = Math.Min(count, currentIndex);
            int startIndex = currentIndex - fetchCount;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get entries in reverse order (newest first)
            // Reverse to display newest at the top
            // GitHub Copilot helped in creating this code block
            var nextEntries = activityLogEntries
                .Skip(startIndex)
                .Take(fetchCount)
                .Reverse() 
                .ToList();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Update currentIndex for next pagination
            currentIndex -= fetchCount;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Return the string
            return string.Join("\n", nextEntries);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Reset the pagination of the activity log entries.
        // This method sets the current index back to 0,
        // allowing the log to be read from the beginning again.
        // </summary>
        public static void ResetPagination()
        {
            currentIndex = activityLogEntries.Count;
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//