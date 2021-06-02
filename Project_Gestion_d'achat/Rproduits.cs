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
namespace Project_Gestion_d_achat
{
    public partial class Rproduits : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion d'achat projet;Integrated Security=True");
        SqlCommand cmd;
        SqlDataReader dr;
        public Rproduits()
        {
            InitializeComponent();
        }

        private void Rproduits_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            cn.Open();
            cmd = new SqlCommand("select*  from PRODUCTS where ID_PRODUCT like '%" + textBox1.Text + "%'", cn);
            dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            dataGridView1.DataSource = dt;
            dr.Close();
            cn.Close();
        }
    }
}
