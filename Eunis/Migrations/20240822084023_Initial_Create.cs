using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Eunis.Migrations
{
    /// <inheritdoc />
    public partial class Initial_Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Credentials",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClientId = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    Code = table.Column<string>(type: "text", nullable: true),
                    Username = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    Password = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    SecretKey = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    Actions = table.Column<string>(type: "text", maxLength: 2147483647, nullable: false),
                    PostedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Credentials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Settings",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ParamName = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    ParamValue = table.Column<string>(type: "text", nullable: true),
                    PostedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Settings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestType = table.Column<string>(type: "text", nullable: true),
                    CredentialsId = table.Column<long>(type: "bigint", nullable: false),
                    ClientId = table.Column<string>(type: "text", nullable: false),
                    RequestId = table.Column<string>(type: "text", nullable: false),
                    Particulars = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    BeneficiaryAccount = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    BeneficiaryName = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: false),
                    MobileNumber = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric(9,2)", precision: 9, scale: 2, nullable: false),
                    Network = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Destination = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    StatusCode = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    VendorMessage = table.Column<string>(type: "character varying(225)", maxLength: 225, nullable: false),
                    VendorReference = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PostedOn = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transactions_Credentials_CredentialsId",
                        column: x => x.CredentialsId,
                        principalTable: "Credentials",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_CredentialsId",
                table: "Transactions",
                column: "CredentialsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Settings");

            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Credentials");
        }
    }
}
