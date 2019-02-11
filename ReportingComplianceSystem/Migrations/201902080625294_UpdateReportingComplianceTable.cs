namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportingComplianceTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Articles", newName: "pArticles");
            DropForeignKey("dbo.ReportingCompliances", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.ReportingCompliances", "SubmissionDueDateId", "dbo.SubmissionDueDates");
            DropForeignKey("dbo.ReportingCompliances", "SupervisoryBodyId", "dbo.SupervisoryBodies");
            DropForeignKey("dbo.ReportingCompliances", "TreatyId", "dbo.Treaties");
            DropIndex("dbo.ReportingCompliances", new[] { "TreatyId" });
            DropIndex("dbo.ReportingCompliances", new[] { "SupervisoryBodyId" });
            DropIndex("dbo.ReportingCompliances", new[] { "ArticleId" });
            DropIndex("dbo.ReportingCompliances", new[] { "SubmissionDueDateId" });
            CreateTable(
                "dbo.pReportingCompliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreatyId = c.Int(nullable: false),
                        SupervisoryBodyId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        InitialReportDueDate = c.DateTime(nullable: false),
                        PeriodicReportDueDate = c.DateTime(nullable: false),
                        GeneralComments = c.String(maxLength: 150),
                        pArticle_Id = c.Int(),
                        pSupervisoryBody_Id = c.Int(),
                        pTreaty_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.pArticles", t => t.pArticle_Id)
                .ForeignKey("dbo.pSupervisoryBodies", t => t.pSupervisoryBody_Id)
                .ForeignKey("dbo.pTreaties", t => t.pTreaty_Id)
                .Index(t => t.pArticle_Id)
                .Index(t => t.pSupervisoryBody_Id)
                .Index(t => t.pTreaty_Id);
            
            CreateTable(
                "dbo.pSupervisoryBodies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SupervisoryBodyName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.pTreaties",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreatyName = c.String(nullable: false, maxLength: 150),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.pSubmissionDueDates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DueDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AlterColumn("dbo.pArticles", "ArticleName", c => c.String(nullable: false, maxLength: 150));
            DropTable("dbo.ReportingCompliances");
            DropTable("dbo.SubmissionDueDates");
            DropTable("dbo.SupervisoryBodies");
            DropTable("dbo.Treaties");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Treaties",
                c => new
                    {
                        TreatyId = c.Int(nullable: false, identity: true),
                        TreatyName = c.String(),
                    })
                .PrimaryKey(t => t.TreatyId);
            
            CreateTable(
                "dbo.SupervisoryBodies",
                c => new
                    {
                        SupervisoryBodyId = c.Int(nullable: false, identity: true),
                        SupervisoryBodyName = c.String(),
                    })
                .PrimaryKey(t => t.SupervisoryBodyId);
            
            CreateTable(
                "dbo.SubmissionDueDates",
                c => new
                    {
                        SubmissionDueDateId = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SubmissionDueDateId);
            
            CreateTable(
                "dbo.ReportingCompliances",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TreatyId = c.Int(nullable: false),
                        SupervisoryBodyId = c.Int(nullable: false),
                        ArticleId = c.Int(nullable: false),
                        SubmissionDueDateId = c.Int(nullable: false),
                        InitialReportDueDate = c.DateTime(nullable: false),
                        PeriodicReportDueDate = c.DateTime(nullable: false),
                        GeneralComments = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.pReportingCompliances", "pTreaty_Id", "dbo.pTreaties");
            DropForeignKey("dbo.pReportingCompliances", "pSupervisoryBody_Id", "dbo.pSupervisoryBodies");
            DropForeignKey("dbo.pReportingCompliances", "pArticle_Id", "dbo.pArticles");
            DropIndex("dbo.pReportingCompliances", new[] { "pTreaty_Id" });
            DropIndex("dbo.pReportingCompliances", new[] { "pSupervisoryBody_Id" });
            DropIndex("dbo.pReportingCompliances", new[] { "pArticle_Id" });
            AlterColumn("dbo.pArticles", "ArticleName", c => c.String());
            DropTable("dbo.pSubmissionDueDates");
            DropTable("dbo.pTreaties");
            DropTable("dbo.pSupervisoryBodies");
            DropTable("dbo.pReportingCompliances");
            CreateIndex("dbo.ReportingCompliances", "SubmissionDueDateId");
            CreateIndex("dbo.ReportingCompliances", "ArticleId");
            CreateIndex("dbo.ReportingCompliances", "SupervisoryBodyId");
            CreateIndex("dbo.ReportingCompliances", "TreatyId");
            AddForeignKey("dbo.ReportingCompliances", "TreatyId", "dbo.Treaties", "TreatyId", cascadeDelete: true);
            AddForeignKey("dbo.ReportingCompliances", "SupervisoryBodyId", "dbo.SupervisoryBodies", "SupervisoryBodyId", cascadeDelete: true);
            AddForeignKey("dbo.ReportingCompliances", "SubmissionDueDateId", "dbo.SubmissionDueDates", "SubmissionDueDateId", cascadeDelete: true);
            AddForeignKey("dbo.ReportingCompliances", "ArticleId", "dbo.Articles", "Id", cascadeDelete: true);
            RenameTable(name: "dbo.pArticles", newName: "Articles");
        }
    }
}
