namespace FinalElectron.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addsubtitleBlog : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "SubTitle", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Blogs", "Title", c => c.String(nullable: false, maxLength: 200));
            DropColumn("dbo.Blogs", "SubTitle");
        }
    }
}
