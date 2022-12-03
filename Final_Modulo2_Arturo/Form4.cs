using Capa_datos;
using Capa_datos.Modelos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        public void dibujar()
        {
            DatosGrafico a2 = Venta.reporte2();
            Graphics h;
            h = pictureBox1.CreateGraphics();
            SolidBrush pinta = new SolidBrush(Color.Black);
            for (int i = 0; i < a2.pri.Rows.Count; i++)
            {
                int y = Convert.ToInt32(a2.pri.Rows[0]["num"]);

                h.FillRectangle(pinta, ((i + 1) * 10), 10, 5, y * 10);
            }
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

        private void button4_Click(object sender, EventArgs e)
        {
            if(dateTimePicker1.Value<= dateTimePicker2.Value)
            {
                string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd HH:mm:ss.fff");
                MessageBox.Show(fecha);
                richTextBox1.Text= Venta.reporte(dateTimePicker1.Value, dateTimePicker2.Value);
            }
            else
            {
                MessageBox.Show("El inicio no es menor o igual al final");
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DatosGrafico a2 = Venta.reporte2();
            Graphics glosary;
            glosary = pictureBox1.CreateGraphics();
            SolidBrush pinta = new SolidBrush(Color.Black);
            Pen lapiz = new Pen(Color.Blue);
            for (int i = 0; i < a2.pri.Rows.Count; i++)
            {
                int y = Convert.ToInt32(a2.pri.Rows[i]["num"]);
                glosary.FillRectangle(pinta, ((i + 1) * 60), 200-(y*10), 60, y * 10);

                Font font = new Font("Arial",7);
                glosary.DrawString(a2.pri.Rows[i]["num"].ToString()+" "+a2.pri.Rows[i]["dia"].ToString(),font,Brushes.Green, ((i + 1) * 60),200+10);
                int var = 0;
                for (int j = 0; j < a2.sec[i].Rows.Count; j++)
                {
                    int y2 = Convert.ToInt32(a2.sec[i].Rows[j]["sum"]);
                    
                    glosary.DrawLine(lapiz, ((i + 1) * 60), 200-(y2*10), ((i + 1) * 60)+60, 200-(y2 * 10));
                    
                    
                    string a = y2.ToString();
                    if (y2 == var)
                        glosary.DrawString(y2.ToString() + " " + a2.sec[i].Rows[j]["nom"].ToString(), font, Brushes.Blue, ((i + 1) * 60), 200 - (y2 * 10) - 24);
                    else
                        glosary.DrawString(y2.ToString() + " " + a2.sec[i].Rows[j]["nom"].ToString(), font, Brushes.Blue, ((i + 1) * 60), 200 - (y2 * 10) - 12);
                    var = y2;

                }
            }
            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}
