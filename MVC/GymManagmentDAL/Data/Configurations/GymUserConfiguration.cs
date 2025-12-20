using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagmentDAL.Data.Configurations
{
    internal class GymUserConfiguration<T> : IEntityTypeConfiguration<T> where T : GymUser // because GymUser is abstract
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<T> builder)
        {
            builder.Property(x => x.Name).HasColumnType("varchar").HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(x => x.Phone).HasColumnType("varchar").HasMaxLength(11);

            builder.ToTable(tb => 
            {
                tb.HasCheckConstraint("GymUserValidEmailCheck", "Email LIKE '_%@_%._%'"); // basic validation
                tb.HasCheckConstraint("GymUserValidPhoneCheck", "Phone LIKE '01%' AND Phone NOT LIKE '%[^0-9]%'");
            });

            builder.HasIndex(x => x.Email).IsUnique();
            builder.HasIndex(x => x.Phone).IsUnique();

            builder.OwnsOne(x => x.Address, addressBuilder =>
            {
                addressBuilder.Property(x => x.Street).HasColumnName("Street").HasColumnType("varchar").HasMaxLength(30);
                addressBuilder.Property(x => x.City).HasColumnName("City").HasColumnType("varchar").HasMaxLength(30);
                addressBuilder.Property(x => x.BuildingNumber).HasColumnName("BuildingNumber"); // optional
            });
        }
    }
}
