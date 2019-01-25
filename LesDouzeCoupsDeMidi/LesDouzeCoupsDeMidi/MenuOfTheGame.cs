/**
* \file      CsvReader.cs
* \author    William Hausmann & Théo Esseiva
* \version   1.0
* \date      6 december 2018
* \brief     Set of methods related to questions in csv files
*
* \details   ReadAllFile & choose the line you will take the question, answers(choices), and the answer
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
    public partial class MenuOfTheGame : Form
    {
        public MenuOfTheGame()
        {
            InitializeComponent();
        }

        #region privates methods
        /// <summary>
        /// Button play used to load the form BoardGame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdPlay_Click(object sender, EventArgs e)
        {
            BaordGame bdg = new BaordGame();
            bdg.Play();
            bdg.ShowDialog();
        }

        /// <summary>
        /// Button for rules
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdRules_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Règles du jeu:\n\nRépondez à la question en cliquant sur une des quatres réponses\n\nSi vous répondez la bonne réponse un partie de l'image se dévoile !\nSinon rien ne se passe et vous passez à la question suivante.\n\nPour gagner entrer le nom de l'image dans le champ texte une fois que vous savez de quoi il s'agit.\nSi vous vous trompez votre vie diminue.\n\nVous avez trois vie. Si vos vie atteigne 0 vous avez perdu.\n\n\nBonne chance !");
        }

        /// <summary>
        /// Button for credits
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdCredits_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Développeur : Esseiva Théo, Hausmann William\n\nTesteur : Favre Zacharie, Mota-Carneiro Rui-Manuel, Decoppet Joris, Golay Maxim, Saraiva Maia Leandro, Hausmann William, Esseiva Théo");
        }

        /// <summary>
        /// Button to show the scoreboard
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdScoreboard_Click(object sender, EventArgs e)
        {
            Scoreboard sbd = new Scoreboard();

            if (File.Exists(Directory.GetCurrentDirectory() + @"\..\..\Scores.csv"))
            {
                sbd.DisplayScores();
                sbd.ShowDialog();
            }
            else
            {
                MessageBox.Show("Le fichier à été déplacé ou supprimé");
            }
        }
        #endregion privates methods
    }
}
