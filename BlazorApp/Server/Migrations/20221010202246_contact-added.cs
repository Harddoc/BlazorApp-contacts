using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Server.Migrations
{
    public partial class contactadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Contacts",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Mail", "Name", "SubCategoryId", "Surname", "Telepfone" },
                values: new object[] { "ofman.damian@gmail.com", "Damian", null, "Ofman", "504 288 656" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubCategoryId",
                value: null);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts");

            migrationBuilder.AlterColumn<int>(
                name: "SubCategoryId",
                table: "Contacts",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Mail", "Name", "SubCategoryId", "Surname", "Telepfone" },
                values: new object[] { "bob@test.pl", "Bob", 0, "", "+48 123 321 456" });

            migrationBuilder.UpdateData(
                table: "Contacts",
                keyColumn: "Id",
                keyValue: 2,
                column: "SubCategoryId",
                value: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_SubCategories_SubCategoryId",
                table: "Contacts",
                column: "SubCategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
