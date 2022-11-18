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
                string aux = "";
                if (reader.Read())
                {
                    sw = reader["cargo"].ToString();

                }
                comando.Dispose();

            }
            return sw;

        }
    }
}
