using Capa_datos;
using Capa_datos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Final_Modulo2_Arturo
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

            string[] a = { "d", "c" };
            string[] b = { "Dueño", "Cajero" };
            OpcionCombo.iniciar_combo(a, b, comboBox1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            farmaceutico a = new farmaceutico();
            a.ci = textBox1.Text;
            a.nombreFarm= textBox2.Text;
            a.apellidoFarm= textBox3.Text;
            a.contrasena= textBox4.Text;
            a.cargo= ((OpcionCombo)comboBox1.SelectedItem).Value.ToString();
            string b = Farmaceutico2.agregar(a);
            if (b != "")
                MessageBox.Show(b);
            else
                MessageBox.Show("No se registro");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            farmaceutico a = new farmaceutico();
            a.ci = textBox1.Text;
            a.nombreFarm = textBox2.Text;
            a.apellidoFarm = textBox3.Text;
            a.contrasena = textBox4.Text;
            a.cargo = ((OpcionCombo)comboBox1.SelectedItem).Value.ToString();
            string b = Farmaceutico2.modificar(a);
            if (b != "")
                MessageBox.Show(b);
            else
                MessageBox.Show("No se modifico");
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string b = Farmaceutico2.eliminar(textBox1.Text);
            if (b != "")
                MessageBox.Show(b);
            else
                MessageBox.Show("No se elimino");
            
        }
    }
}
