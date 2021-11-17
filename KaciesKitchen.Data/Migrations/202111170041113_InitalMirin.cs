namespace KaciesKitchen.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitalMirin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Ingredient", "PricePerUnit", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Recipe", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Recipe", "DateCreated", c => c.DateTimeOffset(nullable: false, precision: 7));
            AlterColumn("dbo.Recipe", "LastUpdated", c => c.DateTimeOffset(precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipe", "LastUpdated", c => c.DateTime());
            AlterColumn("dbo.Recipe", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Recipe", "Cost", c => c.Double(nullable: false));
            AlterColumn("dbo.Ingredient", "PricePerUnit", c => c.Double(nullable: false));
        }
    }
}
