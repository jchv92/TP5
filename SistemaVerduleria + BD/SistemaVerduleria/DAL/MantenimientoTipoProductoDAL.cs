using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace DAL
{
    public class MantenimientoTipoProductoDAL
    {
        /// <summary>
        /// Almacena un producto en la base de datos
        /// </summary>
        /// <param name="Nombre"> Nombre del producto</param>
        /// <param name="TipoProducto"> Tipo de producto </param>
        /// <param name="TipoPrecio"> Tipo de precio</param>
        /// <param name="Cantidad"> Cantidad de productos </param>
        /// <param name="Precio">Precio de productos</param>
        public void InsertaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {
            //Instancia la base de datos
            DataBaseDAL database = new DataBaseDAL();

            //Comando de prodedimiento almacenado en la base de datos para registrar un producto
            SqlCommand comando = new SqlCommand("SP_RegistraTipoProducto");

            //Valores del producto para el procedimiento almacenado
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            comando.Parameters.AddWithValue("@TipoPrecio", TipoPrecio);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Precio", Precio);

            //Se ejectua el comando mediante el metodo insercion de datos
            database.InsercionDatos(comando);
        }

        /// <summary>
        /// Actualiza un tipo de producto en la base de datos
        /// </summary>
        /// <param name="Nombre"> Nombre del producto a actualizar</param>
        /// <param name="TipoProducto">Tipo de producto nuevo valor</param>
        /// <param name="TipoPrecio"></param>
        /// <param name="Cantidad"></param>
        /// <param name="Precio"></param>
        public void ActualizaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {

            //Instancia la base de datos
            DataBaseDAL database = new DataBaseDAL();

            //Comando de prodedimiento almacenado en la base de datos para actualizar un tipo de producto
            SqlCommand comando = new SqlCommand("SP_ActualizaTipoProducto");
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@TipoProducto", TipoProducto);
            comando.Parameters.AddWithValue("@TipoPrecio", TipoPrecio);
            comando.Parameters.AddWithValue("@Cantidad", Cantidad);
            comando.Parameters.AddWithValue("@Precio", Precio);

            //Se ejectua el comando mediante el metodo insercion de datos
            database.InsercionDatos(comando);
        }

        /// <summary>
        /// Realiza la consulta a la base de datos para validar si un producto existe
        /// </summary>
        /// <param name="Nombre">Nombre de producto a verificar en la base de datos</param>
        /// <returns> retorna verdadero solo si el producto existe en la base de datos</returns>
        public bool ValidaExistenciaProducto(string Nombre)
        {

            //Instancia la base de datos
            DataBaseDAL database = new DataBaseDAL();
            //Comando de prodedimiento almacenado en la base de datos para la consulta de la existencia de un producto
            SqlCommand comando = new SqlCommand("SP_ConsultaExistenciaProducto");
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);

            //ejecuta el comando en la base de datos y lo guarda en un data set
            DataSet datasetProductoExistente = database.LecturaDatos(comando, "[T_Productos]");

            /*
             * retorna falso si el valor no existe
             * retorna verdadero si el valor existe
             */
            if (datasetProductoExistente.Tables[0].Rows.Count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
