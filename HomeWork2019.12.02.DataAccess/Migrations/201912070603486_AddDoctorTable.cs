namespace HomeWork2019._12._02.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDoctorTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Specialist = c.String(),
                        SpecialistFullName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Diseases", "Doctor_Id", c => c.Int());
            CreateIndex("dbo.Diseases", "Doctor_Id");
            AddForeignKey("dbo.Diseases", "Doctor_Id", "dbo.Doctors", "Id");
            DropColumn("dbo.Diseases", "Specialist");
            DropColumn("dbo.Diseases", "SpecialistFullName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Diseases", "SpecialistFullName", c => c.String());
            AddColumn("dbo.Diseases", "Specialist", c => c.String());
            DropForeignKey("dbo.Diseases", "Doctor_Id", "dbo.Doctors");
            DropIndex("dbo.Diseases", new[] { "Doctor_Id" });
            DropColumn("dbo.Diseases", "Doctor_Id");
            DropTable("dbo.Doctors");
        }
    }
}
