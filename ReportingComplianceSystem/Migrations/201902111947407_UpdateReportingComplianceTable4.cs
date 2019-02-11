namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportingComplianceTable4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pReportingCompliance", "InitialReportDueDate", c => c.String(nullable: false));
            DropColumn("dbo.pReportingCompliance", "nitialReportDueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.pReportingCompliance", "nitialReportDueDate", c => c.String(nullable: false));
            DropColumn("dbo.pReportingCompliance", "InitialReportDueDate");
        }
    }
}
