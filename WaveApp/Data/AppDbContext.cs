using Microsoft.EntityFrameworkCore;
using Wave.Core.Models;


namespace WaveApp.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Configura o provedor de dados e define o caminho.
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),"waveapp.db");
            optionsBuilder.UseSqlite($"Data Source={databasePath}");


        }
    }
}
