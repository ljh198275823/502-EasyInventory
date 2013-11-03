--
----add by bruce 2013-9-12
--if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Memo' AND id = OBJECT_ID(N'[dbo].[TAOperator]')) 
--IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TAParameter]') AND type in (N'U'))

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Memo' AND id = OBJECT_ID(N'[dbo].[AttachmentHeader]')) 
begin
	alter table AttachmentHeader add Memo nvarchar(200)
end 
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Creater' AND id = OBJECT_ID(N'[dbo].[Customer]')) 
begin
	alter table Customer add Creater nvarchar(50)
end 
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='BusinessMan' AND id = OBJECT_ID(N'[dbo].[Customer]')) 
begin
	alter table Customer add BusinessMan nvarchar(50)
end 
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Media' AND id = OBJECT_ID(N'[dbo].[Customer]')) 
begin
	alter table Customer add Media nvarchar(50)
end 
go

