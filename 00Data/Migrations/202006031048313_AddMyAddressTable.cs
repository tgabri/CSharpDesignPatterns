namespace _00Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMyAddressTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MyAddresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MyAddresses");
        }
    }
}
