using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laplacian_Canny_Sobel_edge_detection
{
    public partial class ValoresCanny : Form
    {
        FormPrincipal formP;
        public ValoresCanny()
        {
            InitializeComponent();
        }

        public  ValoresCanny(FormPrincipal fm)
        {
            InitializeComponent();
            formP = fm;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAplicar_Click(object sender, EventArgs e)
        {
            if(formP!=null)
            {
                formP.AplicarCanny((double)limiteCanny.Value,(double)limiteCanny2.Value);
            }
        }
    }
}
