namespace CDVWebApiv6.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migracja2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Image = c.Binary(),
                        Price = c.Double(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Products");
        }
    }
}
