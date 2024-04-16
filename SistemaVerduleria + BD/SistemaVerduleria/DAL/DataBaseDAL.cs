using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    class DataBaseDAL
    {
        public SqlConnection Conexion { get; set; }
        public SqlConnection AbreConexionSQL()
        {   
            // Cambio en la variable ser por la variable Servidor
            string server = "DESKTOP-3TAVB1D\\SQLEXPRESS";
            string database = "SistemaVerduleria";
            // Cambio en la variable us por la variable usuario y pw por la variable password
            string user = "sa";
            string password = "Welcome123*";
            
            // Cadena de Conexión
            String connection = $"Data source={server}; Initial Catalog={database}; User Id={user}; Password={password}; Integrated Security=false; TrustServerCertificate=true;"; 

            
            // Validacion de pruebas para comprar que la conexión funciona
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connection);
                builder.ConnectTimeout = 30;  // Establece el tiempo de espera de la conexión según tus necesidades

                SqlConnection sqlConexion = new SqlConnection(builder.ConnectionString);

                sqlConexion.Open();

                if (sqlConexion.State != ConnectionState.Open)
                {
                    throw new Exception("No fue posible registrar el producto, intente nuevamente. [Error de conexión]");
                }

                return sqlConexion;
            }
            catch (Exception ex)
            {
                ex.Source += " Conexion " + connection;
                throw ex;
            }
        }


        // Metodo de lectura de la base de datos en SQL y lo convierte a una tabla
        public DataSet LecturaDatos(SqlCommand sqlCommand, String tabla)
        {
            // Creacion de variable DataSet
            DataSet dsTabla = new DataSet();
            try
            {
                using (SqlDataAdapter adaptador = new SqlDataAdapter(sqlCommand))
                {
                    sqlCommand.Connection = AbreConexionSQL();
                    dsTabla = new DataSet();
                    adaptador.Fill(dsTabla, tabla);
                }
                return dsTabla;
            }
            catch (Exception ex)
            {
                ex.Source += " SQL: " + sqlCommand.CommandText.ToString();
                throw ex;
            }
            finally
            {
                Dispose();
            }

        }


        // Metodo de insercion de la base de datos en SQL
        public int InsercionDatos(SqlCommand sqlCommand)
        {
            // Conteo de registros que se modificaron en la base de datos.
            int registrosafectados = 0;
            try
            {

                sqlCommand.Connection = AbreConexionSQL();

                registrosafectados = sqlCommand.ExecuteNonQuery();

                return registrosafectados;

            }
            catch (Exception ex)
            {
                ex.Source += " SQL: " + sqlCommand.CommandText.ToString();
                throw ex;
            }
            finally
            {
                Dispose();
            }
        }

        // Metodo de limpieza del codigo y sis recursos para finalizar la conexion
        public void Dispose()
        {
            if (Conexion != null)
                Conexion.Close();
        }

    }
}