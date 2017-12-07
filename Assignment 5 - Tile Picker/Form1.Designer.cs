namespace Assignment_5___Tile_Picker
{
    partial class Form1
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
            this.btnStart = new System.Windows.Forms.Button();
            this.lblMaxClicks = new System.Windows.Forms.Label();
            this.lblScore = new System.Windows.Forms.Label();
            this.LBLNewGame = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(588, 12);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(95, 35);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click_1);
            // 
            // lblMaxClicks
            // 
            this.lblMaxClicks.AutoSize = true;
            this.lblMaxClicks.Location = new System.Drawing.Point(585, 74);
            this.lblMaxClicks.Name = "lblMaxClicks";
            this.lblMaxClicks.Size = new System.Drawing.Size(76, 13);
            this.lblMaxClicks.TabIndex = 1;
            this.lblMaxClicks.Text = "Max Clicks: 10";
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(585, 99);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 13);
            this.lblScore.TabIndex = 2;
            this.lblScore.Text = "Score: 0";
            // 
            // LBLNewGame
            // 
            this.LBLNewGame.AutoSize = true;
            this.LBLNewGame.Location = new System.Drawing.Point(585, 137);
            this.LBLNewGame.Name = "LBLNewGame";
            this.LBLNewGame.Size = new System.Drawing.Size(0, 13);
            this.LBLNewGame.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(695, 487);
            this.Controls.Add(this.LBLNewGame);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.lblMaxClicks);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblMaxClicks;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Label LBLNewGame;
    }
}

