---�޸���2015-12-13 
if exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutItem]'))
BEGIN
    exec ('update stackoutItem set length=weight ')
	exec ('update stackoutItem set weight=totalweight ')
	exec ('alter table StackOutItem drop column TotalWeight')
end
go


update productinventoryitem set model='ԭ����' where model='��'
go

---�޸���2015-12-21
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='DefaultLinker' AND id = OBJECT_ID(N'[dbo].[Customer]'))
BEGIN
	exec ('alter table Customer add DefaultLinker uniqueidentifier')
end
go