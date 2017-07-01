using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

    public class MRP_BD
    {

        private String Servidor = null;
        private String B_Datos = null;
        private String Usuario = null;
        private String Passs = null;
        private SqlCommand comando;
        SqlConnection conexion = null;     
      
        public MRP_BD(String User, String Pass, String Database, String Server)
        {      
            Servidor = Server;
            B_Datos = Database;
            Usuario = User;
            Passs = Pass;
            //String cadena = "Data Source= " + Servidor + "; Initial Catalog=" + B_Datos + "; User Id=" + Usuario + "; Password=" + Passs + ";";
            String cadena = @"Data Source=.\SQL; Initial Catalog=BD_PRUEBA; User Id=canel; Password=canel;";
            conexion = new SqlConnection(cadena);
        }

        public void insertSQL(String QInsert)
        {

            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }
            comando = new SqlCommand(QInsert, conexion);

            SqlDataAdapter adap = new SqlDataAdapter();
            adap.InsertCommand = comando.Connection.CreateCommand();
            adap.InsertCommand.CommandText = QInsert;
            adap.InsertCommand.ExecuteNonQuery();

            if (conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
            }
        }
        public void deleteSQL(String QInsert, SqlTransaction tran = null)
        {

            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }

            comando = new SqlCommand(QInsert, conexion);

            SqlDataAdapter adap = new SqlDataAdapter();
            adap.DeleteCommand = comando.Connection.CreateCommand();
            adap.DeleteCommand.CommandText = QInsert;
            adap.DeleteCommand.ExecuteNonQuery();

            if (conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
            }
        }
        public void updateSQL(String QInsert, SqlTransaction tran = null)
        {

            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }
            comando = new SqlCommand(QInsert, conexion);


            SqlDataAdapter adap = new SqlDataAdapter();

            adap.UpdateCommand = comando.Connection.CreateCommand();
            adap.UpdateCommand.CommandText = QInsert;
            adap.UpdateCommand.ExecuteNonQuery();

            if (conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
            }
        }

        public DataTable getSQL(String QConsulta)
        {
            DataTable dt = new DataTable();
            if (conexion.State != System.Data.ConnectionState.Open)
            {
                conexion.Open();
            }
            comando = new SqlCommand(QConsulta, conexion);
            SqlDataAdapter adap = new SqlDataAdapter();
            adap.SelectCommand = comando;
            adap.Fill(dt);
            if (conexion.State != System.Data.ConnectionState.Closed)
            {
                conexion.Close();
            }
            return dt;
        }

    }
