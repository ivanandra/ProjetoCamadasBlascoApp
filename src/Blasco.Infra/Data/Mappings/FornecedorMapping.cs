using Blasco.Business.Models.Fornecedores;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blasco.Infra.Data.Mappings
{
    public class FornecedorMapping: EntityTypeConfiguration<Fornecedor>
    {
        public FornecedorMapping()
        {
            HasKey(Fornecedor => Fornecedor.Id);

            Property(Fornecedor => Fornecedor.Nome)
                .IsRequired()
                .HasMaxLength(200);

            Property(Fornecedor => Fornecedor.Documento)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnAnnotation(name:"IX_Documento",
                new IndexAnnotation(new IndexAttribute { IsUnique = true }));

            HasRequired(Fornecedor => Fornecedor.Endereco)
                .WithRequiredPrincipal(Endereco => Endereco.Fornecedor);

            ToTable("Fornecedores");
        }
    }
}
