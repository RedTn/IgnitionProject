namespace AIAWebApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Quotes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Vehicles", "QuoteId", "dbo.Quotes");
            DropForeignKey("dbo.Drivers", "Id", "dbo.Vehicles");
            DropIndex("dbo.Drivers", new[] { "Id" });
            DropIndex("dbo.Drivers", new[] { "QuoteId" });
            DropIndex("dbo.Quotes", new[] { "UserId" });
            DropIndex("dbo.Vehicles", new[] { "QuoteId" });
            DropColumn("dbo.Drivers", "QuoteId");
            DropTable("dbo.Quotes");
            DropTable("dbo.Users");
            DropTable("dbo.Vehicles");
            DropTable("dbo.Rules");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Rules",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Scope = c.String(),
                        State = c.String(),
                        DiscountPercentage = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Make = c.String(),
                        Model = c.String(),
                        Year = c.Int(nullable: false),
                        Mileage = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CurrentValue = c.Int(nullable: false),
                        DaysDrivenPerWeek = c.Int(nullable: false),
                        Vin = c.String(),
                        AnnualMiles = c.Decimal(nullable: false, precision: 18, scale: 2),
                        HasDaytimeRunningLights = c.Boolean(nullable: false),
                        HasAntilockBrakingSystem = c.Boolean(nullable: false),
                        PassiveRestraints = c.Boolean(nullable: false),
                        AntiTheft = c.Boolean(nullable: false),
                        ReduceUse = c.Boolean(nullable: false),
                        GarageDifferent = c.Boolean(nullable: false),
                        QuoteId = c.Guid(nullable: false),
                        MilesDrivenToWork = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        CanUseSystem = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Quotes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        UserId = c.Int(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.String(),
                        SubmissionTime = c.DateTime(nullable: false),
                        State = c.String(),
                        MovingViolation = c.Boolean(nullable: false),
                        PreviousCarrier = c.String(),
                        ClaimInLastFive = c.Boolean(nullable: false),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        CustomerAddress = c.String(),
                        CustomerPhone = c.String(),
                        CustomerSsn = c.String(),
                        CustomerDob = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Drivers", "QuoteId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Vehicles", "QuoteId");
            CreateIndex("dbo.Quotes", "UserId");
            CreateIndex("dbo.Drivers", "QuoteId");
            CreateIndex("dbo.Drivers", "Id");
            AddForeignKey("dbo.Drivers", "Id", "dbo.Vehicles", "Id");
            AddForeignKey("dbo.Vehicles", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quotes", "UserId", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "QuoteId", "dbo.Quotes", "Id", cascadeDelete: true);
        }
    }
}
