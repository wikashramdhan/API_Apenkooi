using Microsoft.EntityFrameworkCore.Migrations;

namespace API_APENKOOI.Migrations
{
    public partial class IngredientTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_IngredientQuantity_IngredientId",
                table: "IngredientQuantity");

            migrationBuilder.DropIndex(
                name: "IX_IngredientQuantity_QuantityTypeId",
                table: "IngredientQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe",
                column: "RecipeTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantity_IngredientId",
                table: "IngredientQuantity",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantity_QuantityTypeId",
                table: "IngredientQuantity",
                column: "QuantityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe");

            migrationBuilder.DropIndex(
                name: "IX_IngredientQuantity_IngredientId",
                table: "IngredientQuantity");

            migrationBuilder.DropIndex(
                name: "IX_IngredientQuantity_QuantityTypeId",
                table: "IngredientQuantity");

            migrationBuilder.CreateIndex(
                name: "IX_Recipe_RecipeTypeId",
                table: "Recipe",
                column: "RecipeTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantity_IngredientId",
                table: "IngredientQuantity",
                column: "IngredientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IngredientQuantity_QuantityTypeId",
                table: "IngredientQuantity",
                column: "QuantityTypeId",
                unique: true);
        }
    }
}
