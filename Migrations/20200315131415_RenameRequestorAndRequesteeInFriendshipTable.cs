using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace splitourbill_backend.Migrations
{
    public partial class RenameRequestorAndRequesteeInFriendshipTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requestee",
                schema: "backend",
                table: "friendships");

            migrationBuilder.DropColumn(
                name: "requestor",
                schema: "backend",
                table: "friendships");

            migrationBuilder.AddColumn<Guid>(
                name: "requestee_id",
                schema: "backend",
                table: "friendships",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "requestor_id",
                schema: "backend",
                table: "friendships",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "backend",
                table: "friendships",
                keyColumn: "id",
                keyValue: new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                columns: new[] { "requestee_id", "requestor_id" },
                values: new object[] { new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "requestee_id",
                schema: "backend",
                table: "friendships");

            migrationBuilder.DropColumn(
                name: "requestor_id",
                schema: "backend",
                table: "friendships");

            migrationBuilder.AddColumn<Guid>(
                name: "requestee",
                schema: "backend",
                table: "friendships",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "requestor",
                schema: "backend",
                table: "friendships",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                schema: "backend",
                table: "friendships",
                keyColumn: "id",
                keyValue: new Guid("709fb6ba-705a-449b-8060-d09626deca01"),
                columns: new[] { "requestee", "requestor" },
                values: new object[] { new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd") });
        }
    }
}
