using Front.Models;
using Front.Servicio;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Json;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Front.App
{
    public partial class Transactions : System.Web.UI.Page
    {
        static HttpClient client = new HttpClient();
        static Codificador encoder = new Codificador();
        static string token = "";

        protected void Page_Load(object sender, EventArgs e)
        {
            if(Session["access_token"]== null)
            {
                Response.Redirect("Login.aspx");
                return;
            }
            
            token = Session["access_token"].ToString().Replace("\"","").Replace("\\","");

            switch (Session["Rol"].ToString().Replace("\"", "").Replace("\\", ""))
            {
                case "Assistant":
                    {
                        p1.Visible = true;
                        p2.Visible = false;
                        break;
                    }
                case "Manager":
                    {
                        p1.Visible = false;
                        p2.Visible = true;
                        break;
                    }
                case "Superintendent":
                    {
                        p1.Visible = false;
                        p2.Visible = true;
                        break;
                    }
                case "Administrator":
                    {
                        p1.Visible = true;
                        p2.Visible = true;
                        break;
                    }
            }
            
        }

        /// <summary>
        /// Metodo del botón guardar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void SaveUserAsync(object sender, EventArgs e)
        {
            var transaction = new TransactionModel()
            {
                Date = DateTime.Parse(txtDate.Text),
                NameDest = txtName.Text                
            };

            var response = await Guardar(transaction);

            if (response["respuesta"] == 1)
            {
                respuesta.Text = "Guardado Exitoso";
            }
            else
            {
                respuesta.Text = "Error al guardar";
            }
            
        }

        /// <summary>
        /// guardar nueva transaccion en base de datos.
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        private static async Task<JsonValue> Guardar(TransactionModel transaction)
        {
            var url = ConfigurationManager.AppSettings["Server"] + "transaction/guardar";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var response = await client.PostAsync(url, encoder.Encode(transaction, token));

            var content = await response.Content.ReadAsStringAsync();
            return JsonValue.Parse(content);
        }

        /// <summary>
        /// Llamado al método de busqueda de transacciones del Api
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public async void Buscar(object sender, EventArgs e)
        {
            var response = await BuscarReq(Criterio.SelectedValue, txtBuscar.Text);

            var json = await response.Content.ReadAsStringAsync();

            var lista = JsonConvert.DeserializeObject<List<TransactionModel>>(json);

            Tabla.DataSource = lista;
            Tabla.DataBind();
        }

        /// <summary>
        /// Buscar transacciones en base de datos
        /// </summary>
        /// <param name="criterio"></param>
        /// <param name="palabra"></param>
        /// <returns></returns>
        private static async Task<HttpResponseMessage> BuscarReq(string criterio, string palabra)
        {
            var url = ConfigurationManager.AppSettings["Server"] + "transaction/buscar";
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);

            var values = new Dictionary<string, string>()
            {
                {"Criterio", criterio},
                {"Palabra", palabra}
            };
            var content = new FormUrlEncodedContent(values);

            return await client.PostAsync(url, content);
        }

    }
}