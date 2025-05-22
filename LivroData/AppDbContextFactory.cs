using LivroData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace LivroApi // ou ajuste para o namespace correto
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();

            // Substitua pela sua string de conexão Oracle
            optionsBuilder.UseOracle("User Id=seu_usuario;Password=sua_senha;Data Source=localhost:1521/xe");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
