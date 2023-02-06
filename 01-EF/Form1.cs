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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //db first --> Veri tabanı içinde yer alan veri tabanına
        //code first --> kendimiz yazıp kendimiz gerçekleştiriyoruz
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        NorthwindEntities1 db = new NorthwindEntities1();
        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server = .; Database=Northwind;Trusted_Connection=true");

            //-----------------------------------CONNECTED-------------------------------------
            //SqlCommand cmd = new SqlCommand("select * from Customers", conn);

            //if (conn.State != ConnectionState.Closed)
            //{
            //    conn.Open();
            //    SqlDataReader dr = cmd.ExecuteReader();
            //    if (dr.HasRows)
            //    {
            //        while (true)
            //        {
            //            //
            //        }
            //    }
            //    else
            //    {
            //        conn.Close();
            //    }
            //}


            //-------------------------------------DISCONNECTED----------------------------------------
            //SqlDataAdapter dap = new SqlDataAdapter("select * from Customers", conn);
            //DataTable dt = new DataTable();
            //dap.Fill(dt);
            //dataGridView1.DataSource = dt;


            //--------------------------------------ENTITIY FRAMEWORK---------------------------------


            //listeleme IEnumarable
            //add,remove gibi fonksiyonları kullancaksan ICollection kullanıyorsun
            /*
               ÖDEV 1 : EasyLoading, EagerLoading, vb farkları nedir --> KONU: Loading
               ÖDEV 2 : IList, IEnumarable, ICollection nedir? Aralarındaki fark nedir? --> KONU : Collection
             */

            //dataGridView1.DataSource = db.Customers.ToList();
            ////Order kolonunun boş gelmesi --> Navigation Property(FK gösterme)
            ////Navigation Property gizleme
            //dataGridView1.Columns["Orders"].Visible = false;


            //2.YOL -- LAMBA

            //Lambda Expression la new lemek
            //dataGridView1.DataSource = db.Categories.Select(c => new {c.CategoryID, c.CategoryName, c.Description, c.Picture }).ToList();,


            //3.YOL -- LINQ
            var query = from item in db.Categories
                                       select new {
                                           item.CategoryID, 
                                           item.CategoryName, 
                                           item.Description, 
                                           item.Picture };

            dataGridView1.DataSource = query.ToList();

        }
    }
}
