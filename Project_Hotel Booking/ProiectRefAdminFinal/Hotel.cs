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
    public partial class Hotel : Form
    {
        private int i = 1;
        public Hotel()
        {
            InitializeComponent();
        }

        private void Hotel_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd = new SqlCommand("select descriere from hotel where nume_hotel='" + HotelList.selectedHotel + "'", con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                textBox1.Text=reader["descriere"].ToString();
            }
            reader.Close();

            pictureBox1.Image = Image.FromFile(""+HotelList.selectedHotel+i+".jfif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (i > 1)
            {
                i--;
                pictureBox1.Image = Image.FromFile("" + HotelList.selectedHotel + i + ".jfif");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (i < 4)
            {
                i++;
                pictureBox1.Image = Image.FromFile("" + HotelList.selectedHotel + i + ".jfif");
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

       

        
    }
}
