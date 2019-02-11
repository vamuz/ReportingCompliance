namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportingComplianceTable2 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.pArticles", newName: "pArticle");
            RenameTable(name: "dbo.pReportingCompliances", newName: "pReportingCompliance");
            RenameTable(name: "dbo.pSupervisoryBodies", newName: "pSupervisoryBody");
            RenameTable(name: "dbo.pTreaties", newName: "pTreaty");
            RenameTable(name: "dbo.pSubmissionDueDates", newName: "pSubmissionDueDate");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.pSubmissionDueDate", newName: "pSubmissionDueDates");
            RenameTable(name: "dbo.pTreaty", newName: "pTreaties");
            RenameTable(name: "dbo.pSupervisoryBody", newName: "pSupervisoryBodies");
            RenameTable(name: "dbo.pReportingCompliance", newName: "pReportingCompliances");
            RenameTable(name: "dbo.pArticle", newName: "pArticles");
        }
    }
}
