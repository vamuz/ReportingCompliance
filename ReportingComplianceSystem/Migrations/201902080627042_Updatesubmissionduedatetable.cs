namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Updatesubmissionduedatetable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.pSubmissionDueDates", "ReportingComplianceId", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.pSubmissionDueDates", "ReportingComplianceId");
        }
    }
}
