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

namespace ProiectRefAdminFinal
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Code for DB
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            //Check if password match
            if (textBox1.Text == "" || textBox2.Text == "")
                MessageBox.Show("Please fill mandatory fields");
            else if (textBox2.Text != textBox3.Text)
                MessageBox.Show("Password do not match");
            else
            {
                SqlCommand cmd2 = new SqlCommand("insert into Users (Username,Password) " + "values ('" + textBox1.Text + "','" + textBox2.Text + "')", con);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Succesfully Registered");
       
            }


            con.Close();


            //Code for going back to LOGIN 
            this.Hide();
            Login f = new Login();
            f.ShowDialog();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
