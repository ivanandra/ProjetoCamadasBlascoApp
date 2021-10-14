using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Blasco.Business.Models.Fornecedores;
using Blasco.Business.Models.Produtos;
using Blasco.Infra.Data.Mappings;

namespace Blasco.Infra.Data.Context
{
    public class BlascoDbContext : DbContext
    {
        public BlascoDbContext() : base("DefaultConnection")
        { }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Para não haver uma exclusão em cascata automática no banco, ao deletar um fornecedor por exemplo//
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //Otimizando a modelagem do BD no contexto//
             
            modelBuilder.Properties<string>()
                .Configure(propertyConfigurationAction: prop => prop
                .HasColumnType("varchar")
                .HasMaxLength(100));
                

            //Adicionando os Mappings das Tabelas do BD//

            modelBuilder.Configurations.Add(new FornecedorMapping());
            modelBuilder.Configurations.Add(new EnderecoMapping());
            modelBuilder.Configurations.Add(new ProdutoMapping());
        }

    }
}
