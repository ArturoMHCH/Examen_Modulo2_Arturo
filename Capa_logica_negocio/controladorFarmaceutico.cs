using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Capa_datos;
using Capa_datos.Modelos;
using Microsoft.Data.SqlClient;

namespace Capa_logica_negocio
{
    public class controladorFarmaceutico
    {
        public static string buscar(int ci, string password)
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
                comando.CommandText = "SELECT * FROM farmaceutico WHERE ci='"+ci+"' contrasena='"+ci+"'";
                comando.Connection = con;
                SqlDataReader reader = comando.ExecuteReader();
                string aux = "";
                if(reader.Read())
                {
                    sw= reader["cargo"].ToString();

                }
                comando.Dispose();

            }
            return sw;

        }

    }
}
