using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutosApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosApp.Infra.Data.Mappings
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(map => map.Id);

            builder.Property(map => map.Preco)
                .HasColumnType("decimal(10,2)");

            builder.HasOne(map => map.Fornecedor) //Produto TEM 1 Fornecedor
                .WithMany(map => map.Produtos) //Fornecedor TEM MUITOS Produtos
                .HasForeignKey(map => map.FornecedorId); //Chave estrangeira
        }
    }
}
