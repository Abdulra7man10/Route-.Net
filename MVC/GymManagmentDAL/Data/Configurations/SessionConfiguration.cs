using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GymManagmentDAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GymManagmentDAL.Data.Configurations
{
    internal class SessionConfiguration : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("SessionCapacityCheck", "Capacity BETWEEN 1 AND 25");
                tb.HasCheckConstraint("SessionEndCheck", "EndDate > StartDate");
            });

            builder.HasOne(x => x.SessionCategory)
                   .WithMany(x => x.Sessions)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.SessionTrainer)
                   .WithMany(x => x.Sessions)
                   .HasForeignKey(x => x.TrainerId);
        }
    }
}
