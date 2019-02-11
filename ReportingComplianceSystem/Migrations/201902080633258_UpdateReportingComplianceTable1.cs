namespace ReportingComplianceSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateReportingComplianceTable1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.pReportingCompliances", "pArticle_Id", "dbo.pArticles");
            DropForeignKey("dbo.pReportingCompliances", "pSupervisoryBody_Id", "dbo.pSupervisoryBodies");
            DropForeignKey("dbo.pReportingCompliances", "pTreaty_Id", "dbo.pTreaties");
            DropIndex("dbo.pReportingCompliances", new[] { "pArticle_Id" });
            DropIndex("dbo.pReportingCompliances", new[] { "pSupervisoryBody_Id" });
            DropIndex("dbo.pReportingCompliances", new[] { "pTreaty_Id" });
            DropColumn("dbo.pReportingCompliances", "ArticleId");
            DropColumn("dbo.pReportingCompliances", "SupervisoryBodyId");
            DropColumn("dbo.pReportingCompliances", "TreatyId");
            RenameColumn(table: "dbo.pReportingCompliances", name: "pArticle_Id", newName: "ArticleId");
            RenameColumn(table: "dbo.pReportingCompliances", name: "pSupervisoryBody_Id", newName: "SupervisoryBodyId");
            RenameColumn(table: "dbo.pReportingCompliances", name: "pTreaty_Id", newName: "TreatyId");
            AlterColumn("dbo.pReportingCompliances", "ArticleId", c => c.Int(nullable: false));
            AlterColumn("dbo.pReportingCompliances", "SupervisoryBodyId", c => c.Int(nullable: false));
            AlterColumn("dbo.pReportingCompliances", "TreatyId", c => c.Int(nullable: false));
            CreateIndex("dbo.pReportingCompliances", "TreatyId");
            CreateIndex("dbo.pReportingCompliances", "SupervisoryBodyId");
            CreateIndex("dbo.pReportingCompliances", "ArticleId");
            AddForeignKey("dbo.pReportingCompliances", "ArticleId", "dbo.pArticles", "Id", cascadeDelete: true);
            AddForeignKey("dbo.pReportingCompliances", "SupervisoryBodyId", "dbo.pSupervisoryBodies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.pReportingCompliances", "TreatyId", "dbo.pTreaties", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.pReportingCompliances", "TreatyId", "dbo.pTreaties");
            DropForeignKey("dbo.pReportingCompliances", "SupervisoryBodyId", "dbo.pSupervisoryBodies");
            DropForeignKey("dbo.pReportingCompliances", "ArticleId", "dbo.pArticles");
            DropIndex("dbo.pReportingCompliances", new[] { "ArticleId" });
            DropIndex("dbo.pReportingCompliances", new[] { "SupervisoryBodyId" });
            DropIndex("dbo.pReportingCompliances", new[] { "TreatyId" });
            AlterColumn("dbo.pReportingCompliances", "TreatyId", c => c.Int());
            AlterColumn("dbo.pReportingCompliances", "SupervisoryBodyId", c => c.Int());
            AlterColumn("dbo.pReportingCompliances", "ArticleId", c => c.Int());
            RenameColumn(table: "dbo.pReportingCompliances", name: "TreatyId", newName: "pTreaty_Id");
            RenameColumn(table: "dbo.pReportingCompliances", name: "SupervisoryBodyId", newName: "pSupervisoryBody_Id");
            RenameColumn(table: "dbo.pReportingCompliances", name: "ArticleId", newName: "pArticle_Id");
            AddColumn("dbo.pReportingCompliances", "TreatyId", c => c.Int(nullable: false));
            AddColumn("dbo.pReportingCompliances", "SupervisoryBodyId", c => c.Int(nullable: false));
            AddColumn("dbo.pReportingCompliances", "ArticleId", c => c.Int(nullable: false));
            CreateIndex("dbo.pReportingCompliances", "pTreaty_Id");
            CreateIndex("dbo.pReportingCompliances", "pSupervisoryBody_Id");
            CreateIndex("dbo.pReportingCompliances", "pArticle_Id");
            AddForeignKey("dbo.pReportingCompliances", "pTreaty_Id", "dbo.pTreaties", "Id");
            AddForeignKey("dbo.pReportingCompliances", "pSupervisoryBody_Id", "dbo.pSupervisoryBodies", "Id");
            AddForeignKey("dbo.pReportingCompliances", "pArticle_Id", "dbo.pArticles", "Id");
        }
    }
}
