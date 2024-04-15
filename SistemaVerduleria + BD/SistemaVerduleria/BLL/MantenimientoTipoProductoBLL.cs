using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL;  // Acceso a datos.

namespace BLL
{
    // Gestiona tipos de producto.
    public class MantenimientoTipoProductoBLL
    {
        // Inserta un nuevo producto.
        public void InsertaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {
            MantenimientoTipoProductoDAL TipoProductoDAL = new MantenimientoTipoProductoDAL(); // Instancia DAL.
            TipoProductoDAL.InsertaTipoProducto(Nombre, TipoProducto, TipoPrecio, Cantidad, Precio); // Inserta producto.
        }

        // Actualiza un producto existente.
        public void ActualizaTipoProducto(string Nombre, string TipoProducto, string TipoPrecio, int Cantidad, decimal Precio)
        {
            MantenimientoTipoProductoDAL TipoProductoDAL = new MantenimientoTipoProductoDAL(); // Instancia DAL.
            TipoProductoDAL.ActualizaTipoProducto(Nombre, TipoProducto, TipoPrecio, Cantidad, Precio); // Actualiza producto.
        }

        // Verifica la existencia de un producto.
        public bool ValidaExistenciaProducto(string nombre)
        {
            MantenimientoTipoProductoDAL Producto = new MantenimientoTipoProductoDAL(); // Instancia DAL.
            return Producto.ValidaExistenciaProducto(nombre); // Retorna existencia.
        }
    }
}
