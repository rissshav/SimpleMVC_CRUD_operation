namespace PracticingMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Employee11 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employees", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Employees", "Desgination", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employees", "Desgination", c => c.String());
            AlterColumn("dbo.Employees", "Name", c => c.String());
        }
    }
}
