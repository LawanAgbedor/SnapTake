using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SnapTake
{
    public partial class frmBusy : Form
    {
        public frmBusy(Form owner)
        {
            InitializeComponent();

            this.Owner = owner;
        }

        private void frmBusy_Load(object sender, EventArgs e)
        {
            RepositionMe();
            ResizeMe();
        }

        public void RepositionMe()
        {
            this.Top = Owner.Top + 32;
            this.Left = Owner.Left + 8;
        }

        public void ResizeMe()
        {
            this.Width = Owner.Width - 16;
            this.Height = Owner.Height - 40;
            RepositionBusy();
        }

        private void RepositionBusy()
        {
            pictureBox1.Top = (this.Height - pictureBox1.Height) / 2;
            pictureBox1.Left = (this.Width - pictureBox1.Width) / 2;
        }
    }
}
