using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFramework.Data3.Migrations
{
    public partial class AdicionandoOutrasTabelasRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LookingForId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RelationshipStatusId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlContent",
                table: "Posts",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DatePublish = table.Column<DateTime>(nullable: false),
                    Text = table.Column<string>(maxLength: 600, nullable: false),
                    UserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comments_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EducationalInstitutions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    GradYear = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalInstitutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationalInstitutions_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Friends",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserFriendId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friends", x => new { x.UserId, x.UserFriendId });
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserFriendId",
                        column: x => x.UserFriendId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friends_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LookingFor",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LookingFor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkPlaces",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    DateAdmission = table.Column<DateTime>(nullable: false),
                    DateOut = table.Column<DateTime>(nullable: true),
                    CurrentCompany = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkPlaces", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkPlaces_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "LookingFor",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "NotSpecified" },
                    { 2, "Dating" },
                    { 3, "Friefriendship" },
                    { 4, "SeriousRelationship" }
                });

            migrationBuilder.InsertData(
                table: "RelationshipStatus",
                columns: new[] { "Id", "Description" },
                values: new object[,]
                {
                    { 1, "NotSpecified" },
                    { 2, "Single" },
                    { 3, "Married" },
                    { 4, "InSeriousRelationship" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_LookingForId",
                table: "Users",
                column: "LookingForId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RelationshipStatusId",
                table: "Users",
                column: "RelationshipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_EducationalInstitutions_UserId",
                table: "EducationalInstitutions",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Friends_UserFriendId",
                table: "Friends",
                column: "UserFriendId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkPlaces_UserId",
                table: "WorkPlaces",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_LookingFor_LookingForId",
                table: "Users",
                column: "LookingForId",
                principalTable: "LookingFor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_RelationshipStatus_RelationshipStatusId",
                table: "Users",
                column: "RelationshipStatusId",
                principalTable: "RelationshipStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_LookingFor_LookingForId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_RelationshipStatus_RelationshipStatusId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "EducationalInstitutions");

            migrationBuilder.DropTable(
                name: "Friends");

            migrationBuilder.DropTable(
                name: "LookingFor");

            migrationBuilder.DropTable(
                name: "WorkPlaces");

            migrationBuilder.DropIndex(
                name: "IX_Users_LookingForId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RelationshipStatusId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "RelationshipStatus",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "LookingForId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RelationshipStatusId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UrlContent",
                table: "Posts");
        }
    }
}
