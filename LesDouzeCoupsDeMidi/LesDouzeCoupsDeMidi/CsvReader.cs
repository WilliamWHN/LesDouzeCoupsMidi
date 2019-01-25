/**
* \file      CsvReader.cs
* \author    William Hausmann & Théo Esseiva
* \version   1.0
* \date      23 november 2018
* \brief     Set of methods related to questions in csv files
*
* \details   ReadAllFile & choose the line you will take the question, answers(choices), and the answer
*/

#region using references
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
#endregion using references

namespace LesDouzeCoupsDeMidi
{
   
    class CsvReader
    {
        #region private attributes
        private StreamReader str;
        string filename;
        #endregion private attributes

        #region constructor
        /// <summary>
        /// CsvReader's constructor
        /// </summary>
        /// <param name="filename">csv's file</param>
        public CsvReader(string filename)
        {
            this.filename = filename;
        }
        #endregion constructor

        #region private method
        /// <summary>
        /// this method is used to take a choosen line in the csv file
        /// </summary>
        /// <param name="line">the choosen line</param>
        /// <returns>return a string wich contains the selected line</returns>
        private string ParseCSV(int line)
        {     
           string[] data = new string[300]; //new array to store all the lines of the file
           if (File.Exists(filename))
           {
                str = new StreamReader(filename); 
                for (int nblines = 0; nblines < 300; nblines++) //Read all 300 lines of the csv
                {
                    string file = str.ReadLine();
                    data[nblines] = file;
                }
                
                str.Close();
            }

            return data[line]; //take the choosen line in the array
        }
        #endregion private method

        #region public methods
        /// <summary>
        /// this method split a string with ';' and take the first index in the array (the question)
        /// </summary>
        /// <param name="line">choosen line for the method ParseCSV</param>
        /// <returns>return a string with the question</returns>
        public string GetAnswer(int line) {
            string sentence = ParseCSV(line);
            string[] actualLine = new string[5]; //new array used to split the sentence

            actualLine = sentence.Split(';'); 

            return actualLine[5]; //take the last index who contains the answer
        }

        /// <summary>
        /// this method split a string with ';' and take the 1,2,3 & 4 index in the array (answers,choices)
        /// </summary>
        /// <param name="line">choosen line for the method ParseCSV</param>
        /// <returns>return a list with the answers(choices)</returns>
        public List<String> GetAnswers(int line)
        {
            string sentence = ParseCSV(line);
            List<String> answers = new List<string>();
            string[] actualLine = new string[5];

            actualLine = sentence.Split(';');
            answers.Add(actualLine[1]);
            answers.Add(actualLine[2]);
            answers.Add(actualLine[3]);
            answers.Add(actualLine[4]);
            return answers;
        }

        /// <summary>
        /// this method split a string with ';' and take the last index in the array (the answer)
        /// </summary>
        /// <param name="line">choosen line for the method ParseCSV</param>
        /// <returns>return a string with the answer (the right one)</returns>
        public string GetQuestion(int line)
        {
            string sentence = ParseCSV(line);
            string[] actualLine = new string[5];

            actualLine = sentence.Split(';');

            return actualLine[0];
        }
        #endregion public methods

    }



}
