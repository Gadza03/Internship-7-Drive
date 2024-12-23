
using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using Drive.Data.Entities.Models;
using File = Drive.Data.Entities.Models.File;
using Drive.Data.Enums;
namespace Drive.Data.Seed
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(new List<User>
                {
                    new User(1, "Ivan", "Horvat", "ivan.horvat@gmail.com", HashPassword("ivan123")),
                    new User(2, "Ana", "Petrović", "ana.petrovic@gmail.com", HashPassword("ana456")),
                    new User(3, "Marko", "Kovač", "marko.kovac@gmail.com", HashPassword("marko789")),
                    new User(4, "Martina", "Matić", "martina.matic@gmail.com", HashPassword("martina111")),
                    new User(5, "Luka", "Šimić", "luka.simic@gmail.com", HashPassword("luka123")),
                    new User(6, "Sara", "Lukšić", "sara.luksic@gmail.com", HashPassword("sara000")),
                    new User(7, "Petar", "Jurić", "petar.juric@gmail.com", HashPassword("petar222"))
                });
            
            modelBuilder.Entity<Folder>()
                    .HasData(new List<Folder>
                    {
                        new Folder
                        {
                            Id = 1,
                            Name = "Documents",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 1,
                        },
                        new Folder
                        {
                            Id = 2,
                            Name = "Business Documents",
                            ParentFolderId = 1,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 1,
                        },
                        new Folder
                        {
                            Id = 3,
                            Name = "Bills",
                            ParentFolderId = 2,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 1,
                        },
                        new Folder
                        {
                            Id = 4,
                            Name = "Presentations",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 2,
                        },
                        new Folder
                        {
                            Id = 5,
                            Name = "Projects",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 3,
                        },
                        new Folder
                        {
                            Id = 6,
                            Name = "Python Web Scraper",
                            ParentFolderId = 5,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 3,
                        },
                        new Folder
                        {
                            Id = 7,
                            Name = "School",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 4,

                        },
                        new Folder
                        {
                            Id = 8,
                            Name = "eBook",
                            ParentFolderId = 7,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 4,
                        },
                        new Folder
                        {
                            Id = 9,
                            Name = "Music",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 5,
                        },
                        new Folder
                        {
                            Id = 10,
                            Name = "Books",
                            ParentFolderId = null,
                            CreatedAt = DateTime.UtcNow,
                            LastModified = DateTime.UtcNow,
                            OwnerId = 6,
                        },
                    });
          
            modelBuilder.Entity<File>()
                    .HasData(new List<File>
                    {
                    new File
                    {
                        Id = 1,
                        Name = "RelatedDoc.txt",
                        Content = "A general document related content.",
                        OwnerId = 1,
                        FolderId = 1,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 2,
                        Name = "BusinessDoc",
                        Content = "A quote from a business strategy book: 'The only limit to our realization of tomorrow is our doubts of today.'",
                        OwnerId = 1,
                        FolderId = 2,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 3,
                        Name = "Invoice.pdf",
                        Content = "Invoices and bills for various expenses can be found here.",
                        OwnerId = 1,
                        FolderId = 3,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 4,
                        Name = "PresentationIdeas.txt",
                        Content = "An outline for a presentation on business development.",
                        OwnerId = 2,
                        FolderId = 4,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 5,
                        Name = "ProjectPlanning.txt",
                        Content = "Project planning notes for a new software development project.",
                        OwnerId = 3,
                        FolderId = 5,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 6,
                        Name = "PythonLibDoc.txt",
                        Content = "Code snippets and documentation for the Python web scraper.",
                        OwnerId = 3,
                        FolderId = 6,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 7,
                        Name = "Quotes.txt",
                        Content = "An eBook excerpt: 'The future belongs to those who believe in the beauty of their dreams.'",
                        OwnerId = 4,
                        FolderId = 8,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 8,
                        Name = "Lyrics.txt",
                        Content = "A song lyric: 'Music can change the world because it can change people.'",
                        OwnerId = 5,
                        FolderId = 9,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 9,
                        Name = "Reviews.txt",
                        Content = "Book review: 'A journey of a thousand pages begins with a single chapter.'",
                        OwnerId = 6,
                        FolderId = 10,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 11,
                        Name = "NovelQuote.txt",
                        Content = "A quote from a classic novel: 'To be, or not to be, that is the question.'",
                        OwnerId = 6,
                        FolderId = 10,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 12,
                        Name = "Books.txt",
                        Content = "An excerpt from a bestselling book: 'The only thing we have to fear is fear itself.'",
                        OwnerId = 6,
                        FolderId = 10,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 13,
                        Name = "FamousWork.txt",
                        Content = "A passage from a famous literary work: 'It was the best of times, it was the worst of times.'",
                        OwnerId = 6,
                        FolderId = 10,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 14,
                        Name = "Novels.txt",
                        Content = "A snippet from a popular novel: 'In the end, we only regret the chances we didn't take.'",
                        OwnerId = 6,
                        FolderId = 10,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    },
                    new File
                    {
                        Id = 15,
                        Name = "ScriptForMaths.txt",
                        Content = "a2 – b2 = (a – b)(a + b)",
                        OwnerId = 4,
                        FolderId = 7,
                        CreatedAt = DateTime.UtcNow,
                        LastModifiedAt = DateTime.UtcNow,
                    }
                    });

            modelBuilder.Entity<Share>()
                .HasData(new List<Share> { 
                    new Share {
                        Id = 1,
                        ItemId = 1,
                        ItemType = ItemType.File,
                        SharedById = 1,
                        SharedWithId = 2,
                    },
                    new Share {
                        Id = 2,
                        ItemId = 10,
                        ItemType = ItemType.Folder,
                        SharedById = 6,
                        SharedWithId = 3,                       
                    }
                });

            modelBuilder.Entity<Comment>()
                .HasData(new List<Comment> {
                    new Comment
                    {
                        Id = 1,
                        Content = "What is this!?",
                        FileId = 1,
                        AuthorId = 1,
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow

                    },
                    new Comment
                    {
                        Id = 2,
                        Content = "That is related doc.",
                        FileId = 1,
                        AuthorId = 2,
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow

                    },
                    new Comment
                    {
                        Id = 3,
                        Content = "Ughhh, this is boring!",
                        FileId = 15,
                        AuthorId = 4,
                        CreatedAt = DateTime.UtcNow,
                        LastModified = DateTime.UtcNow

                    }

                });    
        
        }
        private static string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }
    }
}
