/**
* \file      Form1.cs
* \author    William Hausmann & Théo Esseiva
* \version   0.1
* \date      23 november 2018
* \brief     Set of methods related to the form of the game
*
* \details   Insert a complete description
*/


#region using references
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    public partial class BaordGame : Form
    {
        #region  private attributes
        private List<int> txtbAffichee = new List<int>();
        private List<Question> listQuestions = new List<Question>();
        private int ms = 0;
        private int s = 0;
        private int m = 0;
        private int question = 0;
        private int playerTry = 3;
        private string playername;
        private int CorrectAnswer = 0;
        #endregion private attributes

        /// <summary>
        /// Form's constructor
        /// </summary>
        public BaordGame()
        {
            InitializeComponent();
            TimerGame.Interval = 1000;
            TimerGame.Start();
        }


        public void Play()
        {
            Question qst;
            for (int line = 0; line < 300; line++)
            {
                qst = new Question(line);
                listQuestions.Add(qst);
            }
            listQuestions.Shuffle<Question>();
            DisplayQuestion();
        }

        private void DisplayQuestion()
        {
            Question.Text = listQuestions[question].getQuestion.ToString();
            Answer1.Text = listQuestions[question].Answers[0].ToString();
            Answer2.Text = listQuestions[question].Answers[1].ToString();
            Answer3.Text = listQuestions[question].Answers[2].ToString();
            Answer4.Text = listQuestions[question].Answers[3].ToString();

        }

        /// <summary>
        /// Show a part of the image behind a textbox when the answer of the question is correct
        /// </summary>
        private void rndShowCase()
        {
            #region  private attributes
            int nbTextBox = 1;
            bool result = false;
            int nbRnd;
            #endregion private attributes
            Random rnd = new Random();
            do
            {
                nbRnd = rnd.Next(1, 31); //Generate a random number
                if (txtbAffichee.Contains(nbRnd))
                { //If the random number exist already (the textbox generated is already hideen)
                    result = false;
                }
                else
                {
                    result = true;
                }

            } while (!result); //while result is false re-generate a number and check it
            txtbAffichee.Add(nbRnd); //puts de right number in a list for checking

            foreach (Control x in this.Controls)
            {
                if (x is TextBox && nbTextBox == nbRnd)
                { //if the control is a textbox and the random number match the nbTextBox              
                    x.Visible = false; //Hide the textbox who match with the random number
                }
                if(x is TextBox)
                {
                    nbTextBox++;
                }
            }
        }
        /// <summary>
        /// Display a timer in the game
        /// </summary>
        private void TimerGame_Tick(object sender, EventArgs e)
        {

            //Test if the second achieve 60
            if (s == 60)
            {
                m++;        //Increment the minute
                s = 0;      //Set the s as 0
            }
            else
            {
                s++;
            }
            lblTimerGame.Text = m + ":" + s; //Put the timer in a label
        }

        private void CheckPlayerAnswer(string Answer)
        {
            Answer = Regex.Replace(Answer, "[^a-zA-Z0-9_]", "");
            string TrueAnswer = listQuestions[question].getAnswer.ToString();
            TrueAnswer = Regex.Replace(TrueAnswer, "[^a-zA-Z0-9_]", "");
            if (TrueAnswer.Contains(Answer))
            {
                question++;
                CorrectAnswer++;
                DisplayQuestion();
                rndShowCase();
            }
            else
            {
                question++;
                DisplayQuestion();

                MessageBox.Show("Mauvaise réponse !");
            }
            nbQuestion.Text = "Question " + question + "/30";
            AcutalScore.Text = "Bonne réponse : " + CorrectAnswer + "/30";
            PlayerName.Text = "Jeu de " + playername;
            Answer1.Enabled = true;
            Answer2.Enabled = true;
            Answer3.Enabled = true;
            Answer4.Enabled = true;
        }

        private void Answer1_Click(object sender, EventArgs e)
        {
            CheckPlayerAnswer(Answer1.Text);
        }

        private void Answer2_Click(object sender, EventArgs e)
        {
            CheckPlayerAnswer(Answer2.Text);
        }

        private void Answer3_Click(object sender, EventArgs e)
        {
            CheckPlayerAnswer(Answer3.Text);
        }

        private void Answer4_Click(object sender, EventArgs e)
        {
            CheckPlayerAnswer(Answer4.Text);
        }

        private void Aide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Règles du jeu:\n\nRépondez à la question en cliquant sur une des quatres réponses\n\nSi vous répondez la bonne réponse un partie de l'image se dévoile !\nSinon rien ne se passe et vous passez à la question suivante.\n\nPour gagner entrer le nom de l'image dans le champ texte une fois que vous savez de quoi il s'agit.\nSi vous vous trompez votre vie diminue.\n\nVous avez trois vie. Si vos vie atteigne 0 vous avez perdu.\n\n\nBonne chance !");
        }

        private void JFiftyFifty_Click(object sender, EventArgs e)
        {
            int nbButton = 1;
            int nbRand;
            int[] nbsRand = new int[2];
            int nbButtonTrueAnswer = 0;
            string TrueAnswer = listQuestions[question].getAnswer.ToString();

            tblAnswers.Controls.Add(Answer1); tblAnswers.Controls.Add(Answer2); tblAnswers.Controls.Add(Answer3); tblAnswers.Controls.Add(Answer4);

            foreach (Control ctrl in tblAnswers.Controls)
            {
                if (ctrl.Text == TrueAnswer)
                {
                    nbButtonTrueAnswer = nbButton;
                }
                nbButton++;
            }
            Random QuestionRandom = new Random();
            nbsRand[0] = nbButtonTrueAnswer;
            for (int i = 0; i < 2; i++)
            {
                do
                {
                    nbRand = QuestionRandom.Next(1, 5);
                } while (nbRand == nbButtonTrueAnswer || nbsRand.Contains(nbRand));
                nbsRand[i] = nbRand;
            }

            nbButton = 1;
            foreach (Control ctrl in tblAnswers.Controls)
            {
                if (ctrl.Text != TrueAnswer && nbsRand.Contains(nbButton))
                {
                    ctrl.Enabled = false;
                }
                nbButton++;
            }
            JFiftyFifty.Visible = false;
        }
    }


    static class Randomize
    {
        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
