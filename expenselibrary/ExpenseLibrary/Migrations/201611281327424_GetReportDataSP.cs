namespace ExpenseLibrary.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GetReportDataSP : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure("GetExpenseReportData",
            @"

select AmountPerHead,Consumers,PaidAmount,(isnull(amountPerHead,0)-isnull(PaidAmount,0))as Balance from(
select sum(hp.PerHeadAmount)amountPerHead,hp.consumers,hp.ConsumerID from (
SELECT        CON.Name AS PaidBy, EXPS.Amount, EXPS.Id, EXPCons_1.ExpnsMembers, EXPS.ItemName, EXPCons1.Name AS consumers, EXPS.Amount / EXPCons_1.ExpnsMembers AS PerHeadAmount, 
                         EXPCons1.Id AS ConsumerID
FROM            Expenses AS EXPS INNER JOIN
                         Consumers AS CON ON EXPS.PaidBy = CON.Id INNER JOIN
                             (SELECT        COUNT(Id) AS ExpnsMembers, ExpenseId
                               FROM            ExpenseConsumers AS EXPCons
                               GROUP BY ExpenseId) AS EXPCons_1 ON EXPS.Id = EXPCons_1.ExpenseId INNER JOIN
                             (SELECT        ExpenseConsumers.ExpenseId, Consumers.Name, Consumers.Id
FROM		      ExpenseConsumers INNER JOIN
                         Consumers ON ExpenseConsumers.ConsumerId = Consumers.Id) AS EXPCons1 ON EXPS.Id = EXPCons1.ExpenseId
WHERE        (EXPS.IsAudit = 0)
)hp
group by hp.consumers,hp.ConsumerID
)as t1
 left join
(
SELECT        SUM(EXPS.Amount) AS PaidAmount, CON.Name AS PaidBy, CON.Id
FROM            Expenses AS EXPS INNER JOIN
                         Consumers AS CON ON EXPS.PaidBy = CON.Id
WHERE        (EXPS.IsAudit = 0)
GROUP BY CON.Name, CON.Id
) as t2 on t1.ConsumerID = t2.Id

");
        }
        
        public override void Down()
        {
            DropStoredProcedure(@"drop proc dbo.GetExpenseReportData");
        }
    }
}
