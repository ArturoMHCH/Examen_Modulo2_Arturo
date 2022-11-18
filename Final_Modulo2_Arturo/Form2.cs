using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Final_Modulo2_Arturo
{
    public partial class Form2 : Form
    {
        public Iform contrato { get; set; }
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string var = Capa_datos.Farmaceutico2.buscar((textBox1.Text), textBox2.Text);
            if (var!="")
            {
                MessageBox.Show("ingreso correcto");
                contrato.ejecutar(var,textBox1.Text);
                
            }
            else
            {
                MessageBox.Show("no se encontro");
            }
        }
    }
}
