using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoList.Core;

namespace ToDoList.Infrastructure.Persistence.Configurations
{
    public class ToDoItemsListConfiguration : IEntityTypeConfiguration<ToDoItemsList>
    {
        public void Configure(
            EntityTypeBuilder<ToDoItemsList> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder
                .HasMany(x => x.Items)
                .WithOne()
                .HasForeignKey(x => x.ListId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
