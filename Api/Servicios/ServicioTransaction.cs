using Api.Dominio;
using Api.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Api.Servicios
{
    public class ServicioTransaction
    {
        RepositorioTransaction repo = new RepositorioTransaction();

        /// <summary>
        /// Guardar Transaccion en base de datos
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public int Guardar(Transaction transaction)
        {
            var respuesta = repo.GuardarEditar(transaction, 1);
            if(respuesta != null) { return 1; }
            return 0;
        }


        /// <summary>
        /// Buscar transacciones en base de datos
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        public List<Transaction> Buscar(Busqueda busqueda)
        {
            var lista = repo.Buscar(busqueda);
            var transacciones = new List<Transaction>();

            if(lista != null && lista.Rows.Count > 0)
            {
                foreach (DataRow row in lista.Rows)
                {
                    transacciones.Add(new Transaction()
                    {
                        Id = int.Parse(row["Id"].ToString()),
                        Date = DateTime.Parse(row["Fecha"].ToString()),
                        NameDest = row["NombreDest"].ToString(),
                        IsFraud = string.IsNullOrEmpty(row["IsFraud"].ToString()) ? (bool?)null : bool.Parse(row["IsFraud"].ToString())
                    });
                }

                return transacciones;
            }
            return null;
        }
    }
}