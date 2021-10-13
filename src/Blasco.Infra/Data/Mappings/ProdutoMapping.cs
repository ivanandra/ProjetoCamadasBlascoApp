using Blasco.Business.Models.Produtos;
using System.Data.Entity.ModelConfiguration;

namespace Blasco.Infra.Data.Mappings
{
    public class ProdutoMapping: EntityTypeConfiguration<Produto>
    {
        public ProdutoMapping()
        {
            HasKey(Produto => Produto.Id);

            Property(Produto => Produto.Nome)
                    .IsRequired()
                    .HasMaxLength(200);

            Property(Produto => Produto.Descricao)
                    .IsRequired()
                    .HasMaxLength(1000);


            Property(Produto => Produto.Imagem)
                    .IsRequired()
                    .HasMaxLength(100);

            HasRequired(Produto => Produto.Fornecedor)
                    .WithMany(Fornecedor => Fornecedor.Produtos)
                    .HasForeignKey(Produto => Produto.FornecedorID);
            
            ToTable("Produtos");

        }
    }
}
