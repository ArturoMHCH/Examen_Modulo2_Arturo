using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Final_Modulo2_Arturo
{
    public partial class Form1 : Form
    {
        //private static Farmaceutico usuarioActual;
        private static ToolStripMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;

        public Form1()
        {
            InitializeComponent();
        }
        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario)
        {

            if (MenuActivo != null)
            {
                MenuActivo.BackColor = Color.White;
            }
            menu.BackColor = Color.White;
            MenuActivo = menu;

            if (FormularioActivo != null)
            {
                FormularioActivo.Close();
            }

            FormularioActivo = formulario;
            formulario.TopLevel = false;
            formulario.FormBorderStyle = FormBorderStyle.None;
            formulario.Dock = DockStyle.Fill;
            formulario.BackColor = Color.White;

            panel1.Controls.Add(formulario);
            formulario.Show();


        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {

            AbrirFormulario(toolStripMenuItem3, new Form2());

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(toolStripMenuItem2, new Form3());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(toolStripMenuItem1, new Form4());
        }
    }
}
