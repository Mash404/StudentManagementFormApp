using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using System.Transactions;

namespace StudentManageFormsApp
{
    public partial class AdminForm : Form
    {
        string connectionString = "Data Source=MMR-PC-01\\MSSQLSERVER2022;Initial Catalog=db_student;Integrated Security=True";

        public AdminForm()
        {
            InitializeComponent();
        }
        private void Get_studentsInfo()
        {
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("Select * from studentsInfo", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = command.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            dataGridView1.DataSource = dt;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            Get_studentsInfo();
        }

        //Add
        private void button1_Click(object sender, EventArgs e)
        {
            RegisterStudent rs = new RegisterStudent();
            rs.Show();
        }

        //Edit
        private void button3_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            textBox7.Enabled = true;
            textBox8.Enabled = true;
            textBox9.Enabled = true;
        }

        //Delete
        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int id = Convert.ToInt32(textBox1.Text);
                        string query = "Delete studentsInfo where student_ID='" + id + "'";
                        SqlCommand command = new SqlCommand( query, conn, transaction);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Deleted Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        Get_studentsInfo();

                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Delete Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
        //Update
        private void button4_Click(object sender, EventArgs e)
        {
            int year, semester;
            float cgpa, credit;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        int id = Convert.ToInt32(textBox1.Text);

                        year = (int)Convert.ToInt32((string)textBox6.Text);
                        semester = (int)Convert.ToInt32((string)textBox7.Text);
                        cgpa = (float)Convert.ToDouble(textBox8.Text);
                        credit = (float)Convert.ToDouble(textBox9.Text);

                        string query = "Update studentsInfo set study_year='" + year + "',semester='" + semester + "',CGPA='" + cgpa + "',credit_completed='" + credit + "' where student_id='" + id + "'";
                        SqlCommand command = new SqlCommand(query, conn, transaction);
                        command.ExecuteNonQuery();
                        transaction.Commit();
                        MessageBox.Show("Successfully Updated", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Get_studentsInfo();
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Update Failed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        //Logout
        private void button5_Click(object sender, EventArgs e)
        {
            LoginForm lg = new LoginForm();
            lg.Show();
            this.Hide();
        }

        //Show
        private void Show_Click(object sender, EventArgs e)
        {
            
        }
    }
}
