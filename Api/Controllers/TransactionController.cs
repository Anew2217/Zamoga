using Api.Dominio;
using Api.Servicio;
using Api.Servicios;
using System;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("transaction")]
    public class TransactionController : ApiController
    {
        ServicioTransaction service = new ServicioTransaction();
        ServicioLogin servicioLogin = new ServicioLogin();

        public TransactionController()
        {
            string username = User.Identity.Name;            
        }

        /// <summary>
        /// Guardar nuevas transacciones
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("guardar")]
        [Authorize(Roles = "Assistant, Administrator")]
        public IHttpActionResult Guardar(Transaction transaction)
        {
            var username = User.Identity.Name;

            try
            {
                var respuesta = service.Guardar(transaction);
               
                return Ok(new { respuesta = respuesta });
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Buscar transacciones.
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("buscar")]
        [Authorize(Roles = "Manager, Superintendent, Administrator")]
        public IHttpActionResult Buscar(Busqueda busqueda)
        {
            try
            {
                return Ok(service.Buscar(busqueda));
            }
            catch(Exception ex)
            {
                return InternalServerError();
            }
        }

        /// <summary>
        /// Obtener informacion de usuario
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("getRol")]
        [Authorize(Roles = "Assistant, Manager, Superintendent, Administrator")]
        public IHttpActionResult GetRol(Usuario usuario)
        {
            try
            {
                var user = servicioLogin.ValidarUsuario(usuario.User,usuario.Pass);

                return Ok(user);
            }
            catch (Exception ex)
            {
                return InternalServerError();
            }
        }
    }
}
