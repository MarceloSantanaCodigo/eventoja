using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using EventosJa.Api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventosJa.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private const string strSqlServer =
            "Initial Catalog=EventoJa;User=sa;Password=Your_password123;Data Source=localhost,5434";

        [HttpGet("Banco-sql/{nomeCategoria}")]
        public void Banco(string nomeCategoria)
        {
            SqlConnection coon = new SqlConnection(strSqlServer);
            coon.Open();
            SqlCommand cmd = coon.CreateCommand();
            cmd.CommandText = $"INSERT INTO [dbo].[Categoria]([Nome])VALUES('{nomeCategoria}')";
            var a = cmd.ExecuteScalar();
            coon.Close();
        }
        [HttpGet("Banco-dapper/{nomeCategoria}")]
        public void BancoDapper(string nomeCategoria)
        {
            SqlConnection coon = new SqlConnection(strSqlServer);
            coon.Execute($"INSERT INTO [dbo].[Categoria]([Nome])VALUES('{nomeCategoria}')");
        }
        [HttpPost("Banco-dapper-classe")]
        public void BancoDapperClasse([FromBody] Categoria categoria)
        {
            SqlConnection coon = new SqlConnection(strSqlServer);
            coon.Insert(categoria);
        }
        
        [HttpPost("Banco-EF")]
        public void BancoEF([FromBody] Categoria categoria)
        {
            var db = new InforJaDB();
            db.Categorias.Add(categoria);
            db.SaveChanges();
            
        }
        [HttpPut("atualizar")]
        public void BancoAtualizar([FromBody] Categoria categoria)
        {
            var db = new InforJaDB();
            db.Categorias.Update(categoria);
            db.SaveChanges();
            
        }
        [HttpGet("buscarPorId/{idCategoria}")]
        public Categoria? BancoEF(int idCategoria)
        {
            var db = new InforJaDB();
            Categoria? categoria = db.Categorias.Find(idCategoria);

            return categoria;
        }
        [HttpGet("buscarPorNome/{nomeCategoria}")]
        public IEnumerable<Categoria> BancoEF(string nomeCategoria)
        {
            var db = new InforJaDB();
            var categoria = db.Categorias.Where(cat => cat.Nome.Contains(nomeCategoria));

            return categoria;
        }
        
    }
}
