/**
* \file      Boardgame.cs
* \author    William Hausmann & Théo Esseiva
* \version   1.0
* \date      25 january 2019
* \brief     Set of methods related to the form of the game
*
* \details   this is the main form who contains all the controls to play this game and finish it
*/


#region using references
using System;
using System.IO;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using Microsoft.VisualBasic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using WMPLib;
#endregion using references

namespace LesDouzeCoupsDeMidi
{
    public partial class BaordGame : Form
    {
        #region  private attributes
        private List<int> txtbAffichee = new List<int>();
        private List<Question> listQuestions = new List<Question>();
        private int s = 0;
        private Player player = new Player("", 0);
        private string imageName;
        private int m = 0;
        private int jokerUsed = 0;
        private bool[] arrayBoolButton = new bool[] {true,true,true,true};
        private int question = 0;
        private int playerTry = 3;
        private int CorrectAnswer = 0;
        #endregion private attributes

        /// <summary>
        /// Form's constructor
        /// </summary>
        public BaordGame()
        {
            do
            {
                player.getNickName = Interaction.InputBox("Veuiller entrer le nom du joueur ", "Entrer un joueur","", 500, 500);
            } while ((player.getNickName == "") || (player.getNickName == "prénom"));
            InitializeComponent();

            //set de progressbar min and max value
            pbQuestion.Minimum = 0;
            pbQuestion.Maximum = 31;

            //Add the answers to a layout panel
            tblAnswers.Controls.Add(cmdAnswer1); tblAnswers.Controls.Add(cmdAnswer2); tblAnswers.Controls.Add(cmdAnswer3); tblAnswers.Controls.Add(cmdAnswer4);

            //set interval of the timer to 1 second (1000 ms)
            TimerGame.Interval = 1000;
            TimerGame.Start();

            var rand = new Random();

            //get a random image in the directory located in debug
            var files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"/Images");
            string imagePath = files[rand.Next(files.Length)];
            pictureBox1.Image = System.Drawing.Image.FromFile(imagePath);
            imageName = (imagePath.Split('\\').Last()).Split('.').First();
        }

        /// <summary>
        /// When the game is launching charge all the questions and shuffle 30 question in a list (random)
        /// </summary>
        public void Play()
        {
            Question qst;
            for (int line = 0; line < 300; line++)
            {
                qst = new Question(line);
                listQuestions.Add(qst);
            }

            //Shuffle the list
            listQuestions.Shuffle<Question>();

            //Take only 30 questions and display the first one
            listQuestions.RemoveRange(30, listQuestions.Count() - 30);
            DisplayQuestion();
        }

        /// <summary>
        /// Display the next question, the answers and increase the actual question for the pb (progressbar)
        /// </summary>
        private void DisplayQuestion()
        {
            List<int> rndAnswer = new List<int>() {0,1,2,3}; //list used to randomize the order of the answers
            rndAnswer.Shuffle<int>();//Randomize the list (shuffle)

            //If this is the last question when the player answer all the button and the question disappear 
            if (question + 1 >= 31)
            {
                //Hide the answers,jokers and the question
                cmdAnswer1.Visible = false;
                cmdAnswer2.Visible = false;
                cmdAnswer3.Visible = false;
                cmdAnswer4.Visible = false;           
                rtxtbQuestion.Visible = false;
                cmdJSkip.Visible = false;
                cmdJFiftyFifty.Visible = false;

                //Increment the progressbar & display the good answers/number try
                pbQuestion.Value += 1;
                lblAcutalScore.Text = "Bonne réponse : " + CorrectAnswer + " / " + question;              
            }
            else
            {
                //Display the good answers/number try & playername
                lblAcutalScore.Text = "Bonne réponse : " + CorrectAnswer + " / " + question;
                lblPlayerName.Text = "Jeu de " + player.getNickName;

                //Let the player click on answer again
                cmdAnswer1.Enabled = true;
                cmdAnswer2.Enabled = true;
                cmdAnswer3.Enabled = true;
                cmdAnswer4.Enabled = true;

                //Reset the color to blue after showing the true answer
                cmdAnswer1.BackColor = Color.RoyalBlue;
                cmdAnswer2.BackColor = Color.RoyalBlue;
                cmdAnswer3.BackColor = Color.RoyalBlue;
                cmdAnswer4.BackColor = Color.RoyalBlue;

                //Display the question
                rtxtbQuestion.Text = listQuestions[question].getQuestion.ToString();

                //Display the answers using the list of randomize list
                cmdAnswer1.Text = listQuestions[question].Answers[rndAnswer[0]].ToString();
                cmdAnswer2.Text = listQuestions[question].Answers[rndAnswer[1]].ToString();
                cmdAnswer3.Text = listQuestions[question].Answers[rndAnswer[2]].ToString();
                cmdAnswer4.Text = listQuestions[question].Answers[rndAnswer[3]].ToString();  
                
                //Increment the progressbar
                pbQuestion.Value += 1;
            }
        }

        /// <summary>
        /// Show a part of the image behind a textbox when the answer of the question is correct
        /// </summary>
        private void RndShowCase()
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
                s = 0;      //Set the second as 0
            }
            else
            {
                s++;
            }
            lblTimerGame.Text = m + ":" + s; //Put the timer in a label
        }

        /// <summary>
        /// A method using to check if the answer of the question (30 questions) is right
        /// </summary>
        /// <param type="string" name="Answer">the answer choosen by the player</param>
        private void CheckPlayerAnswer(string Answer)
        {
            //Replace characters like 'é,ä,à'
            Answer = Regex.Replace(Answer, "[^a-zA-Z0-9_]", "");
            string TrueAnswer = listQuestions[question].getAnswer.ToString();
            string ex = TrueAnswer;
            TrueAnswer = Regex.Replace(TrueAnswer, "[^a-zA-Z0-9_]", "");
           
            if (TrueAnswer.Contains(Answer))
            {
                question++;
                CorrectAnswer++;
                RndShowCase();
                //Create a new Exception to show the trueAnswer
                throw new Exception(ex);
            }
            else
            {
                question++;
                //Create a new Exception to show the trueAnswer
                throw new Exception(ex);
            }
        }

        /// <summary>
        /// Give the answer (button1) to the main method who check if this is right and show the true answer (even if it's itself)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdAnswer1_Click(object sender, EventArgs e)
        {
            //used to prevent from the user to click on button while the true answer is showed
            if (arrayBoolButton[0])
            {
                int nbButton = 1;
                int nbButtonTrueAnswer = 0;
                try
                {
                    CheckPlayerAnswer(cmdAnswer1.Text);
                }
                catch (Exception ex)
                {
                    //If we catch an Exception,color the false cmd even it's the right answer
                    cmdAnswer1.BackColor = Color.Red;

                    //foreach of the cmdAnswers to know the cmd with true answer
                    foreach (Control ctrl in tblAnswers.Controls)
                    {
                        if (ctrl.Text == ex.Message)
                        {
                            nbButtonTrueAnswer = nbButton;
                        }
                        nbButton++;
                    }
                    //Switch used to color in green the true answer
                    switch (nbButtonTrueAnswer)
                    {
                        case 1:
                            cmdAnswer1.BackColor = Color.Green;
                            break;
                        case 2:
                            cmdAnswer2.BackColor = Color.Green;
                            break;
                        case 3:
                            cmdAnswer3.BackColor = Color.Green;
                            break;
                        case 4:
                            cmdAnswer4.BackColor = Color.Green;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }

                    //Wait for 1.5sec
                    var cancellationToken = new CancellationTokenSource().Token;
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = false; }
                    await Task.Delay(1500, cancellationToken);
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = true; }
                
                    DisplayQuestion();
                    

                }
            }
        }

        /// <summary>
        /// Give the answer (button2) to the main method who check if this is right and show the true answer (even if it's itself)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdAnswer2_Click(object sender, EventArgs e)
        {
            //used to prevent from the user to click on button while the true answer is showed
            if (arrayBoolButton[1])
            {
                int nbButton = 1;
                int nbButtonTrueAnswer = 0;
                try
                {
                    CheckPlayerAnswer(cmdAnswer2.Text);
                }
                catch (Exception ex)
                {
                    //If we catch an Exception,color the false cmd even it's the right answer
                    cmdAnswer2.BackColor = Color.Red;

                    //foreach of the cmdAnswers to know the cmd with true answer
                    foreach (Control ctrl in tblAnswers.Controls)
                    {
                        if (ctrl.Text == ex.Message)
                        {
                            nbButtonTrueAnswer = nbButton;
                        }
                        nbButton++;
                    }
                    //Switch used to color in green the true answer
                    switch (nbButtonTrueAnswer)
                    {
                        case 1:
                            cmdAnswer1.BackColor = Color.Green;
                            break;
                        case 2:
                            cmdAnswer2.BackColor = Color.Green;
                            break;
                        case 3:
                            cmdAnswer3.BackColor = Color.Green;
                            break;
                        case 4:
                            cmdAnswer4.BackColor = Color.Green;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                    //Wait for 1.5 sec
                    var cancellationToken = new CancellationTokenSource().Token;
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = false; }
                    await Task.Delay(1500, cancellationToken);
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = true; }
                    DisplayQuestion();
                }
            }
        }

        /// <summary>
        /// Give the answer (button3) to the main method who check if this is right and show the true answer (even if it's itself)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdAnswer3_Click(object sender, EventArgs e)
        {
            //used to prevent from the user to click on button while the true answer is showed
            if (arrayBoolButton[3])
            {
                int nbButton = 1;
                int nbButtonTrueAnswer = 0;
                try
                {
                    CheckPlayerAnswer(cmdAnswer3.Text);
                }
                catch (Exception ex)
                {
                    //If we catch an Exception,color the false cmd even it's the right answer
                    cmdAnswer3.BackColor = Color.Red;

                    //foreach of the cmdAnswers to know the cmd with true answer
                    foreach (Control ctrl in tblAnswers.Controls)
                    {
                        if (ctrl.Text == ex.Message)
                        {
                            nbButtonTrueAnswer = nbButton;
                        }
                        nbButton++;
                    }
                    //Switch used to color in green the true answer
                    switch (nbButtonTrueAnswer)
                    {
                        case 1:
                            cmdAnswer1.BackColor = Color.Green;
                            break;
                        case 2:
                            cmdAnswer2.BackColor = Color.Green;
                            break;
                        case 3:
                            cmdAnswer3.BackColor = Color.Green;
                            break;
                        case 4:
                            cmdAnswer4.BackColor = Color.Green;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                    //Wait for 1.5 sec
                    var cancellationToken = new CancellationTokenSource().Token;
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = false; }
                    await Task.Delay(1500, cancellationToken);
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = true; }
                    DisplayQuestion();
                }
            }
        }

        /// <summary>
        /// Give the answer (button4) to the main method who check if this is right and show the true answer (even if it's itself)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void CmdAnswer4_Click(object sender, EventArgs e)
        {
            //used to prevent from the user to click on button while the true answer is showed
            if (arrayBoolButton[3])
            {
                int nbButton = 1;
                int nbButtonTrueAnswer = 0;
                try
                {
                    CheckPlayerAnswer(cmdAnswer4.Text);
                }
                catch (Exception ex)
                {
                    //If we catch an Exception,color the false cmd even it's the right answer
                    cmdAnswer4.BackColor = Color.Red;

                    //foreach of the cmdAnswers to know the cmd with true answer
                    foreach (Control ctrl in tblAnswers.Controls)
                    {
                        if (ctrl.Text == ex.Message)
                        {
                            nbButtonTrueAnswer = nbButton;
                        }
                        nbButton++;
                    }
                    //Switch used to color in green the true answer
                    switch (nbButtonTrueAnswer)
                    {
                        case 1:
                            cmdAnswer1.BackColor = Color.Green;
                            break;
                        case 2:
                            cmdAnswer2.BackColor = Color.Green;
                            break;
                        case 3:
                            cmdAnswer3.BackColor = Color.Green;
                            break;
                        case 4:
                            cmdAnswer4.BackColor = Color.Green;
                            break;
                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                    //Wait 1.5 sec
                    var cancellationToken = new CancellationTokenSource().Token;
                    for(int i = 0; i < 4; i++) { arrayBoolButton[i] = false; }
                    await Task.Delay(1500, cancellationToken);
                    for (int i = 0; i < 4; i++) { arrayBoolButton[i] = true; }
                    DisplayQuestion();
                }
            }
            
        }

        /// <summary>
        /// Show a Message box with the rules of the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdAide_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Règles du jeu:\n\nRépondez à la question en cliquant sur une des quatres réponses\n\nSi vous répondez la bonne réponse un partie de l'image se dévoile !\nSinon rien ne se passe et vous passez à la question suivante.\n\nPour gagner entrer le nom de l'image dans le champ texte une fois que vous savez de quoi il s'agit.\nSi vous vous trompez votre vie diminue.\n\nVous avez trois vie. Si vos vie atteigne 0 vous avez perdu.\n\n\nBonne chance !");
        }

        /// <summary>
        /// A joker used to hide two wrong answer and help the player to answer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdJFiftyFifty_Click(object sender, EventArgs e)
        {
            #region private attributes
            int nbButton = 1;
            int nbRand;
            int[] nbsRand = new int[2];
            int nbButtonTrueAnswer = 0;
            string TrueAnswer = listQuestions[question].getAnswer.ToString();
            #endregion private attributes
            if (arrayBoolButton[0] || arrayBoolButton[1] || arrayBoolButton[2] || arrayBoolButton[3])
            {
                jokerUsed++;

                //foreach to know the button who contains the true answer
                foreach (Control ctrl in tblAnswers.Controls)
                {
                    if (ctrl.Text == TrueAnswer)
                    {
                        nbButtonTrueAnswer = nbButton;
                    }
                    nbButton++;
                }

                Random QuestionRandom = new Random();
                //Generate a table with 2 number 1 to 4 without the number of the right cmd
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
                cmdJFiftyFifty.Visible = false;
            }
        }

        /// <summary>
        /// The final button to check if the guessed image name is right or false 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdValider_Click(object sender, EventArgs e)
        {
            #region private attributes
            int nbCharGuessedImage;
            int nbCharImageName;
            string guessedImage;
            string[] words;
            #endregion private attributes

            //manipulate the string of the true answer (image)
            nbCharImageName = imageName.Length;
            imageName = SortString(imageName.ToLower());
            imageName = NoDups(imageName);

            //manipulate the string of the answer (image)
            guessedImage = rtxtbAnswerImage.Text;
            nbCharGuessedImage = guessedImage.Length;      
            words = guessedImage.Split(' ');

            if(words[0].ToLower() == "les" || words[0].ToLower() == "le" || words[0].ToLower() == "la")
            {
                words[0] = "";
            }
            guessedImage = "";
            foreach(string word in words)
            {
                guessedImage = guessedImage + word;
            }

      
            guessedImage = SortString(guessedImage.ToLower());
            guessedImage = NoDups(guessedImage);

            //if the answer isn't contained by the trueanswer
            if (nbCharGuessedImage <= nbCharImageName - 4 || !imageName.Contains(guessedImage))
            {
                switch (playerTry)
                {
                    //if he has 1 life when he fails he loose
                    case 1:
                        lblLife1.Visible = false;
                        YouLose();
                        break;
                    //Decrement the life
                    case 2:
                        lblLife2.Visible = false;
                        playerTry--;
                        break;
                    //Decrement the life
                    case 3:
                        lblLife3.Visible = false;
                        playerTry--;
                        break;
                    default:
                        break;
                }
                
            }
            //if the answer is contained by the trueanswer 
            else if (imageName.Contains(guessedImage))
            {
                YouWin();
            }

        }

        /// <summary>
        /// A method used to sort a string in Alphabetical Order
        /// </summary>
        /// <param type="string" name="input"></param>
        /// <returns type="string">retrun the string in Alphabetical Order</returns>
        static string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        /// <summary>
        /// Remove the duplicate charachter in a string
        /// </summary>
        /// <param type="string" name="word"></param>
        /// <returns>return the string without duplicates</returns>
        public string NoDups(string word)
        {
            string table = "";

            foreach (var character in word)
            {
                if (table.IndexOf(character) == -1)
                {
                    table += character; 
                }
            }
            return table;
        }

        /// <summary>
        /// Show a MessageBox and close this form
        /// </summary>
        private void YouLose()
        {
            MessageBox.Show("Perdu !\nVous ferez mieux la prochaine fois !");
            //close the form
            this.Close();
        }

        /// <summary>
        /// Show the stats of the party and calculate score
        /// </summary>
        private void YouWin()
        {
            double tempScore = 0;

            //How we calculate the score
            tempScore = (CorrectAnswer * 10 + (30 - question) * 100) - (m + s*60)*0.5;
            tempScore += 300;
            if(jokerUsed == 0)
            {
                tempScore = tempScore * 1.5;
            }
            else if(jokerUsed == 1)
            {
                tempScore = tempScore * 1.25;
            }
            player.Score = Convert.ToInt32(tempScore);  
            
            //Display the full image
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                {            
                    x.Visible = false;
                }
            }

            //Open csv file and create the line to append
            string scoresFile = Directory.GetCurrentDirectory() + @"\..\..\Scores.csv";
            string scoreLine = player.getNickName + ";" + player.Score;

            //Append Score to the CSV file
            File.AppendAllText(scoresFile, "\n" + scoreLine);

            //Stop the timer and hide the question,answers,labels,...
            TimerGame.Stop();
            lblFinalQuestion.Visible = false;
            rtxtbAnswerImage.Visible = false;
            lblLife1.Visible = false;
            lblLife2.Visible = false;
            lblLife3.Visible = false;
            cmdAnswer1.Visible = false;
            cmdAnswer2.Visible = false;
            cmdAnswer3.Visible = false;
            cmdAnswer4.Visible = false;
            cmdJFiftyFifty.Visible = false;
            cmdJSkip.Visible = false;
            cmdValidate.Visible = false;
            pbQuestion.Visible = false;
            lblAcutalScore.Visible = false;
            lblPlayerName.Visible = false;
            cmdHelp.Visible = false;

            //Use the richtextbox with the quesion to display stats
            rtxtbQuestion.Height = 280;
            rtxtbQuestion.Text = "              FELICITATIONS ! TU AS TROUVE L'IMAGE \n" +
                "\n" +
                "Bonnes réponses : " + CorrectAnswer + "/" + question + "\n" +
                "Temps utilisé : " + m + ":" + s + "\n" +
                "Joker utilisés : " + jokerUsed + "/1\n\n" +
                "                               Score Total : "+ player.Score;
            rtxtbQuestion.Visible = true;


            //Create a button exit assigned to a method ExitApp
            Button btnExit = new Button();
            btnExit.AutoSize = true;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Text = "Exit";
            btnExit.Location = new Point(285,796);
            btnExit.Click += new System.EventHandler(this.ExitApp);
            this.Controls.Add(btnExit);
            btnExit.BringToFront();
        }

        /// <summary>
        /// Used to close this form 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitApp(object sender, EventArgs e)
        {
            //close the form
            this.Close();
        }

        /// <summary>
        /// Redirect the selection of the RichTextbox to the timer label
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RtxtbQuestion_Enter(object sender, EventArgs e)
        {
            //Change the active control(selection) to a label
            ActiveControl = lblTimerGame;
        }

        /// <summary>
        /// When the player click on the joker, skip the question give him point and show a part of the image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdJSkip_Click(object sender, EventArgs e)
        {
            //Do the basic thing, increment the question,correct answer,jokerused and display the next question and show a case
            if (arrayBoolButton[0] || arrayBoolButton[1] || arrayBoolButton[2] || arrayBoolButton[3])
            {
                jokerUsed++;
                question += 1;
                CorrectAnswer++;
                DisplayQuestion();
                RndShowCase();
                cmdJSkip.Visible = false;
            }     
        }
    }


    static class Randomize
    {
        private static Random rng = new Random();

        /// <summary>
        /// A method who shuffle a list (int,string)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param type="list" name="list"></param>
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
