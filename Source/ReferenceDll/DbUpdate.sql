---修改于2015-12-13 
if exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
    exec ('update stackoutItem set length=weight ')
	exec ('update stackoutItem set weight=totalweight ')
	exec ('alter table StackOutItem drop column TotalWeight')
end
go


update productinventoryitem set model='原材料' where model='卷'
go

---修改于2015-12-21
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='DefaultLinker' AND id = OBJECT_ID(N'[dbo].[Customer]'))
BEGIN
	exec ('alter table Customer add DefaultLinker uniqueidentifier')
end
go

--2015-01-14
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='OriginalThick' AND id = OBJECT_ID(N'[dbo].[ProductInventoryItem]'))
BEGIN
	exec ('alter table ProductInventoryItem add OriginalThick decimal(18,4)')
end
go