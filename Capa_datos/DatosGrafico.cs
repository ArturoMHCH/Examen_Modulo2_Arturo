using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa_datos
{
    public class DatosGrafico
    {
        public DataTable pri { get; set; }
        public List<DataTable> sec { get; set; }
        public DatosGrafico()
        {
            pri = new DataTable();
            sec = new List<DataTable>();
        }
    }
}
