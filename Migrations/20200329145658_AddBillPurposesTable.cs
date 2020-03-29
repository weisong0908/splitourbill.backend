using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace splitourbill_backend.Migrations
{
    public partial class AddBillPurposesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bill_purposes",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(nullable: true),
                    category = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill_purposes", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "bill_purposes",
                columns: new[] { "id", "category", "name" },
                values: new object[,]
                {
                    { 1, "Meal", "Breakfast" },
                    { 2, "Meal", "Lunch" },
                    { 3, "Meal", "Dinner" },
                    { 4, "Meal", "Supper" },
                    { 5, "Meal", "Snack" },
                    { 6, "Meal", "Drink" },
                    { 7, "Meal", "Brunch" },
                    { 8, "Activity", "Movie" },
                    { 9, "Activity", "Sing K" },
                    { 10, "Activity", "Workout" },
                    { 11, "Event", "Wedding" },
                    { 12, "Event", "Songka" },
                    { 13, "Other", "Other" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill_purposes",
                schema: "backend");
        }
    }
}
