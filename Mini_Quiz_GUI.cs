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
using PROG_6221_ST10438409_Part_1;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
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
    // This class represents the GUI for the Mini Quiz application.
    // </summary>
    public partial class Mini_Quiz_GUI : Form
    {
        //-------------------------------------------------//
        //create a new instance of the MiniQuiz class
        private MiniQuiz miniQuiz = new MiniQuiz();
        //-------------------------------------------------//

        //-------------------------------------------------//
        // Declare int to load each object in the quizQuestions list
        private int currentQuestionIndex = 0;
        private int correctCount = 0; 
        //-------------------------------------------------//

        //-------------------------------------------------//
        // create an array list to store the quiz questions
        private List<MiniQuiz> quizQuestions = new List<MiniQuiz>();
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This is the constructor for the Mini_Quiz_GUI class.
        // </summary>
        public Mini_Quiz_GUI()
        {
            InitializeComponent();
            ApplyStyling();
        }
        //------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Helper method to set rounded edges
        private void SetButtonRoundEdge(Button button, int radius)
        {
            //-------------------------------------------------//
            // Create a GraphicsPath to define the rounded rectangle shape
            var rect = new Rectangle(0, 0, button.Width, button.Height);
            var path = new GraphicsPath();
            int diameter = radius * 2;
            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();
            button.Region = new Region(path);
            //-------------------------------------------------//
        }
        //-------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Applies custom styling to the form and its controls.
        // </summary>
        private void ApplyStyling()
        {
            //-------------------------------------------------//
            // Round the button edges
            SetButtonRoundEdge(btnSubmit, 20);
            SetButtonRoundEdge(btnExit, 20);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Form background
            this.BackColor = Color.FromArgb(30, 34, 45);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Form title
            this.Text = "Mini Quiz Application";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make The answer text block the same formatting as the question text block
            txtChatbotAnswer.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtChatbotAnswer.BackColor = Color.FromArgb(44, 47, 51);
            txtChatbotAnswer.ForeColor = Color.White;
            txtChatbotAnswer.BorderStyle = BorderStyle.FixedSingle;
            txtChatbotAnswer.Padding = new Padding(8, 4, 8, 4);
            txtChatbotAnswer.ReadOnly = true;
            txtChatbotAnswer.Multiline = true; 
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Style for  TextBox txtQuestion
            txtQuestion.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtQuestion.BackColor = Color.FromArgb(44, 47, 51);
            txtQuestion.ForeColor = Color.White;
            txtQuestion.BorderStyle = BorderStyle.FixedSingle;
            txtQuestion.Padding = new Padding(8, 4, 8, 4);
            txtQuestion.ReadOnly = true;
            txtQuestion.Multiline = true;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make radio buttons font 14 and text colour white
            foreach (Control control in this.Controls)
            {
                //-------------------------------------------------//
                // Check if the control is a RadioButton and apply styles
                if (control is RadioButton radioButton)
                {
                    radioButton.Font = new Font("Segoe UI", 14, FontStyle.Regular);
                    radioButton.ForeColor = Color.White;
                    radioButton.BackColor = Color.FromArgb(44, 47, 51);
                    radioButton.FlatStyle = FlatStyle.Flat;
                    radioButton.Padding = new Padding(8, 4, 8, 4);
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set label colour to white
            foreach (Control control in this.Controls)
            {
                //-------------------------------------------------//
                // Check if the control is a Label and apply styles
                if (control is Label label)
                {
                    label.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                    label.ForeColor = Color.White;
                    label.BackColor = Color.Transparent; // Ensure background is transparent
                }
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Style for Button btnSubmit
            if (this.Controls.ContainsKey("btnSubmit"))
            {
                var btnSubmit = this.Controls["btnSubmit"] as Button;
                btnSubmit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnSubmit.BackColor = Color.FromArgb(0, 200, 255);
                btnSubmit.ForeColor = Color.White;
                btnSubmit.FlatStyle = FlatStyle.Flat;
                btnSubmit.FlatAppearance.BorderSize = 0;
                btnSubmit.Cursor = Cursors.Hand;
                btnSubmit.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
                btnSubmit.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Add the same styling to the exit button
            if (this.Controls.ContainsKey("btnExit"))
            {
                var btnExit = this.Controls["btnExit"] as Button;
                btnExit.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btnExit.BackColor = Color.FromArgb(255, 0, 0);
                btnExit.ForeColor = Color.White;
                btnExit.FlatStyle = FlatStyle.Flat;
                btnExit.FlatAppearance.BorderSize = 0;
                btnExit.Cursor = Cursors.Hand;
                btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(200, 0, 0);
                btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(180, 0, 0);
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//


        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the form is loaded.
        // </summary>
        private void Mini_Quiz_GUI_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            //Allow the chatbot reponse window to have multiple lines
            txtChatbotAnswer.Multiline = true;
            txtChatbotAnswer.ScrollBars = RichTextBoxScrollBars.Vertical;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //hide the countdown label until it is needed
            lblCountDown.Visible = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //Make it so that the windoow cannot be resized, or close
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false;
            //-------------------------------------------------//

            //------------------------------------------------------------------------------------------------------------------//
            // Populate the quizQuestions list with the values from the "10 Base Questions.txt" file
            // Build a relative path to the Resources folder
            string filePath = System.IO.Path.Combine(Application.StartupPath, "Resources", "Base Questions.txt");

            //-------------------------------------------------//
            // Check if the file exists and read the questions
            if (System.IO.File.Exists(filePath))
            {
                //-------------------------------------------------//
                // Read all lines from the file and parse them into MiniQuiz objects
                var lines = System.IO.File.ReadAllLines(filePath);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Initialize the index for reading lines
                // Copilot helped when it came to adding the true/false questions
                int i = 0;
                while (i < lines.Length)
                {
                    //-------------------------------------------------//
                    // Skip blank lines
                    if (string.IsNullOrWhiteSpace(lines[i]))
                    {
                        i++;
                        continue;
                    }
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Read the question and trim any leading/trailing whitespace
                    string question = lines[i++].Trim();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    // Check if next line is True/False or MCQ
                    if (i + 1 < lines.Length &&
                        (lines[i].Trim().Equals("True", StringComparison.OrdinalIgnoreCase) ||
                         lines[i].Trim().Equals("False", StringComparison.OrdinalIgnoreCase)))
                    {
                        //-------------------------------------------------//
                        // True/False question
                        string answerA = lines[i++].Trim();
                        string answerB = lines[i++].Trim();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Skip possible blank lines
                        while (i < lines.Length && string.IsNullOrWhiteSpace(lines[i])) i++;
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Read the correct answer and explanation
                        string correct = lines[i++].Trim().ToUpper();
                        string explanation = (i < lines.Length) ? lines[i++].Trim() : "";
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Add the True/False question to the quizQuestions list
                        quizQuestions.Add(new MiniQuiz(
                            question,
                            answerA,
                            answerB,
                            "", // No C
                            "", // No D
                            correct,
                            explanation
                        ));
                        //-------------------------------------------------//
                    }
                    else if (i + 5 < lines.Length)
                    {
                        //-------------------------------------------------//
                        // MCQ question
                        string answerA = lines[i++].Trim();
                        string answerB = lines[i++].Trim();
                        string answerC = lines[i++].Trim();
                        string answerD = lines[i++].Trim();
                        string correct = lines[i++].Trim().ToUpper();
                        string explanation = lines[i++].Trim();
                        //-------------------------------------------------//

                        //-------------------------------------------------//
                        // Add the MCQ question to the quizQuestions list
                        quizQuestions.Add(new MiniQuiz(
                            question,
                            answerA,
                            answerB,
                            answerC,
                            answerD,
                            correct,
                            explanation
                        ));
                    }
                    else
                    {
                        //-------------------------------------------------//
                        // Not enough lines for a question, break
                        break;
                        //-------------------------------------------------//
                    }
                }
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // Show an error message if the file does not exist
                MessageBox.Show("Quiz questions file not found:\n" + filePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //-------------------------------------------------//
            }
            //------------------------------------------------------------------------------------------------------------------//

            //-------------------------------------------------//
            // Change teh button text to "Submit"
            btnSubmit.Text = "Submit";
            //-------------------------------------------------//

            //-------------------------------------------------//
            //load the first question into the GUI
            currentQuestionIndex = LoadCurrentQuestion(currentQuestionIndex);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Text to Speech to greet the user
            Communication.TextToSpeech("Welcome to the Mini Quiz Application! Please answer the questions to the best of your ability.");
            //-------------------------------------------------//

        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Load the next question in the quizQuestions list into the GUI.
        // </summary>
        private int LoadCurrentQuestion(int index)
        {
            //-------------------------------------------------//
            // Check if the index is within the bounds of the quizQuestions list
            if (index < 0 || index >= quizQuestions.Count)
            {
                //-------------------------------------------------//
                // If the index is out of bounds, return the current index
                return index; 
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
            //-------------------------------------------------//
            // Load the current question from the quizQuestions list
            MiniQuiz currentQuestion = quizQuestions[index];
            txtQuestion.Text = currentQuestion.GetQuestionForQuiz();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Clear previous selections
            rBtnA.Checked = false;
            rBtnB.Checked = false;
            rBtnC.Checked = false;
            rBtnD.Checked = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Return the updated index            
            return index; 
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method is called when the Submit button is clicked.
        // </summary>
        private async void btnSubmit_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // check if_ the Quiz has done the first 10 questions then switch to using the True/False questions
            if(currentQuestionIndex > 8)
            {
                //-------------------------------------------------//
                //change the first 2 Radio buttons to True and False
                rBtnA.Text = "True";
                rBtnB.Text = "False";
                //-------------------------------------------------//

                //-------------------------------------------------//
                //Disable and hide the C and D radio buttons
                rBtnC.Visible = false;
                rBtnD.Visible = false;
                rBtnC.Enabled = false;
                rBtnD.Enabled = false;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//            

            //-------------------------------------------------//
            // check if_ the quiz is complete
            if (currentQuestionIndex >= quizQuestions.Count)
            {
                //-------------------------------------------------//
                // If the quiz is complete, show a message and reset the index
                Communication.TextToSpeech("Quiz completed! Thank you for participating.");
                MessageBox.Show("Quiz completed! Thank you for participating.", "Quiz Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Show the final score or any other end-of-quiz logic here
                Communication.TextToSpeech($"You answered {correctCount} out of {quizQuestions.Count} questions correctly.");
                MessageBox.Show($"You answered {correctCount} out of {quizQuestions.Count} questions correctly.", "Final Score", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Add an Quiz Entry
                ActivityLog.addEntry($"Quiz Ended: {correctCount} correct questions answered on " + DateTime.Now);
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Compliment the user if the score was above 12, else give a normnal message
                if (correctCount > 12)
                {
                    Communication.TextToSpeech("You did an amazing job! You are a cybersecurity expert!");
                    MessageBox.Show("You did an amazing job! You are a cybersecurity expert!", "Great Job!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //-----------------------------------//
                    // Open Main Window and dispose this window
                    MainWindow main= new MainWindow();
                    main.ShowDialog();
                    this.Dispose();
                    //-----------------------------------//
                }
                else if(correctCount > 6)
                {
                    Communication.TextToSpeech("Thank you for participating in the quiz. Keep learning and improving your cybersecurity knowledge!");
                    MessageBox.Show("Thank you for participating in the quiz. Keep learning and improving your cybersecurity knowledge!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //-----------------------------------//
                    // Open Main Window and dispose this window
                    MainWindow main = new MainWindow();
                    main.ShowDialog();
                    this.Dispose();
                    //-----------------------------------//
                }
                else
                {
                    Communication.TextToSpeech("Don't worry, you can keep learning and improving your cybersecurity knowledge. This will get you a better score next time.");
                    MessageBox.Show("Don't worry, you can keep learning and improving your cybersecurity knowledge. This will get you a better score next time.", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //-----------------------------------//
                    // Open Main Window and dispose this window
                    MainWindow main = new MainWindow();
                    main.ShowDialog();
                    this.Dispose();
                    //-----------------------------------/

                    //-------------------------------------------------//
                    //Open the Main Window
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.ShowDialog();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //dispose of the current form
                    this.Dispose();
                    //-------------------------------------------------//

                    //-------------------------------------------------//
                    //end method 
                    return;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if there are any quiz questions loaded
            if (quizQuestions.Count == 0)
            {
                MessageBox.Show("All quiz questions available have been answered.", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Communication.TextToSpeech("All quiz questions available have been answered.");
                btnSubmit.Text = "View Result";

                //-------------------------------------------------//
                // return
                return;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // load the current question from the quizQuestions list
            MiniQuiz currentQuestion = quizQuestions[currentQuestionIndex];
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Get the selected answer from the radio buttons
            string selectedAnswer = null;
            if (rBtnA.Checked) selectedAnswer = "A";
            else if (rBtnB.Checked) selectedAnswer = "B";
            else if (rBtnC.Checked) selectedAnswer = "C";
            else if (rBtnD.Checked) selectedAnswer = "D";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Check if an answer was selected
            if (selectedAnswer == null)
            {
                //-------------------------------------------------//
                // If no answer is selected, show a warning message
                Communication.TextToSpeech("Please select an answer before submitting.");
                MessageBox.Show("Please select an answer before submitting.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //get Explination from the current question
            string explanation = currentQuestion.GetExplanation();
            if (explanation == null) 
            {
                //-------------------------------------------------//
                // If no explanation is provided, set it to an empty string
                explanation = "No explanation provided.";
                //-------------------------------------------------//
            }

            //-------------------------------------------------//
            // Check if the selected answer is correct
            // Compare onlt hte first character from the method
            // GetCorrectAnswer returns the correct answer as a string with an explination
            // so we only need to compare the first character
            // This is done to ensure that the correct answer is compared correctly
            if (selectedAnswer == currentQuestion.GetCorrectAnswer())
            {
                //-------------------------------------------------//
                // If the answer is correct, show a success message
                string correctVoice = "Correct! Well done. " + "The correct answer was " + currentQuestion.GetCorrectAnswer() + ". Why? " + explanation;
                txtChatbotAnswer.Text = "Correct! Well done. " + "The correct answer was " + currentQuestion.GetCorrectAnswer() + "\nWhy? " + explanation;
                Communication.TextToSpeech(correctVoice);
                correctCount++;
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // If the answer is incorrect, show an error message
                string inCorrectVoice = "Incorrect. The correct answer was " + currentQuestion.GetCorrectAnswer() + ". Why? " + explanation;
                txtChatbotAnswer.Text = "Incorrect. The correct answer was " + currentQuestion.GetCorrectAnswer() + "\nWhy? " + explanation;
                Communication.TextToSpeech(inCorrectVoice);                
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Show the countdown label
            lblCountDown.Visible = true;
            //hide the submit button
            btnSubmit.Visible = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //start a count down before resuming            
            for (int count = 15; count > 0; count--)
            {
                //-------------------------------------------------//
                // Update the countdown label
                lblCountDown.Text = $"Next question in {count} seconds...";
                await Task.Delay(1000); // Wait for 1 second
                //-------------------------------------------------//
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            //Add Question Number
            if ((currentQuestionIndex + 1) < quizQuestions.Count)
            {
                lblAnswer.Text = $"Question {currentQuestionIndex + 2} of {quizQuestions.Count}";
            }
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Hide the countdown label after the countdown is complete
            lblCountDown.Visible = false;
            // Show the submit button again
            btnSubmit.Visible = true;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Clear the selected radio buttons            
            rBtnA.Checked = false;
            rBtnB.Checked = false;
            rBtnC.Checked = false;
            rBtnD.Checked = false;
            Communication.TextToSpeech("On to the next Question");
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Move to the next question
            currentQuestionIndex++;
            currentQuestionIndex = LoadCurrentQuestion(currentQuestionIndex);
            txtChatbotAnswer.Clear();
            //-------------------------------------------------//

        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Exit quiz and open the main window
        // </summary>
        private void btnExit_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Add an Quiz Entry
            ActivityLog.addEntry($"Quiz Ended: {currentQuestionIndex} questions answered on " + DateTime.Now);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Show a confirmation message before exiting
            this.Dispose();
            MessageBox.Show("Thank you for participating in the quiz. You can now return to the main window.", "Exit Quiz", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Open the Main Window
            MainWindow mainWindow = new MainWindow();
            mainWindow.ShowDialog();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//