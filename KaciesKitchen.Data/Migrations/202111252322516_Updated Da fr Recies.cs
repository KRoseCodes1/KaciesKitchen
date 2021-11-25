namespace KaciesKitchen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDafrRecies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.IngredientListDict",
                c => new
                    {
                        IngredientName = c.String(nullable: false, maxLength: 128),
                        AmountNeeded = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Recipe_RecipeId = c.Int(),
                    })
                .PrimaryKey(t => t.IngredientName)
                .ForeignKey("dbo.Recipe", t => t.Recipe_RecipeId)
                .Index(t => t.Recipe_RecipeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IngredientListDict", "Recipe_RecipeId", "dbo.Recipe");
            DropIndex("dbo.IngredientListDict", new[] { "Recipe_RecipeId" });
            DropTable("dbo.IngredientListDict");
        }
    }
}
