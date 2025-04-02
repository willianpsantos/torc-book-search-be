using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TorcBookSearch.Models;

namespace TorcBookSearch.Data.EntityConfigurations;

public sealed class BookEntityConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).UseIdentityColumn().HasColumnName("book_id");
        builder.Property(x => x.Title).HasMaxLength(100).IsRequired().HasColumnName("title");
        builder.Property(x => x.Firstname).HasMaxLength(50).IsRequired().HasColumnName("first_name");
        builder.Property(x => x.Lastname).HasMaxLength(50).IsRequired().HasColumnName("last_name");
        builder.Property(x => x.TotalCopies).IsRequired(false).HasDefaultValue(0).HasColumnName("total_copies");
        builder.Property(x => x.CopiesInUse).IsRequired(false).HasDefaultValue(0).HasColumnName("copies_in_use");
        builder.Property(x => x.Type).IsRequired(false).HasMaxLength(50).HasColumnName("type");
        builder.Property(x => x.ISBN).IsRequired(false).HasMaxLength(80).HasColumnName("isbn");
        builder.Property(x => x.Category).IsRequired(false).HasMaxLength(50).HasColumnName("category");
    }
}
