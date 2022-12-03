using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Final_Modulo2_Arturo
{
    public class Rectangulo
    {
        int x, y;
        int width, height;
        public Rectangulo(int x, int y, int width, int height)
        {
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
        public void mostrar(Graphics area, SolidBrush pinta)
        {
            area.FillRectangle(pinta, x, y, width, height);
        }
    }
}
