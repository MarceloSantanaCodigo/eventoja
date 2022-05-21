namespace EventosJa.Api.Models
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {

        }
        public ErrorMessage(string titulo = null, string mensagem = null, int interceptor = 1, int statuscode = 200, string result = null)
        {
            Titulo = titulo;
            Mensagem = mensagem;
            Interceptor = interceptor;
            StatusCode = statuscode;
            Result = result;
        }
        public string Titulo { get; set; }
        public string Mensagem { get; set; }
        public int Interceptor { get; set; } = 1;
        public int StatusCode { get; set; }
        public string Result { get; set; }
        public int LogId { get; set; }


    }
}
