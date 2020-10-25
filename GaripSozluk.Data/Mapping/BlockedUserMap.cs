using GaripSozluk.Data.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace GaripSozluk.Data.Mapping
{
    public class BlockedUserMap : IEntityTypeConfiguration<BlockedUser>
    {
        public void Configure(EntityTypeBuilder<BlockedUser> builder)
        {
            builder.HasOne(x => x.User).WithMany(x => x.BlockedUsers).HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);//Benim banladıklarım
            builder.HasOne(x => x.BanUser).WithMany(x => x.BlockedBy).HasForeignKey(x => x.BannedUserId).OnDelete(DeleteBehavior.NoAction);//Beni banlayanlar


        }
    }
}
