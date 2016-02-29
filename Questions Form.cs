using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Questions_Form : Form
    {
        string testTaken = "";
        decimal correctAnswers = 0;
        bool isCorrect = false;
        System.Media.SoundPlayer s = new System.Media.SoundPlayer();
        Dictionary<int, List<string>> questions = new Dictionary<int, List<string>>() {
            {1, new List<string> {"What country has the second largest population in the world?", "Brazil","Italy","India" } },
            {2, new List<string> {"What country has a maple leaf on their national flag?", "France", "Canada", "Bulgaria" } },
            {3, new List<string> {"In what country was Nelson Mandela born?", "Iraq","South Africa","Egypt" } },
            {4, new List<string> {"In what country would you find the cities Lyon and Marseille?", "France","Greece","Argentina" } },
            {5, new List<string> {"What country was known as Ceylon until 1972?", "Sri Lanka", "Japan","New Zeland" } },
            {6, new List<string> {"Which is the longest river in the world?", "Nile River", "Mississippi River", "Yellow River" } },
            {7, new List<string> {"What body of water does the Nile River empty into?", "Indian Ocean", "Lake Victoria", "Mediterranean Sea" } },
            {8, new List<string> {"What was Akhet?", "The harvest season", "The dry season", "The season of flooding" } },
            {9, new List<string> {"The study of lakes and other fresh-water formations, like ponds, is called what?",
                "botany","oceanography","limnology" } },
            {10, new List<string> {"Where is the Snake river?", "USA","Malta","Russia" } },
            {11, new List<string> {"A shorter exhaust pipe would generally be ___ than a longer one.", "Quieter", "Just as loud", "Louder" } },
            {12, new List<string> {"Which of the following can have a negative affect on fuel economy?",
                "Misaligned wheels", "Improperly inflated tires","All of the above" } },
            {13, new List<string> { "Which of the following pairs of car brands would be the LEAST likely to have interchangeable parts?",
                "Volkswagen and Audi","BMW and Mercedes-Benz","Nissan and Infiniti" } },
            {14, new List<string> { "When was the first NASCAR race held?", "1949", "1955", "1960" } },
            {15, new List<string> {"Which of the following materials would NOT be used in an oil filter?", "Iridium", "Rubber", "Fleece" } }
        };
        public Questions_Form()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {
            
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Check which test is selected
            if (listBox1.SelectedItem == null)
            {
                MessageBox.Show("Select test");
            }
            else if (listBox1.SelectedItem.ToString() == "Countries" && label2.Text == "NoScore")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                testTaken = "Countries";
                QuestionBox.Text = questions[1][0]; checkBox1.Text = questions[1][1]; checkBox2.Text = questions[1][2]; checkBox3.Text = questions[1][3];
            }
            else if (listBox1.SelectedItem.ToString() == "Rivers" && label3.Text == "NoScore")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                testTaken = "Rivers";
                QuestionBox.Text = questions[6][0];checkBox1.Text = questions[6][1]; checkBox2.Text = questions[6][2]; checkBox3.Text = questions[6][3];
            }
            else if (listBox1.SelectedItem.ToString() == "Cars" && label4.Text == "NoScore")
            {
                panel1.Visible = false;
                panel2.Visible = true;
                testTaken = "Cars";
                QuestionBox.Text = questions[11][0]; checkBox1.Text = questions[11][1]; checkBox2.Text = questions[11][2];checkBox3.Text = questions[11][3];
            }
        }

        private void QuestionBox_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void progressBar1_Click(object sender, EventArgs e)
        {

        }

        private void QuestionBox_TextChanged_1(object sender, EventArgs e)
        {

        }

        //1st "Next" button
        private void button2_Click(object sender, EventArgs e)
        {
            s.SoundLocation = @"..\..\Sounds\Level1.wav";
            s.Load();
            s.Play();
            if (testTaken == "Countries")
            {
                // Track if answers are correct, so when user go to previous question and 
                isCorrect = false;

                //check if answer is correct and which test is selected
                if (checkBox3.Checked)
                {
                    correctAnswers++;
                    isCorrect = true;
                }
                
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                button5.Visible = true;
                NextOne.Hide();
                button5.Show();

                //Set question and possible answers
                QuestionBox.Text = questions[2][0]; checkBox1.Text = questions[2][1]; checkBox2.Text = questions[2][2]; checkBox3.Text = questions[2][3];

                //Increment progressBar with 1/5
                progressBar1.Value = +20;
            }
            else if (testTaken == "Rivers")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    correctAnswers++;
                    isCorrect = true;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                button5.Visible = true;
                NextOne.Hide();
                button5.Show();
                QuestionBox.Text = questions[7][0]; checkBox1.Text = questions[7][1]; checkBox2.Text = questions[7][2]; checkBox3.Text = questions[7][3];
                progressBar1.Value = +20;
            }
            else if (testTaken == "Cars")
            {
                isCorrect = false;
                if (checkBox3.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                button5.Visible = true;
                NextOne.Hide();
                button5.Show();
                QuestionBox.Text = questions[12][0]; checkBox1.Text = questions[12][1]; checkBox2.Text = questions[12][2]; checkBox3.Text = questions[12][3];
                progressBar1.Value = +20;
            }
        }

        //2nd "Next" button
        private void button5_Click_2(object sender, EventArgs e)
        {
            s.SoundLocation = @"..\..\Sounds\Level1.wav";
            s.Load();
            s.Play();

            //Show "Previous" button
            button4.Show();
            if (testTaken == "Countries")
            {
                isCorrect = false;
                if (checkBox2.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +40;
                button3.Visible = true;
                button5.Hide();
                button3.Show();
                QuestionBox.Text = questions[3][0]; checkBox1.Text = questions[3][1]; checkBox2.Text = questions[3][2]; checkBox3.Text = questions[3][3];
            }
            else if (testTaken == "Rivers")
            {
                isCorrect = false;
                if (checkBox3.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +40;
                button3.Visible = true;
                button5.Hide();
                button3.Show();
                QuestionBox.Text = questions[8][0]; checkBox1.Text = questions[8][1]; checkBox2.Text = questions[8][2]; checkBox3.Text = questions[8][3];
            }
            else if (testTaken == "Cars")
            {
                isCorrect = false;
                if (checkBox3.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +40;
                button3.Visible = true;
                button5.Hide();
                button3.Show();
                QuestionBox.Text = questions[13][0]; checkBox1.Text = questions[13][1]; checkBox2.Text = questions[13][2]; checkBox3.Text = questions[13][3];
            }
        }

        //3th "Next" button
        private void button3_Click(object sender, EventArgs e)
        {
            s.SoundLocation = @"..\..\Sounds\Level2.wav";
            s.Load();
            s.Play();
            button6.Show();
            if (testTaken == "Countries")
            {
                isCorrect = false;
                if (checkBox2.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +60;
                button7.Visible = true;
                button3.Hide();
                button7.Show();
                QuestionBox.Text = questions[4][0]; checkBox1.Text = questions[4][1]; checkBox2.Text = questions[4][2]; checkBox3.Text = questions[4][3];
            }
            else if (testTaken == "Rivers")
            {
                isCorrect = false;
                if (checkBox3.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +60;
                button7.Visible = true;
                button3.Hide();
                button7.Show();
                QuestionBox.Text = questions[9][0]; checkBox1.Text = questions[9][1]; checkBox2.Text = questions[9][2]; checkBox3.Text = questions[9][3];
            }
            else if (testTaken == "Cars")
            {
                isCorrect = false;
                if (checkBox2.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +60;
                button7.Visible = true;
                button3.Hide();
                button7.Show();
                QuestionBox.Text = questions[14][0]; checkBox1.Text = questions[14][1]; checkBox2.Text = questions[14][2]; checkBox3.Text = questions[14][3];
            }
            button4.Hide();
        }

        //4th "Next" button
        private void button7_Click(object sender, EventArgs e)
        {
            s.SoundLocation = @"..\..\Sounds\Level2.wav";
            s.Load();
            s.Play();
            button6.Hide();
            button8.Show();
            if (testTaken == "Countries")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +80;
                button9.Visible = true;
                button7.Hide();
                button9.Show();
                QuestionBox.Text = questions[5][0]; checkBox1.Text = questions[5][1]; checkBox2.Text = questions[5][2]; checkBox3.Text = questions[5][3];
            }
            else if (testTaken == "Rivers")
            {
                isCorrect = false;
                if (checkBox3.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +80;
                button9.Visible = true;
                button7.Hide();
                button9.Show();
                QuestionBox.Text = questions[10][0]; checkBox1.Text = questions[10][1]; checkBox2.Text = questions[10][2]; checkBox3.Text = questions[10][3];
            }
            else if (testTaken == "Cars")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                checkBox1.Checked = false;
                checkBox2.Checked = false;
                checkBox3.Checked = false;
                progressBar1.Value = +80;
                button9.Visible = true;
                button7.Hide();
                button9.Show();
                QuestionBox.Text = questions[15][0]; checkBox1.Text = questions[15][1]; checkBox2.Text = questions[15][2]; checkBox3.Text = questions[15][3];
            }
        }

        //Submit button
        private void button9_Click(object sender, EventArgs e)
        {
            s.SoundLocation = @"..\..\Sounds\Level3.wav";
            s.Load();
            s.Play();
            button8.Hide();
            if (testTaken == "Countries")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                // Add value of correct answers to label text
                label2.Text = (correctAnswers / 5 * 100).ToString() + "%";
                label2.Visible = true;
            }
            else if (testTaken == "Rivers")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                label3.Text = (correctAnswers / 5 * 100).ToString() + "%";
                label3.Visible = true;
            }
            else if (testTaken == "Cars")
            {
                isCorrect = false;
                if (checkBox1.Checked)
                {
                    isCorrect = true;
                    correctAnswers++;
                }

                label4.Text = (correctAnswers / 5 * 100).ToString() + "%";
                label4.Visible = true;
            }
            
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            progressBar1.Value = +100;
            button9.Visible = true;
            button7.Hide();
            button9.Show();
            MessageBox.Show("Your score is " + (correctAnswers / 5 * 100).ToString() + "% !!!");
            correctAnswers = 0;

            //Reset Quiz view to begining
            panel1.Show();
            panel2.Visible = false;
            button9.Hide();
            NextOne.Show();
            progressBar1.Value = 0;
        }

        //1st Previous button
        private void button4_Click(object sender, EventArgs e)
        {
            //Lower correctAnswers value with 1 if your previous ansawer was correct
            if (isCorrect == true)
            {
                correctAnswers--;
            }

            button3.Hide();
            button4.Hide();
            NextOne.Visible = true;
            NextOne.Show();
            NextOne.PerformClick();

        }

        //2nd Previous button
        private void button6_Click(object sender, EventArgs e)
        {
            if (isCorrect == true)
            {
                correctAnswers--;
            }

            button6.Hide();
            button7.Hide();
            button5.Visible = true;
            button5.Show();
            button5.PerformClick();
        }

        //3rd Previous button
        private void button8_Click(object sender, EventArgs e)
        {
            if (isCorrect == true)
            {
                correctAnswers--;
            }

            button8.Hide();
            button9.Hide();
            button3.Visible = true;
            button3.Show();
            button3.PerformClick();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
   //public class Question
   //{
   //    string question;
   //    string answerA;
   //    string answerB;
   //    string answerC;
   //    string correctAnswer;
   //
   //    public Question()
   //    {
   //       
   //    }
   //    public string getQuestion
   //    {
   //        get{return this.question;}
   //        set{this.question = value;}
   //    }
   //
   //    public string A
   //    {
   //        get {return this.answerA; }
   //        set { this.answerA = value; }
   //    }
   //    public string B
   //    {
   //        get { return this.answerB; }
   //        set { this.answerB = value; }
   //    }
   //    public string C
   //    {
   //        get { return this.answerC; }
   //        set { this.answerC = value; }
   //    }
   //    public string corrAnswer
   //    {
   //        get { return this.correctAnswer; }
   //        set { this.correctAnswer = value; }
   //    }
   //}
}
