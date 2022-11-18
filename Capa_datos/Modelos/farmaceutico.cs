using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using System.Text;

namespace Capa_datos.Modelos
{
    public class farmaceutico
    {
        public string ci { get; set; }
        public string nombreFarm { get; set; }
        public string apellidoFarm { get; set; }
        public string fecha_nac { get; set; }
        public string contrasena { get; set; }
        public string cargo { get; set; }

    }
}
