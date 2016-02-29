using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quiz
{
    public partial class Register : Form
    {
        public string yourUsername;
        public Register()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=QuizDB;Integrated Security=True");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT Username FROM [dbo].[Table] WHERE Username = '" + usernameBox.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Open();
            yourUsername = usernameBox.Text;

            string email = emailBox.Text;
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);

            //Check for valid email address
            if (!match.Success)
            {
                MessageBox.Show("Enter valid email address");
            }

            else
            {
                //Cheack if Username already exists, if no we insert new data in Database
                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Your Username already exists!!!");
                }
                else
                {
                    //If there is valid username, proceed with inserting values in database
                    if (con.State == ConnectionState.Open && usernameBox.Text != "")
                    {
                        string insert = "INSERT INTO [dbo].[Table] (Username, Password, Email, FirstName, LastName) VALUES (@Username,@Password,@Email, @FirstName, @LastName)";
                        SqlCommand cmd = new SqlCommand(insert, con);
                        cmd.Parameters.AddWithValue("@Username", usernameBox.Text);
                        cmd.Parameters.AddWithValue("@Password", paswordBox.Text);
                        cmd.Parameters.AddWithValue("@Email", emailBox.Text);
                        cmd.Parameters.AddWithValue("@FirstName", firstNameBox.Text);
                        cmd.Parameters.AddWithValue("@LastName", lastNameBox.Text);
                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("You are now registered");
                }
            }

            con.Close();
            //SqlCommand sqlCmd = new SqlCommand("SELECT Username FROM [dbo].[Table] WHERE Username = '" + textBox1.Text + "'", con);
            //sqlCmd.Parameters.AddWithValue("@Username", this.textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void paswordBox_TextChanged(object sender, EventArgs e)
        {
            paswordBox.PasswordChar = '*';
            paswordBox.MaxLength = 10;
        }
    }
}
