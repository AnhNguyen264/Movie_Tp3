﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TP2.Migrations
{
    public partial class updates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ObjectivesId",
                table: "Vendeurs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Commentaires",
                table: "Objectives",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "NbFimsVendus",
                table: "Objectives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VendeursId",
                table: "Objectives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Commentaires", "NbFimsVendus", "VendeursId" },
                values: new object[] { "Très bon", 150, 1 });

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Commentaires", "NbFimsVendus", "VendeursId" },
                values: new object[] { "Très bon", 100, 2 });

            migrationBuilder.UpdateData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Commentaires", "NbFimsVendus", "VendeursId" },
                values: new object[] { "Très bon", 120, 3 });

            migrationBuilder.InsertData(
                table: "Objectives",
                columns: new[] { "Id", "Commentaires", "NbFimsVendus", "NomObjective", "VendeursId" },
                values: new object[,]
                {
                    { 4, "Très bon", 180, "Ventes les films Juillet ", 1 },
                    { 5, "Très bon", 160, "Ventes les films Mai ", 2 },
                    { 6, "Très bon", 200, "Ventes les films Juin ", 3 }
                });

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ObjectivesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ObjectivesId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 3,
                column: "ObjectivesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 4,
                column: "ObjectivesId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 5,
                column: "ObjectivesId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Vendeurs",
                keyColumn: "Id",
                keyValue: 6,
                column: "ObjectivesId",
                value: 3);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Objectives",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DropColumn(
                name: "ObjectivesId",
                table: "Vendeurs");

            migrationBuilder.DropColumn(
                name: "Commentaires",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "NbFimsVendus",
                table: "Objectives");

            migrationBuilder.DropColumn(
                name: "VendeursId",
                table: "Objectives");
        }
    }
}
