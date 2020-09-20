using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace Domain.DAL
{
    public class VideoDbContext : DbContext
    {
        #region Properties

        public DbSet<Video> Videos { get; set; }
        public DbSet<VideoType> VideoTypes { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<VideoCategory> VideoCategories { get; set; }
        public DbSet<CastPerson> CastPersons { get; set; }
        public DbSet<CastPersonType> CastPersonTypes { get; set; }
        public DbSet<VideoCast> VideoCasts { get; set; }
        public DbSet<VideoImage> VideoImages { get; set; }
        public DbSet<VideoImageType> VideoImageTypes { get; set; }
        public DbContextOptions<VideoDbContext> Options { get; set; }

        #endregion
        #region Constructors

        public VideoDbContext(DbContextOptions<VideoDbContext> options) : base(options) {
            Options = options;

            if (!Database.GetService<IRelationalDatabaseCreator>().Exists())
            {
                Database.Migrate();
            }
        }

        #endregion
        #region Overrides

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Video>(entity =>
            {
                entity.Property(v => v.Id).UseIdentityColumn();
                entity.HasKey(v => v.Id);
                entity.Property(v => v.Title).HasMaxLength(100).IsRequired();
                entity.Property(v => v.Description).HasMaxLength(2000);
                entity.Property(v => v.AgeGroup).HasColumnType("tinyint").IsRequired();
                entity.Property(v => v.AvailabilityFrom).HasColumnType("datetime").IsRequired();
                entity.Property(v => v.AvailabilityTo).HasColumnType("datetime");
                entity.Property(v => v.Url).HasMaxLength(1000);
                entity.HasMany(v => v.SubVideos).WithOne(v => v.ParentVideo).HasForeignKey(v => v.ParentVideoId);
                entity.HasOne(v => v.VideoType).WithMany(vt => vt.Videos).HasForeignKey(v => v.VideoTypeId);
            });

            modelBuilder.Entity<VideoType>(entity =>
            {
                entity.Property(vt => vt.Id).UseIdentityColumn();
                entity.HasKey(vt => vt.Id);
                entity.Property(vt => vt.Name).HasMaxLength(50).IsRequired();
                entity.HasIndex(vt => vt.Name).IsUnique();
            });

            modelBuilder.Entity<VideoType>().HasData(
                 new VideoType() { Id = 1, Name = "Vod" },
                 new VideoType() { Id = 2, Name = "Live" },
                 new VideoType() { Id = 3, Name = "Series" },
                 new VideoType() { Id = 4, Name = "Season" },
                 new VideoType() { Id = 5, Name = "Episode" },
                 new VideoType() { Id = 6, Name = "Channel" },
                 new VideoType() { Id = 7, Name = "Program" }
            );

            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(c => c.Id).UseIdentityColumn();
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).HasMaxLength(100).IsRequired();
                entity.Property(c => c.Description).HasMaxLength(500);
                entity.Property(c => c.Predefined).IsRequired().HasDefaultValue(false);
            });

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Name = "Action" },
                new Category() { Id = 2, Name = "Comedy" },
                new Category() { Id = 3, Name = "Drama" },
                new Category() { Id = 4, Name = "Fantasy" },
                new Category() { Id = 5, Name = "Horror" },
                new Category() { Id = 6, Name = "Mystery" },
                new Category() { Id = 7, Name = "Romance" },
                new Category() { Id = 8, Name = "Thriller" }
            );

            modelBuilder.Entity<VideoCategory>(entity =>
            {
                entity.Property(vc => vc.Id).UseIdentityColumn();
                entity.HasKey(vc => vc.Id);


                entity.HasOne(vc => vc.Category).WithMany(c => c.VideoCategories)
                    .HasForeignKey(vc => vc.CategoryId);

                entity.HasOne(vc => vc.Video).WithMany(v => v.VideoCategories)
                    .HasForeignKey(vc => vc.VideoId);

                entity.HasIndex(vc => new { vc.CategoryId, vc.VideoId }).IsUnique();
            });

            modelBuilder.Entity<CastPerson>(entity =>
            {
                entity.Property(cp => cp.Id).UseIdentityColumn();
                entity.HasKey(cp => cp.Id);
                entity.Property(cp => cp.FirstName).HasMaxLength(100).IsRequired();
                entity.Property(cp => cp.LastName).HasMaxLength(100).IsRequired();
                entity.Property(cp => cp.Biography).HasMaxLength(2000);
                entity.Property(cp => cp.Birthday).HasColumnType("datetime");
                entity.HasOne(cp => cp.CastPersonType).WithMany(cpt => cpt.CastPersons).HasForeignKey(cp => cp.CastPersonTypeId);
            });

            modelBuilder.Entity<CastPersonType>(entity =>
            {
                entity.Property(vt => vt.Id).UseIdentityColumn();
                entity.HasKey(vt => vt.Id);
                entity.Property(vt => vt.Name).HasMaxLength(50).IsRequired();
                entity.HasIndex(vt => vt.Name).IsUnique();
            });

            modelBuilder.Entity<CastPersonType>().HasData(
                 new CastPersonType() { Id = 1, Name = "Director" },
                 new CastPersonType() { Id = 2, Name = "Actor" },
                 new CastPersonType() { Id = 3, Name = "Screenwriter" },
                 new CastPersonType() { Id = 4, Name = "Producer" },
                 new CastPersonType() { Id = 5, Name = "Costume Designer" },
                 new CastPersonType() { Id = 6, Name = "Cinematographer" },
                 new CastPersonType() { Id = 7, Name = "Editor" },
                 new CastPersonType() { Id = 8, Name = "Music Supervisor" }
            );

            modelBuilder.Entity<VideoCast>(entity =>
            {
                entity.Property(vc => vc.Id).UseIdentityColumn();
                entity.HasKey(vc => vc.Id);


                entity.HasOne(vc => vc.CastPerson).WithMany(cp => cp.VideoCasts)
                    .HasForeignKey(vc => vc.CastPersonId);

                entity.HasOne(vc => vc.Video).WithMany(v => v.VideoCasts)
                    .HasForeignKey(vc => vc.VideoId);
            });

            modelBuilder.Entity<VideoImage>(entity =>
            {
                entity.Property(vi => vi.Id).UseIdentityColumn();
                entity.HasKey(vi => vi.Id);
                entity.HasOne(vi => vi.VideoImageType).WithMany(vit => vit.VideoImages).HasForeignKey(vi => vi.VideoImageTypeId);
                entity.HasOne(vi => vi.Video).WithMany(v => v.VideoImages).HasForeignKey(vi => vi.VideoId);
            });

            modelBuilder.Entity<VideoImageType>(entity =>
            {
                entity.Property(vit => vit.Id).UseIdentityColumn();
                entity.HasKey(vit => vit.Id);
                entity.Property(vit => vit.Name).HasMaxLength(50).IsRequired();
                entity.HasIndex(vit => vit.Name).IsUnique();
            });

            modelBuilder.Entity<VideoImageType>().HasData(
                 new VideoImageType() { Id = 1, Name = "FRAME" },
                 new VideoImageType() { Id = 2, Name = "COVER" }
            );

            modelBuilder.Entity<Video>().HasData(
                 new Video() { Id = 1, Title = "The Shawshank Redemption", AgeGroup = 18, Description = "Skazani na Shawsank", AvailabilityFrom = new System.DateTime(1994, 12, 12), VideoTypeId = 1},
                 new Video() { Id = 2, Title = "The Godfather", AgeGroup = 16, AvailabilityFrom = new System.DateTime(1972, 3, 4), VideoTypeId = 1 },
                 new Video() { Id = 3, Title = "The Godfather: Part II", AgeGroup = 16, AvailabilityFrom = new System.DateTime(1974, 5, 6), VideoTypeId = 1 },
                 new Video() { Id = 4, Title = "The Dark Knight", AgeGroup = 12, AvailabilityFrom = new System.DateTime(2008, 11, 11), VideoTypeId = 1 },
                 new Video() { Id = 5, Title = "12 Angry Men", AgeGroup = 12, AvailabilityFrom = new System.DateTime(1957, 1, 1), VideoTypeId = 1 },
                 new Video() { Id = 6, Title = "Schindler's List", AgeGroup = 12, AvailabilityFrom = new System.DateTime(1993, 7, 5), VideoTypeId = 1 },
                 new Video() { Id = 7, Title = "The Lord of the Rings: The Return of the King", AgeGroup = 7, AvailabilityFrom = new System.DateTime(2003, 12, 21), VideoTypeId = 1 }
            );

            modelBuilder.Entity<VideoCategory>().HasData(
                 new VideoCategory() { Id = 1, CategoryId = 1, VideoId = 1},
                 new VideoCategory() { Id = 2, CategoryId = 1, VideoId = 2 },
                 new VideoCategory() { Id = 3, CategoryId = 3, VideoId = 2 },
                 new VideoCategory() { Id = 4, CategoryId = 1, VideoId = 3 },
                 new VideoCategory() { Id = 5, CategoryId = 1, VideoId = 4 },
                 new VideoCategory() { Id = 6, CategoryId = 4, VideoId = 4 },
                 new VideoCategory() { Id = 7, CategoryId = 3, VideoId = 5 },
                 new VideoCategory() { Id = 8, CategoryId = 1, VideoId = 6 },
                 new VideoCategory() { Id = 9, CategoryId = 3, VideoId = 6 },
                 new VideoCategory() { Id = 10, CategoryId = 4, VideoId = 7 }
            );
        }

        #endregion
    }
}
