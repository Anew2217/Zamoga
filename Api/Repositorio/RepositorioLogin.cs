using Api.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Api.Repositorio
{
    public class RepositorioLogin
    {
        private AccesoDual acceso = new AccesoDual();

        /// <summary>
        /// Metodo que valida el usuario y contraseña. Retorna la información de usuario en caso de ser correcta.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        public Usuario ValidarUsuario( string usuario, string password)
        {
            var sp = "ValidarUsuario";

            List<SqlParameter> parametros = new List<SqlParameter>() {
                new SqlParameter("@User", SqlDbType.VarChar){Value = usuario},
                new SqlParameter("@Password", SqlDbType.VarChar){Value = password}
            };

            var result = acceso.EjecutarSp(parametros, sp);

            if (result != null && result.Rows.Count > 0)
            {
                var user = new Usuario()
                {
                    Id = int.Parse(result.Rows[0]["Id"].ToString()),
                    Rol = result.Rows[0]["Rol"].ToString(),
                    User = result.Rows[0]["Usuario"].ToString()
                };

                return user;
            }
            return null;
        }            
        
    }
}