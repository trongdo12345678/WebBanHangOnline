namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateActive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_Category", "IsActived", c => c.Boolean(nullable: false));
            AddColumn("dbo.Tb_New", "IsActived", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Post", "IsActived", c => c.Boolean(nullable: false));
            AddColumn("dbo.tb_Product", "IsActived", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_Product", "IsActived");
            DropColumn("dbo.tb_Post", "IsActived");
            DropColumn("dbo.Tb_New", "IsActived");
            DropColumn("dbo.tb_Category", "IsActived");
        }
    }
}
