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
    public partial class Les_Clients : Form
    {
        SqlConnection cn = new SqlConnection(@"Data Source=MK\MOHAMED;Initial Catalog=gestion d'achat projet;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter Da;
        DataTable dt = new DataTable();
        DataTable dtt = new DataTable();
        public Les_Clients()
        {
            InitializeComponent();
            DataGrid();
            Da = new SqlDataAdapter("select * from CUSTOMERS", cn);
            Da.Fill(dtt);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "ID_CUSTOMER";
        }
        void DataGrid()
        {
            dt.Clear();
            cmd = new SqlCommand("selectCustome", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            Da = new SqlDataAdapter(cmd);
            Da.Fill(dt);
            this.dataGridView1.DataSource = dt;
        }
        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Les_Clients_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnAjou_Click(object sender, EventArgs e)
        {

            try
            {
                if (TxtCin.Text != "" && txtnom.Text != "" && txtprenom.Text != "" && txtemail.Text != "" && txttele.Text != "" && txtville.Text != "")
                {
                    cmd = new SqlCommand("addclient", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[6];
                    param[0] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[0].Value = txtnom.Text;
                    param[1] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[1].Value = txtprenom.Text;
                    param[2] = new SqlParameter("@tel", SqlDbType.NChar, 15);
                    param[2].Value = txttele.Text;
                    param[3] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
                    param[3].Value = txtemail.Text;
                    param[4] = new SqlParameter("@CIN", SqlDbType.NVarChar, 50);
                    param[4].Value = TxtCin.Text;

                    param[5] = new SqlParameter("@ville", SqlDbType.VarChar, 50);
                    param[5].Value = txtville.Text;
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
                    MessageBox.Show("Non Modifier", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    MessageBox.Show("Vous devez remplir tous les champs obligatoires", "Modifier", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cn.Close();
                }
            }
            catch
            {
                MessageBox.Show("Non Ajouter", "add", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cn.Close();
            }

        }

        private void btnSup_Click(object sender, EventArgs e)
        {
            try
            {
                cmd = new SqlCommand("delcustomer", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter();
                param = new SqlParameter("@id", SqlDbType.Int);
                param.Value = comboBox1.Text;
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

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            int pos = dataGridView1.CurrentRow.Index;
            comboBox1.Text = dataGridView1.Rows[pos].Cells[0].Value.ToString();
            txtnom.Text = dataGridView1.Rows[pos].Cells[1].Value.ToString();
            txtprenom.Text = dataGridView1.Rows[pos].Cells[2].Value.ToString();
            txttele.Text = dataGridView1.Rows[pos].Cells[3].Value.ToString();
            txtemail.Text = dataGridView1.Rows[pos].Cells[4].Value.ToString();
            TxtCin.Text = dataGridView1.Rows[pos].Cells[5].Value.ToString();
            txtville.Text = dataGridView1.Rows[pos].Cells[6].Value.ToString();
        }

        private void BtnModi_Click(object sender, EventArgs e)
        {
            try
            {
                if (TxtCin.Text != "" && txtnom.Text != "" && txtprenom.Text != "" && txtemail.Text != "" && txttele.Text != "" && txtville.Text != "")
                {
                    cmd = new SqlCommand("updatecustomer", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] param = new SqlParameter[7];
                    param[0] = new SqlParameter("@id", SqlDbType.Int);
                    param[0].Value = comboBox1.Text;
                    param[1] = new SqlParameter("@nom", SqlDbType.VarChar, 20);
                    param[1].Value = txtnom.Text;
                    param[2] = new SqlParameter("@prenom", SqlDbType.VarChar, 20);
                    param[2].Value = txtprenom.Text;
                    param[3] = new SqlParameter("@tel", SqlDbType.NChar, 15);
                    param[3].Value = txttele.Text;
                    param[4] = new SqlParameter("@email", SqlDbType.NVarChar, 50);
                    param[4].Value = txtemail.Text;
                    param[5] = new SqlParameter("@CIN", SqlDbType.NVarChar, 50);
                    param[5].Value = TxtCin.Text;
                    param[6] = new SqlParameter("@ville", SqlDbType.VarChar, 50);
                    param[6].Value = txtville.Text;
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
    }
    }
    

