using Capa_datos.Modelos;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Capa_datos
{
    public class Farmaceutico2
    {
        public static string buscar(string ci, string password)
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
                comando.CommandText = "SELECT * FROM farmaceutico WHERE ci='" + ci + "' AND contrasena='" + password + "'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.Read())
                {
                    sw = reader["cargo"].ToString();

                }
                comando.Dispose();

            }
            return sw;

        }
        public static string agregar(farmaceutico dato)
        {
            string sw= "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "insert into farmaceutico(ci,nombreFarm,apellidoFarm,contrasena,cargo) values('"+dato.ci+"','"+dato.nombreFarm+"','"+dato.apellidoFarm+"','"+dato.contrasena+"','"+dato.cargo+"');";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                sw = "Estado: Registro insertado";
            }
            return sw;

        }
        public static string modificar(farmaceutico dato)
        {
            string sw = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: insertar en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "update farmaceutico SET nombreFarm='"+dato.nombreFarm+"',apellidoFarm='"+dato.apellidoFarm+"',contrasena='"+dato.contrasena+"',cargo='"+dato.cargo+"' WHERE ci='"+dato.ci+"';";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                sw = "Estado: Registro modificado";
            }
            return sw;

        }
        public static string eliminar(string ci)
        {
            string sw = "";
            string cadenaDeConexion = @"Server=LAPTOP-R4IGAAED\SQLEXPRESS;DataBase=farmacia;User=pepe;Password=pepe";
            using (SqlConnection con = new SqlConnection(cadenaDeConexion))
            {
                con.Open();
                SqlCommand comando = new SqlCommand();
                //Ejemplo: delete en tabla
                comando = new SqlCommand();
                comando.CommandType = CommandType.Text;
                comando.CommandText = "DELETE FROM farmaceutico WHERE ci = '"+ci+"';";
                comando.Connection = con;
                comando.ExecuteNonQuery();
                comando.Dispose();
                sw = "Estado: Registro eliminado";
            }
            return sw;



        }
    }
}
