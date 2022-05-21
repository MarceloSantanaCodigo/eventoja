using EventosJa.Api.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Net;

namespace EventosJa.Api.Middleware
{
    public class AutenticacaoMiddleware
    {
        private static readonly JsonSerializerSettings _serializerSettings = new JsonSerializerSettings
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        private readonly RequestDelegate next;


        public AutenticacaoMiddleware(RequestDelegate next)
        {

            this.next = next;

        }

        public async Task Invoke(HttpContext context)
        {

            //if (context.Request.Path.Value != "/api/Usuario/login")
            //{
            //    string token = context.Request.Headers["token"];
            //    if (token == null) throw new UnauthorizedAccessException("Você não tem acesso");


            //}


            await next(context);


        }




    }
}
