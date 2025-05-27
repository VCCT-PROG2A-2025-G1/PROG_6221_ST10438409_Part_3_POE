using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PROG_6221_ST10438409_Part_3_POE
{
    //------------------------------------------------------------------------------------------------------------------//
    public partial class FirstLoadingScreen : Form
    {
        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // This is the constructor for the FirstLoadingScreen class.
        // </summary>
        public FirstLoadingScreen()
        {
            InitializeComponent();
        }
        //------------------------------------------------------------------------------------------------------------------//

        //------------------------------------------------------------------------------------------------------------------//
        // <summary>
        // I am using this method to handle the loading screen for the project.
        // </summary>
        private void FirstLoadingScreen_Load(object sender, EventArgs e)
        {
            //-------------------------------------------------//
            // Set the title for the loading screen
            this.Text = "Loading Cybersecurity Chatbot...";
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set the symbol for tha chatbot
            txtSymbol.Text = ConsoleFormat.CreateSymbol();
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set the screen so that it cannot be closed manually 
            this.ControlBox = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set so that the Loadinng screen cannot be minimized
            this.MinimizeBox = false;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Sets it so that the user cannot type in the textbox
            txtSymbol.ReadOnly = true;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Set the loading screen to be centered on the screen
            this.StartPosition = FormStartPosition.CenterScreen;
            //-------------------------------------------------//

            //-------------------------------------------------//
            // Wait 13 seconds then close the form
            var timer = new System.Windows.Forms.Timer();

            // 13 seconds
            timer.Interval = 13000;

            // Event handler for the timer tick event
            timer.Tick += (s, args) =>
            {
                timer.Stop();
                this.Close();
            };
            timer.Start();
            //-------------------------------------------------//

        }
        //------------------------------------------------------------------------------------------------------------------//
    }
    //------------------------------------------------------------------------------------------------------------------//
}
//-----------------------------------...ooo000 END OF FILE 000ooo...-----------------------------------//