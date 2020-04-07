using System.Threading.Tasks;
using EntityFrameworkCore.Model.Entidade;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCore.Model.Data
{
    public class MeuDbContext:DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options) : base(options) { }

        public DbSet<Contato> Contatos { get; set; }

        public async Task<Contato> ObterContato(int id)
        {
            Contato resultado = await Contatos.SingleOrDefaultAsync(c => c.Id == id);

            return resultado;
        }

        public async Task<Contato> GravarContato(Contato contato)
        {
            Add(contato);
            await SaveChangesAsync();

            return contato;
        }

        public async Task<Contato> AtualizaContato(Contato contato)
        {
            Update(contato);
            await SaveChangesAsync();

            return contato;
        }

        public async Task<Contato> RemoveContato(Contato contato)
        {
            Remove(contato);
            await SaveChangesAsync();

            return contato;
        }

    }
}
