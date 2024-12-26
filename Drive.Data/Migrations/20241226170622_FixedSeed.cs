using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(243), new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(598) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(1014), new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(1015) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(1018), new DateTime(2024, 12, 26, 17, 6, 21, 909, DateTimeKind.Utc).AddTicks(1019) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(3515), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(3879) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4217), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4218) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4222), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4223) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4226), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4227) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4230), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4246) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4254), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4255) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4258), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4259) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4262), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4263) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4267), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4268) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4273), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4274) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4277), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4278) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4281), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4282) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4285), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4286) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4289), new DateTime(2024, 12, 26, 17, 6, 21, 908, DateTimeKind.Utc).AddTicks(4290) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 905, DateTimeKind.Utc).AddTicks(6672), new DateTime(2024, 12, 26, 17, 6, 21, 905, DateTimeKind.Utc).AddTicks(6829), "Root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8905), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8916), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8917) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8920), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8921), "Root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8924), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8925), "Root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8945), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8946) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8949), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8950), "Root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8953), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8954) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8957), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8958), "Root" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(9546), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(9548), "Root" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$/UtF5wvKqJBQb.J5RdQNH.I5qdIYZv8hiYPaGe2WsPciA7cb7EHeO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$3PtEabqUk0JI0hZ.PNhTp.hG3yzHejePXvsJAxbrorEmZnwDm6iYu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$LP4evcnZYgqhxcrdA4ALkeXS1f/Lq8B3hqh95hnkrVuJT5mgrs/0y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$GCcT8cPJtULIzDy2wDC7/ul6QmWfUunDlb10.bKY7btJQw4CGjpYm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$C1sYpFPMUinyDACBKqfpeOB3wm.Ldx3ufIy4KzjIZbhsh/IWOtgWG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$1hLjfmuGoEcrM/843pnfuOX0pPi..u05S/quoDo5nNSjwTH0dlzBm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$LCb9/2SYWrNIdLDHjolcCuFZ5F4r.1J0OuKyjkzwXfllhx8j2LSVG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(3307), new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(3641) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(4054), new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(4055) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(4058), new DateTime(2024, 12, 23, 15, 59, 52, 915, DateTimeKind.Utc).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(6956), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7304) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7632), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7633) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7637), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7638) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7641), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7642) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7645), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7661) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7671), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7672) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7675), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7676) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7679), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7680) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7684), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7685) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7689), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7690) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7693), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7694) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7697), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7698) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7702), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7703) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7706), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(7707) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 913, DateTimeKind.Utc).AddTicks(5832), new DateTime(2024, 12, 23, 15, 59, 52, 913, DateTimeKind.Utc).AddTicks(5976), "Documents" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3609), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3612) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3617), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3618) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3621), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3622), "Presentations" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3680), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3681), "Projects" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3698), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3699) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3702), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3703), "School" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3706), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3707) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3710), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3711), "Music" });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified", "Name" },
                values: new object[] { new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3716), new DateTime(2024, 12, 23, 15, 59, 52, 914, DateTimeKind.Utc).AddTicks(3717), "Books" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$1qAVos4/Te7UWtC0gztuh.IofeoIcUWsmqRQ9/5rBVvi5018Uwho2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$88MISb1vnvLTNlqGmu6wM..w2L/dE9n0be01vIOY3qrQVLLYiM3LO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$Ri0sdLqy8z9jUqyZ5ZVf9.NUNOlbj.UsKAhP9t8BS7.q9FuKwqdYC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$ARs9OaQVTdNhpg8a2pnwjuEWeXw/oBFGcjmv56kvwSk/Ymn9.HM6i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$YGlQ2RvY4Yzw65fH9X2xou.Y9iiKCAnr29LGp2ceLWaoh/pUgrTRG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$bJhKA11o0.l7d7odwFNkD.uJHhEzXEgUziuAiH0mybWLeoXaQcfh2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$sgRhDCNwAt/.R7KnmRnlwe6PQiS7f4PNUXkTNOWEH/MrVz6l0qVQW");
        }
    }
}
