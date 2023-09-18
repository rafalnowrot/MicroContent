using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicroContent.Products.Domain.Models;
using MicroContent.Products.Domain.Types;
using MicroContent.Products.Domain.Value_Objects;

namespace MicroContent.Products.Infrastructure.Configuration
{

    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(x => x.Id)
                .HasName("Id");
            builder.Property(x => x.Id)
                .HasConversion(x => x.Value, x => new ProductId(x));
            builder.Property(x => x.Price);
            builder.Property(x => x.Name);
            builder.Property(x => x.Status)
                .HasConversion(x => x.Value, x => new ProductStatus(x));
            builder.Property(x => x.CreatedDate);
            builder.Property(x => x.LastUpdateDate);
        }
    }
}
