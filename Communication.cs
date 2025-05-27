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
using System.Speech.Synthesis;
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
    // This is the Communication class which is used to handle all communication from the chatbot.
    // </summary>
    public class Communication
    {

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Ask the user to enter there name and store it in the userName variable.
        // </summary>
        public static string GetUserName()
        {
            //-------------------------------------------------//
            // Declare a string variable to store the user's name
            string userName;
            string message;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Ask the user for their name
            message = "Welcome user, please enter your name: ";
            Communication.TextToSpeech(message);

            //-------------------------------------------------//
            //set the colour to the user
            ConsoleFormat.SwitchTextColour(1);
            //-------------------------------------------------//

            userName = Console.ReadLine();
            ConsoleFormat.PrintBorderWithColour();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the user entered a name
            while (string.IsNullOrWhiteSpace(userName))
            {
                //-------------------------------------------------//
                //set the colour to the chatbot
                ConsoleFormat.SwitchTextColour(0);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Ask the user for their name again if they didn't enter anything
                message = "Please enter your name: ";
                Communication.TextToSpeech(message);

                //-------------------------------------------------//
                //set the colour to the user
                ConsoleFormat.SwitchTextColour(1);
                //-------------------------------------------------//

                //-------------------------------------------------//
                userName = Console.ReadLine();
                ConsoleFormat.PrintBorderWithColour();
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Display the user's name
            message = $"Hello {userName}, it's nice to meet you!\nNow how can I assist you today?";
            Communication.TextToSpeech(message);
            //-------------------------------------------------//

            //-------------------------------------------------//
            //set the colour to the user
            ConsoleFormat.SwitchTextColour(1);
            //-------------------------------------------------//

            Console.Write("\nYou: ");

            //-------------------------------------------------//
            // Return the user's name
            return userName;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Plays the Greeting.wav file to welcome the user.
        // This method contains code from Copilot. 
        // Copilot gave the code to link the 'Greeting.wav' file to the project from the resources folder.
        // </summary>
        public static void FirstGreeting()
        {
            //-------------------------------------------------//
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get the path to the Greeting.wav file in the project folder            
            string welcomeMessage = "Welcome to the Cybersecurity Support Chatbot!";
            Thread.Sleep(500);
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Greeting.wav");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                //-------------------------------------------------//
                // Play the Greeting.wav file
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
                player.PlaySync();
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // Display an error message if the file is not found
                Console.WriteLine("Greeting.wav file not found.");
                Console.Beep(800, 300);
                Console.Beep(600, 300);
                Console.Beep(400, 300);
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //set the colour to the chatbot
            ConsoleFormat.SwitchTextColour(0);
            //-------------------------------------------------//

            //-------------------------------------------------//
            //Call TextToSpeech method to convert the welcome message to speech            
            Communication.TextToSpeech(welcomeMessage);
            //-------------------------------------------------//
            Thread.Sleep(1000);
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        //this method receives a string and uses the Chatbot to create a TTS voice response.
        // This method contains code from Copilot.
        // The code from Copilot was used to create a second thread to run the TTS voice response.
        // </summary>
        public static void TextToSpeech(string v)
        {
            //-------------------------------------------------//
            // Create a new SpeechSynthesizer object
            SpeechSynthesizer synth = new SpeechSynthesizer();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set the output to the default audio device
            synth.SetOutputToDefaultAudioDevice();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Start speaking in a new thread
            Thread speechThread = new Thread(() => synth.SpeakAsync(v));
            speechThread.Start();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Print the text while it's speaking
            PrintTextWithDelay(v);
            //-------------------------------------------------//
        }

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method prints text character by character with a delay.
        // Extracted for better testability.
        // </summary>
        public static void PrintTextWithDelay(string text)
        {
            //-------------------------------------------------//
            // print border
            ConsoleFormat.PrintBorderWithColour();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Print the text character by character with a delay
            Console.Write("\nChatbot: ");
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(50);
            }
            //-------------------------------------------------//
            Thread.Sleep(1000);
        }
        //------------------------------------------------------------------------------------------------------------------//


    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//