//------------------------------------------------------------------------------------------------------------------//
// Name: Dylan Shortt
// Group: 1
// Student Number: ST-10438409
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// Imports the necessary libraries for the program to run.
// </summary>
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// Reference: 
// GitHub Copilot. (2025). AI programming assistant. [online] Available at: https://copilot.github.com/ [Accessed: 2025].
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace for the program that contains the class Program.
// </summary>
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // The public class Program that contains the main method and subsequent methods.
    // </summary>
    public class Program
    {

        //-------------------------------------------------//
        // Declare a static variable to store the chatbot responses
        public static Dictionary<string, Dictionary<string, string>> responses;
        //-------------------------------------------------//

        //-------------------------------------------------//
        // Declare a string variable to store the user's name
        // This variable will be used to personalize the chatbot's responses
        // It will have a getter to allow access from other classes
        public static string userName;
        //-------------------------------------------------//

        //-------------------------------------------------//
        // Get the user's name
        public static string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // The main method that is the entry point for the program.
        // </summary>
        public static void Main(string[] args)
        {
            Mini_Quiz_GUI miniQuizGUI = new Mini_Quiz_GUI();
            miniQuizGUI.ShowDialog(); // Show the mini quiz GUI first

            //-------------------------------------------------//
            // Question 1 - Audio Greeting            
            Communication.FirstGreeting();
            //-------------------------------------------------//   

            //-------------------------------------------------//
            // Method that asks the user for their name and stores it in the userName variable
            // Question 3 - User Interaction 
            userName = Communication.GetUserName();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Display the Main Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Main method of the project that runs the other methods in the solution.
        // </summary>
        public static async Task RunAsync(string userMessage, MainWindow mainWindow)
        {
            //-------------------------------------------------//
            // Load chatbot responses from JSON file
            responses = ChatbotLogic.LoadResponses();
            // Random follow-up prompts to keep the conversation going
            string[] followUpPrompts = {
                            "Anything else you'd like to ask?",
                            "Do you have any more questions?",
                            "How else can I help?",
                            "Would you like more cybersecurity tips?"
                    };
            Random rnd = new Random();
            //-------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user wants to exit
            if (userMessage.ToLower() == "exit")
            {
                //-------------------------------------------------//
                // Call TextToSpeech method to convert the goodbye message to speech
                Communication.TextToSpeech("Goodbye " + userName + ", have a great day!\n");
                await mainWindow.TypeTextToChatbotOutputAsync("Goodbye " + userName + ", have a great day!\n");                
                //-------------------------------------------------//

                //-------------------------------------------------//
                //end the program
                Environment.Exit(0);
                //-------------------------------------------------//
            }
            else if (userMessage.ToLower() == "help")
            {
                //-------------------------------------------------//
                // Print every possible question
                await ChatbotLogic.ListPossibleQuestions(mainWindow);
                //-------------------------------------------------//
            }
            else if(userMessage.ToLower().Contains("show") && userMessage.ToLower().Contains("log") || userMessage.ToLower().Contains("what have you done for me"))
            {

                //-------------------------------------------------//
                // Make the string title
                string message = "Here’s a summary of recent actions:\n";
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Get the last five entries from the activity log
                string lastFiveEntries = ActivityLog.getLastFiveEntries();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Combine the message and the last five entries
                string fullMessage = message + lastFiveEntries;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Print the activity log entries to the chatbot output
                Communication.TextToSpeech(fullMessage);
                await mainWindow.TypeTextToChatbotOutputAsync(fullMessage);
                //-------------------------------------------------//

            }
            else
            {
                //-------------------------------------------------//
                // Print the user's message to the chatbot output
                string fullMessage = "";

                //-------------------------------------------------//
                // Get the chatbot's response using the method
                string chatbotResponse = await ChatbotLogic.GetResponse(userMessage, userName, mainWindow);
                fullMessage = chatbotResponse + "\n\n";
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Call TextToSpeech method to convert response to speech
                Communication.TextToSpeech(chatbotResponse);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Ask the user for another message
                string followupMessage = followUpPrompts[rnd.Next(followUpPrompts.Length)];
                Communication.TextToSpeech(followupMessage);
                fullMessage += followupMessage;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Print the chatbot's response to the chatbot output
                await mainWindow.TypeTextToChatbotOutputAsync(fullMessage);
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//