using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PasswordHash = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Folders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    ParentFolderId = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    OwnerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Folders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Folders_Folders_ParentFolderId",
                        column: x => x.ParentFolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Folders_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SharedItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<int>(type: "integer", nullable: false),
                    ItemType = table.Column<int>(type: "integer", nullable: false),
                    SharedById = table.Column<int>(type: "integer", nullable: false),
                    SharedWithId = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SharedItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_SharedById",
                        column: x => x.SharedById,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_SharedWithId",
                        column: x => x.SharedWithId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SharedItems_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    FolderId = table.Column<int>(type: "integer", nullable: false),
                    OwnerId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Files_Folders_FolderId",
                        column: x => x.FolderId,
                        principalTable: "Folders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Files_Users_OwnerId",
                        column: x => x.OwnerId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Content = table.Column<string>(type: "text", nullable: true),
                    FileId = table.Column<int>(type: "integer", nullable: false),
                    AuthorId = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    LastModified = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Files_FileId",
                        column: x => x.FileId,
                        principalTable: "Files",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Comments_Users_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Name", "PasswordHash", "Surname" },
                values: new object[,]
                {
                    { 1, "ivan.horvat@gmail.com", "Ivan", "$2a$11$Ob1P8AuQxLNz.3ogENufkOdNMyV4zFJ9o7ImcQrd6Uv3N/MeFmnUC", "Horvat" },
                    { 2, "ana.petrovic@gmail.com", "Ana", "$2a$11$gAas6h9tvjdMTJupJdybaO/AHRBqUXCpM5tfdLz6ujod.SBnD8ClK", "Petrović" },
                    { 3, "marko.kovac@gmail.com", "Marko", "$2a$11$wOvSb2cQV2pei1f9TI9RcePICwPZa8Dws1i57kzSaxXo1In6bbzJy", "Kovač" },
                    { 4, "martina.matic@gmail.com", "Martina", "$2a$11$S.vdaeXZx06qzNhQujhp1u/rvH4CasYGwYxShIBda4JdYdfWNo3q.", "Matić" },
                    { 5, "luka.simic@gmail.com", "Luka", "$2a$11$pjYz6BWHMMGgrxyHmj4nuOKafB7q.pyJe1ubTnKnjSze/fVV9o34G", "Šimić" },
                    { 6, "sara.luksic@gmail.com", "Sara", "$2a$11$lGBuLOvR/gkNGO/khpCS6eBGa/.teTUj5LeIoVEQ9Nsh3KrcnnpYC", "Lukšić" },
                    { 7, "petar.juric@gmail.com", "Petar", "$2a$11$mxpmZk96.tHIiC7rQEBE/ewU2rcZsk6zTUnnt7t1z3L.lF3WHNGtC", "Jurić" }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4113), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4267), "Root", 1, null },
                    { 4, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4732), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4732), "Root", 2, null },
                    { 5, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4753), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4754), "Root", 3, null },
                    { 7, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4760), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4761), "Root", 4, null },
                    { 9, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4766), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4767), "Root", 5, null },
                    { 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4769), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4769), "Root", 6, null },
                    { 11, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4775), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4775), "Root", 7, null }
                });

            migrationBuilder.InsertData(
                table: "SharedItems",
                columns: new[] { "Id", "ItemId", "ItemType", "SharedById", "SharedWithId", "UserId" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, 2, null },
                    { 2, 10, 0, 6, 3, null }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 1, "A general document related content.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6115), 1, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6253), "RelatedDoc.txt", 1 },
                    { 4, "An outline for a presentation on business development.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6393), 4, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6407), "PresentationIdeas.txt", 2 },
                    { 5, "Project planning notes for a new software development project.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6408), 5, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6409), "ProjectPlanning.txt", 3 },
                    { 8, "A song lyric: 'Music can change the world because it can change people.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6415), 9, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6416), "Lyrics.txt", 5 },
                    { 9, "Book review: 'A journey of a thousand pages begins with a single chapter.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6417), 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6417), "Reviews.txt", 6 },
                    { 11, "A quote from a classic novel: 'To be, or not to be, that is the question.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6419), 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6420), "NovelQuote.txt", 6 },
                    { 12, "An excerpt from a bestselling book: 'The only thing we have to fear is fear itself.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6421), 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6421), "Books.txt", 6 },
                    { 13, "A passage from a famous literary work: 'It was the best of times, it was the worst of times.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6423), 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6423), "FamousWork.txt", 6 },
                    { 14, "A snippet from a popular novel: 'In the end, we only regret the chances we didn't take.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6424), 10, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6425), "Novels.txt", 6 },
                    { 15, "a2 – b2 = (a – b)(a + b)", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6426), 7, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6426), "ScriptForMaths.txt", 4 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[,]
                {
                    { 2, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4728), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4729), "Business Documents", 1, 1 },
                    { 6, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4759), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4759), "Python Web Scraper", 3, 5 },
                    { 8, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4765), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4765), "eBook", 4, 7 }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "Id", "AuthorId", "Content", "CreatedAt", "FileId", "LastModified" },
                values: new object[,]
                {
                    { 1, 1, "What is this!?", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(8833), 1, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(8971) },
                    { 2, 2, "That is related doc.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(9135), 1, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(9136) },
                    { 3, 4, "Ughhh, this is boring!", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(9137), 15, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(9138) }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[,]
                {
                    { 2, "A quote from a business strategy book: 'The only limit to our realization of tomorrow is our doubts of today.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6390), 2, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6390), "BusinessDoc", 1 },
                    { 6, "Code snippets and documentation for the Python web scraper.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6412), 6, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6412), "PythonLibDoc.txt", 3 },
                    { 7, "An eBook excerpt: 'The future belongs to those who believe in the beauty of their dreams.'", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6414), 8, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6414), "Quotes.txt", 4 }
                });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[] { 3, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4730), new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(4731), "Bills", 1, 2 });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "Id", "Content", "CreatedAt", "FolderId", "LastModifiedAt", "Name", "OwnerId" },
                values: new object[] { 3, "Invoices and bills for various expenses can be found here.", new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6392), 3, new DateTime(2024, 12, 27, 18, 56, 4, 490, DateTimeKind.Utc).AddTicks(6392), "Invoice.pdf", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AuthorId",
                table: "Comments",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_FileId",
                table: "Comments",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_FolderId",
                table: "Files",
                column: "FolderId");

            migrationBuilder.CreateIndex(
                name: "IX_Files_OwnerId",
                table: "Files",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_OwnerId",
                table: "Folders",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Folders_ParentFolderId",
                table: "Folders",
                column: "ParentFolderId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_SharedById",
                table: "SharedItems",
                column: "SharedById");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_SharedWithId",
                table: "SharedItems",
                column: "SharedWithId");

            migrationBuilder.CreateIndex(
                name: "IX_SharedItems_UserId",
                table: "SharedItems",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "SharedItems");

            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Folders");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
