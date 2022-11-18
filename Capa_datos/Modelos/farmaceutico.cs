using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace Capa_datos.Modelos
{
    public class farmaceutico
    {
        public int ci { get; set; }
        public string nombreFarm { get; set; }
        public string apellidoFarm { get; set; }
        public DateTime fecha_nac { get; set; }
        public string contrasena { get; set; }
        public char cargo { get; set; }

    }
}
