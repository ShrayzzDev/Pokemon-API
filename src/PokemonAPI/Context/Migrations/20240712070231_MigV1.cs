using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Context.Migrations
{
    /// <inheritdoc />
    public partial class MigV1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    SP_Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    SP_Defense = table.Column<int>(type: "INTEGER", nullable: false),
                    Special = table.Column<int>(type: "INTEGER", nullable: false),
                    Speed = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Typing = table.Column<string>(type: "TEXT", nullable: false),
                    PokemonEntityId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Name);
                    table.ForeignKey(
                        name: "FK_Types_Pokemons_PokemonEntityId",
                        column: x => x.PokemonEntityId,
                        principalTable: "Pokemons",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    TypeId = table.Column<string>(type: "TEXT", nullable: false),
                    Power = table.Column<int>(type: "INTEGER", nullable: false),
                    PP = table.Column<int>(type: "INTEGER", nullable: false),
                    Accuracy = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Moves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Moves_Types_TypeId",
                        column: x => x.TypeId,
                        principalTable: "Types",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovePool",
                columns: table => new
                {
                    LearningId = table.Column<int>(type: "INTEGER", nullable: false),
                    LearnedMoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    LearningLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovePool", x => new { x.LearningId, x.LearnedMoveId });
                    table.ForeignKey(
                        name: "FK_MovePool_Moves_LearnedMoveId",
                        column: x => x.LearnedMoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovePool_Pokemons_LearningId",
                        column: x => x.LearningId,
                        principalTable: "Pokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovePool_LearnedMoveId",
                table: "MovePool",
                column: "LearnedMoveId");

            migrationBuilder.CreateIndex(
                name: "IX_Moves_TypeId",
                table: "Moves",
                column: "TypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Types_PokemonEntityId",
                table: "Types",
                column: "PokemonEntityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovePool");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "Types");

            migrationBuilder.DropTable(
                name: "Pokemons");
        }
    }
}
