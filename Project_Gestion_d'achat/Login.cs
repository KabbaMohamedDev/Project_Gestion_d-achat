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
    public partial class Login : Form
    {
        BL.login log = new BL.login();
        public Login()
        {
            InitializeComponent();
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Voulez-vous quitte cette page?");
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataTable dt = log.LOGIN(txtID.Text, txtPWD.Text);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("login succes ");
                MN m = new MN();
                m.ShowDialog();
                this.Close();


            }
            else
            {
                MessageBox.Show("login failed");
            }
        }
    }
}
