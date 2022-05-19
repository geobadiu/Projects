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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register f = new Register();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            //Code for DB
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand scmd = new SqlCommand("select count (*) as cnt from Users where Username=@usr and Password=@pwd", con);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@usr", textBox1.Text);
            scmd.Parameters.AddWithValue("@pwd", textBox2.Text);
            //scn.Open();

            if (scmd.ExecuteScalar().ToString() == "1")
            {
                if (textBox1.Text == "admin" && textBox2.Text == "admin")
                {
                    this.Hide();
                    Filtre f = new Filtre();
                    f.ShowDialog();
                    //MessageBox.Show("Login succesfully");
                }
                else if (textBox1.Text == "admin" && textBox2.Text == "1234")
                {
                    this.Hide();
                    Filtre f = new Filtre();
                    f.ShowDialog();
                    //MessageBox.Show("Login succesfully");
                }

                else
                {
                    //MessageBox.Show("Login succesfully");
                    //Code for going to MENU
                    this.Hide();
                    Menu f = new Menu();
                    f.ShowDialog();
                }
            }

            else
            {
                MessageBox.Show("Wrong password or username. Try again!");
                textBox1.Clear();
                textBox2.Clear();
            }

            
            con.Close();

          
          
        }
    }
}
