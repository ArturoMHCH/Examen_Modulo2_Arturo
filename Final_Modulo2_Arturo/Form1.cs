using Microsoft.Data.SqlClient;
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
    public partial class Form1 : Form,Iform
    {
        //private static Farmaceutico usuarioActual;
        private static ToolStripMenuItem MenuActivo = null;
        private static Form FormularioActivo = null;
        public int ingreso = 0;
        public Form1()
        {
            InitializeComponent();
            

        }
        public void ejecutar(string texto,string ci)
        {
            label1.Text = texto;
            label2.Text = ci;
        }
        private void AbrirFormulario(ToolStripMenuItem menu, Form formulario, int form)
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
            if(form==2)
            {
                    Form2 a = new Form2();
                    formulario = a;
                    a.contrato = this;
                repite(formulario);
            }
            else
            {
                if (form == 3)

                {
                    if(label1.Text != "")
                    {
                        Form3 a = new Form3();
                        formulario = a;
                        a.ci = label2.Text;
                        repite(formulario);
                    }
                        
                    else
                        MessageBox.Show("No estas registrado");
                }
                else
                {
                    if (label1.Text == "d")
                        repite(formulario);
                    else
                        MessageBox.Show("No eres dueño");
                }
            }
        }
        private void repite(Form f)
        {
            FormularioActivo = f;
            f.TopLevel = false;
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill;
            f.BackColor = Color.White;
            panel1.Controls.Add(f);
            f.Show();
        }
        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            AbrirFormulario(toolStripMenuItem3, new Form2(),2);
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AbrirFormulario(toolStripMenuItem2, new Form3(),3);
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AbrirFormulario(toolStripMenuItem1, new Form4(),4);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
