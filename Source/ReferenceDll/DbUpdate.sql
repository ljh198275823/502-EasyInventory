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

--2016-1-14 
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

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TransCost' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add TransCost decimal(18,4)')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OtherCost' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OtherCost decimal(18,4)')
end
go
