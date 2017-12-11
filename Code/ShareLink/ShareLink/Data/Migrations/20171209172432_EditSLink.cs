using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShareLink.Data.Migrations
{
    public partial class EditSLink : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_ShareLink_ShareLinkID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_ShareLink_ShareLinkID",
                table: "Like");

            migrationBuilder.DropTable(
                name: "ShareLink");

            migrationBuilder.RenameColumn(
                name: "ShareLinkID",
                table: "Like",
                newName: "SLinkID");

            migrationBuilder.RenameIndex(
                name: "IX_Like_ShareLinkID",
                table: "Like",
                newName: "IX_Like_SLinkID");

            migrationBuilder.RenameColumn(
                name: "ShareLinkID",
                table: "Comment",
                newName: "SLinkID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_ShareLinkID",
                table: "Comment",
                newName: "IX_Comment_SLinkID");

            migrationBuilder.CreateTable(
                name: "SLink",
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
                    table.PrimaryKey("PK_SLink", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SLink_AspNetUsers_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SLink_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SLink_AuthorID",
                table: "SLink",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_SLink_CategoryID",
                table: "SLink",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_SLink_SLinkID",
                table: "Comment",
                column: "SLinkID",
                principalTable: "SLink",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Like_SLink_SLinkID",
                table: "Like",
                column: "SLinkID",
                principalTable: "SLink",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_SLink_SLinkID",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Like_SLink_SLinkID",
                table: "Like");

            migrationBuilder.DropTable(
                name: "SLink");

            migrationBuilder.RenameColumn(
                name: "SLinkID",
                table: "Like",
                newName: "ShareLinkID");

            migrationBuilder.RenameIndex(
                name: "IX_Like_SLinkID",
                table: "Like",
                newName: "IX_Like_ShareLinkID");

            migrationBuilder.RenameColumn(
                name: "SLinkID",
                table: "Comment",
                newName: "ShareLinkID");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_SLinkID",
                table: "Comment",
                newName: "IX_Comment_ShareLinkID");

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
    }
}
