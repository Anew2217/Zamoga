using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Json;
using System.Configuration;

namespace Front.App
{
    public partial class Login : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();

        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Clear();
        }

        /// <summary>
        /// Método que llama los servicios de verificación de usuario y guarda la sesión.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected async void ValidarUsuario(object sender, EventArgs e)
        {
            var response = await Validar( user.Text, pass.Text);
            var response2 = await ObtenerRol(user.Text, pass.Text);            

            try
            {
                Session["access_token"] = response["access_token"];
                Session["Rol"] = response2["Rol"];
                Session["Usuario"] = user.Text;
                Response.Redirect("Transactions.aspx",false);
            }
            catch(Exception ex)
            {
                Error.Text = "Error en el usuario o la contraseña. Por favor vuelva a intentarlo.";
                Error.Visible = true;
            }            
        }

        /// <summary>
        /// Envia el nombre de usuario y contraseña al Api para solicitar el token de autenticación.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        static async Task<JsonValue> Validar(string user, string pass)
        {
            var values = new Dictionary<string, string>
            {
                {"username", user },
                { "password", pass},
                { "grant_type", "password"},
            };

            var body = new FormUrlEncodedContent(values);            
            var url = ConfigurationManager.AppSettings["Server"] + "token";
            
            var response = await client.PostAsync(url, body);
            
            var content = await response.Content.ReadAsStringAsync();
            return JsonValue.Parse(content);
        }

        /// <summary>
        /// Obtiene información del usuario registrado.
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        static async Task<JsonValue> ObtenerRol(string user, string pass)
        {
            var values = new Dictionary<string, string>
            {
                {"User", user },
                {"Pass", pass},
            };

            var body = new FormUrlEncodedContent(values);
            var url = ConfigurationManager.AppSettings["Server"] + "transaction/getRol";

            var response = await client.PostAsync(url, body);

            var content = await response.Content.ReadAsStringAsync();
            return JsonValue.Parse(content);
        }
    }
}