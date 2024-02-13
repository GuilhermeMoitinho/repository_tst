using Microsoft.EntityFrameworkCore;
using WebApi_ASPNETCore.Models;

namespace WebApi_ASPNETCore.Infrastructure.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> op)
        : base(op)
        {    
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}
