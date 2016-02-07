using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Data.Entity;

namespace Comix.Models.Base
{
    public class ComixDbContext : IdentityDbContext<User>
    {
        public DbSet<Comics> Comicses { get; set; }
        public DbSet<ComicsKind> ComicsKinds { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonType> PersonTypes { get; set; }
        public DbSet<ComicsPerson> ComicsPersons { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<Comics>(entity =>
            {
                entity
                    .HasMany(e => e.Comicses)
                    .WithOne(e => e.ParentComics)
                    .HasForeignKey(e => e.ParentComicsId);

            });

            builder.Entity<ComicsPerson>(entity =>
            {
                entity.HasKey(t => new {t.ComicsId, t.PersonId});
                entity
                    .HasOne(cp => cp.Comics)
                    .WithMany(c => c.ComicsPersons)
                    .HasForeignKey(cp => cp.ComicsId);


            });

            

        }
    }
}
