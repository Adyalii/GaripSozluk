using GaripSozluk.Data.Domain;
using GaripSozluk.Data.Mapping;
using GaripSozluk.Data.Mappings;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GaripSozluk.Data
{

    public class GaripSozlukDbContext : IdentityDbContext<User, Role, int> //IdentityDbContext

    {
        public GaripSozlukDbContext() : base()
        {

        }
        public GaripSozlukDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Post> Posts { get; set; }

        public DbSet<HeaderCategory> Categories { get; set; }

        public DbSet<Header> Headers { get; set; }
        public DbSet<PostRating> PostRatings { get; set; }
        public DbSet<BlockedUser> BlockedUsers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new HeaderCategoryMapping());
            builder.ApplyConfiguration(new HeaderMapping());
            builder.ApplyConfiguration(new PostMapping());
            builder.ApplyConfiguration(new PostRatingMapping());
            builder.ApplyConfiguration(new BlockedUserMap());
            builder.ApplyConfiguration(new UserMapping());

        }
    }
}
