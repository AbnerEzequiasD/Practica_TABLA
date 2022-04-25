using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Practica_TABLA.CAPADATOS;

namespace Practica_TABLA.CAPASPRESENTACION
{
    public partial class MantenimientoProducto : Form
    {
        public MantenimientoProducto()
        {
            InitializeComponent();
        }
        ClsProductos objproducto = new ClsProductos();
        public string Operacion = "Insertar";
        public string idprod;
        public void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            cmbCategoria.DataSource = objProd.ListarCategorias();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEG";
        }
        public void ListarMarcas()
        {
            ClsProductos objProd = new ClsProductos();
            CmbMarca.DataSource = objProd.ListarMarcas();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMARCA";
        }
        private void MantenimientoProducto_Load(object sender, EventArgs e)
        {
            //ListarCategorias();
            //ListarMarcas();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto.InsertarProductos(Convert.ToInt32(cmbCategoria.SelectedValue),
                    Convert.ToInt32(CmbMarca.SelectedValue),
                    Convert.ToDouble(txtPrecio.Text),
                    txtdescripcion.Text);
                MessageBox.Show("insertado correctamente");

            }
            else if (Operacion == "Editar")
            {
                objproducto.EditarProductos(Convert.ToInt32(idprod),
                    Convert.ToInt32(cmbCategoria.SelectedValue),
                    Convert.ToInt32(CmbMarca.SelectedValue),
                    Convert.ToDouble(txtPrecio.Text),
                    txtdescripcion.Text);
                MessageBox.Show("Se edito Correctamente");
                this.Close();
            }
        }
        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
