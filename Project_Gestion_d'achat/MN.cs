using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Gestion_d_achat
{
    public partial class MN : Form
    {
        public MN()
        {
            InitializeComponent();
        }

        private void MN_Load(object sender, EventArgs e)
        {

        }

        private void categoriesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Categories ct = new Categories();
            ct.ShowDialog();
        }

        private void produitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Produits pr = new Produits();
            pr.ShowDialog();
        }

        private void cliensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Les_Clients cl = new Les_Clients();
            cl.ShowDialog();
        }

        private void commandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Commande cmd = new Commande();
            cmd.ShowDialog();
        }

        private void detailleCommandeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DetailleCommande dcmd = new DetailleCommande();
            dcmd.ShowDialog();
        }

        private void categoriesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            R rs = new R();
                rs.ShowDialog();
        }

        private void produitsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Rproduits rp = new Rproduits();
            rp.ShowDialog();
        }

        private void clientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RClient rc = new RClient();
            rc.ShowDialog();
        }

        private void commandeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RCommande rc = new RCommande();
            rc.ShowDialog();
        }

        private void detailleCommandeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RDC rDC = new RDC();
            rDC.ShowDialog();
        }
    }
}
