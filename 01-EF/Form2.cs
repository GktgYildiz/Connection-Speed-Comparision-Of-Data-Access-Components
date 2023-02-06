using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_EF
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
        SqlConnection conn = new SqlConnection("Server=DESKTOP-0CEFHU5; Database=Northwind;Trusted_Connection=True;");


        private void button1_Click(object sender, EventArgs e)
        {
            //CONNECTED
            DateTime baslangic = DateTime.Now;

            SqlCommand cmd = new SqlCommand("select * from Orders", conn);

            if (conn.State == ConnectionState.Closed)
            {
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        listBox1.Items.Add(dr["OrderID"]);
                    }
                }
            }
            else
            {
                conn.Close();
            }
            DateTime bitis = DateTime.Now;
            TimeSpan fark = bitis - baslangic;
            label5.Text = fark.TotalMilliseconds.ToString();
        }
        SqlConnection conn2 = new SqlConnection("Server=DESKTOP-0CEFHU5; Database=Northwind;Trusted_Connection=true");

        private void button2_Click(object sender, EventArgs e)
        {
            //disconnected
            DateTime baslangic = DateTime.Now;


            SqlDataAdapter dap = new SqlDataAdapter("select * from Orders", conn2);
            DataTable dt = new DataTable();
            dap.Fill(dt);
            listBox2.DataSource = dt;
            listBox2.DisplayMember = "OrderId";
            DateTime bitis = DateTime.Now;
            TimeSpan fark = bitis - baslangic;
            label6.Text = fark.TotalMilliseconds.ToString();


        }
        NorthwindEntities1 db = new NorthwindEntities1();

        private void button3_Click(object sender, EventArgs e)
        {
            DateTime baslangic = DateTime.Now;

            listBox3.DataSource = db.Orders.Select(o => o.OrderID).ToList();
            listBox3.DisplayMember = "OrderId";
            DateTime bitis = DateTime.Now;
            TimeSpan fark = bitis - baslangic;
            label7.Text = fark.TotalMilliseconds.ToString();

        }
    }
}
