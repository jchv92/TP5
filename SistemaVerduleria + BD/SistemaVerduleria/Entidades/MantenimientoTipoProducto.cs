using System;

namespace Entidades
{
    /// Representa un tipo de producto para operaciones de mantenimiento.
    public class MantenimientoTipoProducto
    {
        // Nombre del producto.
        public String Nombre { get; set; }

        // Categoría o tipo del producto.
        public String TipoProducto { get; set; }

        // Descripción del tipo de precio aplicable.
        public String TipoPrecio { get; set; }

        // Cantidad disponible del producto.
        public int Cantidad { get; set; }

        // Precio unitario del producto.
        public float Precio { get; set; }
    }
}
