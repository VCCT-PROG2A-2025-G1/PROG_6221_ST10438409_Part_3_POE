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
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

//------------------------------------------------------------------------------------------------------------------//

//-----------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    public partial class MainWindow : Form
    {
        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Constructor for the MainWindow class that initializes the components of the form.
        // </summary>
        public MainWindow()
        {
            //-------------------------------------------------//
            InitializeComponent();
            //-------------------------------------------------//

            //-------------------------------------------------//
            txtUserInput.KeyDown += txtUserInput_KeyDown;
            //-------------------------------------------------//

            //-------------------------------------------------//
            ApplyStyling();
            //-------------------------------------------------//

            //-------------------------------------------------//
            ApplyRoundedCorners();
            //-------------------------------------------------//

            //-------------------------------------------------//
            MainWindow_Shown();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method, makes the chatbot output view hidden then show 2 seconds after the window loads.
        // </summary>
        private async void MainWindow_Shown()
        {
            //-------------------------------------------------//
            // Hide the chatbot output TextBox initially
            txtChatbotOutput.Visible = false;
            txtErrorMessage.Visible = false;
            txtUserInput.Visible = false;
            lblCybersecurityChatbot.Visible = false;
            lblErrorMessage.Visible = false;
            lblUsername.Visible = false;
            lblExplain.Visible = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Wait for 2 seconds before showing the table
            await Task.Delay(1000);
            txtUserInput.Visible = true;

            await Task.Delay(500);
            txtChatbotOutput.Visible = true;

            await Task.Delay(200);
            lblUsername.Visible = true;

            await Task.Delay(200);
            lblCybersecurityChatbot.Visible = true;

            await Task.Delay(200);
            lblErrorMessage.Visible = true;

            await Task.Delay(200);
            lblExplain.Visible = true;
            string explain = "Type your message below and press Enter or click Send to chat with me.";


            lblExplain.Text = explain;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make the lblUsername equal the name of the user entered in the Communication.GetUserName() method
            lblUsername.Text = Program.userName;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Handles the KeyDown event for the user input TextBox to send input when Enter is pressed.
        // </summary>
        private void txtUserInput_KeyDown(object sender, KeyEventArgs e)
        {
            //-------------------------------------------------//
            // Check if the Enter key was pressed
            if (e.KeyCode == Keys.Enter)
            {
                //-------------------------------------------------//
                // Prevent the beep sound when Enter is pressed
                e.SuppressKeyPress = true;
                //-------------------------------------------------//
                // Trigger the button click event to send the input
                btnSend.PerformClick();
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //-------------------------------------------------//
        // Create a text string to return input from window
        public string UserInput
        {
            get { return txtUserInput.Text; }
            set { txtUserInput.Text = value; }
        }
        //-------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // Call this method to "speak" text in the chatbot output view
        public async Task TypeTextToChatbotOutputAsync(string message, int delayMs = 50)
        {
            //-------------------------------------------------//
            // Clear previous output
            txtChatbotOutput.Text = string.Empty;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Loop through each character in the message
            foreach (char c in message)
            {
                //-------------------------------------------------//
                // Append character
                txtChatbotOutput.Text += c;
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Optional: Scroll to end if multiline
                if (txtChatbotOutput.InvokeRequired)
                {
                    //-------------------------------------------------//
                    txtChatbotOutput.Invoke(new Action(() =>
                    {
                        txtChatbotOutput.SelectionStart = txtChatbotOutput.Text.Length;
                        txtChatbotOutput.ScrollToCaret();
                    }));
                    //-------------------------------------------------//
                }
                else
                {
                    //-------------------------------------------------//
                    txtChatbotOutput.SelectionStart = txtChatbotOutput.Text.Length;
                    //-------------------------------------------------//
                }

                //-------------------------------------------------//

                //-------------------------------------------------//
                // Wait for the specified delay
                await Task.Delay(delayMs);
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//


        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Applies custom styling to the form and its controls.
        // </summary>
        private void ApplyStyling()
        {
            //-------------------------------------------------//
            // Form background
            this.BackColor = Color.FromArgb(30, 34, 45);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // User input TextBox styling
            txtUserInput.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtUserInput.BackColor = Color.FromArgb(44, 47, 51);
            txtUserInput.ForeColor = Color.White;
            txtUserInput.BorderStyle = BorderStyle.FixedSingle;
            txtUserInput.BackColor = Color.FromArgb(44, 47, 51);
            txtUserInput.ForeColor = Color.White;
            txtUserInput.Padding = new Padding(8, 4, 8, 4);
            txtUserInput.ReadOnly = false; // Editable
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Error message TextBox styling
            txtErrorMessage.Font = new Font("Segoe UI", 10, FontStyle.Italic);
            txtErrorMessage.BackColor = Color.FromArgb(44, 47, 51);
            txtErrorMessage.ForeColor = Color.Red;
            txtErrorMessage.BorderStyle = BorderStyle.None;
            txtErrorMessage.ReadOnly = true; // Not editable
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Chatbot output TextBox styling
            txtChatbotOutput.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtChatbotOutput.BackColor = Color.FromArgb(44, 47, 51);
            txtChatbotOutput.ForeColor = Color.FromArgb(0, 200, 255);
            txtChatbotOutput.BorderStyle = BorderStyle.None;
            txtChatbotOutput.BackColor = Color.FromArgb(44, 47, 51);
            txtChatbotOutput.ForeColor = Color.FromArgb(0, 200, 255);
            txtChatbotOutput.Padding = new Padding(8, 4, 8, 4);
            txtChatbotOutput.ReadOnly = true; // Not editable
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Button styling
            btnSend.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnSend.BackColor = Color.FromArgb(0, 200, 255);
            btnSend.ForeColor = Color.White;
            btnSend.FlatStyle = FlatStyle.Flat;
            btnSend.FlatAppearance.BorderSize = 0;
            btnSend.Cursor = Cursors.Hand;
            btnSend.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnSend.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);
            btnSend.Region = new Region(new GraphicsPath(
                new[] {
                new Point(0, 10), new Point(10, 0), new Point(btnSend.Width - 10, 0),
                new Point(btnSend.Width, 10), new Point(btnSend.Width, btnSend.Height - 10),
                new Point(btnSend.Width - 10, btnSend.Height), new Point(10, btnSend.Height), new Point(0, btnSend.Height - 10)
                    },
                    new byte[] 
                    {
                        1, 1, 1, 1, 1, 1, 1, 1
                    }
                ));
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Button styling for help button
            btnHelp.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnHelp.BackColor = Color.FromArgb(0, 200, 255);
            btnHelp.ForeColor = Color.White;
            btnHelp.FlatStyle = FlatStyle.Flat;
            btnHelp.FlatAppearance.BorderSize = 0;
            btnHelp.Cursor = Cursors.Hand;
            btnHelp.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 150, 200);
            btnHelp.FlatAppearance.MouseDownBackColor = Color.FromArgb(0, 120, 180);
            btnHelp.Region = new Region(new GraphicsPath(
                new[] {
                new Point(0, 10), new Point(10, 0), new Point(btnHelp.Width - 10, 0),
                new Point(btnHelp.Width, 10), new Point(btnHelp.Width, btnSend.Height - 10),
                new Point(btnHelp.Width - 10, btnHelp.Height), new Point(10, btnHelp.Height), new Point(0, btnHelp.Height - 10)
                    },
                    new byte[]
                    {
                        1, 1, 1, 1, 1, 1, 1, 1
                    }
                ));
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Overrides the CreateParams property to add a drop shadow effect to the form.
        // </summary>
        protected override CreateParams CreateParams
        {
            //-------------------------------------------------//
            // Get the base CreateParams and modify it to include the drop shadow style
            get
            {
                //-------------------------------------------------//
                // CreateParams is a property that provides parameters for creating the form
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= 0x00020000;
                return cp;
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        private void txtErrorMessage_TextChanged(object sender, EventArgs e)
        { }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Method to change the Error message outside of the main window load method.
        // </summary>
        public void ChangeErrorMessage(string message)
        {
            //-------------------------------------------------//
            // Update the error message text
            txtErrorMessage.Text = message;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make the error message visible
            txtErrorMessage.Visible = true;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method will set the message directly without delay into the chatbot output screen
        // </summary>
        public void SetChatbotOutput(string message)
        {
            //-------------------------------------------------//
            // Set the chatbot output text directly
            txtChatbotOutput.Text = message;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Scroll to end if multiline
            txtChatbotOutput.SelectionStart = txtChatbotOutput.Text.Length;
            txtChatbotOutput.ScrollToCaret();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Handles the Load event of the MainWindow.
        // </summary>
        private void MainWindow_Load(object sender, EventArgs e)
        {
            // Call the asynchronous method from here
            _ = MainWindow_LoadAsync(sender, e);
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // loads the main window when the program starts.
        // </summary>
        private async Task MainWindow_LoadAsync(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Set the title of the main window
            this.Text = "Cybersecurity Chatbot";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set focus to the user input TextBox by default
            txtUserInput.Focus();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set so the window cannot be resized
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Make the window so that it cannot be closed
            this.ControlBox = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            //hide the error message label and block by default
            txtErrorMessage.Visible = false;
            txtErrorMessage.Enabled = false;
            txtErrorMessage.Text = "An error has occurred. Please try again later.";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Start the conversation loop
            await StartConversationAsync();
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method starts the conversation loop for the chatbot.
        // It continuously waits for user input, processes it, and provides responses.
        // The method uses asynchronous programming to handle user input without blocking the UI.
        // It was created with the help of GitHub Copilot.
        // </summary>
        public async Task StartConversationAsync()
        {
            //-------------------------------------------------//
            // Start the conversation loop
            while (true)
            {
                //-------------------------------------------------//
                // Wait for user input
                string userInput = await GetUserInputAsync();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Check if the user wants to exit
                if (string.IsNullOrWhiteSpace(userInput))
                {
                    //-------------------------------------------------//
                    // Display error message if input is empty or whitespace
                    txtErrorMessage.Text = "Please enter a valid message.";
                    txtErrorMessage.Visible = true;
                    Communication.TextToSpeech(txtErrorMessage.Text);
                    continue;
                    //-------------------------------------------------//
                }
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Hide the error message if input is valid
                txtErrorMessage.Visible = false;
                txtUserInput.Text = userInput.ToLower();
                //-------------------------------------------------//

                //-------------------------------------------------//
                // Process the input
                await Program.RunAsync(userInput, this);
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        private void label1_Click(object sender, EventArgs e)
        { }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Handles the click event for the Send button.
        // </summary>
        private async void btnSendInformation_ClickAsync(object sender, EventArgs e)
        {
            string userInput = txtUserInput.Text.Trim();

            //-------------------------------------------------//
            // Check user input for empty or whitespace
            if (string.IsNullOrWhiteSpace(userInput))
            {
                //-------------------------------------------------//
                // Display error message if input is empty or whitespace
                txtErrorMessage.Text = "Please enter a valid message.";
                txtErrorMessage.Visible = true;
                Communication.TextToSpeech(txtErrorMessage.Text);
                //-------------------------------------------------//
            }
            else
            {
                //-------------------------------------------------//
                // GetUserInputAsync handles the input.
                //-------------------------------------------------//
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This method retrieves user input from the TextBox asynchronously.
        // It uses a TaskCompletionSource to handle the asynchronous operation.
        // This method was created with the help of GitHub Copilot.
        // </summary>
        public Task<string> GetUserInputAsync()
        {
            //-------------------------------------------------//
            // Create a TaskCompletionSource to handle the asynchronous operation
            var tcs = new TaskCompletionSource<string>();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Create an event handler to capture the button click event
            EventHandler handler = null;
            handler = (s, e) =>
            {
                btnSend.Click -= handler;
                tcs.SetResult(txtUserInput.Text);
            };
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Attach the event handler to the button click event
            btnSend.Click += handler;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Clear the TextBox for new input
            txtUserInput.Clear();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Return the Task from the TaskCompletionSource
            return tcs.Task;
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Applies rounded corners to the form by creating a GraphicsPath and setting the Region property.
        // </summary>
        private void ApplyRoundedCorners(int radius = 20)
        {
            //-------------------------------------------------//
            // Create a GraphicsPath to define the rounded corners
            var path = new System.Drawing.Drawing2D.GraphicsPath();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Define the rounded rectangle path using arcs for each corner
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);
            path.AddArc(new Rectangle(this.Width - radius, 0, radius, radius), 270, 90);
            path.AddArc(new Rectangle(this.Width - radius, this.Height - radius, radius, radius), 0, 90);
            path.AddArc(new Rectangle(0, this.Height - radius, radius, radius), 90, 90);
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Close the figure to complete the path
            path.CloseFigure();
            this.Region = new Region(path);
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // Overrides the OnPaintBackground method to apply a custom gradient background to the form.
        // </summary>
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //-------------------------------------------------//
            // Create a linear gradient brush with custom colors and angle
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                Color.FromArgb(30, 34, 45), Color.FromArgb(0, 200, 255), 135F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
            }
            //-------------------------------------------------//
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        //This button will used to tell the user how to use the chatbot
        private void btnHelp_Click(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // set the help message
            string helpMessage = "This is a overview of what I am capable of helping you with!\n\n" +
                                 "1. Type your message in the input box.\n" +
                                 "2. Type 'show tasks' to get a list of created tasks\n" +
                                 "3. You can ask the chatbot to add a task.\n" +
                                 "4. You can ask the chatbot to set a reminder.\n" +
                                 "5. You can ask the chatbot to start a quiz to test your knowledge by typing 'start quiz'.\n" +
                                 "6. If you want to exit, type 'exit' and press Enter.\n\n" +
                                 "Feel free to ask about cybersecurity topics, tips, or any questions you have!";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Speak out loud and print in chatbot output
            Communication.TextToSpeech(helpMessage);
            TypeTextToChatbotOutputAsync(helpMessage);
            //-------------------------------------------------//

        }
        //------------------------------------------------------------------------------------------------------------------//

    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//