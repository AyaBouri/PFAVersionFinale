using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PFAVersionFinale.Migrations
{
    /// <inheritdoc />
    public partial class PFAVersionFinale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImgPubs",
                columns: table => new
                {
                    ImgPubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Chemin = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImgPubs", x => x.ImgPubId);
                });

            migrationBuilder.CreateTable(
                name: "Inscriptions",
                columns: table => new
                {
                    InscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RepeatPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inscriptions", x => x.InscriptionId);
                });

            migrationBuilder.CreateTable(
                name: "Publications",
                columns: table => new
                {
                    PublicationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatePub = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypePublication = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImgPubId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publications", x => x.PublicationId);
                    table.ForeignKey(
                        name: "FK_Publications_ImgPubs_ImgPubId",
                        column: x => x.ImgPubId,
                        principalTable: "ImgPubs",
                        principalColumn: "ImgPubId");
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateEnvoie = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                });

            migrationBuilder.CreateTable(
                name: "PublicationUser",
                columns: table => new
                {
                    UsersUserId = table.Column<int>(type: "int", nullable: false),
                    publicationsPublicationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicationUser", x => new { x.UsersUserId, x.publicationsPublicationId });
                    table.ForeignKey(
                        name: "FK_PublicationUser_Publications_publicationsPublicationId",
                        column: x => x.publicationsPublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Rating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ServiceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Libelle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OuvrierUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ville = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    login = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirmPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateDerniereConnection = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InscriptionId = table.Column<int>(type: "int", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceId = table.Column<int>(type: "int", nullable: true),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    Client_VoteId = table.Column<int>(type: "int", nullable: true),
                    Client_PublicationId = table.Column<int>(type: "int", nullable: true),
                    OuvrierId = table.Column<int>(type: "int", nullable: true),
                    VoteId = table.Column<int>(type: "int", nullable: true),
                    PublicationId = table.Column<int>(type: "int", nullable: true),
                    WebMasterId = table.Column<int>(type: "int", nullable: true),
                    WebMaster_PublicationId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Inscriptions_InscriptionId",
                        column: x => x.InscriptionId,
                        principalTable: "Inscriptions",
                        principalColumn: "InscriptionId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Publications_Client_PublicationId",
                        column: x => x.Client_PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId");
                    table.ForeignKey(
                        name: "FK_Users_Publications_PublicationId",
                        column: x => x.PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId");
                    table.ForeignKey(
                        name: "FK_Users_Publications_WebMaster_PublicationId",
                        column: x => x.WebMaster_PublicationId,
                        principalTable: "Publications",
                        principalColumn: "PublicationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Services_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Services",
                        principalColumn: "ServiceId");
                });

            migrationBuilder.CreateTable(
                name: "Votes",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateVote = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NoteVote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientUserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Votes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_Votes_Users_ClientUserId",
                        column: x => x.ClientUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Publications_ImgPubId",
                table: "Publications",
                column: "ImgPubId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicationUser_publicationsPublicationId",
                table: "PublicationUser",
                column: "publicationsPublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_ClientId",
                table: "Reviews",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Services_OuvrierUserId",
                table: "Services",
                column: "OuvrierUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Client_PublicationId",
                table: "Users",
                column: "Client_PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_InscriptionId",
                table: "Users",
                column: "InscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_PublicationId",
                table: "Users",
                column: "PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_ServiceId",
                table: "Users",
                column: "ServiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_VoteId",
                table: "Users",
                column: "VoteId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_WebMaster_PublicationId",
                table: "Users",
                column: "WebMaster_PublicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Votes_ClientUserId",
                table: "Votes",
                column: "ClientUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_Users_UserId",
                table: "Messages",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PublicationUser_Users_UsersUserId",
                table: "PublicationUser",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reviews_Users_ClientId",
                table: "Reviews",
                column: "ClientId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Users_OuvrierUserId",
                table: "Services",
                column: "OuvrierUserId",
                principalTable: "Users",
                principalColumn: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Votes_VoteId",
                table: "Users",
                column: "VoteId",
                principalTable: "Votes",
                principalColumn: "VoteId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Services_Users_OuvrierUserId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Users_ClientUserId",
                table: "Votes");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "PublicationUser");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Inscriptions");

            migrationBuilder.DropTable(
                name: "Publications");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Votes");

            migrationBuilder.DropTable(
                name: "ImgPubs");
        }
    }
}
