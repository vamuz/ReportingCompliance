namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportingComplianceTable3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pReportingCompliance", "nitialReportDueDate", c => c.String(nullable: false));
            AlterColumn("dbo.pReportingCompliance", "PeriodicReportDueDate", c => c.Int(nullable: false));
            CreateIndex("dbo.pSubmissionDueDate", "ReportingComplianceId");
            AddForeignKey("dbo.pSubmissionDueDate", "ReportingComplianceId", "dbo.pReportingCompliance", "Id", cascadeDelete: true);
            DropColumn("dbo.pReportingCompliance", "InitialReportDueDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.pReportingCompliance", "InitialReportDueDate", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.pSubmissionDueDate", "ReportingComplianceId", "dbo.pReportingCompliance");
            DropIndex("dbo.pSubmissionDueDate", new[] { "ReportingComplianceId" });
            AlterColumn("dbo.pReportingCompliance", "PeriodicReportDueDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.pReportingCompliance", "nitialReportDueDate");
        }
    }
}
