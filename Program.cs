//------------------------------------------------------------------------------------------------------------------//
// Name: Dylan Shortt
// Group: 1
// Student Number: ST-10438409
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// Imports the necessary libraries for the program to run.
// </summary>
using System;
using System.Collections.Generic;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// Reference: 
// GitHub Copilot. (2025). AI programming assistant. [online] Available at: https://copilot.github.com/ [Accessed: 2025].
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace for the program that contains the class Program.
// </summary>
namespace PROG_6221_ST10438409_Part_1
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

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // The main method that is the entry point for the program.
        // </summary>
        public static void Main(string[] args)
        {

            //-------------------------------------------------//
            // Declare a string variable to store the user's name
            string userName;
            // Load chatbot responses from JSON file
            responses = ChatbotLogic.LoadResponses();
            // Declare a string variable to store the user's message
            string userMessage;
            // Random follow-up prompts to keep the conversation going
            string[] followUpPrompts = {
                            "Anything else you'd like to ask?",
                            "Do you have any more questions?",
                            "How else can I help?",
                            "Would you like more cybersecurity tips?"
                    };
            Random rnd = new Random();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Method that display the cybersecurity-themed symbol using ASCII art
            // Question 2 - ASCII Art-*
            ConsoleFormat.PrintBorderWithColour();
            ConsoleFormat.DisplaySymbol();
            //-------------------------------------------------//

            //-------------------------------------------------//
            //method that calls the Greeting method that welcomes the user
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Question 1 - Audio Greeting            
            Communication.FirstGreeting();
            Console.WriteLine();
            //-------------------------------------------------//

            //-------------------------------------------------//    

            //-------------------------------------------------//
            // Method that asks the user for their name and stores it in the userName variable
            // Question 3 - User Interaction 
            userName = Communication.GetUserName();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Question 4 - Chatbot Basic Interaction
            // Loop that runs until the user types "exit"
            do
            {
                //-------------------------------------------------//
                // Get the user's message
                userMessage = Console.ReadLine().Trim();
                Console.WriteLine();
                ConsoleFormat.PrintBorderWithColour();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the user's message is empty
                if (string.IsNullOrWhiteSpace(userMessage))
                {
                    //-------------------------------------------------//
                    //set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    Communication.TextToSpeech("Please enter a valid message.\n");
                    ConsoleFormat.PrintBorderWithColour();
                    ConsoleFormat.PrintBorderWithColour();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nYou: ");
                    continue;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the user wants to exit
                if (userMessage.ToLower() == "exit")
                {
                    //-------------------------------------------------//
                    //set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Call TextToSpeech method to convert the goodbye message to speech
                    Communication.TextToSpeech("Goodbye " + userName + ", have a great day!\n");
                    ConsoleFormat.PrintBorderWithColour();
                    //-------------------------------------------------//
                }
                else if (userMessage.ToLower() == "help")
                {
                    //-------------------------------------------------//
                    //set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Print every possible question
                    ChatbotLogic.ListPossibleQuestions();
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("\nYou: ");
                    //-------------------------------------------------//
                }
                else
                {
                    //-------------------------------------------------//
                    // Get the chatbot's response using the method
                    string chatbotResponse = ChatbotLogic.GetResponse(userMessage, userName);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Call TextToSpeech method to convert response to speech
                    Communication.TextToSpeech(chatbotResponse);
                    Console.WriteLine("");
                    ConsoleFormat.PrintBorderWithColour();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Ask the user for another message
                    Communication.TextToSpeech(followUpPrompts[rnd.Next(followUpPrompts.Length)]);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //set the colour to the user
                    ConsoleFormat.SwitchTextColour(1);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // get the user's message
                    Console.Write("\nYou: ");
                    //-------------------------------------------------//
                }

            } while (userMessage.ToLower() != "exit");
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//        

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//