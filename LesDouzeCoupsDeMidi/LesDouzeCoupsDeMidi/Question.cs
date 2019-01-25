/**
* \file      Question.cs
* \author    William Hausmann & Théo Esseiva
* \version   1.0
* \date      23 november 2018
* \brief     Constructor of the question with accesors
*/

#region using references
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    class Question
    {
        #region private attributes
        string question;
        string answer;
        List<String> answers;
        int line;
        #endregion private attributes

        #region constructor
        /// <summary>
        /// Question's constructor
        /// </summary>
        /// <param type="int" name="line">the is here to take questions one by one</param>
        public Question(int line)
        {
            this.line = line;
            CsvReader csvreader = new CsvReader(Directory.GetCurrentDirectory() + @"\..\..\Questions.csv");
            this.question = csvreader.GetQuestion(line);
            this.answer = csvreader.GetAnswer(line);
            this.answers = csvreader.GetAnswers(line);
        }
        #endregion constructor

        #region public methods
        /// <summary>
        /// getter of the question
        /// </summary>
        public string getQuestion
        {
            get
            {
                return this.question;
            }
        }
        /// <summary>
        /// getter of the answers
        /// </summary>
        public List<String> Answers
        {
            get
            {
                return this.answers;
            }
        }
        /// <summary>
        /// getter of the true answer
        /// </summary>
        public string getAnswer
        {
            get
            {
                return this.answer;
            }
        }
        #endregion public methods

    }
}
