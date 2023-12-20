using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Examen3_Monserrat.Clases
{
    public class Formulario
    {
    
        public int Numero_de_encuesta { get; set; }
        public string Nombre_de_participante { get; set; }
        public DateTime Fecha_de_nacimiento { get; set; }
        public string Correo_electronico { get; set; }
         public string Partido_Politico { get; set; }

        public Formulario() { }


        public static int Agregar( string Nombre_de_participante, string Fecha_de_nacimiento, string Correo_electronico, string Partido_Politico)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DBConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("sp_ingreso_encuesta", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    int Numero_de_encuesta=0;
                    Numero_de_encuesta = Numero_de_encuesta + 1;
                    cmd.Parameters.Add(new SqlParameter("@Numero_de_encuesta", Numero_de_encuesta));
                    cmd.Parameters.Add(new SqlParameter("@Nombre_de_participante", Nombre_de_participante));
                    cmd.Parameters.Add(new SqlParameter("@Fecha_de_nacimiento", Fecha_de_nacimiento));
                    cmd.Parameters.Add(new SqlParameter("@Correo_electronico", Correo_electronico));
                    cmd.Parameters.Add(new SqlParameter("@Partido_Politico", Partido_Politico));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;

        }

        
    }
}