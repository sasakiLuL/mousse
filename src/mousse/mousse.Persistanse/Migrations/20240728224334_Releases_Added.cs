using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace mousse.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Releases_Added : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AudioBlobId",
                table: "Tracks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoverBlobId",
                table: "Tracks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ReleasePlaylistId",
                table: "Tracks",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "CoverId",
                table: "Playlists",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "TrackUser",
                columns: table => new
                {
                    ArtistsId = table.Column<Guid>(type: "uuid", nullable: false),
                    TrackId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrackUser", x => new { x.ArtistsId, x.TrackId });
                    table.ForeignKey(
                        name: "FK_TrackUser_Tracks_TrackId",
                        column: x => x.TrackId,
                        principalTable: "Tracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TrackUser_Users_ArtistsId",
                        column: x => x.ArtistsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tracks_ReleasePlaylistId",
                table: "Tracks",
                column: "ReleasePlaylistId");

            migrationBuilder.CreateIndex(
                name: "IX_TrackUser_TrackId",
                table: "TrackUser",
                column: "TrackId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tracks_Playlists_ReleasePlaylistId",
                table: "Tracks",
                column: "ReleasePlaylistId",
                principalTable: "Playlists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tracks_Playlists_ReleasePlaylistId",
                table: "Tracks");

            migrationBuilder.DropTable(
                name: "TrackUser");

            migrationBuilder.DropIndex(
                name: "IX_Tracks_ReleasePlaylistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "AudioBlobId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "CoverBlobId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "ReleasePlaylistId",
                table: "Tracks");

            migrationBuilder.DropColumn(
                name: "CoverId",
                table: "Playlists");
        }
    }
}
