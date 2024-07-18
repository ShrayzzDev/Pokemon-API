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
                name: "SimplePokemons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Discriminator = table.Column<string>(type: "TEXT", maxLength: 34, nullable: false),
                    HP = table.Column<int>(type: "INTEGER", nullable: true),
                    Attack = table.Column<int>(type: "INTEGER", nullable: true),
                    Defense = table.Column<int>(type: "INTEGER", nullable: true),
                    SP_Attack = table.Column<int>(type: "INTEGER", nullable: true),
                    SP_Defense = table.Column<int>(type: "INTEGER", nullable: true),
                    Special = table.Column<int>(type: "INTEGER", nullable: true),
                    Speed = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimplePokemons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Types",
                columns: table => new
                {
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Typing = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Types", x => x.Name);
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
                name: "PokemonWithoutMovesEntityTypeEntity",
                columns: table => new
                {
                    PokemonsId = table.Column<int>(type: "INTEGER", nullable: false),
                    TypesName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokemonWithoutMovesEntityTypeEntity", x => new { x.PokemonsId, x.TypesName });
                    table.ForeignKey(
                        name: "FK_PokemonWithoutMovesEntityTypeEntity_SimplePokemons_PokemonsId",
                        column: x => x.PokemonsId,
                        principalTable: "SimplePokemons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PokemonWithoutMovesEntityTypeEntity_Types_TypesName",
                        column: x => x.TypesName,
                        principalTable: "Types",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TypeEfficiencies",
                columns: table => new
                {
                    DamagingId = table.Column<string>(type: "TEXT", nullable: false),
                    TargetId = table.Column<string>(type: "TEXT", nullable: false),
                    Coefficient = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeEfficiencies", x => new { x.DamagingId, x.TargetId });
                    table.ForeignKey(
                        name: "FK_TypeEfficiencies_Types_DamagingId",
                        column: x => x.DamagingId,
                        principalTable: "Types",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TypeEfficiencies_Types_TargetId",
                        column: x => x.TargetId,
                        principalTable: "Types",
                        principalColumn: "Name",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovePool",
                columns: table => new
                {
                    LearningId = table.Column<int>(type: "INTEGER", nullable: false),
                    Generation = table.Column<int>(type: "INTEGER", nullable: false),
                    LearnedMoveId = table.Column<int>(type: "INTEGER", nullable: false),
                    LearningLevel = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovePool", x => new { x.LearningId, x.LearnedMoveId, x.Generation });
                    table.ForeignKey(
                        name: "FK_MovePool_Moves_LearnedMoveId",
                        column: x => x.LearnedMoveId,
                        principalTable: "Moves",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovePool_SimplePokemons_LearningId",
                        column: x => x.LearningId,
                        principalTable: "SimplePokemons",
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
                name: "IX_PokemonWithoutMovesEntityTypeEntity_TypesName",
                table: "PokemonWithoutMovesEntityTypeEntity",
                column: "TypesName");

            migrationBuilder.CreateIndex(
                name: "IX_TypeEfficiencies_TargetId",
                table: "TypeEfficiencies",
                column: "TargetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovePool");

            migrationBuilder.DropTable(
                name: "PokemonWithoutMovesEntityTypeEntity");

            migrationBuilder.DropTable(
                name: "TypeEfficiencies");

            migrationBuilder.DropTable(
                name: "Moves");

            migrationBuilder.DropTable(
                name: "SimplePokemons");

            migrationBuilder.DropTable(
                name: "Types");
        }
    }
}
