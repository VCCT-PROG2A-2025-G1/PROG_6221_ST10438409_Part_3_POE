namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class MainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.txtChatbotOutput = new System.Windows.Forms.RichTextBox();
            this.txtUserInput = new System.Windows.Forms.RichTextBox();
            this.txtErrorMessage = new System.Windows.Forms.RichTextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.lblCybersecurityChatbot = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.lblErrorMessage = new System.Windows.Forms.Label();
            this.lblExplain = new System.Windows.Forms.Label();
            this.btnHelp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(533, 554);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // txtChatbotOutput
            // 
            this.txtChatbotOutput.Location = new System.Drawing.Point(17, 76);
            this.txtChatbotOutput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtChatbotOutput.Name = "txtChatbotOutput";
            this.txtChatbotOutput.Size = new System.Drawing.Size(495, 462);
            this.txtChatbotOutput.TabIndex = 1;
            this.txtChatbotOutput.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(541, 76);
            this.txtUserInput.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(495, 218);
            this.txtUserInput.TabIndex = 2;
            this.txtUserInput.Text = "";
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(541, 348);
            this.txtErrorMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(333, 83);
            this.txtErrorMessage.TabIndex = 3;
            this.txtErrorMessage.Text = "";
            this.txtErrorMessage.TextChanged += new System.EventHandler(this.txtErrorMessage_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(905, 434);
            this.btnSend.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(132, 86);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSendInformation_ClickAsync);
            // 
            // lblCybersecurityChatbot
            // 
            this.lblCybersecurityChatbot.AutoSize = true;
            this.lblCybersecurityChatbot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCybersecurityChatbot.Location = new System.Drawing.Point(17, 16);
            this.lblCybersecurityChatbot.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCybersecurityChatbot.Name = "lblCybersecurityChatbot";
            this.lblCybersecurityChatbot.Size = new System.Drawing.Size(138, 16);
            this.lblCybersecurityChatbot.TabIndex = 5;
            this.lblCybersecurityChatbot.Text = "Cybersecurity Chatbot";
            this.lblCybersecurityChatbot.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(541, 16);
            this.lblUsername.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(86, 16);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "User account";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblErrorMessage.Location = new System.Drawing.Point(541, 311);
            this.lblErrorMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(96, 16);
            this.lblErrorMessage.TabIndex = 7;
            this.lblErrorMessage.Text = "Error Message";
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblExplain.Location = new System.Drawing.Point(541, 46);
            this.lblExplain.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(242, 16);
            this.lblExplain.TabIndex = 8;
            this.lblExplain.Text = "Enter Your Message in the Block below:";
            // 
            // btnHelp
            // 
            this.btnHelp.Location = new System.Drawing.Point(544, 434);
            this.btnHelp.Margin = new System.Windows.Forms.Padding(4);
            this.btnHelp.Name = "btnHelp";
            this.btnHelp.Size = new System.Drawing.Size(132, 86);
            this.btnHelp.TabIndex = 9;
            this.btnHelp.Text = "Help";
            this.btnHelp.UseVisualStyleBackColor = true;
            this.btnHelp.Click += new System.EventHandler(this.btnHelp_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.btnHelp);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCybersecurityChatbot);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.txtChatbotOutput);
            this.Controls.Add(this.splitter1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.RichTextBox txtChatbotOutput;
        private System.Windows.Forms.RichTextBox txtUserInput;
        private System.Windows.Forms.RichTextBox txtErrorMessage;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblCybersecurityChatbot;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblErrorMessage;
        private System.Windows.Forms.Label lblExplain;
        private System.Windows.Forms.Button btnHelp;
    }
}