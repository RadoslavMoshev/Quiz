using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Media;

namespace Quiz
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register r = new Register();
            r.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Media.SoundPlayer s = new System.Media.SoundPlayer();
            s.SoundLocation = @"..\..\Sounds\Start.wav";
            s.Load();
            s.Play();
            string getPassword = "SELECT * FROM [dbo].[Table] WHERE Password = '" + paswordTxtBox.Text + "' AND Username = '" + usernameTxtBox.Text + "'";
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=QuizDB;Integrated Security=True");

            //if Username and password are correct we proceed with Quiz
            SqlCommand cmd = new SqlCommand(getPassword, con);
            con.Open();
            var result = cmd.ExecuteScalar();
            if (result != null)
            {
                MessageBox.Show("Succesfully logged in");
                Questions_Form q = new Questions_Form();
                this.Hide();
                q.Show();
            }
            else
            {
                MessageBox.Show("Your username or password is incorrect!");
            }
        }

        private void paswordTxtBox_TextChanged(object sender, EventArgs e)
        {
            paswordTxtBox.PasswordChar = '*';
            paswordTxtBox.MaxLength = 10;
        }
    }
}