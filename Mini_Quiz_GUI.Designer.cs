namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class Mini_Quiz_GUI
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
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.lblAnswer = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.rBtnA = new System.Windows.Forms.RadioButton();
            this.rBtnB = new System.Windows.Forms.RadioButton();
            this.txtChatbotAnswer = new System.Windows.Forms.RichTextBox();
            this.lblResponse = new System.Windows.Forms.Label();
            this.rBtnC = new System.Windows.Forms.RadioButton();
            this.rBtnD = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.lblCountDown = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(9, 8);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(49, 13);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "Question";
            // 
            // lblAnswer
            // 
            this.lblAnswer.AutoSize = true;
            this.lblAnswer.Location = new System.Drawing.Point(317, 9);
            this.lblAnswer.Name = "lblAnswer";
            this.lblAnswer.Size = new System.Drawing.Size(42, 13);
            this.lblAnswer.TabIndex = 1;
            this.lblAnswer.Text = "Answer";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(9, 42);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(270, 259);
            this.txtQuestion.TabIndex = 2;
            this.txtQuestion.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // rBtnA
            // 
            this.rBtnA.AutoSize = true;
            this.rBtnA.Location = new System.Drawing.Point(320, 58);
            this.rBtnA.Name = "rBtnA";
            this.rBtnA.Size = new System.Drawing.Size(32, 17);
            this.rBtnA.TabIndex = 4;
            this.rBtnA.TabStop = true;
            this.rBtnA.Text = "A";
            this.rBtnA.UseVisualStyleBackColor = true;
            // 
            // rBtnB
            // 
            this.rBtnB.AutoSize = true;
            this.rBtnB.Location = new System.Drawing.Point(320, 94);
            this.rBtnB.Name = "rBtnB";
            this.rBtnB.Size = new System.Drawing.Size(32, 17);
            this.rBtnB.TabIndex = 5;
            this.rBtnB.TabStop = true;
            this.rBtnB.Text = "B";
            this.rBtnB.UseVisualStyleBackColor = true;
            // 
            // txtChatbotAnswer
            // 
            this.txtChatbotAnswer.Location = new System.Drawing.Point(9, 353);
            this.txtChatbotAnswer.Name = "txtChatbotAnswer";
            this.txtChatbotAnswer.Size = new System.Drawing.Size(530, 99);
            this.txtChatbotAnswer.TabIndex = 6;
            this.txtChatbotAnswer.Text = "";
            // 
            // lblResponse
            // 
            this.lblResponse.AutoSize = true;
            this.lblResponse.Location = new System.Drawing.Point(6, 315);
            this.lblResponse.Name = "lblResponse";
            this.lblResponse.Size = new System.Drawing.Size(79, 13);
            this.lblResponse.TabIndex = 7;
            this.lblResponse.Text = "Correct Answer";
            // 
            // rBtnC
            // 
            this.rBtnC.AutoSize = true;
            this.rBtnC.Location = new System.Drawing.Point(320, 130);
            this.rBtnC.Name = "rBtnC";
            this.rBtnC.Size = new System.Drawing.Size(32, 17);
            this.rBtnC.TabIndex = 8;
            this.rBtnC.TabStop = true;
            this.rBtnC.Text = "C";
            this.rBtnC.UseVisualStyleBackColor = true;
            // 
            // rBtnD
            // 
            this.rBtnD.AutoSize = true;
            this.rBtnD.Location = new System.Drawing.Point(320, 166);
            this.rBtnD.Name = "rBtnD";
            this.rBtnD.Size = new System.Drawing.Size(33, 17);
            this.rBtnD.TabIndex = 9;
            this.rBtnD.TabStop = true;
            this.rBtnD.Text = "D";
            this.rBtnD.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(336, 212);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(186, 88);
            this.btnSubmit.TabIndex = 10;
            this.btnSubmit.Text = "Start";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // lblCountDown
            // 
            this.lblCountDown.AutoSize = true;
            this.lblCountDown.Location = new System.Drawing.Point(333, 315);
            this.lblCountDown.Name = "lblCountDown";
            this.lblCountDown.Size = new System.Drawing.Size(35, 13);
            this.lblCountDown.TabIndex = 11;
            this.lblCountDown.Text = "label1";
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(141, 310);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Mini_Quiz_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(551, 464);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblCountDown);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.rBtnD);
            this.Controls.Add(this.rBtnC);
            this.Controls.Add(this.lblResponse);
            this.Controls.Add(this.txtChatbotAnswer);
            this.Controls.Add(this.rBtnB);
            this.Controls.Add(this.rBtnA);
            this.Controls.Add(this.txtQuestion);
            this.Controls.Add(this.lblAnswer);
            this.Controls.Add(this.lblQuestion);
            this.Name = "Mini_Quiz_GUI";
            this.Text = "Mini_Quiz_GUI";
            this.Load += new System.EventHandler(this.Mini_Quiz_GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Label lblAnswer;
        private System.Windows.Forms.RichTextBox txtQuestion;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.RadioButton rBtnA;
        private System.Windows.Forms.RadioButton rBtnB;
        private System.Windows.Forms.RichTextBox txtChatbotAnswer;
        private System.Windows.Forms.Label lblResponse;
        private System.Windows.Forms.RadioButton rBtnC;
        private System.Windows.Forms.RadioButton rBtnD;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Label lblCountDown;
        private System.Windows.Forms.Button btnExit;
    }
}