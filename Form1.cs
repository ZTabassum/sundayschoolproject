using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.ComponentModel;
namespace sundayschoolproject
{
    public partial class Form1 : Form
    {
        string con = ("Data Source=ZTABASSUM\\SQLEXPRESS01;Initial Catalog= Sunday School;Integrated Security=True");
        SqlCommand comm;
        SqlDataReader dreader;
      
        public System.Windows.Forms.ListView.SelectedListViewItemCollection ListViewSelectedItems
        {
            get { return listView1.SelectedItems; }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listView1.GridLines = true;
            listView1.View = View.Details;
           
            //Add Columns 
            listView1.Columns.Add("ParentName", 100);
            listView1.Columns.Add("Address", 150);
            listView1.Columns.Add("City", 100);
            listView1.Columns.Add("State", 50);
            listView1.Columns.Add("Zipcode", 100);
            listView1.Columns.Add("Phone", 150);


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string sql = ("Select * from Family");
            SqlConnection connection = new SqlConnection(con);

            SqlCommand cmd = new SqlCommand(sql, connection);

            connection.Open();

            SqlDataReader dr = cmd.ExecuteReader();

            listView1.Items.Clear();

            while (dr.Read())
            {
                ListViewItem lv = new ListViewItem(dr.GetString(0));
                lv.SubItems.Add(dr.GetString(1));     
                lv.SubItems.Add(dr.GetString(2));
                lv.SubItems.Add(dr.GetString(3));
                lv.SubItems.Add(dr.GetString(4));
                lv.SubItems.Add(dr.GetString(5));
                listView1.Items.Add(lv);
                
            }


            

            dr.Close();
            connection.Close();



        }


        //registered a listview1_click handler and then if name is clicked, a new form pops up 
     private void listView1_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                Form2 frm = new Form2(this);
                frm.Show();
                //MessageBox.Show("You clicked " + listView1.SelectedItems[0].Text);
               //ListViewItem item1 = listView1.SelectedItems[0];
              
               



                //MessageBox.Show("Person's phone number is " + item1.SubItems[5].Text);
            }
            else
            {
                MessageBox.Show("Please select an item");
            }

            





        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form3 fl = new Form3();
            fl.Show();
        }

        private void button5_Click(object sender, EventArgs e)

        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();
            comm = new SqlCommand("select * FROM FAMILY WHERE Phone  =  @Phone OR ParentName = @Parentname;", connection);
            comm.Parameters.AddRange(new[]{
                new SqlParameter("@Phone",SqlDbType.NVarChar,255){Value = textBox1.Text},
                new SqlParameter("@ParentName",SqlDbType.NVarChar,255){Value = textBox2.Text},
            });
            
            try
            {
                dreader = comm.ExecuteReader();
                if (dreader.Read())
                {
                    textBox1.Text = dreader[5].ToString();
                    textBox2.Text = dreader[0].ToString();
                    textBox3.Text = dreader[1].ToString();
                    textBox4.Text = dreader[2].ToString();
                    textBox5.Text = dreader[3].ToString();
                    textBox6.Text = dreader[4].ToString();

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
            
            


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(con);
            connection.Open();

           
            
            comm = new SqlCommand("Insert into Family (ParentName, Phone, Address, City, State, Zipcode) values (@1,@2,@3,@4,@5,@6);", connection);
            comm.Parameters.AddRange(new[]{
            new SqlParameter("@1",SqlDbType.NVarChar,255){Value = textBox2.Text},
            new SqlParameter("@2",SqlDbType.NVarChar,255){ Value= textBox1.Text},
            new SqlParameter("@3",SqlDbType.NVarChar,255){ Value= textBox3.Text},
            new SqlParameter("@4",SqlDbType.NVarChar,255){ Value= textBox4.Text},
            new SqlParameter("@5",SqlDbType.NVarChar,255){ Value= textBox5.Text},
            new SqlParameter("@6",SqlDbType.NVarChar,255){ Value= textBox6.Text},



            });

            int o = comm.ExecuteNonQuery();
            MessageBox.Show(o + ":Record has been inserted");
           
        }
        
        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();

        }
    }
    }







