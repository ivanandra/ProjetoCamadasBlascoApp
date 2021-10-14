using System.Data.Entity.ModelConfiguration;
using Blasco.Business.Models.Fornecedores;

namespace Blasco.Infra.Data.Mappings
{
    public class EnderecoMapping: EntityTypeConfiguration<Endereco>
    {

        public EnderecoMapping()
        {
            HasKey(Endereco => Endereco.Id);

            Property(Endereco => Endereco.Logradouro)
                    .IsRequired()
                    .HasMaxLength(200);

            Property(Endereco => Endereco.Numero)
                    .IsRequired()
                    .HasMaxLength(50);


            Property(Endereco => Endereco.CEP)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsFixedLength();


            Property(Endereco => Endereco.Complemento)
                    .HasMaxLength(150);

            Property(Endereco => Endereco.Bairro)
                    .IsRequired();
                 

            Property(Endereco => Endereco.Cidade)
                    .IsRequired()
                    .HasMaxLength(150);

            Property(Endereco => Endereco.Estado)
                    .IsRequired();


            ToTable("Enderecos");

        }
    }
}
