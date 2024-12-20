using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class ModifiedInitial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3674), new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3811) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3987), new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3987) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3989), new DateTime(2024, 12, 20, 18, 17, 59, 891, DateTimeKind.Utc).AddTicks(3989) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(7956), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8289) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8613), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8614) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8617), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8618) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8621), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8622) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8625), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8642) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8651), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8652) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8655), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8656) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8660), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8661) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8664), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8665) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8669), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8674), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8678), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8679) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8682), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8683) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8687), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(8688) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 889, DateTimeKind.Utc).AddTicks(5178), new DateTime(2024, 12, 20, 18, 17, 59, 889, DateTimeKind.Utc).AddTicks(5356) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3602), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3642), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3643) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3647), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3647) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3650), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3651) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3671), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3672) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3675), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3676) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3679), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3680) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3683), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3684) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3688), new DateTime(2024, 12, 20, 18, 17, 59, 890, DateTimeKind.Utc).AddTicks(3689) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$7enc27iN8Rrx9Ynv0dsMP.hQ3kK7vNhDYhlPJAJrxcF3uvv44NZuK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$VKWW59x8jaHEXjU/gvjYluNgPsumZjCcjp9y8eQRZ3h8vAs5RjYEa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$xXGyq.6Zlxoci1//0KtKrOAs/EoAIK9y/UMXv9Rhx/Oo9j8HCbXvu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$FojcW/l1qyJpK/8eIWcfQe7R3FCtAGdCwA9PMgFPfdo/FVkJDu.zS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$V6bK6/ZMPqdX44fRdcSQd.tGybjqcR1D5OKLs5tUGPO5x.01Us1VG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$NmogTCFxNXX5Ky7fAxFhzek5/.wrmh8Fi/oi0Kz.8/VvhpMzY6hBe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$O1fGG48l/aiWECOk8S1oJ.4DYgSmp/S4uqP/GlV6YSD/QIYXkFN82");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6103), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6245) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6508), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6510), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(6511) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3408), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3549) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3692), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3692) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3694), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3694) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3695), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3696) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3697), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3697) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3701), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3701) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3702), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3703) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3704), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3704) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3706), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3706) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3708), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3722) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3723), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3723) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3725), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3725) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3726), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3727) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3728), new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(3728) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(1696), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2170), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2174), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2175), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2192), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2197), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2198), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2199), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2200), null });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 20, 18, 6, 51, 248, DateTimeKind.Utc).AddTicks(2203), null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$byjN71wBKBnpoU34h9mY4.riZazqE7vxkt5Dt2al47KVV0AN4/By6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$6xMXyai0wDPPDlrP7jWnieBR10RRG1EjI3XunoS3pRlz03Im97PWe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$HvlhvG9IS.C0CN0S9Mc.IunTwJtcoKvxkiCHZrGp3Ltn9HfHDbg56");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$/JQoX5byAzaLBBq3ux9zBetRjo4AfXcnm5/VYobg7WxKk5pKs06oC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$bnaqTkYciYvp/CKqATkNBOOwvyCNbLjp.qSZ8f/.8kMLEqO0KBePq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$7hkFw833iXF0BMG5DDbJY.EtadEJ4mobd82f2JYEtAvbzGDeKqUmu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$BurPptzWXO2Iu6pWk4Cu6Oac9.VMs8Nxjbl1kkFqwjfITEpfHiaYy");
        }
    }
}
