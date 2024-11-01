using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Candidate_BusinessObjects.Models;

public partial class CandidateManagementContext : DbContext
{
    public CandidateManagementContext()
    {
    }

    public CandidateManagementContext(DbContextOptions<CandidateManagementContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CandidateProfile> CandidateProfiles { get; set; }

    public virtual DbSet<Hraccount> Hraccounts { get; set; }

    public virtual DbSet<JobPosting> JobPostings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=localhost;Database= CandidateManagement;Uid=sa;Pwd=12345;TrustServerCertificate=True");

    private String GetConnectionString()
    {
        IConfiguration configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsetting.json", true, true).Build();
        return configuration.GetConnectionString("DbConnect");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CandidateProfile>(entity =>
        {
            entity.HasKey(e => e.CandidateId).HasName("PK__Candidat__DF539BFC00D51DB4");

            entity.ToTable("CandidateProfile");

            entity.Property(e => e.CandidateId)
                .HasMaxLength(20)
                .HasColumnName("CandidateID");
            entity.Property(e => e.Birthday).HasColumnType("datetime");
            entity.Property(e => e.Fullname).HasMaxLength(100);
            entity.Property(e => e.PostingId)
                .HasMaxLength(20)
                .HasColumnName("PostingID");
            entity.Property(e => e.ProfileShortDescription).HasMaxLength(250);
            entity.Property(e => e.ProfileUrl)
                .HasMaxLength(150)
                .HasColumnName("ProfileURL");

            entity.HasOne(d => d.Posting).WithMany(p => p.CandidateProfiles)
                .HasForeignKey(d => d.PostingId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK__Candidate__Posti__398D8EEE");
        });

        modelBuilder.Entity<Hraccount>(entity =>
        {
            entity.HasKey(e => e.Email).HasName("PK__HRAccoun__A9D10535B1FAEAF4");

            entity.ToTable("HRAccount");

            entity.Property(e => e.Email).HasMaxLength(20);
            entity.Property(e => e.FullName).HasMaxLength(30);
            entity.Property(e => e.Password).HasMaxLength(40);
        });

        modelBuilder.Entity<JobPosting>(entity =>
        {
            entity.HasKey(e => e.PostingId).HasName("PK__JobPosti__C31796A5CE19DBAD");

            entity.ToTable("JobPosting");

            entity.Property(e => e.PostingId)
                .HasMaxLength(20)
                .HasColumnName("PostingID");
            entity.Property(e => e.Description).HasMaxLength(250);
            entity.Property(e => e.JobPostingTitle).HasMaxLength(100);
            entity.Property(e => e.PostedDate).HasColumnType("datetime");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
