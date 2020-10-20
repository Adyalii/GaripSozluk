using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data.Mappings
{
    public class HeaderCategoryMapping : BaseMapping<HeaderCategory>
    {
        public override void Configure(EntityTypeBuilder<HeaderCategory> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Title)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
