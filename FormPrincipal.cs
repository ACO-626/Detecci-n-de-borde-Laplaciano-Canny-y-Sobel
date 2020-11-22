using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.CV.Structure;

namespace Laplacian_Canny_Sobel_edge_detection
{
    public partial class FormPrincipal : Form
    {
        //Declaramos una imagen como global
        Image<Bgr, byte> img;

        #region Inicializar
        public FormPrincipal()
        {
            InitializeComponent();
        }
        #endregion

        #region Salir
        //Para cerrar programa
        private void salidrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pedimos confirmación
            if(MessageBox.Show("¿Está seguro que desea salir?","MENSAJE DE CONFIRMACIÓN",MessageBoxButtons.YesNo)==DialogResult.Yes)
            {
                this.Close();
            }
        }
        #endregion

        #region IMPORTAR

        //Para importar la imagen
        private void importarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ventanaDialog = new OpenFileDialog();
            //Si dice que todo se lleva a cabo correctamente
            if(ventanaDialog.ShowDialog()==DialogResult.OK)
            {
                try
                {
                    img = new Image<Bgr, byte>(ventanaDialog.FileName);
                    //Igualamos la imagen subida con la imagen de la ventana
                    imageBox1.Image = img;
                    //Podriamos definir el comportamiento del imageBox con 
                }catch(Exception )
                {
                    MessageBox.Show("El archivo seleccionado no es del formato requerido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
        }
        #endregion

        private void cannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AplicarCanny();

        }

        public void AplicarCanny(double limite=50.0,double limite2=20.0)
        {
            if (img != null)
            {
                Image<Gray, byte> imgCanny = new Image<Gray, byte>(img.Width, img.Height, new Gray(0));
                imgCanny = img.Canny(limite , limite2);
                imageBox1.Image = imgCanny;

            }
            else
            {
                MessageBox.Show("Debe cargar una imagen para poder encontrar su borde", "Sin imagen", MessageBoxButtons.OK);
            }

        }

        private void sobelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                //Para el sobel necesitamos una imagen en escala de grises y de extensión float

                Image<Gray, byte> imgGray = img.Convert<Gray,byte>();
                Image<Gray, float> imgSobel = new Image<Gray, float>(img.Width, img.Height, new Gray(0));
                imgSobel = imgGray.Sobel(1, 1, 3);
                imageBox1.Image = imgSobel;
            }else
            {
                MessageBox.Show("Debe cargar una imagen para poder encontrar su borde", "Sin imagen", MessageBoxButtons.OK);
            }
}

        private void laplacianToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (img != null)
            {
                //Para el sobel necesitamos una imagen en escala de grises y de extensión float

                Image<Gray, byte> imgGray = img.Convert<Gray, byte>();
                Image<Gray, float> imgLaplace = new Image<Gray, float>(img.Width, img.Height, new Gray(0));
                imgLaplace = imgGray.Laplace(3);
                imageBox1.Image = imgLaplace;
            }
            else
            {
                MessageBox.Show("Debe cargar una imagen para poder encontrar su borde", "Sin imagen", MessageBoxButtons.OK);
            }
        }

        private void valoresCannyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ValoresCanny cp = new Laplacian_Canny_Sobel_edge_detection.ValoresCanny(this);
            cp.StartPosition = FormStartPosition.CenterParent;
            cp.Show();
        }
    }
}
