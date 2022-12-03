using Capa_datos.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Reflection.PortableExecutable;
using System.Text;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Capa_datos
{
    public class Venta
    {
        public static string verint(string a, string var)
        {
            string sw = "";
            try
            {
                if (Convert.ToInt32(a) <= 0)
                    sw = var+" No es un entero mayor a 0; ";

            }
            catch(Exception)
            {
                sw = var+" No es un entero valido; ";
            }
            return sw;
        }
        public static string vervacio(string a, string var)
        {
            return (a == "") ? var+" Es vacio" : "";
        }
        public static List<string> autocompletar(int caso)
        {
            List<string> a;
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                
                comando.CommandText = caso==1 ? "select nit from cliente": "select d.nombreMedic as nom from medicamento m, detalleMed d where m.codDetalleMed=d.codDetalle";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                a = new List<string>();
                while (reader.Read())
                {
                    a.Add(reader[caso==1 ? "nit" : "nom"].ToString());
                }
                comando.Dispose();
                con.Close();
            }
            return a;

        }
        public static string listarproductos(int numfac)
        {
            string listado = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select d.nombreMedic,dv.cantidad from detalleMed d, medicamento m, detalleVenta dv where m.codDetalleMed=d.codDetalle AND m.codMedic=dv.codMedic AND dv.numFactura='"+numfac+"'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                while (reader.Read())
                {
                    listado+=reader["nombreMedic"].ToString()+"  "+ reader["cantidad"].ToString()+" (unid)\n";
                }
                comando.Dispose();
                con.Close();
            }
            return listado;
        }
        public static string farmaceutico(int fac)
        {
            string fecha = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select c.nombreFarm, c.apellidoFarm from farmaceutico c, factura f where c.ci=f.ci AND f.numFactura='" + fac + "'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    fecha = reader["nombreFarm"].ToString()+" "+ reader["apellidoFarm"].ToString()+"\n";
                }
                comando.Dispose();
                con.Close();
            }
            return fecha;
        }
        public static string reporte(DateTime ini, DateTime fin)
        {
            string reporte = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comandoa = new SqlCommand();
                //Ejemplo: select en tabla
                comandoa = new SqlCommand();
                comandoa.CommandType = CommandType.Text;
                comandoa.CommandText = "select d.nombreMedic, tmp.venta from detalleMed d, medicamento m, (select dv.codMedic, sum(dv.cantidad) as venta from factura f, detalleVenta dv where f.numFactura=dv.numFactura AND Convert(date,f.fecha)>='"+ini.ToString("yyyy-MM-dd")+"' AND Convert(date,f.fecha)<='"+fin.ToString("yyyy-MM-dd")+"' group by dv.codMedic) tmp where d.codDetalle=m.codDetalleMed AND m.codMedic=tmp.codMedic";
                comandoa.Connection = con;
                SqlDataReader readera = comandoa.ExecuteReader();

                while (readera.Read())
                {
                    reporte += readera["nombreMedic"].ToString() + " " + readera["venta"].ToString() + "\n";
                }
                comandoa.Dispose();
                con.Close();
            }
            return reporte;
        }
        public static DatosGrafico reporte2()
        {
            //string reporte = "";
            DatosGrafico a;
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();

                /*
                SqlCommand comandoa = new SqlCommand();
                //Ejemplo: select en tabla
                comandoa = new SqlCommand();
                comandoa.CommandType = CommandType.Text;
                */
                DataTable dt = new DataTable();
                SqlDataAdapter ad = new SqlDataAdapter("select top 3 DATENAME(dw,fecha) as dia, count(numFactura) as num from factura group by DATENAME(dw,fecha) order by num desc", con);
                /*
                comandoa.CommandText = "select top 3 DATENAME(dw,fecha) as dia, count(numFactura) as num from factura group by DATENAME(dw,fecha) order by num desc";
                comandoa.Connection = con;
                SqlDataReader readera = comandoa.ExecuteReader();
                while (readera.Read())
                */
                ad.Fill(dt);
                a = new DatosGrafico();
                a.pri = dt;
                
                for (int i=0;i<dt.Rows.Count;i++)
                {
                    //reporte += "**dia y cantidad de clientes**\n";
                    string dia = dt.Rows[i]["dia"].ToString();
                    //reporte += dia + " " + dt.Rows[i]["num"].ToString() + "\n";
                    //Ejemplo: select en tabla
                    con.Close();
                    con.Open();
                    DataTable dt2 = new DataTable();
                    SqlDataAdapter ad2 = new SqlDataAdapter("select top 2 d.nombreMedic as nom, tmp.sum as sum from medicamento m, detalleMed d, (select dv.codMedic, sum(dv.cantidad) as sum from factura f, detalleVenta dv where f.numFactura=dv.numFactura AND DATENAME(dw,f.fecha)='" + dia + "' group by dv.codMedic) tmp where d.codDetalle=m.codDetalleMed AND m.codMedic=tmp.codMedic order by sum desc", con);
                    ad2.Fill(dt2);
                    a.sec.Add(dt2);
                    /*
                    SqlCommand comandob = new SqlCommand();
                    comandob.CommandType = CommandType.Text;
                    comandob.CommandText = "select top 2 d.nombreMedic as nom, tmp.sum as sum from medicamento m, detalleMed d, (select dv.codMedic, sum(dv.cantidad) as sum from factura f, detalleVenta dv where f.numFactura=dv.numFactura AND DATENAME(dw,f.fecha)='" + dia + "' group by dv.codMedic) tmp where d.codDetalle=m.codDetalleMed AND m.codMedic=tmp.codMedic order by sum desc";

                    comandob.Connection = con;
                    SqlDataReader readerb = comandob.ExecuteReader();
                    reporte += "-----Medicamentos mas vendidos----\n";
                    while (readerb.Read())
                    {
                        reporte += readerb["nom"].ToString() + " " + readerb["sum"].ToString() + "\n";
                    }
                    comandob.Dispose();
                    //
                    */

                }
                //comandoa.Dispose();
                
                con.Close();
            }
            return a;
        }
        public static string fecha(int fac)
        {
            string fecha = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select fecha from factura where numFactura='" + fac + "'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();

                if (reader.Read())
                {
                    fecha = reader["fecha"].ToString();
                }
                comando.Dispose();
                con.Close();
            }
            return fecha;
        }
        public static bool buscarnit(string nit, out string nombre,out string apellido)
        {
            nombre = "";
            apellido = "";
            bool b = false;
            if (verint(nit, "n") == "")
            {
                string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
                using (SqlConnection con = new SqlConnection(cadenaDeConexion))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand();
                    //Ejemplo: select en tabla
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "select nombreCliente,apellidoCliente from cliente where nit='" + nit + "'";
                    comando.Connection = con;
                    SqlDataReader reader = comando.ExecuteReader();
                    
                    if (reader.Read())
                    {
                        nombre = reader["nombreCliente"].ToString();
                        apellido = reader["apellidoCliente"].ToString();
                        b = true;
                    }
                    comando.Dispose();
                    con.Close();
                }

                    
            }
            return b;
        }

        public static string vermedreg(string med, int fac,string cantidad)
        {
            string sw = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: select en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "select m.codMedic as cod from medicamento m, detalleMed d where m.codDetalleMed=d.codDetalle AND d.nombreMedic='" + med + "'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                string codMedic = "";
                if (reader.Read())
                {
                    codMedic = reader["cod"].ToString();
                    comando.Dispose();
                    con.Close();

                    con.Open();
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "select * from detalleVenta where numFactura='"+fac+"' AND codMedic='" + codMedic + "'";
                    comando.Connection = con;
                    reader = comando.ExecuteReader();
                    if (reader.Read())
                    {
                        comando.Dispose();
                        con.Close();
                        con.Open();
                        //SqlCommand comando = new SqlCommand();
                        //Ejemplo: insertar en tabla
                        comando = new SqlCommand();
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = "update detalleVenta set cantidad='" + cantidad + "' where numFactura='"+fac+"' AND codMedic='" + codMedic + "'";
                        comando.Connection = con;
                        comando.ExecuteNonQuery();
                        comando.Dispose();
                        con.Close();
                    }
                    else
                    {
                        comando.Dispose();
                        con.Close();
                        con.Open();
                        //SqlCommand comando = new SqlCommand();
                        //Ejemplo: insertar en tabla
                        comando = new SqlCommand();
                        comando.CommandType = CommandType.Text;
                        comando.CommandText = "insert into detalleVenta(numFactura,codMedic,cantidad) values('" + fac + "','" + codMedic + "','" + cantidad + "');";
                        comando.Connection = con;
                        comando.ExecuteNonQuery();
                        comando.Dispose();
                        con.Close();

                    }

                }
                else
                {
                    comando.Dispose();
                    con.Close();
                    sw = "No existe el medicamento; ";
                }


            }
            return sw;

        }
        public static string agregar(string ci,string  nit, string nombre, string apellido,string nombreMedic, string cantidad,out int id)
        {
            id = 0;
            var fecha = Convert.ToDateTime(DateTime.Now.ToString("F"));
            string msg = verint(nit,"Nit") +verint(cantidad,"Cantidad")+vervacio(nombreMedic,"Producto");
            if (msg == "")
            {

                string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
                using (SqlConnection con = new SqlConnection(cadenaDeConexion))
                {
                    con.Open();
                    SqlCommand comando = new SqlCommand();
                    //Ejemplo: select en tabla
                    comando = new SqlCommand();
                    comando.CommandType = CommandType.Text;
                    comando.CommandText = "select nit from cliente where nit='" + nit + "'";
                    comando.Connection = con;
                    SqlDataReader reader = comando.ExecuteReader();
                    if (!reader.Read())
                    {
                        string msg2 = vervacio(nombre,"Nombre cliente")+vervacio(apellido,"Apellido cliente");
                        if (msg2 == "")
                        {
                            comando.Dispose();
                            con.Close();
                            con.Open();
                            comando = new SqlCommand();
                            comando.CommandType = CommandType.Text;
                            comando.CommandText = "insert into cliente(nit,nombreCliente,apellidoCliente) values('" + nit + "','" + nombre + "','" + apellido + "');";
                            comando.Connection = con;
                            comando.ExecuteNonQuery();
                            comando.Dispose();
                            con.Close();
                        }
                        else
                            return msg2;
                    }
                    else
                    {
                        comando.Dispose();
                        con.Close();
                    }




                    

                    con.Open();
                    SqlCommand comando2 = new SqlCommand("guardar", con);
                    comando2.Parameters.AddWithValue("@nit", Convert.ToInt32(nit));
                    comando2.Parameters.AddWithValue("@ci", ci);
                    comando2.Parameters.AddWithValue("@fecha", Convert.ToDateTime(DateTime.Now.ToString("F")));
                    comando2.Parameters.Add("id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    comando2.CommandType = CommandType.StoredProcedure;
                    comando2.ExecuteNonQuery();
                    int numFactura = Convert.ToInt32(comando2.Parameters["id"].Value);
                    id = numFactura;
                    comando2.Dispose();
                    con.Close();


                    




                    /*
                    con.Open();
                    comando = new SqlCommand();
                    comando.CommandText = "insert into factura(fecha,ci,nit) values('"+fecha+"','" + ci + "','" + Convert.ToInt32(nit) + "');";
                    comando.Connection = con;
                    comando.ExecuteNonQuery();
                    comando.Dispose();
                    con.Close();
                    */


                    /*
                    con.Open();
                    //SqlCommand comando22 = new SqlCommand();
                    //Ejemplo: select en tabla
                    SqlCommand comando3 = new SqlCommand();

                    comando3.CommandType = CommandType.Text;
                    comando3.CommandText = "select numFactura from factura where fecha='" + fecha + "' AND ci='" + ci + "' AND nit='" + Convert.ToInt32(nit) + "'";
                    comando3.Connection = con;
                    reader = comando3.ExecuteReader();
                    int numFactura = 0;
                    if (reader.Read())
                    {
                        numFactura = Convert.ToInt32(reader["numFactura"]);
                        id = numFactura;

                    }

                    comando.Dispose();
                    con.Close();
                    */
                    msg = vermedreg(nombreMedic,numFactura,cantidad);
                }
            }
            return msg;

        }
        public static string agregar(string nombreMedic, string cantidad, int id)
        {
            string msg = vervacio(nombreMedic,"Producto") +verint(cantidad,"Cantidad");
            if (msg=="")
            {
                msg = vermedreg(nombreMedic, id, cantidad);
            }
            return msg;
        }
     }
}
