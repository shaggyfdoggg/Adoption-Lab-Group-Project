using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Adoption_Lab.Models;

public partial class AnimalsDbContext : DbContext
{
    public AnimalsDbContext()
    {
    }

    public AnimalsDbContext(DbContextOptions<AnimalsDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdoptList> AdoptLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=AnimalsDb; User ID=SA; Password=EnterPasswordHere123; TrustServerCertificate=true;");

    //  => optionsBuilder.UseSqlServer("Data Source=.\\sqlexpress;Initial Catalog=AnimalsDb; Integrated Security=SSPI;Encrypt=false;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdoptList>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdoptLis__3213E83FC9F2E176");

            entity.ToTable("AdoptList");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Breed).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(3000);
            entity.Property(e => e.Img)
                .HasMaxLength(3000)
                .HasColumnName("img");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
