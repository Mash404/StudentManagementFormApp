using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Data.SqlClient;
using System.Net;
using System.Security.Policy;


namespace StudentManageFormsApp
{
    public partial class RegisterStudent : Form
    {
        string connectionString = "Data Source=MMR-PC-01\\MSSQLSERVER2022;Initial Catalog=db_student;Integrated Security=True";

        public RegisterStudent()
        {
            InitializeComponent();
        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                
                using (SqlTransaction transaction = conn.BeginTransaction())
                {

                    string name = textBox1.Text;
                    string dob = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                    string gender = comboBox1.Text;
                    string email = textBox2.Text;
                    string department = comboBox2.Text;
                    int year = Convert.ToInt32(comboBox3.Text);
                    int semester = Convert.ToInt32(comboBox4.Text);
                    float cgpa = (float)Convert.ToDecimal(textBox5.Text);
                    float credit = (float)Convert.ToDecimal(textBox6.Text);

                    try
                    {
                        string query = "Insert into studentsInfo values('" + name + "','" + dob + "','" + gender + "','" + email + "','" + department + "','" + year + "','" + semester + "','" + cgpa + "','" + credit + "')";
                        SqlCommand command = new SqlCommand(query, conn, transaction);

                        command.ExecuteNonQuery();


                        transaction.Commit();

                        MessageBox.Show("New student Registered, Successfully", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                    }
                    catch
                    {
                        transaction.Rollback();
                        MessageBox.Show("Something went wrong", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
            textBox6.Clear();
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            comboBox4.Items.Clear();
        }
    }
}
