using Capa_datos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Final_Modulo2_Arturo
{
    public partial class Form3 : Form
    {
        bool inicio = true;
        int numFactura;
        public string ci { get; set; }
        public Form3()
        {
            InitializeComponent();
            autocompletar(textBox1);
            autocompletar(textBox4);
        }
        
        private void tb()
        {
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (inicio)
            {
                int id;
            
                string msg = Venta.agregar(ci, textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, out id);
                if (msg != "")
                    MessageBox.Show(msg);
                else
                {
                    inicio = false;
                    numFactura = id;
                    MessageBox.Show("Cliente y medicamento registrado, se inhabilitara los datos de cliente hasta que genere factura");
                    textBox1.Enabled = false;
                    textBox2.Enabled = false;
                    textBox3.Enabled = false;
                    tb();

                }
            }

            else
            {
                string msg=Venta.agregar(textBox4.Text, textBox5.Text, numFactura);
                if(msg!="")
                    MessageBox.Show(msg);
                else
                {
                    MessageBox.Show("Medicamento registrado en la misma factura");
                    tb();
                }


            }

            
        }
        private void autocompletar(TextBox tb)
        {
            List<string> a = Venta.autocompletar(tb.Name == "textBox1" ? 1:2) ;
            foreach (string b in a)
            {
                tb.AutoCompleteCustomSource.Add(b);
            }


        }

        private void button1_textchanged(object sender, EventArgs e)
        {
            string nombre, apellido;
            if (Venta.buscarnit(textBox1.Text, out nombre, out apellido))
            {
                textBox2.Text = nombre;
                textBox3.Text = apellido;
                textBox2.Enabled = false;
                textBox3.Enabled = false;
            }
            else
            {
                textBox2.Text = "";
                textBox3.Text = "";
                textBox2.Enabled = true;
                textBox3.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!inicio)
            {
                richTextBox1.Text = "         Factura #" + numFactura + "      \n";
                richTextBox1.Text += "-------------------------------------------------\n";
                richTextBox1.Text += "Nit: "+textBox1.Text+"   Fecha:"+Venta.fecha(numFactura)+"\n";
                richTextBox1.Text += "Nombre: " + textBox2.Text + "\n";
                richTextBox1.Text += "Apellido: " + textBox3.Text + "\n";
                richTextBox1.Text += "Productos y cantidades\n";
                richTextBox1.Text += "-------------------------------------------------\n";
                richTextBox1.Text += Venta.listarproductos(numFactura);
                richTextBox1.Text += "-------------------------------------------------\n";
                richTextBox1.Text += "Cajero: "+Venta.farmaceutico(numFactura);
                inicio = true;
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                MessageBox.Show("Se termino");

                
            }
            else
            {
                MessageBox.Show("No se agrego ningun producto");
            }

        }
    }
}
