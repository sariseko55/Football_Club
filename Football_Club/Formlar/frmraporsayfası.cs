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
    public partial class frmraporsayfası : Form
    {
        public frmraporsayfası()
        {
            InitializeComponent();
        }

        raporformu fr;
        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            if (fr==null || fr.IsDisposed)
            {
                fr = new raporformu();
                fr.Show();
            
            }
            
        }

        private void frmraporsayfası_Load(object sender, EventArgs e)
        {

        }

        frmesamerapor fresame;
        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            if (fresame == null || fr.IsDisposed)
            {
                fresame = new frmesamerapor();
                fresame.Show();

            }
        }
    }
}
