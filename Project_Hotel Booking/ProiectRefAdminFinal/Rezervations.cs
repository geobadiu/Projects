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
    public partial class Rezervations : Form
    {
        public Rezervations()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear(); 
            string cs = @"Data Source=DESKTOP-OQB19BR;Initial Catalog=Online_Hotel_Booking;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            SqlCommand scmd = new SqlCommand("select count (*) from client where nume=@nume and prenume=@pre", con);
            scmd.Parameters.Clear();
            scmd.Parameters.AddWithValue("@nume", textBox1.Text);
            scmd.Parameters.AddWithValue("@pre", textBox2.Text);
            
            if (int.Parse(scmd.ExecuteScalar().ToString()) == 1)
            {

                SqlCommand cmd1 = new SqlCommand("select hotel.nume_hotel,camere.tip_camera, rezervari.data_sosire, rezervari.data_plecare from camere " +
                    "inner join rezervari on camere.id_camera=rezervari.id_camera " +
                    "inner join hotel on hotel.id_hotel = rezervari.id_hotel " +
                    "inner join client on rezervari.id_client=client.id_client " +
                    "where client.nume='"+textBox1.Text+"' and client.prenume='"+textBox2.Text+"'", con);
                SqlDataReader r1=cmd1.ExecuteReader();
                while(r1.Read())
                {
                    ListViewItem lvitem=new ListViewItem();
                    lvitem.SubItems.Add(r1["nume_hotel"].ToString());
                    lvitem.SubItems.Add(r1["tip_camera"].ToString());
                    lvitem.SubItems.Add(r1["data_sosire"].ToString());
                    lvitem.SubItems.Add(r1["data_plecare"].ToString());
                    listView1.Items.Add(lvitem);
                }
                
                r1.Close();
            }
            else { MessageBox.Show("No rezervations on this name.","Error!"); }
        }
    }
}
