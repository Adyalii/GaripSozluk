using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GaripSozluk.Data.Domain;

namespace GaripSozluk.Data.Mapping
{
    public class PostMap : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            //builder.Property(c => c.Title).IsRequired();

            //builder.HasOne(x => x.Category)
                //.WithMany(y => y.Posts)
                //.HasForeignKey(x => x.CategoryId);
        }
    }
}
