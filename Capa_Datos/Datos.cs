using System;
//Librerias
using System.Data;
using System.Data.SqlClient;
using Capa_Entidades;

namespace Capa_Datos
{
  public  class Datos
    {
        readonly Acceso _conexion;
        SqlCommand _comando;
        SqlDataAdapter _adaptador;
        DataTable _tabla;
        SqlDataReader _reader;

        public Datos() 
        {
           
            _conexion = new Acceso();
        }

        #region Insertar
        public int InsertarCli(Entidades enti)
        {
            if (enti == null) throw new ArgumentNullException("enti");
            using(_comando = new SqlCommand())
            {
                const string query = "INSERT INTO CLIENTE(CEDULA,NOMBRE,APELLIDO,TELEFONO,DIRECCION) VALUES(@CEDULA,@NOMBRE,@APELLIDO,@TELEFONO,@DIRECCION)";
                _comando.CommandText = query;
                _comando.CommandType = CommandType.Text;
                _comando.Connection = _conexion.ObtenerConexion();

                _comando.Parameters.AddWithValue("@CEDULA",enti.Cedula);
                _comando.Parameters.AddWithValue("@NOMBRE", enti.Nombre);
                _comando.Parameters.AddWithValue("@APELLIDO", enti.Apellido);
                _comando.Parameters.AddWithValue("@TELEFONO", enti.Telefono);
                _comando.Parameters.AddWithValue("@DIRECCION", enti.Direccion);

                int result;
                try
                {
                    _conexion.ObtenerConexion().Open();
                 result = _comando.ExecuteNonQuery();


                }
                finally
                {
                    if (_conexion.ObtenerConexion().State == ConnectionState.Open)
                    {
                        _conexion.ObtenerConexion().Close();
                    }
                }

                return result;
            }
        }

      #endregion

        #region llenar DataGrid
        public DataTable GetFillGrid()
        {
           
                _tabla = new DataTable();
                const string serchCli = "SELECT * FROM CLIENTE";
                _adaptador = new SqlDataAdapter(serchCli,_conexion.ObtenerConexion());
                _adaptador.Fill(_tabla);
                return _tabla;
            
        }
        #endregion

        #region EditarCli
        public Entidades EditarCli(int id) 
        {
           const string query = "SELECT * FROM CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE";

            var enti = new Entidades();
            using (_comando = new SqlCommand())
            {
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = query;
                _comando.Connection = _conexion.ObtenerConexion();
                _comando.Parameters.AddWithValue("@ID_CLIENTE", id);

                try
                {
                    _conexion.ObtenerConexion().Open();
                    _reader = _comando.ExecuteReader();

                    while (_reader.Read())
                    {
                        enti = new Entidades
                            { 
                            Cedula = _reader["CEDULA"].ToString(),
                            Nombre = _reader["NOMBRE"].ToString(),
                            Apellido = _reader["APELLIDO"].ToString(),
                            Telefono = _reader["TELEFONO"].ToString(),
                            Direccion = _reader["DIRECCION"].ToString()

                        };
                        
                        
                    }
                    _reader.Close();

                }
              
                finally
                {
                    if (_conexion.ObtenerConexion().State == ConnectionState.Open)
                    {
                        _conexion.ObtenerConexion().Close();
                    }
                }
                return enti;
                
            }
        }
        #endregion

        #region Actualizar
        public int Update(int id,Entidades enti)
        {
          const string query = "UPDATE CLIENTE SET CEDULA=@CEDULA,NOMBRE=@NOMBRE,APELLIDO=@APELLIDO,TELEFONO=@TELEFONO,DIRECCION=@DIRECCION WHERE ID_CLIENTE=@ID_CLIENTE";
            using (_comando = new SqlCommand())
            {

                _comando.CommandType = CommandType.Text;
                _comando.CommandText = query;
                _comando.Connection = _conexion.ObtenerConexion();

                //PARAMETROS
                _comando.Parameters.AddWithValue("@CEDULA", enti.Cedula);
                _comando.Parameters.AddWithValue("@NOMBRE", enti.Nombre);
                _comando.Parameters.AddWithValue("@APELLIDO", enti.Apellido);
                _comando.Parameters.AddWithValue("@TELEFONO", enti.Telefono);
                _comando.Parameters.AddWithValue("@DIRECCION", enti.Direccion);
                _comando.Parameters.AddWithValue("@ID_CLIENTE",id);

                int resultado;
                try
                {

                    _conexion.ObtenerConexion().Open();
                    resultado = _comando.ExecuteNonQuery();
                }
              
                finally
                {
                    if (_conexion.ObtenerConexion().State == ConnectionState.Open)
                    {
                        _conexion.ObtenerConexion().Close();
                    }
                }
                return resultado;
            }
        }
        #endregion

        #region Borrar
        public int Delete(int id)
        {
           const string query = "DELETE FROM CLIENTE WHERE ID_CLIENTE = @ID_CLIENTE";
            using (_comando = new SqlCommand())
            {
                _comando.CommandType = CommandType.Text;
                _comando.CommandText = query;
                _comando.Connection = _conexion.ObtenerConexion();
                _comando.Parameters.AddWithValue("@ID_CLIENTE", id);

                int resultado;
                try
                {
                    _conexion.ObtenerConexion().Open();
                    resultado = _comando.ExecuteNonQuery();

                }
              
                finally
                {
                    if (_conexion.ObtenerConexion().State == ConnectionState.Open)
                    {
                        _conexion.ObtenerConexion().Close();
                    }
                }
                return resultado;
            }
        }
        #endregion
    }
}
