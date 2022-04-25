using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Practica_TABLA.CAPADATOS
{
    internal class ConexionBD                         
    {
        static private string CadenaConexion = "Data Source=desktop-kc8bsdt;Initial Catalog=PRACTICA_TABLAS;User ID=sa;Password=sa";
        private SqlConnection Conexion = new SqlConnection(CadenaConexion);
        
        public SqlConnection Abrirconexion()
        {
            if (Conexion.State==ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
        public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Open)
                Conexion.Close();
            return Conexion;
        }
    }

}
