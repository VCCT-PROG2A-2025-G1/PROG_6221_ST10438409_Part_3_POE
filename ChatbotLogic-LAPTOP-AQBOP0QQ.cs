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
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Speech.Synthesis.TtsEngine;
using System.Text.RegularExpressions;
using System.Threading;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_2
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

        //-------------------------------------------------//
        // Declare a static variable to store the last question key incase the user wants to ask,
        // for more details about the question
        public static string lastQuestionKey;
        //-------------------------------------------------//

        //-------------------------------------------------//
        // String to store the users favoirite topic
        public static string favouriteTopic;
        public static string favouriteCategory;
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is responsible for checking if the user added sentiment to their message.
        // </summary>
        public static string CheckSentiment(string message)
        {
            //-------------------------------------------------//
            // Convert the message to lowercase for case-insensitive matching
            string lowered = message.ToLower();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if_ the user is worried about a subject
            if (lowered.Contains("worried") || lowered.Contains("concerned") || lowered.Contains("anxious"))
            {
                return "worried";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user is frustrated about a subject
            if (lowered.Contains("frustrated") || lowered.Contains("overwhelmed") || lowered.Contains("confused"))
            {
                return "frustrated";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user is curious about a subject
            if (lowered.Contains("curious") || lowered.Contains("wondering"))
            {
                return "curious";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // if_ the message does not match, return null
            return null;
            //-------------------------------------------------//

        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Create the helper method to identify when the user names there favorite topic
        public static string IsFavouriteTopic(string message)
        {
            //-------------------------------------------------//
            // Check if the message is null or empty
            if (string.IsNullOrWhiteSpace(message))
            {
                return null;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Convert the message to lowercase for case-insensitive matching
            string lowered = message.ToLower();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the message contains "I'm interested in" or "My favourite topic is"
            if (Regex.IsMatch(lowered, @"i('?| a)m interested in") || lowered.Contains("my favourite topic is"))
            {
                //-------------------------------------------------//
                // Set the colour to the chatbot
                string[] parts = message.Split(new[] { "is", "interested in" }, StringSplitOptions.RemoveEmptyEntries);
                //-------------------------------------------------//
                
                //-------------------------------------------------//
                // Check if the message contains "is" or "interested in"
                if (parts.Length > 1)
                {
                    //-------------------------------------------------//
                    // Set the favourite topic to the part after "is" or "interested in"
                    favouriteTopic = parts[1].Trim();
                    favouriteTopic = Regex.Replace(favouriteTopic, @"[^\w\s]", "");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the colour to the chatbot
                    favouriteCategory = null;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Load the responses from the JSON file
                    if (responses != null)
                    {
                        //-------------------------------------------------//
                        // Check if the favourite topic matches any category
                        foreach (var category in responses.Keys)
                        {
                            //-------------------------------------------------//
                            // Check if the category contains the favourite topic
                            if (category.Replace('_', ' ').ToLower().Trim().Contains(favouriteTopic.ToLower().Trim()))
                            {
                                //-------------------------------------------------//
                                // Set the favourite category to the matching category
                                favouriteCategory = category;
                                break;
                                //-------------------------------------------------//
                            }
                            //-------------------------------------------------//
                        }
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    string confirmation;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Provide confirmation to the user
                    if (!string.IsNullOrEmpty(favouriteCategory))
                    {
                        //-------------------------------------------------//
                        // Provide confirmation with the category
                        confirmation = $"That's great! I'll remember that your favorite topic is {favouriteTopic}, which matches the {favouriteCategory.Replace('_', ' ')} category.";
                        //-------------------------------------------------//
                    }
                    else
                    {
                        //-------------------------------------------------//
                        // Provide confirmation without the category
                        confirmation = $"That's great! I'll remember that your favorite topic is {favouriteTopic}.";
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Return the confirmation message
                    return confirmation;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
            return null;
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Helper method to detect confusion or follow-up requests
        // This method was assistedby Copilot, I used it to create the list of triggers
        public static bool IsConfusionOrFollowUp(string message)
        {
            //-------------------------------------------------//
            // Check if the message is null or empty
            if (string.IsNullOrWhiteSpace(message))
            {
                return false;
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Convert the message to lowercase for case-insensitive matching
            string lowered = message.ToLower();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // List of triggers for confusion or follow-up requests
            string[] triggers = new string[]
            {
                "i don't understand",
                "can you explain",
                "explain more",
                "tell me more",
                "more details",
                "what do you mean",
                "clarify",
                "could you elaborate",
                "elaborate"
            };
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the message contains any of the triggers
            foreach (var trigger in triggers)
            {
                //-------------------------------------------------//
                if (lowered.Contains(trigger))
                {
                    // set the colour to the chatbot
                    ConsoleFormat.SwitchTextColour(0);
                    Communication.TextToSpeech("I see, no worries at all, I'll be happy to explain in further detail.");
                    Console.WriteLine();
                    Thread.Sleep(3100);

                    return true;
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
            //-------------------------------------------------//
            // If no triggers are found, return false
            return false;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Searches for the user's message in the response dictionary and returns the chatbot's response.
        // Includes "general" category in both exact match and keyword fallback logic.
        // Randomly selects from multiple responses separated by "###".
        // Copilot assisted in creating this method.
        // </summary>
        public static string GetResponse(string message, string userName)
        {
            responses = LoadResponses();

            //-------------------------------------------------//
            // Convert message to lowercase for case-insensitive matching
            string loweredMessage = message.ToLower();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the message contains a note for a favourite topic
            string favouriteTopicResponse = IsFavouriteTopic(message);
            if (!string.IsNullOrEmpty(favouriteTopicResponse))
            {
                return favouriteTopicResponse;
            }
            //-------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//
            // Detect sentiment and set empathy prefix
            string sentiment = CheckSentiment(message);
            string empathyPrefix = "";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check the sentiment and set the empathy prefix accordingly
            if (sentiment == "worried")
            {
                //-------------------------------------------------//
                empathyPrefix = "It's completely understandable to feel that way. Cybersecurity can be scary, but feel free to ask me any questions you might have! Let me see if I can help you feel better";
                //set the colour to the chatbot
                ConsoleFormat.SwitchTextColour(0);
                Communication.TextToSpeech(empathyPrefix);
                Console.WriteLine();
                //-------------------------------------------------//
            }
            else if (sentiment == "frustrated")
            {
                //-------------------------------------------------//
                empathyPrefix = "I understand this can be frustrating. Cybersecurity can feel overwhelming, but I'm always here to help. ";
                //set the colour to the chatbot
                ConsoleFormat.SwitchTextColour(0);
                Communication.TextToSpeech(empathyPrefix);
                Console.WriteLine();
                //-------------------------------------------------//
            }
            else if (sentiment == "curious")
            {
                //-------------------------------------------------//
                empathyPrefix = "Curiosity is great! Learning more about cybersecurity in general is always a good idea. ";
                //set the colour to the chatbot
                ConsoleFormat.SwitchTextColour(0);
                Communication.TextToSpeech(empathyPrefix);
                Console.WriteLine();
                //-------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//
            // check if the message is a confusion or follow-up request
            if (IsConfusionOrFollowUp(loweredMessage) && !string.IsNullOrEmpty(lastQuestionKey))
            {
                //-------------------------------------------------//
                // Try to find a "more details" response for the last topic
                foreach (var categoryPair in responses)
                {
                    //-------------------------------------------------//
                    // Get the category name and its responses
                    var category = categoryPair.Value;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Check if the last question key exists in the category
                    string moreDetailsKey = lastQuestionKey + "_more_details";
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Check if the category contains the "more details" key
                    if (category.ContainsKey(moreDetailsKey))
                    {
                        //-------------------------------------------------//
                        // Return the personalized response
                        return category[moreDetailsKey].Replace("{UserName}", userName);
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // If not found, return a generic clarification
                return "Let me try to clarify. Could you please specify what you need more details about?";
                //-------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------------------//
            // Loop through all categories including general
            foreach (var categoryPair in responses)
            {
                //-------------------------------------------------//
                // Get the category name and its responses
                string categoryName = categoryPair.Key;
                var category = categoryPair.Value;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the message is an exact match in this category
                if (category.ContainsKey(loweredMessage))
                {
                    //-------------------------------------------------//
                    // Set the last question key to the current message
                    lastQuestionKey = loweredMessage;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Get raw response and pick a random variant
                    string[] possibleResponses = category[loweredMessage].Split(new string[] { "###" }, StringSplitOptions.None);
                    var random = new Random();
                    string chosenResponse = possibleResponses[random.Next(possibleResponses.Length)];
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // If this is the user's favorite category, return a custom message
                    if (!string.IsNullOrEmpty(favouriteCategory) && categoryName == favouriteCategory)
                    {
                        return $"As someone interested in {favouriteTopic}, here's some advice: {chosenResponse.Replace("{UserName}", userName)}";
                    }

                    // Return the personalized response
                    return chosenResponse.Replace("{UserName}", userName);

                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//
            // If exact match not found, check for keyword-based fallback

            //-------------------------------------------------//
            // Create an Array with the list of keywords and corresponding category keys
            string[,] keywords =
            {
                { "password", "phishing", "scam", "browsing", "browse", "personal data", "device", "threats", "privacy", "footprint" },
                { "password_security", "phishing_scams", "phishing_scams", "safe_browsing", "safe_browsing", "personal_data_protection", "device_security", "cyber_threats", "privacy", "privacy" }
            };
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Loop through the keyword list
            // Copilot assisted in creating this method by giving the code to loop through the keywords
            for (int i = 0; i < keywords.GetLength(1); i++)
            {
                if (loweredMessage.Contains(keywords[0, i].ToLower()))
                {
                    //-------------------------------------------------//
                    // Set the category key based on the keyword match
                    string categoryKey = keywords[1, i];
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // If category exists, get a random response from that category
                    if (responses.ContainsKey(categoryKey))
                    {
                        //-------------------------------------------------//
                        // Get all keys in the category
                        var keys = responses[categoryKey].Keys.ToList();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Check if there are any keys available
                        var random = new Random();
                        string selectedKey = keys[random.Next(keys.Count)];
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Track the actual question key used
                        lastQuestionKey = selectedKey;
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Get the response and split by "###" to pick a random one
                        string[] possibleResponses = responses[categoryKey][selectedKey].Split(new string[] { "###" }, StringSplitOptions.None);
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Pick a random response from the possible responses
                        string chosenResponse = possibleResponses[random.Next(possibleResponses.Length)];
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // If this is the user's favorite category, return a custom message
                        if (!string.IsNullOrEmpty(favouriteCategory) && categoryKey == favouriteCategory)
                        {
                            return $"As someone interested in {favouriteTopic}, here's some advice: {chosenResponse.Replace("{UserName}", userName)}";
                        }
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Return the personalized response
                        return chosenResponse.Replace("{UserName}", userName);
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Copilot help create this method by giving the code to check the general category should the others fail
            // Check if the message is an exact match in the general category
            if (responses.ContainsKey("general"))
            {
                //-------------------------------------------------//
                // Get a random response from the general category
                var generalResponses = responses["general"].Values.ToList();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if there are any responses available
                if (generalResponses.Count > 0)
                {
                    //-------------------------------------------------//
                    // Pick a random response from the general category
                    var random = new Random();
                    string rawResponse = generalResponses[random.Next(generalResponses.Count)];
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Split the response by "###" and pick a random one
                    string[] possibleResponses = rawResponse.Split(new string[] { "###" }, StringSplitOptions.None);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Pick a random response from the possible responses
                    string chosenResponse = possibleResponses[random.Next(possibleResponses.Length)];
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Return the personalized response
                    return chosenResponse.Replace("{UserName}", userName);
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
            // Default fallback response
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