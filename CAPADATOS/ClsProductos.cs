using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Practica_TABLA.CAPADATOS
{
    internal class ClsProductos
    {
        private ConexionBD Conexion = new ConexionBD();
        private SqlCommand Comando = new SqlCommand();
        private SqlDataReader LeerFilas;
        //ATRIBUTOS
        private int idprod;
        private int idCategoria;
        private int idMarca;
        private string descripcion;
        private double precio;
        //metodos get y set
        public int _Idprod
        {
            get { return idprod; }
            set { idprod = value; }
        }
        public int _IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
        public int _IdMarca
        {
            get { return idMarca; }
            set { idMarca = value; }
        }
        public string _Descripcion
        {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public double _Precio
        {
            get { return precio; }
            set { precio = value; }
        }

        //METODOS /Funciones
        public DataTable ListarCategorias()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "ListarCategorias";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public DataTable ListarMarcas()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "ListarMarcas";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }

        internal void InsertarProductos()
        {
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idcategoria", idCategoria);
            Comando.Parameters.AddWithValue("@idmarca", idMarca);
            Comando.Parameters.AddWithValue("@descrip", descripcion);
            Comando.Parameters.AddWithValue("@prec", precio);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }

      

        internal void EditarProductos()
        {
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "update PRODUCTOS set IDCATEGORIA=" + idCategoria + ",IDMARCA=" + idMarca + ",DESCRIPCION='" + descripcion + "',PRECIO=" + precio + " WHERE IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }

        public DataTable ListarProductos()
        {
            DataTable Tabla = new DataTable();
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "ListarProductos";
            Comando.CommandType = CommandType.StoredProcedure;
            LeerFilas = Comando.ExecuteReader();
            Tabla.Load(LeerFilas);
            LeerFilas.Close();
            Conexion.CerrarConexion();
            return Tabla;
        }
        public void EliminarProducto()
        {
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "delete PRODUCTOS where IDPROD=" + idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }
        public void InsertarProductos(int idCategoria, int idMarca, double precio, string decripcion)
        {
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText = "AgregarProducto";
            Comando.CommandType = CommandType.StoredProcedure;
            Comando.Parameters.AddWithValue("@idcategoria", idCategoria);
            Comando.Parameters.AddWithValue("@idmarca", idMarca);
            Comando.Parameters.AddWithValue("@descrip", descripcion);
            Comando.Parameters.AddWithValue("@prec", precio);
            Comando.ExecuteNonQuery();
            Comando.Parameters.Clear();
        }
        public void EditarProductos(int idprod, int idCategoria, int idMarca, double precio, string decripcion)        
            {
            Comando.Connection = Conexion.Abrirconexion();
            Comando.CommandText ="update PRODUCTOS set IDCATEGORIA="+idCategoria+",IDMARCA="+idMarca+",DESCRIPCION='"+descripcion+"',PRECIO="+precio+"WHERE IDPROD="+idprod;
            Comando.CommandType = CommandType.Text;
            Comando.ExecuteNonQuery();
            Conexion.CerrarConexion();
        }       

    }
}
