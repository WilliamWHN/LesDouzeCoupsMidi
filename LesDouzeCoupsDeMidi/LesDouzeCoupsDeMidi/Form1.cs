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
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    public partial class Form1 : Form
    {
        #region  private attributes
        private List<int> txtbAffichee = new List<int>();
        private List<Question> listQuestions = new List<Question>();
        private int ms = 0;
        private int s = 0;
        private int m = 0;
        private int question = 0;
        private int playerTry = 3;
        #endregion private attributes

        /// <summary>
        /// Form's constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            TimerGame.Interval = 1000;
            TimerGame.Start();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            rndShowCase();
            Question qst;
            for(int line = 0; line < 300; line++)
            {
                qst = new Question(line);
                listQuestions.Add(qst);
            }
            
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
            do{             
                nbRnd = rnd.Next(1, 32); //Generate a random number
                if (txtbAffichee.Contains(nbRnd)){ //If the random number exist already (the textbox generated is already hideen)
                    result = false;
                }
                else{
                    result = true;
                }

            } while (!result); //while result is false re-generate a number and check it
            txtbAffichee.Add(nbRnd); //puts de right number in a list for checking

            foreach (Control x in this.Controls){
                if (x is TextBox && nbTextBox == nbRnd){ //if the control is a textbox and the random number match the nbTextBox              
                    x.Visible = false; //Hide the textbox who match with the random number
                }
                nbTextBox++;
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
            lblTimerGame.Text = m +":" + s; //Put the timer in a label
        }

        private void CheckPlayerAnswer(string Answer)
        {
            Answer = Regex.Replace(Answer, "[^a-zA-Z0-9_]", "");
            string TrueAnswer = listQuestions[question].getAnswer.ToString();
            TrueAnswer = Regex.Replace(TrueAnswer, "[^a-zA-Z0-9_]", "");
            if (TrueAnswer.Contains(Answer))
            {
                question++;
                Question.Text = listQuestions[question].getQuestion.ToString();

                Answer1.Text = listQuestions[question].Answers[0].ToString();
                Answer2.Text = listQuestions[question].Answers[1].ToString();
                Answer3.Text = listQuestions[question].Answers[2].ToString();
                Answer4.Text = listQuestions[question].Answers[3].ToString();
                rndShowCase();
            }
            else
            {
                playerTry--;
            }
            
            if (playerTry == 0)
            {
                MessageBox.Show("Vous n'avez plus de vie. Vous avez perdu");
                Application.Exit();
                
            }
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
    }
}
