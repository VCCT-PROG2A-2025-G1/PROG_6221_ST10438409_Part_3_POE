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
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(400, 450);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // txtChatbotOutput
            // 
            this.txtChatbotOutput.Location = new System.Drawing.Point(13, 62);
            this.txtChatbotOutput.Name = "txtChatbotOutput";
            this.txtChatbotOutput.Size = new System.Drawing.Size(372, 376);
            this.txtChatbotOutput.TabIndex = 1;
            this.txtChatbotOutput.Text = "";
            // 
            // txtUserInput
            // 
            this.txtUserInput.Location = new System.Drawing.Point(406, 62);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(372, 178);
            this.txtUserInput.TabIndex = 2;
            this.txtUserInput.Text = "";
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(406, 283);
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(251, 141);
            this.txtErrorMessage.TabIndex = 3;
            this.txtErrorMessage.Text = "";
            this.txtErrorMessage.TextChanged += new System.EventHandler(this.txtErrorMessage_TextChanged);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(679, 353);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(99, 70);
            this.btnSend.TabIndex = 4;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSendInformation_ClickAsync);
            // 
            // lblCybersecurityChatbot
            // 
            this.lblCybersecurityChatbot.AutoSize = true;
            this.lblCybersecurityChatbot.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblCybersecurityChatbot.Location = new System.Drawing.Point(13, 13);
            this.lblCybersecurityChatbot.Name = "lblCybersecurityChatbot";
            this.lblCybersecurityChatbot.Size = new System.Drawing.Size(110, 13);
            this.lblCybersecurityChatbot.TabIndex = 5;
            this.lblCybersecurityChatbot.Text = "Cybersecurity Chatbot";
            this.lblCybersecurityChatbot.Click += new System.EventHandler(this.label1_Click);
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblUsername.Location = new System.Drawing.Point(406, 13);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(71, 13);
            this.lblUsername.TabIndex = 6;
            this.lblUsername.Text = "User account";
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblErrorMessage.Location = new System.Drawing.Point(406, 253);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(75, 13);
            this.lblErrorMessage.TabIndex = 7;
            this.lblErrorMessage.Text = "Error Message";
            // 
            // lblExplain
            // 
            this.lblExplain.AutoSize = true;
            this.lblExplain.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblExplain.Location = new System.Drawing.Point(406, 37);
            this.lblExplain.Name = "lblExplain";
            this.lblExplain.Size = new System.Drawing.Size(196, 13);
            this.lblExplain.TabIndex = 8;
            this.lblExplain.Text = "Enter Your Message in the Block below:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lblExplain);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.lblUsername);
            this.Controls.Add(this.lblCybersecurityChatbot);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.txtChatbotOutput);
            this.Controls.Add(this.splitter1);
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
    }
}