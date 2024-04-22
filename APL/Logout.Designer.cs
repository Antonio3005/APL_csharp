namespace APL
{
    partial class Logout
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
            this.b_logout = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // b_logout
            // 
            this.b_logout.Location = new System.Drawing.Point(110, 86);
            this.b_logout.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.b_logout.Name = "b_logout";
            this.b_logout.Size = new System.Drawing.Size(89, 38);
            this.b_logout.TabIndex = 0;
            this.b_logout.Text = "Logout";
            this.b_logout.UseVisualStyleBackColor = true;
            this.b_logout.Click += new System.EventHandler(this.b_logout_Click);
            // 
            // Logout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 211);
            this.Controls.Add(this.b_logout);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Logout";
            this.Text = "Logout";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button b_logout;
    }
}