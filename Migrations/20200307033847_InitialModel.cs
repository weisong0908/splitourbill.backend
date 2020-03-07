using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace splitourbill_backend.Migrations
{
    public partial class InitialModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "backend");

            migrationBuilder.CreateTable(
                name: "relationships",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    requestor = table.Column<Guid>(nullable: false),
                    requestee = table.Column<Guid>(nullable: false),
                    relationship_type = table.Column<string>(nullable: true),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationships", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    username = table.Column<string>(nullable: true),
                    email_address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "relationships",
                columns: new[] { "id", "relationship_type", "requestee", "requestor", "status" },
                values: new object[] { new Guid("709fb6ba-705a-449b-8060-d09626deca01"), "friend", new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), "accepted" });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "users",
                columns: new[] { "id", "email_address", "username" },
                values: new object[,]
                {
                    { new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), null, "User 1" },
                    { new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), null, "User 2" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relationships",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "users",
                schema: "backend");
        }
    }
}
