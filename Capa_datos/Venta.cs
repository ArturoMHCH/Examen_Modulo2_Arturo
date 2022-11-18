using Capa_datos.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows;
namespace Capa_datos
{
    public class Venta
    {
        public static string agregar(string fecha, string ci,int  nit, string nombre, string apellido,string nombreMedic, int cantidad)
        {
            string sw = "";
            string cod = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();

                SqlCommand comando0 = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando0 = new SqlCommand();
                comando0.CommandType = CommandType.Text;
                comando0.CommandText = "insert into cliente(nit,nombreCliente,apellidoCliente) values('" + nit + "','" + nombre + "','" + apellido + "');";
                comando0.Connection = con;
                comando0.ExecuteNonQuery();
                comando0.Dispose();

                con.Close();
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into factura(fecha,ci,nit) values('" + fecha + "','" + ci + "','" + nit + "');";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                con.Close();
                con.Open();
                SqlCommand comando2 = new SqlCommand();
                //Ejemplo: select en tabla
                comando2 = new SqlCommand();
                comando2.CommandType = CommandType.Text;
                comando2.CommandText = "select m.codMedic as cod from medicamento m, detalleMed d where m.codDetalleMed=d.codDetalle AND d.nombreMedic='" + nombreMedic+"'";
                comando2.Connection = con;
                SqlDataReader reader = comando2.ExecuteReader();
                string codMedic = "";
                if (reader.Read())
                {
                    codMedic = reader["cod"].ToString();

                }
                
                comando2.Dispose();
                con.Close();
                con.Open();
                SqlCommand comando3 = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando3 = new SqlCommand();
                comando3.CommandType = CommandType.Text;
                comando3.CommandText = "insert into detalleVenta(numFactura,codMedic,cantidad) values(SCOPE_IDENTITY(),'" + codMedic + "','" + cantidad + "');";
                comando3.Connection = con;
                comando3.ExecuteNonQuery();
                comando3.Dispose();
                con.Close();
                sw = "Estado: Venta insertada";
            }
            return sw;

        }
        public static string agregar(string nombreMedic, int cantidad)
        {
            string sw = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando2 = new SqlCommand();
                //Ejemplo: select en tabla
                comando2 = new SqlCommand();
                comando2.CommandType = CommandType.Text;
                comando2.CommandText = "select m.codMedic as cod from medicamento m, detalleMed d where m.codDetalleMed=d.codDetalle AND d.nombreMedic='" + nombreMedic + "'";
                comando2.Connection = con;
                SqlDataReader reader2 = comando2.ExecuteReader();
                string codMedic = "";
                if (reader2.Read())
                {
                    codMedic = reader2["cod"].ToString();

                }
                comando2.Dispose();

                SqlCommand comando3 = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando3 = new SqlCommand();
                comando3.CommandType = CommandType.Text;
                comando3.CommandText = "insert into detalleVenta(numFactura,codMedic,cantidad) values(SCOPE_IDENTITY(),'" + codMedic + "','" + cantidad + "');";
                comando3.Connection = con;
                comando3.ExecuteNonQuery();
                comando3.Dispose();

            }
            return sw;
        }
     }
}
