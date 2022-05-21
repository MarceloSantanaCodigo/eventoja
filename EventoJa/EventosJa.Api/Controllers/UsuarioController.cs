using EventosJa.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

namespace EventosJa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
     
        public static List<Usuario> UsuariosDB = new List<Usuario>()
        {
            new Usuario("Marcelo Santana", "marcelo", "1234", 99999998),
            new Usuario("Raphael Garcia", "raphael", "1234", 100),
            new Usuario("Giovanni Gordo", "giovanni", "1234", 200)
        };

        [HttpGet("buscar-todos")]
        public IEnumerable<Usuario> BuscarTodosUsuarios()
        {
            return UsuariosDB;
        }

        [HttpPost("login")]
        public Usuario? Login([FromBody] Usuario usuario)
        {
            return UsuariosDB
                .FirstOrDefault(usuarioLista =>
                    usuarioLista.Login.ToLower() == usuario.Login.ToLower() &&
                    usuarioLista.Senha == usuario.Senha);
        }

        [HttpPost("adicionar")]
        public Usuario Adicionar([FromBody] Usuario usuario)
        {
            UsuariosDB.Add(usuario);

            return usuario;
        }


        [HttpGet("busca-nome/{nome}")]
        public string BuscaNome(string nome)
        {
            return "Seu nome é " + nome;
        }

     
    }
}