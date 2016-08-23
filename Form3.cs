using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Windows.Forms;
using System.Data.SqlClient;

namespace sundayschoolproject
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        SqlConnection connection = new SqlConnection("Data Source=ZTABASSUM\\SQLEXPRESS01;Initial Catalog= Sunday School;Integrated Security=True");
       
        private void button1_Click(object sender, EventArgs e)

        {
            SqlCommand comm;
            

            comm = new SqlCommand("Select * FROM Login WHERE UserName  =  @Username and Password = @Password ;", connection);
            comm.Parameters.AddRange(new[]{
                new SqlParameter("@Username", SqlDbType.NVarChar,255) { Value = textBox1.Text},
                new SqlParameter("@Password", SqlDbType.NVarChar,255) { Value = textBox2.Text},
            });
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please provide Username and Password");
                return;
            } try
            {
                SqlDataAdapter adapt = new SqlDataAdapter(comm);
                DataSet ds = new DataSet();
                adapt.Fill(ds);
                connection.Close();
                int count = ds.Tables[0].Rows.Count;
               
                if (count == 1)
                {
                    MessageBox.Show("Login Successful!");
                    this.Hide();
                    Form1 otherForm = new Form1();
                    otherForm.Show();
                }
                else
                { 
                    MessageBox.Show("Login Failed!");
                    textBox1.Clear();
                    textBox2.Clear();


                }
            } catch (Exception ex){
                MessageBox.Show(ex.Message);
            };

        }
    }
}
