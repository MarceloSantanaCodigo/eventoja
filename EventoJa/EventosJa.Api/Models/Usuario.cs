namespace EventosJa.Api.Models
{
    public class Usuario
    {
        public Usuario()
        {

        }
        public Usuario(string nome, string login, string senha, float saldoBancario)
        {
            Nome = nome;
            Login = login;
            Senha = senha;
            SaldoBancario = saldoBancario;
        }

        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public float SaldoBancario { get; set; }
    }
}
