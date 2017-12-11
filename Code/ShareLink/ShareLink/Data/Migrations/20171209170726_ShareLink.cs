using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShareLink.Data.Migrations
{
    public partial class ShareLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ShareLinkID",
                table: "Like",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "ShareLinkID",
                table: "Comment",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ShareLink",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Active = table.Column<string>(maxLength: 1, nullable: true),
                    Approved = table.Column<string>(maxLength: 1, nullable: true),
                    AuthorID = table.Column<string>(nullable: true),
                    CategoryID = table.Column<int>(nullable: false),
                    CreateDT = table.Column<DateTime>(nullable: true),
                    Description = table.Column<string>(maxLength: 200, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    Name = table.Column<string>(maxLength: 200, nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: true),
                    Slug = table.Column<string>(maxLength: 30, nullable: false),
                    Type = table.Column<int>(nullable: false),
                    UpdateDT = table.Column<DateTime>(nullable: true),
                    Views = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShareLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ShareLink_AspNetUsers_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ShareLink_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Like_ShareLinkID",
                table: "Like",
                column: "ShareLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ShareLinkID",
                table: "Comment",
                column: "ShareLinkID");

            migrationBuilder.CreateIndex(
                name: "IX_ShareLink_AuthorID",
                table: "ShareLink",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_ShareLink_CategoryID",
                table: "ShareLink",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_ShareLink_ShareLinkID",
                table: "Comment",
                column: "ShareLinkID",
                principalTable: "ShareLink",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_ShareLink_ShareLinkID",
                table: "Like",
                column: "ShareLinkID",
                principalTable: "ShareLink",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ShareLink_ShareLinkID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_ShareLink_ShareLinkID",
                table: "Like");

            migrationBuilder.DropTable(
                name: "ShareLink");

            migrationBuilder.DropIndex(
                name: "IX_Like_ShareLinkID",
                table: "Like");

            migrationBuilder.DropIndex(
                name: "IX_Comment_ShareLinkID",
                table: "Comment");

            migrationBuilder.DropColumn(
                name: "ShareLinkID",
                table: "Like");

            migrationBuilder.DropColumn(
                name: "ShareLinkID",
                table: "Comment");
        }
    }
}
