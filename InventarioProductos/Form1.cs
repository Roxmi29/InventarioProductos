using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using InventarioProductos.Modelos;

namespace InventarioProductos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (var db = new InventarioContext())
            {
                dataGridView1.DataSource = db.Productos.ToList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            FrmInventarioProductos frm = new FrmInventarioProductos();
            frm.ShowDialog();

            using (var db = new InventarioContext())
            {
                dataGridView1.DataSource = db.Productos.ToList();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                using (var db = new InventarioContext())
                {
                    var producto = db.Productos.Find(id);
                    if (producto != null)
                    {
                        FrmInventarioProductos frm = new FrmInventarioProductos();


                        frm.ProductoId = producto.Id;


                        frm.textNombre.Text = producto.Nombre;
                        frm.textPrecio.Text = producto.Precio.ToString();
                        frm.textStock.Text = producto.Stock.ToString();

                        if (frm.ShowDialog() == DialogResult.OK)
                        {

                        }
                    }
                }

                using (var db = new InventarioContext())
                {
                    dataGridView1.DataSource = db.Productos.ToList();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                int id = (int)dataGridView1.CurrentRow.Cells["Id"].Value;

                var confirm = MessageBox.Show("¿Seguro que deseas eliminar este producto?",
                                              "Confirmar eliminación",
                                              MessageBoxButtons.YesNo,
                                              MessageBoxIcon.Warning);

                if (confirm == DialogResult.Yes)
                {
                    using (var db = new InventarioContext())
                    {
                        var producto = db.Productos.Find(id);
                        if (producto != null)
                        {
                            db.Productos.Remove(producto);
                            db.SaveChanges();
                        }
                    }

                    using (var db = new InventarioContext())
                    {
                        dataGridView1.DataSource = db.Productos.ToList();
                    }
                }
            }
        }
    }
}

