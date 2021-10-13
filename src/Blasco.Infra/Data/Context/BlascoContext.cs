using System.Data.Entity;
using Blasco.Business.Models.Fornecedores;
using Blasco.Business.Models.Produtos;
using Blasco.Infra.Data.Mappings;

namespace Blasco.Infra.Data.Context
{
    public class BlascoContext : DbContext
    {
        public BlascoContext() : base("DefaultConnection")
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Configurations.Add(new FornecedorMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());
            modelBuilder.Configurations.Add(new ProdutoMapping());
        }

    }
}
