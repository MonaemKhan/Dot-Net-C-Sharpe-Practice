using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WEB_API_AUTH_Parctice.Model;

namespace WEB_API_AUTH_Parctice.DBCon;

public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable(nameof(Student));
        builder.HasKey(t => t.Id);
        builder.HasIndex(t => t.Id);
        builder.Property(t => t.Name).HasMaxLength(30)
            .IsUnicode(true)
            .IsRequired(true);
        builder.Property(t => t.Email).HasMaxLength(30)
            .IsUnicode(true)
            .IsRequired(true);
        builder.Property(t => t.Phone).HasMaxLength(30)
            .IsUnicode(true)
            .IsRequired(true);

        builder.HasData(new Student
        {
            Id = 1,
            Name = "Monaem",
            Email = "Khanmonaem07@gmail.com",
            Phone = "01303271848"
        },
        new Student
        {
            Id = 2,
            Name = "Monaem Khan",
            Email = "Khanmonaem077@gmail.com",
            Phone = "01832233593"
        });
    }
}
