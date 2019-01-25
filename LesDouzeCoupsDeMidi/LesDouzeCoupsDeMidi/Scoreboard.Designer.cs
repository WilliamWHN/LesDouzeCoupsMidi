namespace LesDouzeCoupsDeMidi
{
    partial class Scoreboard
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
            this.Scores = new System.Windows.Forms.Label();
            this.Playername = new System.Windows.Forms.Label();
            this.Score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Scores
            // 
            this.Scores.AutoSize = true;
            this.Scores.Font = new System.Drawing.Font("Microsoft Sans Serif", 25.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Scores.ForeColor = System.Drawing.Color.White;
            this.Scores.Location = new System.Drawing.Point(65, 23);
            this.Scores.Name = "Scores";
            this.Scores.Size = new System.Drawing.Size(314, 39);
            this.Scores.TabIndex = 0;
            this.Scores.Text = "Tableau des scores";
            // 
            // Playername
            // 
            this.Playername.AutoSize = true;
            this.Playername.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Playername.ForeColor = System.Drawing.Color.White;
            this.Playername.Location = new System.Drawing.Point(33, 91);
            this.Playername.Name = "Playername";
            this.Playername.Size = new System.Drawing.Size(118, 20);
            this.Playername.TabIndex = 1;
            this.Playername.Text = "Nom du joueur";
            // 
            // Score
            // 
            this.Score.AutoSize = true;
            this.Score.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Score.ForeColor = System.Drawing.Color.White;
            this.Score.Location = new System.Drawing.Point(339, 91);
            this.Score.Name = "Score";
            this.Score.Size = new System.Drawing.Size(53, 20);
            this.Score.TabIndex = 2;
            this.Score.Text = "Score";
            // 
            // Scoreboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.ClientSize = new System.Drawing.Size(440, 602);
            this.Controls.Add(this.Score);
            this.Controls.Add(this.Playername);
            this.Controls.Add(this.Scores);
            this.MaximumSize = new System.Drawing.Size(456, 641);
            this.MinimumSize = new System.Drawing.Size(456, 641);
            this.Name = "Scoreboard";
            this.Text = "Scoreboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Scores;
        private System.Windows.Forms.Label Playername;
        private System.Windows.Forms.Label Score;
    }
}