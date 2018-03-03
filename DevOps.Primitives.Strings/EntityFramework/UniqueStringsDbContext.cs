using Microsoft.EntityFrameworkCore;

namespace DevOps.Primitives.Strings.EntityFramework
{
    public class UniqueStringsDbContext : DbContext
    {
        public UniqueStringsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<AsciiMaxStringReference> AsciiMaxStringReferences { get; set; }
        public DbSet<AsciiStringReference> AsciiStringReferences { get; set; }
        public DbSet<AsciiStringReferenceList> AsciiStringReferenceLists { get; set; }
        public DbSet<AsciiStringReferenceListAssociation> AsciiStringReferenceListAssociations { get; set; }
        public DbSet<UnicodeMaxStringReference> UnicodeMaxStringReferences { get; set; }
        public DbSet<UnicodeStringReference> UnicodeStringReferences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AsciiMaxStringReference>().HasIndex(e => new { e.HashId }).IsUnique();
            modelBuilder.Entity<AsciiStringReference>().HasIndex(e => new { e.Value }).IsUnique();
            modelBuilder.Entity<AsciiStringReferenceList>().HasIndex(e => new { e.ListIdentifierId }).IsUnique();
            modelBuilder.Entity<AsciiStringReferenceListAssociation>().HasIndex(e => new { e.AsciiStringReferenceId, e.AsciiStringReferenceListId }).IsUnique();
            modelBuilder.Entity<UnicodeMaxStringReference>().HasIndex(e => new { e.HashId }).IsUnique();
            modelBuilder.Entity<UnicodeStringReference>().HasIndex(e => new { e.Value }).IsUnique();
        }
    }
}
