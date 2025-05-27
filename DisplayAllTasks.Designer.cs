namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class DisplayAllTasks
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtListOfTasks = new System.Windows.Forms.RichTextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCompleteTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitle.Location = new System.Drawing.Point(13, 7);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(162, 25);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "List of all Tasks";
            // 
            // txtListOfTasks
            // 
            this.txtListOfTasks.Location = new System.Drawing.Point(5, 52);
            this.txtListOfTasks.Name = "txtListOfTasks";
            this.txtListOfTasks.Size = new System.Drawing.Size(385, 294);
            this.txtListOfTasks.TabIndex = 1;
            this.txtListOfTasks.Text = "";
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(10, 390);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(82, 56);
            this.btnReturn.TabIndex = 2;
            this.btnReturn.Text = "Return";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(161, 390);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(82, 56);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Task";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCompleteTask
            // 
            this.btnCompleteTask.Location = new System.Drawing.Point(308, 390);
            this.btnCompleteTask.Name = "btnCompleteTask";
            this.btnCompleteTask.Size = new System.Drawing.Size(82, 56);
            this.btnCompleteTask.TabIndex = 4;
            this.btnCompleteTask.Text = "Complete Task";
            this.btnCompleteTask.UseVisualStyleBackColor = true;
            this.btnCompleteTask.Click += new System.EventHandler(this.btnCompleteTask_Click);
            // 
            // DisplayAllTasks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(402, 450);
            this.Controls.Add(this.btnCompleteTask);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtListOfTasks);
            this.Controls.Add(this.lblTitle);
            this.Name = "DisplayAllTasks";
            this.Text = "DisplayAllTasks";
            this.Load += new System.EventHandler(this.DisplayAllTasks_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.RichTextBox txtListOfTasks;
        private System.Windows.Forms.Button btnReturn;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCompleteTask;
    }
}