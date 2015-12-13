---ÐÞ¸ÄÓÚ2015-12-13 
if exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
    exec ('update stackoutItem set length=weight ')
	exec ('update stackoutItem set weight=totalweight ')
	exec ('alter table StackOutItem drop column TotalWeight')
end
go

if exists (SELECT * FROM dbo.syscolumns WHERE name ='Count' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem Alter column Count decimal(18,4) null')
end
go


