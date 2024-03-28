
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
            this.mainlbl.Location = new System.Drawing.Point(150, 55);
            this.mainlbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.mainlbl.Name = "mainlbl";
            this.mainlbl.Size = new System.Drawing.Size(270, 48);
            this.mainlbl.TabIndex = 0;
            this.mainlbl.Text = "Chess game";
            // 
            // blackCheck
            // 
            this.blackCheck.AutoSize = true;
            this.blackCheck.Location = new System.Drawing.Point(108, 186);
            this.blackCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.blackCheck.Name = "blackCheck";
            this.blackCheck.Size = new System.Drawing.Size(74, 24);
            this.blackCheck.TabIndex = 1;
            this.blackCheck.Text = "Black";
            this.blackCheck.UseVisualStyleBackColor = true;
            // 
            // whiteCheck
            // 
            this.whiteCheck.AutoSize = true;
            this.whiteCheck.Location = new System.Drawing.Point(108, 222);
            this.whiteCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.whiteCheck.Name = "whiteCheck";
            this.whiteCheck.Size = new System.Drawing.Size(76, 24);
            this.whiteCheck.TabIndex = 2;
            this.whiteCheck.Text = "White";
            this.whiteCheck.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(378, 177);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "With AI";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(378, 222);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "with partner";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 152);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Choose your side";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(360, 152);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Choose game mode";
            // 
            // Start
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.MenuBar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.MediumAquamarine;
            this.ClientSize = new System.Drawing.Size(603, 385);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
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