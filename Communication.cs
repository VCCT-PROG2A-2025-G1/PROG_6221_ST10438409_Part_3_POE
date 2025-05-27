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
using System.Collections.Concurrent;
using System.ComponentModel;
using System.Diagnostics;
using System.Speech.Synthesis;
using System.Threading;
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
    // This is the Communication class which is used to handle all communication from the chatbot.
    // </summary>
    public class Communication
    {
        //-------------------------------------------------//
        // Declare a static variable to store the chatbot responses
        private static readonly ConcurrentQueue<string> speechQueue = new ConcurrentQueue<string>();
        private static bool isSpeaking = false;
        private static readonly object lockObj = new object();
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is used to add a string to the speech queue and start the speech queue if it is not already running.
        // This method was created to handle the text-to-speech functionality in a thread-safe manner.
        // This method contains code from Copilot.
        // </summary>
        private static void StartSpeechQueue()
        {
            //-------------------------------------------------//
            // Check if the speech queue is already running
            lock (lockObj)
            {
                //-------------------------------------------------//
                // If it is already speaking, do not start again
                if (isSpeaking) return;
                isSpeaking = true;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Start a new task to process the speech queue
            Task.Run(() =>
            {
                //-------------------------------------------------//
                // Process the speech queue until it is empty
                while (speechQueue.TryDequeue(out string text))
                {
                    //-------------------------------------------------//
                    // Create a new SpeechSynthesizer instance and set the output to the default audio device
                    using (SpeechSynthesizer synth = new SpeechSynthesizer())
                    {
                        //-------------------------------------------------//
                        // Set the output to the default audio device
                        synth.SetOutputToDefaultAudioDevice();
                        synth.Speak(text);
                        //-------------------------------------------------//
                    }
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
                // After processing the queue, set isSpeaking to false
                lock (lockObj)
                {
                    //-------------------------------------------------//
                    // Indicate that the speech queue is no longer speaking
                    isSpeaking = false;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//
            });
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Ask the user to enter there name and store it in the userName variable.
        // </summary>
        public static string GetUserName()
        {
            //-------------------------------------------------//
            GetUsername getUsernameForm = new GetUsername();
            getUsernameForm.ShowDialog();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Close the FirstLoadingScreen form before the user has entered their name
            FirstLoadingScreen screen = new FirstLoadingScreen();
            screen.Close();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Declare a string variable to store the user's name
            string userName;
            string message;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get the username from the Username form
            userName = GetUsername.Username;
            //-------------------------------------------------//

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
            // Get the path to the Greeting.wav file in the project folder            
            string filePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "Greeting.wav");            
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if the file exists
            if (System.IO.File.Exists(filePath))
            {
                //-------------------------------------------------//
                // Play the Greeting.wav file
                System.Media.SoundPlayer player = new System.Media.SoundPlayer(filePath);
                player.Play();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Method that display the cybersecurity-themed symbol using ASCII art
                FirstLoadingScreen screen = new FirstLoadingScreen();
                screen.ShowDialog();
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // Display an error message if the file is not found
                Console.WriteLine("Greeting.wav file not found.");
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
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
                // Check if the string is null or whitespace before adding it to the queue
                if (string.IsNullOrWhiteSpace(v))
                {
                    //-------------------------------------------------//
                    // If the string is null or whitespace, do not add it to the queue
                    return;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Add the string to the speech queue
                speechQueue.Enqueue(v);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Start the speech queue if it is not already running
                StartSpeechQueue();
                //-------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//