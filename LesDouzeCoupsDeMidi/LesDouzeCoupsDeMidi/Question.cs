using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LesDouzeCoupsDeMidi
{
    class Question
    {
        string question;
        string answer;
        List<String> answers;
        int line;

        public Question(int line)
        {
            this.line = line;
            CsvReader csvreader = new CsvReader(Directory.GetCurrentDirectory() + @"\..\..\Questions.csv");
            this.question = csvreader.GetQuestion(line);
            this.answer = csvreader.GetAnswer(line);
            this.answers = csvreader.GetAnswers(line);
        }

        public string getQuestion
        {
            get
            {
                return this.question;
            }
        }

        public List<String> Answers
        {
            get
            {
                return this.answers;
            }
        }

        public string getAnswer
        {
            get
            {
                return this.answer;
            }
        }
        
    }
}
