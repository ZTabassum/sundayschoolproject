using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sundayschoolproject
{
    public partial class Form2 : Form
    {
        public Form2(Form1 form1)
        {
            InitializeComponent();
            Text = "Form2";
            otherForm = form1;
        }
        SqlConnection connection = new SqlConnection("Data Source=ZTABASSUM\\SQLEXPRESS01;Initial Catalog= Sunday School;Integrated Security=True");
        SqlCommand comm;
        SqlCommand comm2;
        SqlDataReader dreader;
        string check1;
        string check2;
        string check3;
        string check4;
        string check5;
        string check6;
        string check7;
        string check8;
        string check9;
        
        



        private void frm_Load(object sender, EventArgs e)
        {
            connection.Open();
            comm = new SqlCommand("select * FROM Family WHERE Phone =  @ParentPhone;", connection);
            comm2 = new SqlCommand("select * FROM Students WHERE Phone =  @ParentPhone;", connection);
           
            ListViewItem item1 = otherForm.ListViewSelectedItems[0];

            


            comm.Parameters.AddRange(new[]{
                new SqlParameter("@ParentPhone",SqlDbType.NVarChar,255){Value = item1.SubItems[5].Text},
            });
            comm2.Parameters.AddRange(new[]{
                new SqlParameter("@ParentPhone",SqlDbType.NVarChar,255){Value = item1.SubItems[5].Text},
            });

            //Load the parent info based on key, the phone

            try
            {
                dreader = comm.ExecuteReader();
                if (dreader.Read())
                {
                    textBox1.Text = dreader[0].ToString();
                    textBox2.Text = dreader[1].ToString();
                    textBox3.Text = dreader[2].ToString();
                    textBox4.Text = dreader[3].ToString();
                    textBox5.Text = dreader[4].ToString();
                    textBox6.Text = dreader[5].ToString();
                    textBox7.Text = dreader[6].ToString();
                    textBox8.Text = dreader[7].ToString();
                    textBox9.Text = dreader[8].ToString();
                    textBox10.Text = dreader[9].ToString();
                    textBox11.Text = dreader[10].ToString();
                    textBox12.Text = dreader[11].ToString();
                    textBox13.Text = dreader[12].ToString();
                    textBox14.Text = dreader[13].ToString();
                    textBox15.Text = dreader[14].ToString();
                    textBox16.Text = dreader[15].ToString();
                    string text4 = dreader[16].ToString();
                    if (text4 == "True")
                    {
                        checkBox4.Checked = true;
                    }
                    else
                    {
                        checkBox5.Checked = false;
                    }
                    textBox18.Text = dreader[17].ToString();
                    String Text2 = dreader[18].ToString();
                    if (Text2 == "True")
                    {
                        checkBox3.Checked = true;
                    }
                    else
                    {
                        checkBox3.Checked = false;
                    }
                    String Text3 = dreader[19].ToString();
                    if (Text3 == "True")
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                    String Text1 = dreader[20].ToString();
                    if (Text1 == "True")
                    {
                        checkBox1.Checked = true;
                    } else
                    {
                        checkBox1.Checked = false;
                    }
                    string text5= dreader[21].ToString();
                    if (text5 == "True")
                    {
                        checkBox5.Checked = true;
                    } else
                    {
                        checkBox5.Checked = false;
                    }
                    string text8 = dreader[22].ToString();
                    if (text8 == "True")
                    {
                        checkBox8.Checked = true;
                    }
                    else
                    {
                        checkBox8.Checked = false;
                    }
                    string text9 = dreader[23].ToString();
                    if(text9 == "True")
                    {
                        checkBox9.Checked = true;
                    }
                    else
                    {
                        checkBox9.Checked = false;
                    }
                    textBox25.Text = dreader[24].ToString();
                    textBox26.Text = dreader[25].ToString();
                   string text6  = dreader[26].ToString();
                    if (text6 == "True")
                    {
                        checkBox6.Checked = true;
                    }
                    else
                    {
                        checkBox6.Checked = false;
                    }
                        string text7= dreader[27].ToString();
                    if (text7 == "True")
                    {
                        checkBox7.Checked = true;
                    }
                    else
                    {
                        checkBox7.Checked = false;
                    }



                }
                else
                {
                    MessageBox.Show("No record to show");
                }

                dreader.Close();
            }
            catch (Exception x)
            {
                MessageBox.Show(" No Record" + x.Message);
            }

            finally
            {
                connection.Close();

            }


            //Load the listview with child detail based on key, parent phone 
            //Add columns of listview 
            listView1.Columns.Add("Student ID", 100);
            listView1.Columns.Add("Student's Name", 150);
            listView1.Columns.Add("Date of Birth", 150);
            listView1.Columns.Add("Gender", 100);
            listView1.Columns.Add("Previous Grade", 100);
            listView1.Columns.Add("Grade", 150);
            listView1.Columns.Add("Actual Grade", 150);
            listView1.Columns.Add("Phone", 150);
            listView1.GridLines = true;
            listView1.View = View.Details;
            connection.Open();

            SqlDataReader dr = comm2.ExecuteReader();

            listView1.Items.Clear();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetInt32(0).ToString());
                lv.SubItems.Add(dr.GetString(1));
                lv.SubItems.Add(dr.GetDateTime(2).ToString());
                lv.SubItems.Add(dr.GetString(3));
                lv.SubItems.Add(dr.GetString(4));
                lv.SubItems.Add(dr.GetString(5));
                lv.SubItems.Add(dr.GetString(6));
                lv.SubItems.Add(dr.GetString(7));
                listView1.Items.Add(lv);

            }




            dr.Close();
            connection.Close();


        }

        //Clear Button

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            textBox12.Clear();
            textBox13.Clear();
            textBox14.Clear();
            textBox15.Clear();
            textBox16.Clear();
            textBox18.Clear();
            textBox25.Clear();
            textBox26.Clear();

            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;
            checkBox4.Checked = false;
            checkBox5.Checked = false;
            checkBox6.Checked = false;
            checkBox7.Checked = false;
            checkBox8.Checked = false;
            checkBox9.Checked = false;



        }
        

        
        private void button4_Click(object sender, EventArgs e)
        {
            connection.Open();
            
            if(checkBox1.Checked == true)
            {
                check1 = "true";
            } else
            {
                check1 = "false";
            }

            if (checkBox2.Checked == true)
            {
                check2 = "true";
            }
            else
            {
                check2 = "false";
            }

            if (checkBox3.Checked == true)
            {
                check3 = "true";
            }
            else
            {
                check3 = "false";
            }

            if (checkBox4.Checked == true)
            {
                check4 = "true";
            }
            else
            {
                check4 = "false";
            }
            if (checkBox5.Checked == true)
            {
                check5 = "true";
            }
            else
            {
                check5 = "false";
            }
            if (checkBox6.Checked == true)
            {
                check6 = "true";
            }
            else
            {
                check6 = "false";
            }
            if (checkBox7.Checked == true)
            {
                check7 = "true";
            }
            else
            {
                check7 = "false";
            }
            if (checkBox8.Checked == true)
            {
                check8= "true";
            }
            else
            {
                check8 = "false";
            }
            if (checkBox9.Checked == true)
            {
                check9 = "true";
            }
            else
            {
                check9 = "false";
            }




            comm = new SqlCommand("update  Family set ParentName = @1, Address = @2, City=@3, State=@4, Zipcode=@5, Phone=@Phone, GeneralHelp = @checkbox1, LastModified = @LastModified, Emergency1=@Emergency1, Emergency2=@Emergency2, Email1 = @Email1, Email2 = @Email2 WHERE Phone = @Phone;", connection);
            comm.Parameters.AddRange(new[]{
            new SqlParameter("@1",SqlDbType.NVarChar,255){Value = textBox1.Text},
            new SqlParameter("@2",SqlDbType.NVarChar,255){ Value= textBox2.Text},
            new SqlParameter("@3",SqlDbType.NVarChar,255){ Value= textBox3.Text},
            new SqlParameter("@4",SqlDbType.NVarChar,255){ Value= textBox4.Text},
            new SqlParameter("@5",SqlDbType.NVarChar,255){ Value= textBox5.Text},
            new SqlParameter("@Phone",SqlDbType.NVarChar,255){Value = textBox6.Text},
            new SqlParameter("@checkbox1",SqlDbType.Bit,255){Value = Convert.ToBoolean(check1)},
            new SqlParameter("@LastModified",SqlDbType.DateTime,255){Value = Convert.ToDateTime(textBox18.Text)},
            new SqlParameter("@Emergency1",SqlDbType.NVarChar,255){Value = textBox7.Text},
            new SqlParameter("@Emergency2",SqlDbType.NVarChar,255){Value = textBox8.Text},
            new SqlParameter("@Email1",SqlDbType.NVarChar,255){Value = textBox9.Text},
            new SqlParameter("@Email2",SqlDbType.NVarChar,255){Value = textBox10.Text},
            






        });

            int o = comm.ExecuteNonQuery();
            MessageBox.Show(o + ":Record has been updated");
            connection.Close();
        }
    }
}
