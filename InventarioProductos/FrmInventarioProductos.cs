using InventarioProductos.Modelos;
using System;
using System.Windows.Forms;

namespace InventarioProductos
{
    public partial class FrmInventarioProductos : Form
    {

        public int? ProductoId { get; set; }

        public FrmInventarioProductos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var db = new InventarioContext())
            {
                if (ProductoId == null) 
                {
                    var producto = new Producto
                    {
                        Nombre = textNombre.Text,
                        Precio = decimal.Parse(textPrecio.Text),
                        Stock = int.Parse(textStock.Text)
                    };

                    db.Productos.Add(producto);
                    MessageBox.Show("Producto guardado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                {
                    var producto = db.Productos.Find(ProductoId);
                    if (producto != null)
                    {
                        producto.Nombre = textNombre.Text;
                        producto.Precio = decimal.Parse(textPrecio.Text);
                        producto.Stock = int.Parse(textStock.Text);

                        MessageBox.Show("Producto actualizado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                db.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}