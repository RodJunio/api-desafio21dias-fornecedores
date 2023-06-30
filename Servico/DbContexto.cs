using api_desafio21dias_fornecedores.Models;
using Microsoft.EntityFrameworkCore;

namespace api_desafio21dias.Servicos
{
    public class DbContexto : DbContext
    {
        public DbContexto(DbContextOptions<DbContexto> options) : base(options) { }

        public DbSet<Material> Materiais { get; set; }      
       
    }
}