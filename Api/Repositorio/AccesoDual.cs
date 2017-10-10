using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Api.Repositorio
{
    public class AccesoDual
    {
        /// <summary>
        /// Ejecutar store Procedure
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="sp"></param>
        /// <returns></returns>
        public DataTable EjecutarSp(List<SqlParameter> parameter, string sp)
        {
            SqlConnection conexion = new SqlConnection(ConfigurationManager.AppSettings["SQLConnention"]);

            var command = new SqlCommand()
            {
                Connection = conexion,
                CommandText = sp,
                CommandType = CommandType.StoredProcedure
            };

            var sqlAdapter = new SqlDataAdapter(command);

            conexion.Open();

            if (parameter != null)
            {
                foreach (var param in parameter)
                {
                    command.Parameters.Add(param);
                }
            }

            DataTable Resultado = new DataTable();
            try
            {
                sqlAdapter.Fill(Resultado);
                conexion.Close();
                conexion.Dispose();

                return Resultado;
            }
            catch (Exception e)
            {
                conexion.Close();
                conexion.Dispose();
                return null;
            }
        }
    }
}