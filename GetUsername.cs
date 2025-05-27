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
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
//------------------------------------------------------------------------------------------------------------------//

//------------------------------------------------------------------------------------------------------------------//
// <summary>
// The namespace is used to group classes that are logically related.
// </summary>
// </summary>
namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    public partial class GetUsername : Form
    {
        //--------------------------------------------------------------------------------------------//
        // This variable stores the username entered by the user.
        private static string username = "";
        //--------------------------------------------------------------------------------------------//

        //-------------------------------------------------//
        // This property allows access to the username variable.
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }
        //-------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        public GetUsername()
        {
            InitializeComponent();
            SetupForm();
            ApplyStyling();
        }
        //--------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        /// <summary>
        /// Sets up the form's properties and initial state.
        /// </summary>
        private void SetupForm()
        {
            this.Text = "Enter Your Name";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ControlBox = false;
            this.MinimizeBox = false;
            lblEnterName.Text = "Please enter your name:";
            txtName.Text = string.Empty;
        }
        //--------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        /// <summary>
        /// Applies professional, colorful, and modern styling to the form and its controls.
        /// </summary>
        private void ApplyStyling()
        {
            // Form background
            this.BackColor = Color.FromArgb(30, 34, 45);

            // Label styling
            lblEnterName.ForeColor = Color.FromArgb(0, 200, 255);
            lblEnterName.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblEnterName.BackColor = Color.Transparent;

            // TextBox styling
            txtName.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            txtName.BackColor = Color.FromArgb(44, 47, 51);
            txtName.ForeColor = Color.White;
            txtName.BorderStyle = BorderStyle.FixedSingle;

            // Button styling
            btnEnterName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            btnEnterName.BackColor = Color.FromArgb(0, 200, 255);
            btnEnterName.ForeColor = Color.White;
            btnEnterName.FlatStyle = FlatStyle.Flat;
            btnEnterName.FlatAppearance.BorderSize = 0;
            btnEnterName.Cursor = Cursors.Hand;

            // Optional: Rounded corners for the button (Windows 11+)
            btnEnterName.Region = System.Drawing.Region.FromHrgn(
                NativeMethods.CreateRoundRectRgn(0, 0, btnEnterName.Width, btnEnterName.Height, 20, 20)
            );
        }
        //--------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        // Native method for rounded corners
        private static class NativeMethods
        {
            [System.Runtime.InteropServices.DllImport("gdi32.dll", SetLastError = true)]
            public static extern IntPtr CreateRoundRectRgn(
                int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        }
        //--------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        private void GetUsername_Load(object sender, EventArgs e)
        {
            string message = "Welcome user, please enter your name: ";
            Communication.TextToSpeech(message);
        }
        //--------------------------------------------------------------------------------------------//

        //--------------------------------------------------------------------------------------------//
        private void btnEnterName_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                // Trim the input to remove leading and trailing whitespace
                Username = txtName.Text.Trim();

                //display a confirmation message
                string confirmationMessage = $"Thank you, {Username}. Your name has been recorded.";
                Communication.TextToSpeech(confirmationMessage);
                MessageBox.Show(confirmationMessage, "Name Recorded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Close the form after the name is entered
                this.Close();
            }
            else
            {
                string message = "Invalid Input";
                Communication.TextToSpeech(message);
                MessageBox.Show("Please enter your name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        //--------------------------------------------------------------------------------------------//

    }
    //--------------------------------------------------------------------------------------------//
}
//----------------------------------------  END OF FILE  ----------------------------------------------------//