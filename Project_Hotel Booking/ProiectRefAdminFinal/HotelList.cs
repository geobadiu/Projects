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
    public partial class HotelList : Form
    {
        public static ListBox hotelList;
        public static string selectedHotel;
        public static string tipCamera;
        public HotelList()
        {
            InitializeComponent();
            hotelList = listBox1;
                    
        }
       
        private void HotelList_Load(object sender, EventArgs e)
        {
            
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            if (Filtre.conditii[0].Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='piscina in aer liber' and disponibilitate='Yes' " +
                    "and locatie.id_locatie-1="+ Filtre.locatii.SelectedIndex.ToString() +"", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close();
            }

            else if (Filtre.conditii[1].Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='parcare' and disponibilitate='Yes'" +
                    "and locatie.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close(); 
            }

            

            else if (Filtre.conditii[2].Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='terasa' and disponibilitate='Yes'" +
                    "and locatie.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close(); 

            }

            else if (Filtre.conditii[3].Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='mic dejun' and disponibilitate='Yes'" +
                    "and locatie.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close();

            }

            else if (Filtre.conditii[4].Checked == true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='spa' and disponibilitate='Yes'" +
                    "and hotel.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close ();
            }

            else if (Filtre.conditii[5].Checked==true)
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join facilitati on hotel.id_hotel=facilitati.id_hotel " +
                    "join detalii_facilitate on facilitati.id_facilitate=detalii_facilitate.id_facilitate " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where nume_facilitate='pet friendly' and disponibilitate='Yes'" +
                    "and locatie.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close();

            }
            else 
            {
                SqlCommand cmd = new SqlCommand("Select nume_hotel from hotel " +
                    "join locatie on hotel.id_locatie=locatie.id_locatie " +
                    "where locatie.id_locatie-1=" + Filtre.locatii.SelectedIndex.ToString() + "", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!listBox1.Items.Contains(reader["nume_hotel"]))
                    {
                        listBox1.Items.Add(reader["nume_hotel"]);
                    }
                }
                reader.Close();
            }


            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            selectedHotel = listBox1.SelectedItem.ToString();
            Hotel hot=new Hotel();
            hot.ShowDialog();

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedHotel = listBox1.SelectedItem.ToString();
            comboBox2.Items.Clear();
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();
            SqlCommand cmd2 = new SqlCommand("Select * from hotel " +
               "full join camere on hotel.id_hotel=camere.id_hotel " +
               "where nume_hotel='" + listBox1.SelectedItem.ToString() + "'", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            while (reader2.Read())
            {
                comboBox2.Items.Add(reader2["Tip_camera"].ToString());

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            PersonalInfo info = new PersonalInfo();
            info.ShowDialog();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            tipCamera=comboBox2.SelectedItem.ToString();
        }
    }
}
