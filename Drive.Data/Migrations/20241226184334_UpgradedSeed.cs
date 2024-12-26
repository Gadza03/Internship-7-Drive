using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Drive.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpgradedSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2340), new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2479) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2657), new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2657) });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2658), new DateTime(2024, 12, 26, 18, 43, 34, 18, DateTimeKind.Utc).AddTicks(2659) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9615), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9904), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9904) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9906), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9906) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9907), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9919) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9921), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9921) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9925), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9925) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9927), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9927) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9951), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9952) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9953), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9954) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9956), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9956) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9958), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9958) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9959), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9960) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9961), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9962) });

            migrationBuilder.UpdateData(
                table: "Files",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "CreatedAt", "LastModifiedAt" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9963), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(9963) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 16, DateTimeKind.Utc).AddTicks(8631), new DateTime(2024, 12, 26, 18, 43, 34, 16, DateTimeKind.Utc).AddTicks(8773) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6881), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6884) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6886), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6887) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6889), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6889) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6891), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6891) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6905), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6905) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6907), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6907) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6909), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6909) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6911), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(6911) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(7499), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(7500) });

            migrationBuilder.InsertData(
                table: "Folders",
                columns: new[] { "Id", "CreatedAt", "LastModified", "Name", "OwnerId", "ParentFolderId" },
                values: new object[] { 11, new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(7512), new DateTime(2024, 12, 26, 18, 43, 34, 17, DateTimeKind.Utc).AddTicks(7512), "Root", 7, null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "$2a$11$CsWrHfXzGs9JQ1ti2otxzuF7NjRB8ndiGt0ecH79hQskPpvfosiUi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "$2a$11$UVhipVsytwcmRmH4cN77jubd3kv48v9qXZp9vcYNmxdd6FEao7RHC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "PasswordHash",
                value: "$2a$11$G/oj.3m3eeB/G/JPQbbYheTJeB/cwgnhD8.hult5bh0r/exXah45K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "PasswordHash",
                value: "$2a$11$PxT7.VL8WXNiTZmY.3OiA.cPzUk1aXzyx0O.Cgif7l6ajBUKJEq.m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "PasswordHash",
                value: "$2a$11$dQIp7iEbITK1HAsTfgn2..9Y8BG4V2QHyJnSqt/IMxbjjiQtCdnIC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "PasswordHash",
                value: "$2a$11$DK4I14Hylh8yA3fAmDpUdeY0Y44MQD3IvFJysFpNu2YNJsp7LSpny");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "PasswordHash",
                value: "$2a$11$CnGw5WKxs/PssETCfEp4/eLgdk6/24Hvw.AWLAo/rcSgms1Z1PWU2");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 11);

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
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 905, DateTimeKind.Utc).AddTicks(6672), new DateTime(2024, 12, 26, 17, 6, 21, 905, DateTimeKind.Utc).AddTicks(6829) });

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
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8920), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8921) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8924), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8925) });

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
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8949), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8950) });

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
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8957), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(8958) });

            migrationBuilder.UpdateData(
                table: "Folders",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedAt", "LastModified" },
                values: new object[] { new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(9546), new DateTime(2024, 12, 26, 17, 6, 21, 907, DateTimeKind.Utc).AddTicks(9548) });

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
    }
}
