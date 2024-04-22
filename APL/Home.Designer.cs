namespace APL
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.label1 = new System.Windows.Forms.Label();
            this.search = new System.Windows.Forms.Button();
            this.txtFrom = new System.Windows.Forms.TextBox();
            this.txtTo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.priceMin = new System.Windows.Forms.TextBox();
            this.priceMax = new System.Windows.Forms.TextBox();
            this.favourites = new System.Windows.Forms.PictureBox();
            this.account = new System.Windows.Forms.PictureBox();
            this.DataFrom = new System.Windows.Forms.DateTimePicker();
            this.DataTo = new System.Windows.Forms.DateTimePicker();
            this.ReturnFrom = new System.Windows.Forms.DateTimePicker();
            this.ReturnTo = new System.Windows.Forms.DateTimePicker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.favourites)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.account)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(65, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Benvenuto";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(287, 272);
            this.search.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(111, 36);
            this.search.TabIndex = 1;
            this.search.Text = "Cerca";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // txtFrom
            // 
            this.txtFrom.Location = new System.Drawing.Point(70, 90);
            this.txtFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtFrom.Name = "txtFrom";
            this.txtFrom.Size = new System.Drawing.Size(212, 22);
            this.txtFrom.TabIndex = 2;
            this.txtFrom.Text = "Da";
            // 
            // txtTo
            // 
            this.txtTo.Location = new System.Drawing.Point(333, 90);
            this.txtTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtTo.Name = "txtTo";
            this.txtTo.Size = new System.Drawing.Size(214, 22);
            this.txtTo.TabIndex = 3;
            this.txtTo.Text = "A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Date di partenza";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(330, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Date di ritorno";
            // 
            // priceMin
            // 
            this.priceMin.Location = new System.Drawing.Point(70, 227);
            this.priceMin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceMin.Name = "priceMin";
            this.priceMin.Size = new System.Drawing.Size(212, 22);
            this.priceMin.TabIndex = 9;
            this.priceMin.Text = "Prezzo min";
            // 
            // priceMax
            // 
            this.priceMax.Location = new System.Drawing.Point(333, 227);
            this.priceMax.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.priceMax.Name = "priceMax";
            this.priceMax.Size = new System.Drawing.Size(214, 22);
            this.priceMax.TabIndex = 10;
            this.priceMax.Text = "Prezzo max";
            // 
            // favourites
            // 
            this.favourites.Image = ((System.Drawing.Image)(resources.GetObject("favourites.Image")));
            this.favourites.Location = new System.Drawing.Point(544, 33);
            this.favourites.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.favourites.Name = "favourites";
            this.favourites.Size = new System.Drawing.Size(43, 29);
            this.favourites.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.favourites.TabIndex = 11;
            this.favourites.TabStop = false;
            this.favourites.Click += new System.EventHandler(this.favourites_Click);
            // 
            // account
            // 
            this.account.Image = ((System.Drawing.Image)(resources.GetObject("account.Image")));
            this.account.Location = new System.Drawing.Point(515, 33);
            this.account.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.account.Name = "account";
            this.account.Size = new System.Drawing.Size(24, 29);
            this.account.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.account.TabIndex = 12;
            this.account.TabStop = false;
            this.account.Click += new System.EventHandler(this.account_Click);
            // 
            // DataFrom
            // 
            this.DataFrom.Location = new System.Drawing.Point(70, 146);
            this.DataFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataFrom.Name = "DataFrom";
            this.DataFrom.Size = new System.Drawing.Size(212, 22);
            this.DataFrom.TabIndex = 15;
            // 
            // DataTo
            // 
            this.DataTo.Location = new System.Drawing.Point(70, 181);
            this.DataTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.DataTo.Name = "DataTo";
            this.DataTo.Size = new System.Drawing.Size(212, 22);
            this.DataTo.TabIndex = 16;
            // 
            // ReturnFrom
            // 
            this.ReturnFrom.Location = new System.Drawing.Point(333, 146);
            this.ReturnFrom.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnFrom.Name = "ReturnFrom";
            this.ReturnFrom.Size = new System.Drawing.Size(214, 22);
            this.ReturnFrom.TabIndex = 17;
            // 
            // ReturnTo
            // 
            this.ReturnTo.Location = new System.Drawing.Point(333, 181);
            this.ReturnTo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ReturnTo.Name = "ReturnTo";
            this.ReturnTo.Size = new System.Drawing.Size(214, 22);
            this.ReturnTo.TabIndex = 18;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Location = new System.Drawing.Point(25, 345);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(577, 232);
            this.flowLayoutPanel1.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 327);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 16);
            this.label4.TabIndex = 20;
            this.label4.Text = "Mete più ricercate";
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 588);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.ReturnTo);
            this.Controls.Add(this.ReturnFrom);
            this.Controls.Add(this.DataTo);
            this.Controls.Add(this.DataFrom);
            this.Controls.Add(this.account);
            this.Controls.Add(this.favourites);
            this.Controls.Add(this.priceMax);
            this.Controls.Add(this.priceMin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtTo);
            this.Controls.Add(this.txtFrom);
            this.Controls.Add(this.search);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Home";
            this.Text = "Home";
            ((System.ComponentModel.ISupportInitialize)(this.favourites)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.account)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.TextBox txtFrom;
        private System.Windows.Forms.TextBox txtTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox priceMin;
        private System.Windows.Forms.TextBox priceMax;
        private System.Windows.Forms.PictureBox favourites;
        private System.Windows.Forms.PictureBox account;
        private System.Windows.Forms.DateTimePicker DataFrom;
        private System.Windows.Forms.DateTimePicker DataTo;
        private System.Windows.Forms.DateTimePicker ReturnFrom;
        private System.Windows.Forms.DateTimePicker ReturnTo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label4;
    }
}