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
    public partial class Produits : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion d'achat projet;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        DataTable dts = new DataTable();
        public Produits()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from CATEGORIES", cn);
            Da.Fill(dtt);
            comboBox1.DataSource = dtt;
            comboBox1.DisplayMember = "ID_CAT";

            Da = new SqlDataAdapter("select * from PRODUCTS", cn);
            Da.Fill(dts);
            comboBox2.DataSource = dts;
            comboBox2.DisplayMember = "ID_PRODUCT";
        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectproduit", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("deleteProduit", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.VarChar,30);
                param.Value = comboBox2.Text;
                cmd.Parameters.Add(param);
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                MessageBox.Show("Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataGrid();
            }
            catch
            {
                MessageBox.Show(" Non Supprimer ", "del", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void btnQui_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAjou_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    cmd = new SqlCommand("addProduits", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@id", SqlDbType.VarChar, 30);
                    param[0].Value = comboBox2.Text;
                    param[1] = new SqlParameter("@lab", SqlDbType.VarChar, 30);
                    param[1].Value = textBox1.Text;
                    param[2] = new SqlParameter("@Q", SqlDbType.Int);
                    param[2].Value = textBox3.Text;
                    param[3] = new SqlParameter("@price", SqlDbType.VarChar, 50);
                    param[3].Value = textBox2.Text;
                    param[4] = new SqlParameter("@IDS", SqlDbType.Int);
                    param[4].Value = comboBox1.Text;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                }
                else
                {
                    MessageBox.Show("non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MessageBox.Show("problem dans le saisie", "Ajouter", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void btnModi_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox2.Text != "" && textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
                {
                    cmd = new SqlCommand("updateproduits", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[5];
                    param[0] = new SqlParameter("@id", SqlDbType.VarChar, 30);
                    param[0].Value = comboBox2.Text;
                    param[1] = new SqlParameter("@lab", SqlDbType.VarChar, 30);
                    param[1].Value = textBox1.Text;
                    param[2] = new SqlParameter("@Qte", SqlDbType.Int);
                    param[2].Value = textBox3.Text;
                    param[3] = new SqlParameter("@pri", SqlDbType.VarChar, 50);
                    param[3].Value = textBox2.Text;
                    param[4] = new SqlParameter("@idc", SqlDbType.Int);
                    param[4].Value = comboBox1.Text;
                    cmd.Parameters.AddRange(param);
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    MessageBox.Show("Bien Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                    DataGrid();
                }
                else
                {
                    MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox2.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            textBox1.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
           
        }
    }
}
