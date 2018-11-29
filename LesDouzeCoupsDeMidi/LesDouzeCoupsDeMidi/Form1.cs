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
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    public partial class Form1 : Form
    {
        #region  private attributes
        private List<int> txtbAffichee = new List<int>();
        private List<Question> listQuestions = new List<Question>();
        #endregion private attributes

        /// <summary>
        /// Form's constructor
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            rndShowCase();
            Question qst;
            for(int line = 0; line < 10; line++)
            {
                qst = new Question(line);
                listQuestions.Add(qst);
            }

            label1.Text = listQuestions[0].getQuestion.ToString() + listQuestions[0].Answers[0].ToString();
       
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
                nbRnd = rnd.Next(1, 31); //Generate a random number
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
    }
}
