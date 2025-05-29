namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class TaskAssistant_GUI
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
            this.lblTaskName = new System.Windows.Forms.Label();
            this.lblTaskDescription = new System.Windows.Forms.Label();
            this.lblTaskReminder = new System.Windows.Forms.Label();
            this.txtTaskName = new System.Windows.Forms.RichTextBox();
            this.txtTaskDescription = new System.Windows.Forms.RichTextBox();
            this.btnSaveTask = new System.Windows.Forms.Button();
            this.btnCancelTask = new System.Windows.Forms.Button();
            this.txtErrorMessage = new System.Windows.Forms.RichTextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dtpReminderDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // lblTaskName
            // 
            this.lblTaskName.AutoSize = true;
            this.lblTaskName.Location = new System.Drawing.Point(7, 6);
            this.lblTaskName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaskName.Name = "lblTaskName";
            this.lblTaskName.Size = new System.Drawing.Size(78, 16);
            this.lblTaskName.TabIndex = 0;
            this.lblTaskName.Text = "Task Name";
            // 
            // lblTaskDescription
            // 
            this.lblTaskDescription.AutoSize = true;
            this.lblTaskDescription.Location = new System.Drawing.Point(352, 6);
            this.lblTaskDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaskDescription.Name = "lblTaskDescription";
            this.lblTaskDescription.Size = new System.Drawing.Size(109, 16);
            this.lblTaskDescription.TabIndex = 1;
            this.lblTaskDescription.Text = "Task Description";
            // 
            // lblTaskReminder
            // 
            this.lblTaskReminder.AutoSize = true;
            this.lblTaskReminder.Location = new System.Drawing.Point(741, 6);
            this.lblTaskReminder.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTaskReminder.Name = "lblTaskReminder";
            this.lblTaskReminder.Size = new System.Drawing.Size(160, 16);
            this.lblTaskReminder.TabIndex = 2;
            this.lblTaskReminder.Text = "Reminder Date (optional):";
            // 
            // txtTaskName
            // 
            this.txtTaskName.Location = new System.Drawing.Point(11, 53);
            this.txtTaskName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTaskName.Name = "txtTaskName";
            this.txtTaskName.Size = new System.Drawing.Size(301, 259);
            this.txtTaskName.TabIndex = 3;
            this.txtTaskName.Text = "";
            // 
            // txtTaskDescription
            // 
            this.txtTaskDescription.Location = new System.Drawing.Point(356, 53);
            this.txtTaskDescription.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTaskDescription.Name = "txtTaskDescription";
            this.txtTaskDescription.Size = new System.Drawing.Size(301, 259);
            this.txtTaskDescription.TabIndex = 4;
            this.txtTaskDescription.Text = "";
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Location = new System.Drawing.Point(888, 321);
            this.btnSaveTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(160, 68);
            this.btnSaveTask.TabIndex = 6;
            this.btnSaveTask.Text = "Save Task";
            this.btnSaveTask.UseVisualStyleBackColor = true;
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // btnCancelTask
            // 
            this.btnCancelTask.Location = new System.Drawing.Point(11, 320);
            this.btnCancelTask.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCancelTask.Name = "btnCancelTask";
            this.btnCancelTask.Size = new System.Drawing.Size(160, 68);
            this.btnCancelTask.TabIndex = 7;
            this.btnCancelTask.Text = "Cancel Task";
            this.btnCancelTask.UseVisualStyleBackColor = true;
            this.btnCancelTask.Click += new System.EventHandler(this.btnCancelTask_Click);
            // 
            // txtErrorMessage
            // 
            this.txtErrorMessage.Location = new System.Drawing.Point(312, 324);
            this.txtErrorMessage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtErrorMessage.Name = "txtErrorMessage";
            this.txtErrorMessage.Size = new System.Drawing.Size(432, 62);
            this.txtErrorMessage.TabIndex = 8;
            this.txtErrorMessage.Text = "";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // dtpReminderDate
            // 
            this.dtpReminderDate.Location = new System.Drawing.Point(745, 134);
            this.dtpReminderDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpReminderDate.Name = "dtpReminderDate";
            this.dtpReminderDate.Size = new System.Drawing.Size(265, 22);
            this.dtpReminderDate.TabIndex = 9;
            // 
            // TaskAssistant_GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 404);
            this.Controls.Add(this.dtpReminderDate);
            this.Controls.Add(this.txtErrorMessage);
            this.Controls.Add(this.btnCancelTask);
            this.Controls.Add(this.btnSaveTask);
            this.Controls.Add(this.txtTaskDescription);
            this.Controls.Add(this.txtTaskName);
            this.Controls.Add(this.lblTaskReminder);
            this.Controls.Add(this.lblTaskDescription);
            this.Controls.Add(this.lblTaskName);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "TaskAssistant_GUI";
            this.Text = "TaskAssistant_GUI";
            this.Load += new System.EventHandler(this.TaskAssistant_GUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTaskName;
        private System.Windows.Forms.Label lblTaskDescription;
        private System.Windows.Forms.Label lblTaskReminder;
        private System.Windows.Forms.RichTextBox txtTaskName;
        private System.Windows.Forms.RichTextBox txtTaskDescription;
        private System.Windows.Forms.Button btnSaveTask;
        private System.Windows.Forms.Button btnCancelTask;
        private System.Windows.Forms.RichTextBox txtErrorMessage;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.DateTimePicker dtpReminderDate;
    }
}