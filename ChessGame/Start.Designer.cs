﻿
namespace ChessGame
{
    partial class Start
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Start));
            this.mainlbl = new System.Windows.Forms.Label();
            this.blackCheck = new System.Windows.Forms.CheckBox();
            this.whiteCheck = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainlbl
            // 
            this.mainlbl.AutoSize = true;
            this.mainlbl.Font = new System.Drawing.Font("SimSun-ExtB", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mainlbl.Location = new System.Drawing.Point(100, 36);
            this.mainlbl.Name = "mainlbl";
            this.mainlbl.Size = new System.Drawing.Size(185, 33);
            this.mainlbl.TabIndex = 0;
            this.mainlbl.Text = "Chess game";
            // 
            // blackCheck
            // 
            this.blackCheck.AutoSize = true;
            this.blackCheck.Location = new System.Drawing.Point(72, 121);
            this.blackCheck.Name = "blackCheck";
            this.blackCheck.Size = new System.Drawing.Size(53, 17);
            this.blackCheck.TabIndex = 1;
            this.blackCheck.Text = "Black";
            this.blackCheck.UseVisualStyleBackColor = true;
            // 
            // whiteCheck
            // 
            this.whiteCheck.AutoSize = true;
            this.whiteCheck.Location = new System.Drawing.Point(72, 144);
            this.whiteCheck.Name = "whiteCheck";
            this.whiteCheck.Size = new System.Drawing.Size(54, 17);
            this.whiteCheck.TabIndex = 2;
            this.whiteCheck.Text = "White";
            this.whiteCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(252, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "With AI";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(252, 144);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 4;
            this.button2.Text = "with partner";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(69, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose your side";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(240, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose game mode";
            // 
            // Start
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(402, 250);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.whiteCheck);
            this.Controls.Add(this.blackCheck);
            this.Controls.Add(this.mainlbl);
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::ChessGame.Properties.Settings.Default, "aaa", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = global::ChessGame.Properties.Settings.Default.aaa;
            this.Name = "Start";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ShowInTaskbar = false;
            this.Text = "Chess";
            this.Load += new System.EventHandler(this.Start_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label mainlbl;
        public System.Windows.Forms.CheckBox blackCheck;
        public System.Windows.Forms.CheckBox whiteCheck;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}