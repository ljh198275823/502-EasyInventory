
--2015-11-26 送货单项增加TOTALWEIGHT字段
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
	exec ('alter table StackOutItem add TotalWeight decimal(18,4) null')
end
go

--2015-11-27 
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OriginalThick' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OriginalThick decimal(18,4) null')
end
go

--2016-1-15
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Bank' AND id = OBJECT_ID(N'[dbo].[CustomerPayment]'))
BEGIN
	exec ('alter table CustomerPayment add Bank nvarchar(50)')
end
go

--2016-2-19
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='DefaultLinker' AND id = OBJECT_ID(N'[dbo].[Customer]'))
BEGIN
	exec ('alter table Customer add DefaultLinker uniqueidentifier')
end
go

--2016-2-25
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='CarPlate' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add Carplate nvarchar(50)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Material' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add Material nvarchar(50)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='PurchasePrice' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add PurchasePrice decimal(18,4)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='WithTax' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add WithTax bit')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TransCost' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add TransCost decimal(18,4)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TransCostPrepay' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add TransCostPrepay bit')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OtherCost' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OtherCost decimal(18,4)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OtherCostPrepay' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OtherCostPrepay bit')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Position' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add Position nvarchar(50) null')
end
go

--2016-2-29 
if exists (SELECT * FROM dbo.syscolumns WHERE name ='Weight' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
	exec ('update StackoutItem set TotalWeight = Weight')
	exec ('alter table StackOutItem drop column weight')
end
go

--2016-3-1
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OriginalCount' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OriginalCount decimal(18,4)')
end
go

--2016-3-10
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='AddDate' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
	exec ('alter table StackOutItem add AddDate DateTime null')
end
go

--2016-3-10 
ALTER VIEW [dbo].[View_StackOutRecord] AS
 SELECT     a.ID, b.LastActiveDate, a.SheetNo, b.CustomerID, b.WareHouseID, a.ProductID, a.Unit, a.Price, a.Count, a.Length, a.TotalWeight as Weight, b.State, b.SalesPerson, b.WithTax, a.OrderID, a.OrderItem, a.Memo, b.ClassID
 FROM         dbo.StackOutItem AS a INNER JOIN  dbo.StackOutSheet AS b ON a.SheetNo = b.ID
go

--送货单增加两列，一列总金额，一列总重量
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Amount' AND id = OBJECT_ID(N'[dbo].[StackOutSheet]'))
BEGIN
	exec ('alter table StackOutSheet add Amount decimal(18,4) null')
	exec ('update StackOutSheet set Amount =a.Amount from (select SheetID ,SUM(Amount)as amount from CustomerReceivable  where ClassID=1 group by SheetID ) as a where a.SheetID =ID ')
    exec ('update StackOutSheet set Amount =0 where Amount is null')
	exec ('alter table StackOutSheet alter column Amount decimal(18,4) not null')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutSheet]'))
BEGIN
	exec ('alter table StackOutSheet add TotalWeight decimal(18,4) null')
    exec ('update StackOutSheet set TotalWeight =0 where TotalWeight is null')
	exec ('alter table StackOutSheet alter column TotalWeight decimal(18,4) not null')
end
go
