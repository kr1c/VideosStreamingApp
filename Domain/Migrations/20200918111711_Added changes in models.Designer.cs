﻿// <auto-generated />
using System;
using Domain.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Domain.Migrations
{
    [DbContext(typeof(VideoDbContext))]
    [Migration("20200918111711_Added changes in models")]
    partial class Addedchangesinmodels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.CastPerson", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Biography")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("datetime");

                    b.Property<int>("CastPersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("CastPersonTypeId");

                    b.ToTable("CastPersons");
                });

            modelBuilder.Entity("Domain.Entities.CastPersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("CastPersonTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Director"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Actor"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Screenwriter"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Producer"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Costume Designer"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Cinematographer"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Editor"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Music Supervisor"
                        });
                });

            modelBuilder.Entity("Domain.Entities.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("Predefined")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Name = "Action",
                            Predefined = false
                        },
                        new
                        {
                            Id = 2L,
                            Name = "Comedy",
                            Predefined = false
                        },
                        new
                        {
                            Id = 3L,
                            Name = "Drama",
                            Predefined = false
                        },
                        new
                        {
                            Id = 4L,
                            Name = "Fantasy",
                            Predefined = false
                        },
                        new
                        {
                            Id = 5L,
                            Name = "Horror",
                            Predefined = false
                        },
                        new
                        {
                            Id = 6L,
                            Name = "Mystery",
                            Predefined = false
                        },
                        new
                        {
                            Id = 7L,
                            Name = "Romance",
                            Predefined = false
                        },
                        new
                        {
                            Id = 8L,
                            Name = "Thriller",
                            Predefined = false
                        });
                });

            modelBuilder.Entity("Domain.Entities.Video", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("AgeGroup")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("AvailabilityFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("AvailabilityTo")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(2000)")
                        .HasMaxLength(2000);

                    b.Property<long?>("ParentVideoId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<int>("VideoTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentVideoId");

                    b.HasIndex("VideoTypeId");

                    b.ToTable("Videos");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            AgeGroup = (byte)18,
                            AvailabilityFrom = new DateTime(1994, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Skazani na Shawsank",
                            Title = "The Shawshank Redemption",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 2L,
                            AgeGroup = (byte)16,
                            AvailabilityFrom = new DateTime(1972, 3, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 3L,
                            AgeGroup = (byte)16,
                            AvailabilityFrom = new DateTime(1974, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Godfather: Part II",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 4L,
                            AgeGroup = (byte)12,
                            AvailabilityFrom = new DateTime(2008, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Dark Knight",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 5L,
                            AgeGroup = (byte)12,
                            AvailabilityFrom = new DateTime(1957, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "12 Angry Men",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 6L,
                            AgeGroup = (byte)12,
                            AvailabilityFrom = new DateTime(1993, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Schindler's List",
                            VideoTypeId = 1
                        },
                        new
                        {
                            Id = 7L,
                            AgeGroup = (byte)7,
                            AvailabilityFrom = new DateTime(2003, 12, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "The Lord of the Rings: The Return of the King",
                            VideoTypeId = 1
                        });
                });

            modelBuilder.Entity("Domain.Entities.VideoCast", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CastPersonId")
                        .HasColumnType("bigint");

                    b.Property<long>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CastPersonId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoCasts");
                });

            modelBuilder.Entity("Domain.Entities.VideoCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("VideoId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("VideoId");

                    b.ToTable("VideoCategories");
                });

            modelBuilder.Entity("Domain.Entities.VideoImage", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("VideoId")
                        .HasColumnType("bigint");

                    b.Property<int>("VideoImageTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("VideoId");

                    b.HasIndex("VideoImageTypeId");

                    b.ToTable("VideoImages");
                });

            modelBuilder.Entity("Domain.Entities.VideoImageType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VideoImageTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "FRAME"
                        },
                        new
                        {
                            Id = 2,
                            Name = "COVER"
                        });
                });

            modelBuilder.Entity("Domain.Entities.VideoType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("VideoTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vod"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Live"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Series"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Season"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Episode"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Channel"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Program"
                        });
                });

            modelBuilder.Entity("Domain.Entities.CastPerson", b =>
                {
                    b.HasOne("Domain.Entities.CastPersonType", "CastPersonType")
                        .WithMany("CastPersons")
                        .HasForeignKey("CastPersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.Video", b =>
                {
                    b.HasOne("Domain.Entities.Video", "ParentVideo")
                        .WithMany("SubVideos")
                        .HasForeignKey("ParentVideoId");

                    b.HasOne("Domain.Entities.VideoType", "VideoType")
                        .WithMany("Videos")
                        .HasForeignKey("VideoTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VideoCast", b =>
                {
                    b.HasOne("Domain.Entities.CastPerson", "CastPerson")
                        .WithMany("VideoCasts")
                        .HasForeignKey("CastPersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Video", "Video")
                        .WithMany("VideoCasts")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VideoCategory", b =>
                {
                    b.HasOne("Domain.Entities.Category", "Category")
                        .WithMany("VideoCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Video", "Video")
                        .WithMany("VideoCategories")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Domain.Entities.VideoImage", b =>
                {
                    b.HasOne("Domain.Entities.Video", "Video")
                        .WithMany("VideoImages")
                        .HasForeignKey("VideoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.VideoImageType", "VideoImageType")
                        .WithMany("VideoImages")
                        .HasForeignKey("VideoImageTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
