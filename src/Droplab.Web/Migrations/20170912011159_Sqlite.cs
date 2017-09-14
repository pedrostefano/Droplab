using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Droplab.Web.Migrations
{
    public partial class Sqlite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_STATE",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_STATE", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_ORDER",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    StateId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ORDER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ORDER_T_STATE_StateId",
                        column: x => x.StateId,
                        principalTable: "T_STATE",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "T_ORDER_ITEM",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    OrderId = table.Column<long>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ORDER_ITEM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_ORDER_ITEM_T_ORDER_OrderId",
                        column: x => x.OrderId,
                        principalTable: "T_ORDER",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_ORDER_StateId",
                table: "T_ORDER",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ORDER_ITEM_OrderId",
                table: "T_ORDER_ITEM",
                column: "OrderId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_ORDER_ITEM");

            migrationBuilder.DropTable(
                name: "T_ORDER");

            migrationBuilder.DropTable(
                name: "T_STATE");
        }
    }
}
