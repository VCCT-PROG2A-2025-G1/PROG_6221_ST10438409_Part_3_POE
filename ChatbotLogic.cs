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
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_1
{
    //------------------------------------------------------------------------------------------------------------------//
    // <summary>
    // This class is used to manage the chatbot logic.
    // </summary>
    public class ChatbotLogic
    {
        //-------------------------------------------------//
        // Declare a static variable to store the chatbot responses
        // This variable was created by copilot, I needed to research how to create this almost "dictionary dictionary" to store the responses
        public static Dictionary<string, Dictionary<string, string>> responses;
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Searches for the user's message in the response dictionary and returns the chatbot's response.
        // </summary>
        public static string GetResponse(string message, string userName)
        {
            responses = LoadResponses();
            //-------------------------------------------------//
            // Loop through each category in the responses dictionary
            foreach (var category in responses.Values)
            {
                //-------------------------------------------------//
                // Check if the message is in the category
                if (category.ContainsKey(message))
                {
                    //-------------------------------------------------//
                    // Return the response if the message is found
                    return category[message].Replace("{UserName}", userName);
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Return a default response if the message is not found
            return "I'm sorry, I don't understand that.";
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Method that loads the chatbot responses from the responses.json file.
        // This method contains code from Copilot.
        // The code was modified to include the path to the responses.json file in the project folder.
        // As well as the Dictionary <string, Dictionary<string, string>> to store the responses.
        // </summary>
        public static Dictionary<string, Dictionary<string, string>> LoadResponses()
        {
            //-------------------------------------------------//
            // Get the path to the responses.json file in the project folder
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Response.json");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the file exists
            if (File.Exists(filePath))
            {
                //-------------------------------------------------//
                // Read the JSON data from the file
                string jsonData = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, string>>>(jsonData);
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                //set the colour to the chatbot
                ConsoleFormat.SwitchTextColour(0);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Display an error message if the file is not found
                Communication.TextToSpeech("Error: response.json file not found!");
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Return empty dictionary if file is missing
                return new Dictionary<string, Dictionary<string, string>>();
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // List questions based on user selection of category or all available questions.
        // </summary>
        public static void ListPossibleQuestions()
        {
            responses = LoadResponses();
            //-------------------------------------------------//
            // Set the chatbot text color
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            string choice;
            bool validChoice = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Ask if the user wants to see questions by category or all questions
            Communication.TextToSpeech("Would you like to see questions for a specific category or all available questions?");
            Console.WriteLine("\n1. View questions by category");
            Console.WriteLine("2. View all questions");
            Console.Write("\nPlease enter your choice (1 or 2): ");
            //-------------------------------------------------//

            while (!validChoice)
            {
                //-------------------------------------------------//
                // Set user text color
                ConsoleFormat.SwitchTextColour(1);
                //-------------------------------------------------//

                choice = Console.ReadLine()?.Trim();
                Console.WriteLine();
                //-------------------------------------------------//
                // Check if the user entered a valid choice
                if (choice == "1")
                {
                    validChoice = true;

                    //-------------------------------------------------//
                    // List available categories
                    ConsoleFormat.SwitchTextColour(0);
                    ConsoleFormat.PrintBorderWithColour();
                    Communication.TextToSpeech("Here are the available categories:");
                    Console.WriteLine();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Display the categories
                    int index = 1;
                    foreach (var category in responses.Keys)
                    {
                        Console.WriteLine($"{index}. {category.Replace('_', ' ')}");
                        index++;
                    }
                    ConsoleFormat.PrintBorderWithColour();
                    ConsoleFormat.PrintBorderWithColour();
                    Console.WriteLine();
                    Console.Write("\nPlease enter the category number: ");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set user text color
                    ConsoleFormat.SwitchTextColour(1);
                    //-------------------------------------------------//

                    bool validCategory = false;
                    while (!validCategory)
                    {
                        //-------------------------------------------------//
                        // Read user input and validate the category selection
                        if (int.TryParse(Console.ReadLine()?.Trim(), out int categoryChoice) && categoryChoice > 0 && categoryChoice <= responses.Keys.Count)
                        {
                            //-------------------------------------------------//
                            // Set the selected category
                            validCategory = true;
                            string selectedCategory = responses.Keys.ElementAt(categoryChoice - 1);
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Display questions from the selected category
                            ConsoleFormat.SwitchTextColour(0);
                            ConsoleFormat.PrintBorderWithColour();
                            Communication.TextToSpeech($"Here are the questions in {selectedCategory.Replace('_', ' ')}:");
                            Console.WriteLine();
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Loop through and display the questions
                            foreach (var key in responses[selectedCategory].Keys)
                            {
                                Console.WriteLine(key);
                            }
                            ConsoleFormat.PrintBorderWithColour();
                            //-------------------------------------------------//
                        }
                        else
                        {
                            //-------------------------------------------------//
                            // Invalid category choice, prompt again
                            ConsoleFormat.SwitchTextColour(0);
                            Communication.TextToSpeech("Invalid choice. Please enter a valid category number.");
                            Console.Write("\nPlease enter the category number: ");
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Set user text color
                            ConsoleFormat.SwitchTextColour(1);
                            //-------------------------------------------------//
                        }
                    }
                }
                else if (choice == "2")
                {
                    validChoice = true;

                    //-------------------------------------------------//
                    // Display all questions
                    ConsoleFormat.SwitchTextColour(0);
                    ConsoleFormat.PrintBorderWithColour();
                    Console.WriteLine();
                    Communication.TextToSpeech("Here are all the questions you can ask:");
                    Console.WriteLine();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Loop through all categories and display questions
                    foreach (var category in responses.Values)
                    {
                        //-------------------------------------------------//
                        // Loop through and display the questions
                        foreach (var key in category.Keys)
                        {
                            Console.WriteLine(key);
                        }
                        //-------------------------------------------------//
                    }
                    ConsoleFormat.PrintBorderWithColour();
                    //-------------------------------------------------//
                }
                else
                {
                    //-------------------------------------------------//
                    // Invalid input, retry
                    ConsoleFormat.SwitchTextColour(0);
                    Communication.TextToSpeech("Invalid choice. Please enter 1 or 2: ");
                    ConsoleFormat.SwitchTextColour(0);
                    //-------------------------------------------------//
                }
            }

            //-------------------------------------------------//
            // Ask the user for another message
            Thread.Sleep(2000);
            Communication.TextToSpeech("How else can I help you today: ");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set user text color
            ConsoleFormat.SwitchTextColour(1);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//

}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//