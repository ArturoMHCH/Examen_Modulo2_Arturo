using Capa_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Final_Modulo2_Arturo
{
    public partial class Form3 : Form
    {
        bool inicio = true;
        public string ci { get; set; }
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inicio)
            {
                Venta.agregar(DateTime.Now.ToString("dd-MM-yyyy"), ci, Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToInt32(textBox5.Text));
                inicio = false;
            }

            else
                Venta.agregar(textBox4.Text, Convert.ToInt32(textBox5.Text));
            
        }
    }
}
