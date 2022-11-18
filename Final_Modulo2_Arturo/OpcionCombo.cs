using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Final_Modulo2_Arturo
{
    public class OpcionCombo
    {
        public string Texto { get; set; }
        public string Value { get; set; }
        public static void iniciar_combo(string[] valores, string[] texto, ComboBox combo)
        {
            int lo = valores.Length;
            combo.DisplayMember = "Texto";
            combo.ValueMember = "Value";
            for (int i = 0; i < lo; i++)
            {
                combo.Items.Add(new OpcionCombo() { Texto = texto[i], Value = valores[i] });

            }

            combo.SelectedIndex = 0;
        }

    }
}
