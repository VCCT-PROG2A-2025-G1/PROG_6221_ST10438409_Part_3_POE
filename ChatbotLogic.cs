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
using PROG_6221_ST10438409_Part_1;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
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
            if (lowered.Contains("worried") 
                || lowered.Contains("concerned") 
                || lowered.Contains("anxious") 
                || lowered.Contains("nervous")
                || lowered.Contains("uneasy")
                || lowered.Contains("apprehensive")
                || lowered.Contains("fearful")
                || lowered.Contains("distressed"))
            {
                return "worried";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user is frustrated about a subject
            if (lowered.Contains("frustrated")
                || lowered.Contains("overwhelmed")
                || lowered.Contains("confused")
                || lowered.Contains("irritated")
                || lowered.Contains("discouraged")
                || lowered.Contains("exasperated")
                || lowered.Contains("disheartened")
                || lowered.Contains("agitated"))
            {
                return "frustrated";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user is curious about a subject
            if (lowered.Contains("curious")
                || lowered.Contains("wondering")
                || lowered.Contains("inquisitive")
                || lowered.Contains("eager")
                || lowered.Contains("inquiring")
                || lowered.Contains("questioning")
                || lowered.Contains("exploring"))
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
        public static async Task<bool> IsConfusionOrFollowUp(string message, MainWindow mainWindow)
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
                    Communication.TextToSpeech("I see, no worries at all, I'll be happy to explain in further detail.");
                    await mainWindow.TypeTextToChatbotOutputAsync("I see, no worries at all, I'll be happy to explain in further detail.");
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

        //-------------------------------------------------//
        // Add to ChatbotLogic class
        public static List<string> recentActions = new List<string>();
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method returns a summary of recent actions taken by the user.
        // </summary>
        public static string GetRecentActionsSummary()
        {
            //-------------------------------------------------//
            // Check if there are any recent actions
            if (recentActions.Count == 0)
            { 
                return "No recent actions found.";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Create a summary of recent actions
            string summary = "Here’s a summary of recent actions:\n";
            for (int i = 0; i < recentActions.Count; i++)
            {
                summary += $" {i + 1}. {recentActions[i]}\n";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Trim the summary to remove any trailing whitespace or newlines
            return summary.TrimEnd();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method checks if the user wants to create a task and opens the Task Assistant GUI if so.
        // Copilot helped with the creation of NPL simulation for task and reminder detection.
        // </summary>
        public static bool Check_TaskAssistant(string userMessage, MainWindow mainWindow)
        {

            //------------------------------------------------------------------------------------------------------------------//
            // Natural Language Processing (NLP) Simulation (GUI)

            //-------------------------------------------------//
            // Normalize message for case-insensitive matching
            string lowered = userMessage.ToLower();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Patterns for reminders and tasks
            var reminderPatterns = new[]
            {
                @"remind me to (?<title>.+?) (?<date>tomorrow|today|yesterday|monday|tuesday|wednesday|thursday|friday|saturday|sunday)(?:[?.,:]\s*)?$",
                @"remind me to (?<title>.+?)(?: on (?<date>[^?.,:]+))?(?:[?.,:]\s*)?$",
                @"can you remind me to (?<title>.+?) (?<date>tomorrow|today|yesterday|monday|tuesday|wednesday|thursday|friday|saturday|sunday)(?:[?.,:]\s*)?$",
                @"can you remind me to (?<title>.+?)(?: on (?<date>[^?.,:]+))?(?:[?.,:]\s*)?$",
                @"set a reminder (for|to) (?<title>.+?) (?<date>tomorrow|today|yesterday|monday|tuesday|wednesday|thursday|friday|saturday|sunday)(?:[?.,:]\s*)?$",
                @"set a reminder (for|to) (?<title>.+?)(?: on (?<date>[^?.,:]+))?(?:[?.,:]\s*)?$",
                @"add (a )?reminder (for|to) (?<title>.+?) (?<date>tomorrow|today|yesterday|monday|tuesday|wednesday|thursday|friday|saturday|sunday)(?:[?.,:]\s*)?$",
                @"add (a )?reminder (for|to) (?<title>.+?)(?: on (?<date>[^?.,:]+))?(?:[?.,:]\s*)?$",

                @"add (a )?reminder (for|to) (?<title>.+?) in (?<number>\d+) (?<unit>day|days|week|weeks|hour|hours|minute|minutes)(?:[?.,:]\s*)?$",
                @"set a reminder (for|to) (?<title>.+?) in (?<number>\d+) (?<unit>day|days|week|weeks|hour|hours|minute|minutes)(?:[?.,:]\s*)?$",
                @"can you remind me to (?<title>.+?) in (?<number>\d+) (?<unit>day|days|week|weeks|hour|hours|minute|minutes)(?:[?.,:]\s*)?$",
                @"remind me to (?<title>.+?) in (?<number>\d+) (?<unit>day|days|week|weeks|hour|hours|minute|minutes)(?:[?.,:]\s*)?$"
            };
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Patterns for task creation
            var taskPatterns = new[]
            {
                @"add (a )?task (to|for) (?<title>.+?)(?:\:|,|\.|\?|$)(?<desc>.*)",
                @"create (a )?task (to|for) (?<title>.+?)(?:\:|,|\.|\?|$)(?<desc>.*)"
            };
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Reminder detection
            foreach (var pattern in reminderPatterns)
            {
                //-------------------------------------------------//
                // Match the user message against the reminder patterns
                var match = Regex.Match(userMessage, pattern, RegexOptions.IgnoreCase);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // If a match is found, extract the title, date, and description
                if (match.Success)
                {
                    //-------------------------------------------------//
                    // Extract title, date, and description from the match
                    string title = match.Groups["title"].Value.Trim();
                    string desc = match.Groups["desc"].Value.Trim();
                    string date = match.Groups["date"].Success ? match.Groups["date"].Value.Trim() : "";                    
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Just use the title as the description for reminders
                    desc = title;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the Title to be only the first Word of the title
                    if (title.Contains(" "))
                    {
                        title = title.Split(' ')[0];
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Add to the summary and recent actions
                    string summary = $"Reminder set for '{title}'" + (string.IsNullOrEmpty(date) ? "" : $" on {date}") + ".";
                    recentActions.Add(summary);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Notify the user and open the Task Assistant GUI
                    Communication.TextToSpeech(summary);
                    mainWindow.Dispose();
                    TaskAssistant_GUI taskAssistantGUI = new TaskAssistant_GUI();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // create entry to activity log, check if_ it is a reminder or task
                    string lower = userMessage.ToLower();
                    string log = "";

                    if (lower.Contains("remind"))
                    {
                        log = "Reminder Added: " + title + " on " + DateTime.Now;
                    }else
                    {
                        log = "Task Added: " + title + " on " + DateTime.Now;
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //Add entry to activity log
                    ActivityLog.addEntry(log);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //import the title and description into the Task Assistant
                    taskAssistantGUI.setTaskDetails(title, desc, date);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Show the Task Assistant GUI
                    taskAssistantGUI.ShowDialog();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //return true
                    return true;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Task detection
            foreach (var pattern in taskPatterns)
            {
                //-------------------------------------------------//
                // Match the user message against the task patterns
                var match = Regex.Match(userMessage, pattern, RegexOptions.IgnoreCase);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // If a match is found, extract the title and description
                if (match.Success)
                {
                    //-------------------------------------------------//
                    // Extract title and description from the match
                    string title = match.Groups["title"].Value.Trim();
                    string desc = match.Groups["desc"].Value.Trim();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // If the description is empty, use the title as the description
                    if (string.IsNullOrEmpty(desc)) desc = title;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the Title to be only the first Word of the title
                    if (title.Contains(" "))
                    {
                        title = title.Split(' ')[0];
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Add to the summary and recent actions
                    string summary = $"Task added: '{title}'. Would you like to set a reminder for this task?";
                    recentActions.Add($"Task added: '{title}' (no reminder set).");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Notify the user and open the Task Assistant GUI
                    Communication.TextToSpeech(summary);
                    mainWindow.Dispose();
                    TaskAssistant_GUI taskAssistantGUI = new TaskAssistant_GUI();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Add entry to activity log
                    string lower = userMessage.ToLower();
                    string log = "";

                    if (lower.Contains("remind"))
                    {
                         log = "Reminder Added: " + title + " on " + DateTime.Now;
                    }
                    else
                    {
                         log = "Task Added: " + title + " on " + DateTime.Now;
                    }
                    //-------------------------------------------------//
                    ActivityLog.addEntry(log);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //import the title and description into the Task Assistant
                    taskAssistantGUI.setTaskDetails(title, desc, "");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Show the Task Assistant GUI
                    taskAssistantGUI.ShowDialog();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // return true
                    return true;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                //Check if the user is asking to create a task
                if (userMessage.ToLower().Contains("add") && userMessage.ToLower().Contains("task"))
                {
                    mainWindow.Dispose();
                    TaskAssistant_GUI GUI = new TaskAssistant_GUI();
                    GUI.ShowDialog();
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user message contains "create" and "task"
            if (lowered.Contains("reminder") || lowered.Contains("create") && lowered.Contains("task"))
            {
                //-------------------------------------------------//
                // close the main window
                mainWindow.Dispose();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // If the user wants to create a task, open the Task Assistant GUI
                TaskAssistant_GUI taskAssistantGUI = new TaskAssistant_GUI();
                taskAssistantGUI.ShowDialog();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the chatbot output to an empty string
                return true;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // If the user message does not contain "create" and "task", do nothing
            if((lowered.Contains("show") && lowered.Contains("task")) || (lowered.Contains("display") && lowered.Contains("task")))
            {
                //-------------------------------------------------//
                // close the main window
                mainWindow.Dispose();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Open the Display Window
                TaskAssistant taskAssistant = new TaskAssistant();
                taskAssistant.DisplayAllTasks();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the chatbot output to an empty string
                return true;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //if the usre asks to start the quiz, open the quiz window
            if (lowered.Contains("quiz"))
            {
                //-------------------------------------------------//
                // close the main window
                mainWindow.Dispose();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Open the Quiz Window
                Mini_Quiz_GUI quiz = new Mini_Quiz_GUI();
                quiz.ShowDialog();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Set the chatbot output to an empty string
                return true;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // else return false
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
        public static async Task<string> GetResponse(string message, string userName, MainWindow mainWindow)
        {
            responses = LoadResponses();

            //-------------------------------------------------//
            // Check if the user wants a task list summary_
            if (message.ToLower().Contains("what have you done for me"))
            {
                return GetRecentActionsSummary();
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //check task assistant
            if (Check_TaskAssistant(message, mainWindow))
            {
                return null;
            }
            //-------------------------------------------------//

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
                 
                Communication.TextToSpeech(empathyPrefix);
                await mainWindow.TypeTextToChatbotOutputAsync(empathyPrefix);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Continue with the program to generate a response for the user's question
                //--------------------------------------------------//
            }
            else if (sentiment == "frustrated")
            {
                //-------------------------------------------------//
                empathyPrefix = "I understand this can be frustrating. Cybersecurity can feel overwhelming, but I'm always here to help. ";
                //set the colour to the chatbot
                 
                Communication.TextToSpeech(empathyPrefix);
                await mainWindow.TypeTextToChatbotOutputAsync(empathyPrefix);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Continue with the program to generate a response for the user's question
                //--------------------------------------------------//
            }
            else if (sentiment == "curious")
            {
                //-------------------------------------------------//
                empathyPrefix = "Curiosity is great! Learning more about cybersecurity in general is always a good idea. ";
                //set the colour to the chatbot
                 
                Communication.TextToSpeech(empathyPrefix);
                await mainWindow.TypeTextToChatbotOutputAsync(empathyPrefix);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Continue with the program to generate a response for the user's question
                //--------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//
            // check if the message is a confusion or follow-up request
            if (await IsConfusionOrFollowUp(loweredMessage, mainWindow) && !string.IsNullOrEmpty(lastQuestionKey))
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
                { "password", "phishing", "scam", "browsing", "browse", "personal data", "device", "threats", "privacy", "footprint","hack", "malware", "virus", "encryption", "firewall", "update", "backup" },
                { "password_security", "phishing_scams", "phishing_scams", "safe_browsing", "safe_browsing", "personal_data_protection", "device_security", "cyber_threats", "privacy", "privacy", "cyber_threats", "cyber_threats", "cyber_threats", "privacy", "device_security", "device_security", "personal_data_protection" }
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
                        var random = new Random();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Create a random number generator
                        string selectedKey = keys

                            // Try to find a close match
                            .FirstOrDefault(k => k.ToLower().Contains(loweredMessage))

                            // Try to find a close match
                            ?? keys.FirstOrDefault(k => loweredMessage.Contains(k.ToLower()))

                            // Fallback to random
                            ?? keys[random.Next(keys.Count)];

                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Set the last question key to the selected key
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
                // Get the general category responses
                return "I'm sorry, I couldn't find an answer to your question.";
                //-------------------------------------------------//
            }
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
        public static async Task ListPossibleQuestions(MainWindow mainWindow)
        {
            //-------------------------------------------------//
            // Load the responses from the JSON file
            responses = LoadResponses();
            //-------------------------------------------------//

            //-------------------------------------------------//
            string fullMessage = "";
            string choice;
            bool validChoice = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Ask if the user wants to see questions by category or all questions
            string prompt = "Would you like to see questions for a specific category or all available questions?\n1. View questions by category\n2. View all questions\nPlease enter your choice (1 or 2): ";
            Communication.TextToSpeech(prompt);
            await mainWindow.TypeTextToChatbotOutputAsync(prompt);
            //-------------------------------------------------//

            while (!validChoice)
            {
                //-------------------------------------------------//
                // Get the input from the user
                choice = await mainWindow.GetUserInputAsync();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the user entered a valid choice
                if (choice == "1")
                {
                    //-------------------------------------------------//
                    // User chose to view questions by category
                    validChoice = true;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // List available categories
                    prompt = "Here are the available categories:\n";
                    fullMessage = prompt;
                    Communication.TextToSpeech("Here are the available categories:");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Display the categories
                    int index = 1;
                    foreach (var category in responses.Keys)
                    {
                        fullMessage += "\n" + index + ". " + category;
                        index++;
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Ask the user to select a category
                    Communication.TextToSpeech("Please enter the category number to see the questions: ");
                    fullMessage += ("\nPlease enter the category number to see the questions: ");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Display the categories in the chatbot output
                    await mainWindow.TypeTextToChatbotOutputAsync(fullMessage);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set validCategory to false to start the loop for category selection
                    bool validCategory = false;
                    while (!validCategory)
                    {
                        //-------------------------------------------------//
                        // Read user input and validate the category selection
                        if (int.TryParse(await mainWindow.GetUserInputAsync(), out int categoryChoice) && categoryChoice > 0 && categoryChoice <= responses.Keys.Count)
                        {
                            //-------------------------------------------------//
                            // Set the selected category
                            validCategory = true;
                            string selectedCategory = responses.Keys.ElementAt(categoryChoice - 1);
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Display questions from the selected category
                            Communication.TextToSpeech($"Here are the questions in {selectedCategory.Replace('_', ' ')}:");
                            fullMessage = ($"Here are the questions in {selectedCategory.Replace('_', ' ')}:") + "\n";
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Loop through and display the questions
                            foreach (var key in responses[selectedCategory].Keys)
                            {
                                fullMessage += (key) + "\n";
                            }
                            //-------------------------------------------------//

                            //-------------------------------------------------//
                            // Display the questions in the chatbot output
                            await mainWindow.TypeTextToChatbotOutputAsync(fullMessage);
                            //-------------------------------------------------//
                        }
                        else
                        {
                            //-------------------------------------------------//
                            // Invalid category choice, prompt again                             
                            Communication.TextToSpeech("Invalid choice. Please enter a valid category number.");
                            mainWindow.ChangeErrorMessage("\nPlease enter the category number: ");
                            //-------------------------------------------------//
                        }
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                else if (choice == "2")
                {
                    //-------------------------------------------------//
                    // User chose to view all questions
                    validChoice = true;
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Display all questions
                    Communication.TextToSpeech("Here are all the questions you can ask:");
                    fullMessage = ("Here are all the questions you can ask:");
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Loop through all categories and display questions
                    foreach (var category in responses.Values)
                    {
                        //-------------------------------------------------//
                        // Loop through and display the questions
                        foreach (var key in category.Keys)
                        {
                            fullMessage += "\n" + (key);
                        }
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                else
                {
                    //-------------------------------------------------//
                    // Invalid input, retry                     
                    Communication.TextToSpeech("Invalid choice. Please enter 1 or 2: ");
                     await mainWindow.TypeTextToChatbotOutputAsync("Invalid choice. Please enter 1 or 2: ");
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Ask the user for another message
            Thread.Sleep(2000);
            Communication.TextToSpeech("How else can I help you today: ");
            fullMessage += "\n\n\n" + ("How else can I help you today: ");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Display the questions in the chatbot output
            mainWindow.SetChatbotOutput(fullMessage);
            //-------------------------------------------------/
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//