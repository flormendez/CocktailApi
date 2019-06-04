using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CocktailRealApi.Migrations
{
    public partial class one : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cocktails",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Thumb = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cocktails", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cocktails_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IngredientsAndCocktailsRelation",
                columns: table => new
                {
                    CocktailId = table.Column<int>(nullable: false),
                    IngredientId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredientsAndCocktailsRelation", x => new { x.CocktailId, x.IngredientId });
                    table.ForeignKey(
                        name: "FK_IngredientsAndCocktailsRelation_Cocktails_CocktailId",
                        column: x => x.CocktailId,
                        principalTable: "Cocktails",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredientsAndCocktailsRelation_Ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Cocktail" },
                    { 101, "Beer" }
                });

            migrationBuilder.InsertData(
                table: "Ingredients",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 100, "Ingrediente 1" },
                    { 101, "Ingrediente 2" }
                });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 100, 100, "How To Make it", "Cocktail Name 1", "Image/URL" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 101, 100, "How To Make it", "Cocktail Name 2", "Image/URL" });

            migrationBuilder.InsertData(
                table: "Cocktails",
                columns: new[] { "Id", "CategoryId", "Instructions", "Name", "Thumb" },
                values: new object[] { 102, 100, "How To Make it", "Cocktail Name 3", "Image/URL" });

            migrationBuilder.InsertData(
                table: "IngredientsAndCocktailsRelation",
                columns: new[] { "CocktailId", "IngredientId" },
                values: new object[] { 100, 100 });

            migrationBuilder.InsertData(
                table: "IngredientsAndCocktailsRelation",
                columns: new[] { "CocktailId", "IngredientId" },
                values: new object[] { 100, 101 });

            migrationBuilder.CreateIndex(
                name: "IX_Cocktails_CategoryId",
                table: "Cocktails",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientsAndCocktailsRelation_IngredientId",
                table: "IngredientsAndCocktailsRelation",
                column: "IngredientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IngredientsAndCocktailsRelation");

            migrationBuilder.DropTable(
                name: "Cocktails");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
