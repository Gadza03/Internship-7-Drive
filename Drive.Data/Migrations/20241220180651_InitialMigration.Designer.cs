﻿// <auto-generated />
using System;
using Drive.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Drive.Data.Migrations
{
    [DbContext(typeof(DriveDbContext))]
    [Migration("20241220180651_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Drive.Data.Entities.Models.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FileId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("FileId");

                    b.ToTable("Comments");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            Content = "What is this!?",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6103),
                            FileId = 1,
                            LastModified = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6245)
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 2,
                            Content = "That is related doc.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6508),
                            FileId = 1,
                            LastModified = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6509)
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 4,
                            Content = "Ughhh, this is boring!",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6510),
                            FileId = 15,
                            LastModified = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6511)
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("FolderId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastModifiedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("FolderId");

                    b.HasIndex("OwnerId");

                    b.ToTable("Files");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Content = "A general document related content.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3408),
                            FolderId = 1,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3549),
                            Name = "RelatedDoc.txt",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            Content = "A quote from a business strategy book: 'The only limit to our realization of tomorrow is our doubts of today.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3692),
                            FolderId = 2,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3692),
                            Name = "BusinessDoc",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 3,
                            Content = "Invoices and bills for various expenses can be found here.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3694),
                            FolderId = 3,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3694),
                            Name = "Invoice.pdf",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 4,
                            Content = "An outline for a presentation on business development.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3695),
                            FolderId = 4,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3696),
                            Name = "PresentationIdeas.txt",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 5,
                            Content = "Project planning notes for a new software development project.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3697),
                            FolderId = 5,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3697),
                            Name = "ProjectPlanning.txt",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 6,
                            Content = "Code snippets and documentation for the Python web scraper.",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3701),
                            FolderId = 6,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3701),
                            Name = "PythonLibDoc.txt",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 7,
                            Content = "An eBook excerpt: 'The future belongs to those who believe in the beauty of their dreams.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3702),
                            FolderId = 8,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3703),
                            Name = "Quotes.txt",
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 8,
                            Content = "A song lyric: 'Music can change the world because it can change people.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3704),
                            FolderId = 9,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3704),
                            Name = "Lyrics.txt",
                            OwnerId = 5
                        },
                        new
                        {
                            Id = 9,
                            Content = "Book review: 'A journey of a thousand pages begins with a single chapter.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3706),
                            FolderId = 10,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3706),
                            Name = "Reviews.txt",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 11,
                            Content = "A quote from a classic novel: 'To be, or not to be, that is the question.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3708),
                            FolderId = 10,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3722),
                            Name = "NovelQuote.txt",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 12,
                            Content = "An excerpt from a bestselling book: 'The only thing we have to fear is fear itself.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3723),
                            FolderId = 10,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3723),
                            Name = "Books.txt",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 13,
                            Content = "A passage from a famous literary work: 'It was the best of times, it was the worst of times.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3725),
                            FolderId = 10,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3725),
                            Name = "FamousWork.txt",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 14,
                            Content = "A snippet from a popular novel: 'In the end, we only regret the chances we didn't take.'",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3726),
                            FolderId = 10,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3727),
                            Name = "Novels.txt",
                            OwnerId = 6
                        },
                        new
                        {
                            Id = 15,
                            Content = "a2 – b2 = (a – b)(a + b)",
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3728),
                            FolderId = 7,
                            LastModifiedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3728),
                            Name = "ScriptForMaths.txt",
                            OwnerId = 4
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OwnerId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentFolderId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.HasIndex("ParentFolderId");

                    b.ToTable("Folders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(1696),
                            Name = "Documents",
                            OwnerId = 1
                        },
                        new
                        {
                            Id = 2,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2170),
                            Name = "Business Documents",
                            OwnerId = 1,
                            ParentFolderId = 1
                        },
                        new
                        {
                            Id = 3,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2174),
                            Name = "Bills",
                            OwnerId = 1,
                            ParentFolderId = 2
                        },
                        new
                        {
                            Id = 4,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2175),
                            Name = "Presentations",
                            OwnerId = 2
                        },
                        new
                        {
                            Id = 5,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2192),
                            Name = "Projects",
                            OwnerId = 3
                        },
                        new
                        {
                            Id = 6,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2197),
                            Name = "Python Web Scraper",
                            OwnerId = 3,
                            ParentFolderId = 5
                        },
                        new
                        {
                            Id = 7,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2198),
                            Name = "School",
                            OwnerId = 4
                        },
                        new
                        {
                            Id = 8,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2199),
                            Name = "eBook",
                            OwnerId = 4,
                            ParentFolderId = 7
                        },
                        new
                        {
                            Id = 9,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2200),
                            Name = "Music",
                            OwnerId = 5
                        },
                        new
                        {
                            Id = 10,
                            CreatedAt = new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2203),
                            Name = "Books",
                            OwnerId = 6
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Share", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ItemId")
                        .HasColumnType("integer");

                    b.Property<int>("ItemType")
                        .HasColumnType("integer");

                    b.Property<int>("SharedById")
                        .HasColumnType("integer");

                    b.Property<int>("SharedWithId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("SharedById");

                    b.HasIndex("SharedWithId");

                    b.HasIndex("UserId");

                    b.ToTable("SharedItems");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ItemId = 1,
                            ItemType = 1,
                            SharedById = 1,
                            SharedWithId = 2
                        },
                        new
                        {
                            Id = 2,
                            ItemId = 10,
                            ItemType = 0,
                            SharedById = 6,
                            SharedWithId = 3
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "ivan.horvat@gmail.com",
                            Name = "Ivan",
                            PasswordHash = "$2a$11$byjN71wBKBnpoU34h9mY4.riZazqE7vxkt5Dt2al47KVV0AN4/By6",
                            Surname = "Horvat"
                        },
                        new
                        {
                            Id = 2,
                            Email = "ana.petrovic@gmail.com",
                            Name = "Ana",
                            PasswordHash = "$2a$11$6xMXyai0wDPPDlrP7jWnieBR10RRG1EjI3XunoS3pRlz03Im97PWe",
                            Surname = "Petrović"
                        },
                        new
                        {
                            Id = 3,
                            Email = "marko.kovac@gmail.com",
                            Name = "Marko",
                            PasswordHash = "$2a$11$HvlhvG9IS.C0CN0S9Mc.IunTwJtcoKvxkiCHZrGp3Ltn9HfHDbg56",
                            Surname = "Kovač"
                        },
                        new
                        {
                            Id = 4,
                            Email = "martina.matic@gmail.com",
                            Name = "Martina",
                            PasswordHash = "$2a$11$/JQoX5byAzaLBBq3ux9zBetRjo4AfXcnm5/VYobg7WxKk5pKs06oC",
                            Surname = "Matić"
                        },
                        new
                        {
                            Id = 5,
                            Email = "luka.simic@gmail.com",
                            Name = "Luka",
                            PasswordHash = "$2a$11$bnaqTkYciYvp/CKqATkNBOOwvyCNbLjp.qSZ8f/.8kMLEqO0KBePq",
                            Surname = "Šimić"
                        },
                        new
                        {
                            Id = 6,
                            Email = "sara.luksic@gmail.com",
                            Name = "Sara",
                            PasswordHash = "$2a$11$7hkFw833iXF0BMG5DDbJY.EtadEJ4mobd82f2JYEtAvbzGDeKqUmu",
                            Surname = "Lukšić"
                        },
                        new
                        {
                            Id = 7,
                            Email = "petar.juric@gmail.com",
                            Name = "Petar",
                            PasswordHash = "$2a$11$BurPptzWXO2Iu6pWk4Cu6Oac9.VMs8Nxjbl1kkFqwjfITEpfHiaYy",
                            Surname = "Jurić"
                        });
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Comment", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.File", "File")
                        .WithMany("Comments")
                        .HasForeignKey("FileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("File");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.Folder", "Folder")
                        .WithMany("Files")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.User", "Owner")
                        .WithMany("Files")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.User", "Owner")
                        .WithMany("Folders")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.Folder", "ParentFolder")
                        .WithMany("SubFolders")
                        .HasForeignKey("ParentFolderId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Owner");

                    b.Navigation("ParentFolder");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Share", b =>
                {
                    b.HasOne("Drive.Data.Entities.Models.User", "SharedBy")
                        .WithMany()
                        .HasForeignKey("SharedById")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.User", "SharedWith")
                        .WithMany()
                        .HasForeignKey("SharedWithId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Drive.Data.Entities.Models.User", null)
                        .WithMany("SharedItems")
                        .HasForeignKey("UserId");

                    b.Navigation("SharedBy");

                    b.Navigation("SharedWith");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.File", b =>
                {
                    b.Navigation("Comments");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.Folder", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("SubFolders");
                });

            modelBuilder.Entity("Drive.Data.Entities.Models.User", b =>
                {
                    b.Navigation("Files");

                    b.Navigation("Folders");

                    b.Navigation("SharedItems");
                });
#pragma warning restore 612, 618
        }
    }
}
