using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace splitourbill_backend.Migrations
{
    public partial class RenamedRelationshipsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "relationships",
                schema: "backend");

            migrationBuilder.CreateTable(
                name: "friendships",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    requestor = table.Column<Guid>(nullable: false),
                    requestee = table.Column<Guid>(nullable: false),
                    status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_friendships", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "friendships",
                columns: new[] { "id", "requestee", "requestor", "status" },
                values: new object[] { new Guid("709fb6ba-705a-449b-8060-d09626deca01"), new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), "accepted" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "friendships",
                schema: "backend");

            migrationBuilder.CreateTable(
                name: "relationships",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    relationship_type = table.Column<string>(type: "text", nullable: true),
                    requestee = table.Column<Guid>(type: "uuid", nullable: false),
                    requestor = table.Column<Guid>(type: "uuid", nullable: false),
                    status = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_relationships", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "relationships",
                columns: new[] { "id", "relationship_type", "requestee", "requestor", "status" },
                values: new object[] { new Guid("709fb6ba-705a-449b-8060-d09626deca01"), "friend", new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), "accepted" });
        }
    }
}
