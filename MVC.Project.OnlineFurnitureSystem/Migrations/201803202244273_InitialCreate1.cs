namespace MVC.Project.OnlineFurnitureSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.tblProducts", "New");
            DropColumn("dbo.tblProducts", "QuantityInStock");
            DropColumn("dbo.tblProducts", "Discount");
            DropColumn("dbo.tblProducts", "Style");
            DropColumn("dbo.tblProducts", "Likes");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblProducts", "Likes", c => c.Int());
            AddColumn("dbo.tblProducts", "Style", c => c.String(maxLength: 50));
            AddColumn("dbo.tblProducts", "Discount", c => c.Int());
            AddColumn("dbo.tblProducts", "QuantityInStock", c => c.Int());
            AddColumn("dbo.tblProducts", "New", c => c.Boolean());
        }
    }
}
