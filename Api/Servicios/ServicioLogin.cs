using Api.Dominio;
using Api.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Api.Servicio
{
    public class ServicioLogin
    {
        RepositorioLogin repoLogin = new RepositorioLogin();

        /// <summary>
        /// Metodo que valida el usuario y contraseña. Retorna la información de usuario en caso de ser correcta.
        /// </summary>
        /// <param name="usuario"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public Usuario ValidarUsuario(string usuario, string password)
        {
            return repoLogin.ValidarUsuario(usuario, EncriptarClave(password));
        }

        /// <summary>
        /// Metodo que encripta la contraseña en Sha256
        /// </summary>
        /// <param name="clave"></param>
        /// <returns></returns>
        private string EncriptarClave(string clave)
        {
            using (var encryp = SHA256.Create())
            {
                encryp.ComputeHash(Encoding.ASCII.GetBytes(clave));
                return BitConverter.ToString(encryp.Hash);
            }
        }
    }
}