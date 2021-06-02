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
    public partial class Commande : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion d'achat projet;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dts = new DataTable();
        public Commande()
        {
            InitializeComponent();
            DataGrid();
           

            Da = new SqlDataAdapter("select * from CUSTOMERS", cn);
            Da.Fill(dts);
            comboBox2.DataSource = dts;
            comboBox2.DisplayMember = "ID_CUSTOMER";

            Da = new SqlDataAdapter("select * from Commande", cn);
            Da.Fill(dtt);
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = "IdCommande";
            
        }
        public void DataGrid()
        {
            
            dt.Clear();
            cmd = new SqlCommand("selectCommande", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnAjou_Click(object sender, EventArgs e)
        {

            try
         {
                cmd = new SqlCommand("addCommande", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[2];
                param[0] = new SqlParameter("@dates", SqlDbType.Date);
                param[0].Value = date.Value;
                param[1] = new SqlParameter("@idclient", SqlDbType.Int);
                param[1].Value = comboBox2.Text;
                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
               
          }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void btnsu_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("deletecommande", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
                cmd.Parameters.Add(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("updatecommande", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("@id", SqlDbType.Int);
                param[0].Value = comboBox1.Text;
                param[1] = new SqlParameter("@idc", SqlDbType.Int);
                param[1].Value = comboBox2.Text;
                param[2] = new SqlParameter("@dates", SqlDbType.Date);
                param[2].Value = date.Text;

                cmd.Parameters.AddRange(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Bien Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
                DataGrid();
            }
            catch
            {
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void btnqui_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            //date.Value = dataGridView1.Rows[pos].Cells[2].Value.ToString("");
        }
    }
}
