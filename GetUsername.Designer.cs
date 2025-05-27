namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class GetUsername
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
            this.lblEnterName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnEnterName = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblEnterName
            // 
            this.lblEnterName.AutoSize = true;
            this.lblEnterName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEnterName.Location = new System.Drawing.Point(10, 11);
            this.lblEnterName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEnterName.Name = "lblEnterName";
            this.lblEnterName.Size = new System.Drawing.Size(45, 20);
            this.lblEnterName.TabIndex = 0;
            this.lblEnterName.Text = "label1";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.ForeColor = System.Drawing.SystemColors.Info;
            this.txtName.Location = new System.Drawing.Point(4, 43);
            this.txtName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(300, 26);
            this.txtName.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // btnEnterName
            // 
            this.btnEnterName.Location = new System.Drawing.Point(3, 81);
            this.btnEnterName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEnterName.Name = "btnEnterName";
            this.btnEnterName.Size = new System.Drawing.Size(97, 53);
            this.btnEnterName.TabIndex = 3;
            this.btnEnterName.Text = "Enter";
            this.btnEnterName.UseVisualStyleBackColor = true;
            this.btnEnterName.Click += new System.EventHandler(this.btnEnterName_Click_1);
            // 
            // GetUsername
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 138);
            this.Controls.Add(this.btnEnterName);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblEnterName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "GetUsername";
            this.Text = "GetUsername";
            this.Load += new System.EventHandler(this.GetUsername_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEnterName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button btnEnterName;
    }
}