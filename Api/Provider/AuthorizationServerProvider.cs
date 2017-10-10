using Api.Dominio;
using Api.Servicio;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace Api.Provider
{
    public class AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }
        
        /// <summary>
        /// Metodo que valida las credenciales de usuario y retorna un token para usar los métodos del API dependiendo de los permisos.
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var servicioLogin = new ServicioLogin();

            var usuario = context.UserName;
            var password = context.Password;

            var user = servicioLogin.ValidarUsuario(usuario, password);

            if (user != null)
            {
                var identity = new ClaimsIdentity(context.Options.AuthenticationType);
                
                identity.AddClaim(new Claim(ClaimTypes.Role, user.Rol));
                identity.AddClaim(new Claim(ClaimTypes.Name, user.User));
                context.Validated(identity);
            }
            else
            {
                context.SetError("Permiso Denegado", "Error en el usuario o la contraseña. Por favor vuelva a intentarlo.");
                return;
            }
        }
    }
}