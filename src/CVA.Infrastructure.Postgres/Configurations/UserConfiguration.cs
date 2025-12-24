namespace CVA.Infrastructure.Postgres;

/// <summary>
/// Configures the entity mapping for the <c>User</c> class within the database context.
/// </summary>
public class UserConfiguration : IEntityTypeConfiguration<User>
{
    /// <inheritdoc />
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.HasKey(user => user.Id);

        builder.Property(user => user.Id)
            .HasColumnName(nameof(User.Id).ToSnakeCase())
            .ValueGeneratedNever();

        builder.Property(user => user.Name)
            .HasColumnName(nameof(User.Name).ToSnakeCase())
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.Surname)
            .HasColumnName(nameof(User.Surname).ToSnakeCase())
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.Email)
            .HasColumnName(nameof(User.Email).ToSnakeCase())
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(user => user.Phone)
            .HasColumnName(nameof(User.Phone).ToSnakeCase())
            .HasMaxLength(20);

        builder.Property(user => user.Birthday)
            .HasColumnName(nameof(User.Birthday).ToSnakeCase())
            .HasColumnType("date");

        builder.Property(user => user.SummaryInfo)
            .HasColumnName(nameof(User.SummaryInfo).ToSnakeCase());

        builder.Property(user => user.Skills)
            .HasColumnName(nameof(User.Skills).ToSnakeCase())
            .HasColumnType("text[]");

        builder.OwnsMany(user => user.WorkExperience, WorkConfiguration.Configure);
    }
}