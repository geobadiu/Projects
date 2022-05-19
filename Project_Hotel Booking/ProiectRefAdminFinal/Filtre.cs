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
    
    public partial class Filtre : Form
    {
        public static ListBox locatii;
        public static string numarPers;
        public static string dataSosire;
        public static string dataPlecare;
        public static CheckBox[] conditii = new CheckBox[6];
        public static int[] filtru = new int[] { 0, 0, 0, 0, 0, 0 };
        public Filtre()
        {
            InitializeComponent();
            locatii = listBox1;
            conditii[0] = checkBox1;
            conditii[1] = checkBox2;
            conditii[2] = checkBox3;
            conditii[3] = checkBox4;
            conditii[4] = checkBox5;
            conditii[5] = checkBox6;
            dataSosire=dateTimePicker1.Value.ToString("yyyy-MM-dd");
            dataSosire=dateTimePicker2.Value.ToString("yyyy-MM-dd");

        }

        private void Filtre_Load(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand cmd = new SqlCommand("Select * from locatie",con);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                listBox1.Items.Add(string.Format("{0}, {1}, {2}", reader["oras"],reader["judet"],reader["tara"]));
            }
            comboBox1.Items.Add("1");
            comboBox1.Items.Add("2");
            comboBox1.Items.Add("3");
            comboBox1.Items.Add("4");
            comboBox1.Items.Add("5+");
           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {           
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            HotelList hotels = new HotelList();
            hotels.ShowDialog();
      

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            int nrPers = comboBox1.SelectedIndex;
            if (nrPers == 4) 
            { 
                numarPers = "5+"; 
            } 
            else 
            {
                numarPers=""+(nrPers + 1)+""; 
            }
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
