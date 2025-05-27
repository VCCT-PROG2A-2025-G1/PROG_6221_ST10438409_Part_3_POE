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
using System.ComponentModel;
using System.Diagnostics;
using System.Speech.Synthesis;
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
            //------------------------------------------------------------------------------------------------------------------//
            // only run this method if_ 'v' is not null
            if(v != null)
            {
                //-------------------------------------------------//
                // Print border and label first
                ConsoleFormat.PrintBorderWithColour();
                Console.Write("\nChatbot: ");
                //-------------------------------------------------//

                //-------------------------------------------------//
                // This method uses the System.Speech.Synthesis namespace to convert text to speech
                using (SpeechSynthesizer synth = new SpeechSynthesizer())
                {
                    //-------------------------------------------------//
                    // Set the voice to the default system voice
                    synth.SetOutputToDefaultAudioDevice();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Set the rate of speech
                    int charIndex = 0;
                    synth.SpeakProgress += (sender, e) =>
                    {
                        //-------------------------------------------------//
                        // Print the next chunk of text as it's spoken
                        while (charIndex < e.CharacterPosition + e.CharacterCount && charIndex < v.Length)
                        {
                            //-------------------------------------------------//
                            // Print the next character
                            Console.Write(v[charIndex]);
                            charIndex++;
                            //-------------------------------------------------//
                        }
                        //-------------------------------------------------//
                    };
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Speak synchronously (blocks until done to prevent voice overlap)

                    synth.Speak(v);
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Print any remaining characters
                    while (charIndex < v.Length)
                    {
                        //-------------------------------------------------//
                        Console.Write(v[charIndex]);
                        charIndex++;
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                Thread.Sleep(1000);
            }
            //------------------------------------------------------------------------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//