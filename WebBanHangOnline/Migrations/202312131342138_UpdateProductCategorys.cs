namespace WebBanHangOnline.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateProductCategorys : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tb_ProductCategory", "SeoTitle", c => c.String(maxLength: 150));
            AddColumn("dbo.tb_ProductCategory", "SeoDescripton", c => c.String(maxLength: 250));
            AddColumn("dbo.tb_ProductCategory", "SeoKeywords", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.tb_ProductCategory", "SeoKeywords");
            DropColumn("dbo.tb_ProductCategory", "SeoDescripton");
            DropColumn("dbo.tb_ProductCategory", "SeoTitle");
        }
    }
}
