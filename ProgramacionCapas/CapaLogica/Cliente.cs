using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace CapaLogica
{

    public class Cliente
    {

        MRP_BD cnn = new MRP_BD("", "", "", "");
        private string nombreCliente;
        private string direccionCliente;
        private int telefonoCliente;
        private int codigoCliente;


        //Constructor vacío
        public Cliente()
        {

        }

        //Constructor con parámetros
        public Cliente(string nombre, string direccion, int telefono)
        {
            nombreCliente = nombre;
            direccionCliente = direccion;
            telefonoCliente = telefono;
        }


        //Métodos setter and Getter
        #region Metodos Get y Set
        public int Codigo { get { return codigoCliente; } set { codigoCliente = value; } }
        public string Nombre { get {  return nombreCliente; } set { nombreCliente = value; } }
        public string Direccion { get { return direccionCliente; } set { direccionCliente = value; } }
        public int Telefono { get { return telefonoCliente; } set { telefonoCliente = value; } }

        #endregion
        //insertar
        public void Insertar_Cliente(Cliente Var_Cliente)
        {
            String cadena = "Insert into Cliente(NOMBRE, DIRECCION, TELEFONO) values('" + Var_Cliente.Nombre + "','" + Var_Cliente.Direccion + "','" + Var_Cliente.Telefono + "')";
            cnn.insertSQL(cadena);
            MessageBox.Show("Usuario Registrado");
        }

        //eliminar
        public void Eliminar_Cliente(int codigoCliente)
        {
            String cadena = "delete Cliente where CODIGO="+ codigoCliente;
            cnn.deleteSQL(cadena);
            MessageBox.Show("Registro eliminado");
        }

        //actualizar
        public void Actualizar_Cliente(Cliente Var_Cliente)
        {

            String cadena = "update Cliente set NOMBRE='"+Var_Cliente.Nombre +"', DIRECCION='"+ Var_Cliente.Direccion +"', TELEFONO='"+ Var_Cliente.Telefono + "' where CODIGO=" + Var_Cliente.Codigo;
            cnn.updateSQL(cadena);
            MessageBox.Show("Registro Actualizado");
        }        
        //'consulta
        public List<Cliente> Listado_Clientes()
        {
            List<Cliente> lista = new List<Cliente>();
            DataTable tablas = cnn.getSQL("select * from Cliente");
            Cliente cl; 
            foreach (DataRow fila in tablas.Rows)
            {
                cl = new Cliente();
                cl.Codigo= Convert.ToInt32( fila["CODIGO"].ToString());
                cl.Nombre = fila["NOMBRE"].ToString();
                cl.Direccion = fila["DIRECCION"].ToString();
                cl.Telefono = Convert.ToInt32( fila["TELEFONO"].ToString());
                lista.Add(cl);
            }           
            
            return lista;
        }
        



    }


}
