using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Infrastructure.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            // Configuration de l'entité Order

            
            builder.HasKey(o => o.OrderId);

            // Configuration des propriétés
            builder.Property(o => o.CustomerName)
                .IsRequired() // La propriété CustomerName est obligatoire
                .HasMaxLength(200); // La longueur maximale de CustomerName est 200 caractères

            builder.Property(o => o.Address)
                .IsRequired() // La propriété Address est obligatoire
                .HasMaxLength(500); // La longueur maximale de Address est 500 caractères

            builder.Property(o => o.OrderDate)
                .IsRequired(); // La propriété OrderDate est obligatoire
        }
    }
}
