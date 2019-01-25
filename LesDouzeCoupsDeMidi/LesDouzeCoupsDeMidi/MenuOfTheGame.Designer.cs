namespace LesDouzeCoupsDeMidi
{
    partial class MenuOfTheGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuOfTheGame));
            this.cmdPlay = new System.Windows.Forms.Button();
            this.cmdScoreboard = new System.Windows.Forms.Button();
            this.cmdRules = new System.Windows.Forms.Button();
            this.cmdCredits = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdPlay
            // 
            this.cmdPlay.BackColor = System.Drawing.Color.Transparent;
            this.cmdPlay.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdPlay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Ivory;
            this.cmdPlay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdPlay.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdPlay.Location = new System.Drawing.Point(74, 92);
            this.cmdPlay.Name = "cmdPlay";
            this.cmdPlay.Size = new System.Drawing.Size(251, 78);
            this.cmdPlay.TabIndex = 0;
            this.cmdPlay.Text = "Jouer";
            this.cmdPlay.UseVisualStyleBackColor = false;
            this.cmdPlay.Click += new System.EventHandler(this.CmdPlay_Click);
            // 
            // cmdScoreboard
            // 
            this.cmdScoreboard.BackColor = System.Drawing.Color.Transparent;
            this.cmdScoreboard.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdScoreboard.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Ivory;
            this.cmdScoreboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdScoreboard.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdScoreboard.Location = new System.Drawing.Point(74, 355);
            this.cmdScoreboard.Name = "cmdScoreboard";
            this.cmdScoreboard.Size = new System.Drawing.Size(251, 78);
            this.cmdScoreboard.TabIndex = 3;
            this.cmdScoreboard.Text = "Tableau des Scores";
            this.cmdScoreboard.UseVisualStyleBackColor = false;
            this.cmdScoreboard.Click += new System.EventHandler(this.CmdScoreboard_Click);
            // 
            // cmdRules
            // 
            this.cmdRules.BackColor = System.Drawing.Color.Transparent;
            this.cmdRules.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdRules.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Ivory;
            this.cmdRules.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdRules.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdRules.Location = new System.Drawing.Point(74, 223);
            this.cmdRules.Name = "cmdRules";
            this.cmdRules.Size = new System.Drawing.Size(251, 78);
            this.cmdRules.TabIndex = 4;
            this.cmdRules.Text = "Règles";
            this.cmdRules.UseVisualStyleBackColor = false;
            this.cmdRules.Click += new System.EventHandler(this.CmdRules_Click);
            // 
            // cmdCredits
            // 
            this.cmdCredits.BackColor = System.Drawing.Color.Transparent;
            this.cmdCredits.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.cmdCredits.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Ivory;
            this.cmdCredits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmdCredits.Font = new System.Drawing.Font("Ravie", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdCredits.Location = new System.Drawing.Point(74, 492);
            this.cmdCredits.Name = "cmdCredits";
            this.cmdCredits.Size = new System.Drawing.Size(251, 78);
            this.cmdCredits.TabIndex = 5;
            this.cmdCredits.Text = "Crédits";
            this.cmdCredits.UseVisualStyleBackColor = false;
            this.cmdCredits.Click += new System.EventHandler(this.CmdCredits_Click);
            // 
            // MenuOfTheGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(408, 690);
            this.Controls.Add(this.cmdCredits);
            this.Controls.Add(this.cmdRules);
            this.Controls.Add(this.cmdScoreboard);
            this.Controls.Add(this.cmdPlay);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(424, 729);
            this.MinimumSize = new System.Drawing.Size(424, 729);
            this.Name = "MenuOfTheGame";
            this.Text = "Menu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button cmdPlay;
        private System.Windows.Forms.Button cmdScoreboard;
        private System.Windows.Forms.Button cmdRules;
        private System.Windows.Forms.Button cmdCredits;
    }
}