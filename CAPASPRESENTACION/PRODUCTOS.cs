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
    public partial class PRODUCTOS : Form
    {       
        public PRODUCTOS()
        {
            InitializeComponent();
        }
        ClsProductos objproducto = new ClsProductos();
        string Operacion = "Insertar";
        string idprod;       
        private void PRODUCTOS_Load(object sender, EventArgs e)
        {
            ListarCategorias();
            ListarMarcas();
            ListarProductos();
        }
        private void LimpiarFormulario()
        {
            txtdescripcion.Clear();
            txtPrecio.Clear();
        }
        private void ListarCategorias()
        {
            ClsProductos objProd = new ClsProductos();
            cmbCategoria.DataSource = objProd.ListarCategorias();
            cmbCategoria.DisplayMember = "CATEGORIA";
            cmbCategoria.ValueMember = "IDCATEG";
        }
        private void ListarMarcas()
        {
            ClsProductos objPro = new ClsProductos();
            CmbMarca.DataSource = objPro.ListarMarcas();
            CmbMarca.DisplayMember = "MARCA";
            CmbMarca.ValueMember = "IDMARCA";
        }     

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Operacion == "Insertar")
            {
                objproducto._IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                objproducto._IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto._Descripcion = txtdescripcion.Text;
                objproducto._Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto.InsertarProductos();
                MessageBox.Show("Se inserto correctamente");
            }
            else if (Operacion == "Editar")
            {
                objproducto._IdCategoria = Convert.ToInt32(cmbCategoria.SelectedValue);
                objproducto._IdMarca = Convert.ToInt32(CmbMarca.SelectedValue);
                objproducto._Descripcion = txtdescripcion.Text;
                objproducto._Precio = Convert.ToDouble(txtPrecio.Text);
                objproducto._Idprod = Convert.ToInt32(idprod);
                objproducto.EditarProductos();
                Operacion = "Insertar";
                MessageBox.Show("Se edito correctamente");
            }
            ListarProductos();
            //Limpiar texboxs
            LimpiarFormulario();
        }
        private void ListarProductos()
        {
            ClsProductos objPro = new ClsProductos();
            dataGridView1.DataSource = objPro.ListarProductos();

        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                Operacion = "Editar";
                cmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                CmbMarca.Text=dataGridView1.CurrentRow.Cells[2].Value.ToString();
                txtdescripcion.Text=dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                idprod=dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
            }
            else
                MessageBox.Show("debe Seleccionar una fila");
        }
        private void btnEditarf2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                 MantenimientoProducto frm = new MantenimientoProducto();                             
                //frm.Operacion = "Editar";
                frm.ListarCategorias();
                frm.ListarMarcas();

                frm.idprod = dataGridView1.CurrentRow.Cells["ID"].Value.ToString();
                frm.cmbCategoria.Text = dataGridView1.CurrentRow.Cells["CATEGORIA"].Value.ToString();
                frm.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                frm.txtdescripcion.Text = dataGridView1.CurrentRow.Cells["DESCRIPCION"].Value.ToString();
                frm.txtPrecio.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();                
                frm.ShowDialog();
                
            }
            else
                MessageBox.Show("debe Seleccionar una fila");
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                objproducto._Idprod = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
                objproducto.EliminarProducto();
                MessageBox.Show("Se elimino satisfactoriamente");
                ListarProductos();
            }
            else
                MessageBox.Show("Seleccione una fila");
        }
    }
}
