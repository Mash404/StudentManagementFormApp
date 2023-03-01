using System;
using System.Data;
using System.Data.SqlClient;

namespace StudentManageFormsApp
{
    public partial class LoginForm : Form
    {
        string connectionString = "Data Source=MMR-PC-01\\MSSQLSERVER2022;Initial Catalog=db_student;Integrated Security=True";
        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                String Username_admin = textBox1.Text;
                String Password_admin = maskedTextBox1.Text;

                try
                {
                    if (Username_admin == "" || Password_admin == "")
                    {
                        MessageBox.Show("Enter your email and password!!!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        string query = "select * from adminInfo where username='" + Username_admin + "' and password='" + Password_admin + "'";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            SqlDataReader dr = command.ExecuteReader();

                            if (dr.Read())
                            {
                                AdminForm form2 = new AdminForm();
                                //form2.Setusername = Username_admin;
                                form2.Show();
                                this.Hide();
                            }

                            else
                            {
                                MessageBox.Show("Invalid login details", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                textBox1.Clear();
                                maskedTextBox1.Clear();

                                textBox1.Focus();
                            }
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Error");
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}