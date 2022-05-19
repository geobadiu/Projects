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
using System.Text.RegularExpressions;

namespace ProiectRefAdminFinal
{
    public partial class PersonalInfo : Form
    {
        public static string numeClient;
        public static string prenumeClient;

        public PersonalInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            if (!String.IsNullOrEmpty(textBox2.Text) && 
                !String.IsNullOrEmpty(textBox3.Text) && 
                !String.IsNullOrEmpty(textBox4.Text) && 
                !String.IsNullOrEmpty(textBox1.Text) &&  
                !String.IsNullOrEmpty(textBox7.Text) &&
                
                (radioButton1.Checked || radioButton2.Checked))
            {
                numeClient = textBox1.Text;
                prenumeClient = textBox2.Text;
                
                SqlCommand cmd2 = new SqlCommand( 
                    "insert into rezervari(id_hotel,id_camera,id_client,data_sosire,data_plecare) " +
                    "values(" +
                    "(select id_hotel from hotel where nume_hotel='" + HotelList.selectedHotel + "'), " +
                    "(select id_camera from camere where tip_camera='" + HotelList.tipCamera + "'), " +
                    "(select id_client from client where nume='" + numeClient + "' and prenume='" + prenumeClient + "'), " +
                    "'" + Filtre.dataSosire + "'," +
                    "'" + Filtre.dataPlecare + "')" , con); 
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Reservation has been made successfully!\n" +
                "A confirmation email should be sent momentarily", "Success!", MessageBoxButtons.OK);

            }
            else
            {
                MessageBox.Show("Enter valid Data!", "Error!");
            }


            
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            string pattern1 = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$";
            if (Regex.IsMatch(textBox7.Text, pattern1))
            {
                errorProvider1.Clear();
                button1.Enabled = true;
            }
            else
            {
                errorProvider1.SetError(this.textBox7, "Please enter a valid email adress");
                button1.Enabled = false;
                return;
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox3.Text, "[^0-9]"))
            {
                errorProvider1.SetError(this.textBox3, "Please enter only numbers");
                button1.Enabled = false;
                return;
            }
            else
            {
                errorProvider1.Clear();
                button1.Enabled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (Regex.IsMatch(textBox4.Text, "[^0-9]"))
            {

                errorProvider1.SetError(this.textBox4, "Please enter only numbers");
                button1.Enabled = false;
                return;
            }
            else
            {
                errorProvider1.Clear();
                button1.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            char sex;

            if (!String.IsNullOrEmpty(textBox2.Text) &&
                !String.IsNullOrEmpty(textBox3.Text) &&
                !String.IsNullOrEmpty(textBox4.Text) &&
                !String.IsNullOrEmpty(textBox1.Text) &&
                !String.IsNullOrEmpty(textBox7.Text) &&

                (radioButton1.Checked || radioButton2.Checked))
            {
                if (radioButton1.Checked == true)
                {
                    sex = 'M';
                }
                else
                {
                    sex = 'F';
                }
                string data = dateTimePicker1.Value.ToString("yyyy-MM-dd");
                numeClient = textBox1.Text;
                prenumeClient = textBox2.Text;

                SqlCommand cmd1 = new SqlCommand("insert into client(cnp,nume,prenume,data_nasterii,sex,telefon,email) " +
                    "values ('" + textBox4.Text +
                    "','" + textBox1.Text +
                    "','" + textBox2.Text +
                    "','" + data +
                    "','" + sex +
                    "','" + textBox3.Text +
                    "','" + textBox7.Text + "')", con);
                cmd1.ExecuteNonQuery(); 
            }
        
            else
            {
                MessageBox.Show("Enter valid Data!", "Error!");
            }
        }  
        }
}
