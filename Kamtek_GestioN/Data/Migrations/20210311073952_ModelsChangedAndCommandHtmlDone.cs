using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kamtek_GestioN.Data.Migrations
{
    public partial class ModelsChangedAndCommandHtmlDone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commande_Utilisateurs_UtilisateurId",
                table: "Commande");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneCommande_Articles_ArticleId",
                table: "LigneCommande");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneCommande_Commande_CommandeId",
                table: "LigneCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigneCommande",
                table: "LigneCommande");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commande",
                table: "Commande");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "LigneCommande");

            migrationBuilder.RenameTable(
                name: "LigneCommande",
                newName: "LigneCommandes");

            migrationBuilder.RenameTable(
                name: "Commande",
                newName: "Commandes");

            migrationBuilder.RenameIndex(
                name: "IX_LigneCommande_CommandeId",
                table: "LigneCommandes",
                newName: "IX_LigneCommandes_CommandeId");

            migrationBuilder.RenameIndex(
                name: "IX_LigneCommande_ArticleId",
                table: "LigneCommandes",
                newName: "IX_LigneCommandes_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Commande_UtilisateurId",
                table: "Commandes",
                newName: "IX_Commandes_UtilisateurId");

            migrationBuilder.AddColumn<string>(
                name: "LigneId",
                table: "LigneCommandes",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateCreated",
                table: "LigneCommandes",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "LigneCommandes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigneCommandes",
                table: "LigneCommandes",
                column: "LigneId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commandes_Utilisateurs_UtilisateurId",
                table: "Commandes",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneCommandes_Articles_ArticleId",
                table: "LigneCommandes",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneCommandes_Commandes_CommandeId",
                table: "LigneCommandes",
                column: "CommandeId",
                principalTable: "Commandes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commandes_Utilisateurs_UtilisateurId",
                table: "Commandes");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneCommandes_Articles_ArticleId",
                table: "LigneCommandes");

            migrationBuilder.DropForeignKey(
                name: "FK_LigneCommandes_Commandes_CommandeId",
                table: "LigneCommandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LigneCommandes",
                table: "LigneCommandes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Commandes",
                table: "Commandes");

            migrationBuilder.DropColumn(
                name: "LigneId",
                table: "LigneCommandes");

            migrationBuilder.DropColumn(
                name: "DateCreated",
                table: "LigneCommandes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LigneCommandes");

            migrationBuilder.RenameTable(
                name: "LigneCommandes",
                newName: "LigneCommande");

            migrationBuilder.RenameTable(
                name: "Commandes",
                newName: "Commande");

            migrationBuilder.RenameIndex(
                name: "IX_LigneCommandes_CommandeId",
                table: "LigneCommande",
                newName: "IX_LigneCommande_CommandeId");

            migrationBuilder.RenameIndex(
                name: "IX_LigneCommandes_ArticleId",
                table: "LigneCommande",
                newName: "IX_LigneCommande_ArticleId");

            migrationBuilder.RenameIndex(
                name: "IX_Commandes_UtilisateurId",
                table: "Commande",
                newName: "IX_Commande_UtilisateurId");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "LigneCommande",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LigneCommande",
                table: "LigneCommande",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Commande",
                table: "Commande",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Commande_Utilisateurs_UtilisateurId",
                table: "Commande",
                column: "UtilisateurId",
                principalTable: "Utilisateurs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneCommande_Articles_ArticleId",
                table: "LigneCommande",
                column: "ArticleId",
                principalTable: "Articles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LigneCommande_Commande_CommandeId",
                table: "LigneCommande",
                column: "CommandeId",
                principalTable: "Commande",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
