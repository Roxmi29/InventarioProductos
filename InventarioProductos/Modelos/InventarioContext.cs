using System.Data.Entity;

namespace InventarioProductos.Modelos
{
    public class InventarioContext : DbContext
    {

        public InventarioContext() : base("name=InventarioDB") { }

        public DbSet<Producto> Productos { get; set; }
    }
}