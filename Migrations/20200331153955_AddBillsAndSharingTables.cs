using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace splitourbill_backend.Migrations
{
    public partial class AddBillsAndSharingTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "bill_sharings",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    sharer_id = table.Column<Guid>(nullable: false),
                    amount = table.Column<decimal>(nullable: false),
                    bill_id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bill_sharings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "bills",
                schema: "backend",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    initiator_id = table.Column<Guid>(nullable: false),
                    bill_purpose_id = table.Column<int>(nullable: false),
                    total_amount = table.Column<decimal>(nullable: false),
                    date_time = table.Column<DateTime>(nullable: false),
                    remarks = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bills", x => x.id);
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "bill_sharings",
                columns: new[] { "id", "amount", "bill_id", "sharer_id" },
                values: new object[,]
                {
                    { new Guid("e05ffb93-82ca-44fb-ab65-a4bdf415b237"), 3m, new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd") },
                    { new Guid("abdf45b0-3038-4659-a791-9b212528cc70"), 7m, new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"), new Guid("e1db792b-fce0-4355-a9bc-242fbf7232c6") }
                });

            migrationBuilder.InsertData(
                schema: "backend",
                table: "bills",
                columns: new[] { "id", "bill_purpose_id", "date_time", "initiator_id", "remarks", "total_amount" },
                values: new object[] { new Guid("9024c3c8-a3f8-4b09-9ae5-d44850d9f354"), 1, new DateTime(2020, 1, 20, 10, 20, 33, 0, DateTimeKind.Unspecified), new Guid("f8b784ae-9dea-48e2-8d81-20f9dcb532bd"), "no remarks", 10m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bill_sharings",
                schema: "backend");

            migrationBuilder.DropTable(
                name: "bills",
                schema: "backend");
        }
    }
}
