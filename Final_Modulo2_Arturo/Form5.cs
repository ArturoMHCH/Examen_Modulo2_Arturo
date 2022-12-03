using Capa_datos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows.Forms;

namespace Final_Modulo2_Arturo
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DatosGrafico a2 = Venta.reporte2();
            Graphics glosary;
            glosary = pictureBox1.CreateGraphics();
            SolidBrush pinta = new SolidBrush(Color.Black);
            int x = 0;
            for (int i = 0; i < a2.pri.Rows.Count; i++)
            {
            int y = Convert.ToInt32(a2.pri.Rows[i]["num"]);
            glosary.FillRectangle(pinta, ((i+1)*10), 10, 5, y*10);
            }
        }
    }
}
