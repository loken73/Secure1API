namespace Secure1API.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserOnly : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Appointments", name: "UserId", newName: "User_Id");
            RenameIndex(table: "dbo.Appointments", name: "IX_UserId", newName: "IX_User_Id");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Appointments", name: "IX_User_Id", newName: "IX_UserId");
            RenameColumn(table: "dbo.Appointments", name: "User_Id", newName: "UserId");
        }
    }
}
