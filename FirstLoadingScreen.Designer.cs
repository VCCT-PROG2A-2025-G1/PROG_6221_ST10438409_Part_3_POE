namespace PROG_6221_ST10438409_Part_3_POE
{
    partial class FirstLoadingScreen
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
            this.txtSymbol = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // txtSymbol
            // 
            this.txtSymbol.Font = new System.Drawing.Font("Arial", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSymbol.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.txtSymbol.Location = new System.Drawing.Point(4, 4);
            this.txtSymbol.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtSymbol.Name = "txtSymbol";
            this.txtSymbol.Size = new System.Drawing.Size(1356, 446);
            this.txtSymbol.TabIndex = 0;
            this.txtSymbol.Text = "";
            // 
            // FirstLoadingScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 458);
            this.Controls.Add(this.txtSymbol);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FirstLoadingScreen";
            this.Text = "FirstLoadingScreen";
            this.Load += new System.EventHandler(this.FirstLoadingScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox txtSymbol;
    }
}