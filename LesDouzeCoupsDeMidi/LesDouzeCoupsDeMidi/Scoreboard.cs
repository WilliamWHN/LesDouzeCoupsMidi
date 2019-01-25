/**
* \file      Scoreboard.cs
* \author    William Hausmann
* \version   1.0
* \date      25 january 2019
* \brief     Display the scoreboard a
*
* \details   Read the .csv Scoreboard and create two labels for each entrance
*/

#region using references
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    public partial class Scoreboard : Form
    {
        #region private attributes
        private List<string> listPlayernames = new List<string>();
        private List<string> listScores = new List<string>();
        private int filend;
        #endregion private attributes

        #region constructor
        public Scoreboard()
        {
            InitializeComponent();
        }
        #endregion constructor

        /// <summary>
        /// A method used to creates two label each time we have an entrance with a score
        /// </summary>
        public void DisplayScores()
        {                     
            var reader = new StreamReader(Directory.GetCurrentDirectory() + @"\..\..\Scores.csv");
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                var values = line.Split(';');

                listPlayernames.Add(values[0]);
                listScores.Add(values[1]);
            }
            filend = listPlayernames.Count();
            for (int i = 0; i < filend; i++)
            {
                Label labelPlayername = new Label();
                labelPlayername.Location = new Point(Playername.Location.X + 3, Playername.Location.Y + (i + 1) * 30);
                labelPlayername.ForeColor = Color.White;
                labelPlayername.Text = listPlayernames[i];
                labelPlayername.AutoSize = true;
                this.Controls.Add(labelPlayername);

                Label labelScore = new Label();
                labelScore.Location = new Point(Score.Location.X + 1, Score.Location.Y + (i + 1) * 30);
                labelScore.ForeColor = Color.White;
                labelScore.Text = listScores[i] + " PTS";
                labelScore.AutoSize = true;
                this.Controls.Add(labelScore);
            }            
        }
    }
}
