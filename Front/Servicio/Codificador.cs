using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace Front.Servicio
{
    public class Codificador
    {
        public ByteArrayContent Encode(object objeto, string token)
        {
            var json = JsonConvert.SerializeObject(objeto);
            var buffer = System.Text.Encoding.UTF8.GetBytes(json);
            var byteContent = new ByteArrayContent(buffer);

            byteContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            try
            {
                byteContent.Headers.Add(HttpRequestHeader.Authorization.ToString(), "bearer " + token);
            }
            catch (Exception ex) { }
            
            return byteContent;
        }
    }
}