using Api.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Api.Repositorio
{
    public class RepositorioTransaction
    {
        AccesoDual acceso = new AccesoDual();

        /// <summary>
        /// Método para guardar y editar transacciones.
        /// </summary>
        /// <param name="transaction"></param>
        /// <param name="operacion"></param>
        /// <returns></returns>
        public Transaction GuardarEditar(Transaction transaction, int operacion)
        {
            var sp = "TransactionCrud";

            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Operation", SqlDbType.Int){Value = operacion},
                new SqlParameter("@Id", SqlDbType.Int){Value = transaction.Id},
                new SqlParameter("@NombreDest", SqlDbType.VarChar){Value = transaction.NameDest},                
                new SqlParameter("@Fecha", SqlDbType.Date){Value = transaction.Date},
                new SqlParameter("@IsFraud", SqlDbType.Bit){Value = transaction.IsFraud}
            };

            var result = acceso.EjecutarSp(parametros, sp);

            if(result== null || result.Rows.Count > 0)
            {
                return new Transaction()
                {
                    Date = DateTime.Parse(result.Rows[0]["Fecha"].ToString()),
                    Id = int.Parse(result.Rows[0]["Id"].ToString()),
                    IsFraud = string.IsNullOrEmpty(result.Rows[0]["IsFraud"].ToString())? (bool?)null : bool.Parse(result.Rows[0]["IsFraud"].ToString()),
                    NameDest = result.Rows[0]["NombreDest"].ToString()
                };
            }

            return null;
        }

        /// <summary>
        /// Realiza la busqueda de transacciones según el criterio solicitado.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        public DataTable Buscar(Busqueda busqueda)
        {
            var sp = "TransactionCrud";
            
            List<SqlParameter> parametros = new List<SqlParameter>()
            {
                new SqlParameter("@Operation", SqlDbType.Int){Value = busqueda.Criterio},
                new SqlParameter("@Palabra", SqlDbType.VarChar){Value = busqueda.Palabra}
            };

            return acceso.EjecutarSp(parametros, sp);
        }

    }
}