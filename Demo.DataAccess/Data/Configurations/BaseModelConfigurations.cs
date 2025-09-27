using Demo.DataAccess.Entities.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.DataAccess.Data.Configurations
{
    internal class BaseModelConfigurations<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(b => b.CreatedOn).HasDefaultValueSql("getdate()");
            builder.Property(b => b.LastModifiedOn).HasDefaultValueSql("getdate()");
        }
    }
}
