using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Football_Club.Formlar
{
    public partial class frmayarlar : Form
    {
        public frmayarlar()
        {
            InitializeComponent();
        }

        frmtakimekle takimekle;
        private void btntakimekle_Click(object sender, EventArgs e)
        {
            if (takimekle == null || takimekle.IsDisposed)
            {
                takimekle = new frmtakimekle();
                //takimekle.MdiParent = this;
                takimekle.Show();
            }
        }
    }
}
