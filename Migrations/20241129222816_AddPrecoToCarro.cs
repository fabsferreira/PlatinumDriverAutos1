﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PlatinumDriverAutos.Migrations
{
    public partial class AddPrecoToCarro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Preco",
                table: "Carro",
                type: "decimal(65,30)",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Carro");
        }
    }
}
