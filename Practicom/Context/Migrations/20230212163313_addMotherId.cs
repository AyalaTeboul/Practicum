using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class addMotherId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HMOs",
                columns: table => new
                {
                    HMOId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HMOName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HMOs", x => x.HMOId);
                });

            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    personId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    firstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    lastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    HMOid = table.Column<int>(type: "int", nullable: true),
                    idNumber = table.Column<string>(type: "nchar(9)", fixedLength: true, maxLength: 9, nullable: true),
                    dateOfBirth = table.Column<DateTime>(type: "date", nullable: true),
                    MaleOrFemale = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.personId);
                    table.ForeignKey(
                        name: "FK_Persons_HMOs",
                        column: x => x.HMOid,
                        principalTable: "HMOs",
                        principalColumn: "HMOId");
                });

            migrationBuilder.CreateTable(
                name: "FatherAndChild",
                columns: table => new
                {
                    FatherAndChildId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fatherId = table.Column<int>(type: "int", nullable: true),
                    motherId = table.Column<int>(type: "int", nullable: true),
                    childId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FatherAndChild", x => x.FatherAndChildId);
                    table.ForeignKey(
                        name: "FK_FatherAndChild_Persons",
                        column: x => x.fatherId,
                        principalTable: "Persons",
                        principalColumn: "personId");
                    table.ForeignKey(
                        name: "FK_FatherAndChild_Persons1",
                        column: x => x.childId,
                        principalTable: "Persons",
                        principalColumn: "personId");
                    table.ForeignKey(
                        name: "FK_FatherAndChild_Persons2",
                        column: x => x.motherId,
                        principalTable: "Persons",
                        principalColumn: "personId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndChild_childId",
                table: "FatherAndChild",
                column: "childId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndChild_fatherId",
                table: "FatherAndChild",
                column: "fatherId");

            migrationBuilder.CreateIndex(
                name: "IX_FatherAndChild_motherId",
                table: "FatherAndChild",
                column: "motherId");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_HMOid",
                table: "Persons",
                column: "HMOid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FatherAndChild");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "HMOs");
        }
    }
}
