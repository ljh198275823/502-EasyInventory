
--2015-11-26 �ͻ���������TOTALWEIGHT�ֶ�
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

--�ͻ����������У�һ���ܽ�һ��������
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Amount' AND id = OBJECT_ID(N'[dbo].[StackOutSheet]'))
BEGIN
	exec ('alter table StackOutSheet add Amount decimal(18,4) null')
	exec ('update StackOutSheet set Amount =a.Amount from (select SheetID ,SUM(Amount)as amount from CustomerReceivable  where ClassID=1 group by SheetID ) as a where a.SheetID =ID ')
    exec ('update StackOutSheet set Amount =0 where Amount is null')
	exec ('alter table StackOutSheet alter column Amount decimal(18,4) not null')
	exec ('alter table ProductInventoryItem alter column Model nchar(5) not null')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='TotalWeight' AND id = OBJECT_ID(N'[dbo].[StackOutSheet]'))
BEGIN
	exec ('alter table StackOutSheet add TotalWeight decimal(18,4) null')
	exec ('update StackOutSheet set TotalWeight =w.totalweight from (select sheetno, SUM(totalweight) as totalweight from (select sheetno ,isnull(totalweight,0) as totalweight,ProductID  from StackOutItem group by SheetNo,ProductID,TotalWeight) a group by SheetNo )w where stackoutsheet.id=w.SheetNo ')
    exec ('update StackOutSheet set TotalWeight =0 where TotalWeight is null')
	exec ('alter table StackOutSheet alter column TotalWeight decimal(18,4) not null')
end
go

--2017-05-26 ����ģ������һЩ�ϴ�ĸĶ�
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Account]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[Account](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Ispublic] [bit] NOT NULL,
	[AddDate] [datetime] not null,
	[Operator] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
	 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	) ON [PRIMARY]
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OtherReceivableSheet]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[OtherReceivableSheet](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 2) NOT NULL,
	[State] [tinyint] NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[StackSheetID] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
	CONSTRAINT [PK_OtherReceivableSheet] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	) ON [PRIMARY]
END
go

--�ͻ�������ˮ�����ĸ��ֶ� �˺ţ����λ
if not exists (SELECT * FROM dbo.syscolumns WHERE name ='AccountID' AND id = OBJECT_ID(N'[dbo].[CustomerPayment]'))
BEGIN
	exec ('alter table CustomerPayment add AccountID nvarchar(50) null')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Payer' AND id = OBJECT_ID(N'[dbo].[CustomerPayment]'))
BEGIN
	exec ('alter table CustomerPayment add Payer nvarchar(50) null')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Note' AND id = OBJECT_ID(N'[dbo].[CustomerPayment]'))
BEGIN
	exec ('alter table CustomerPayment add Note nvarchar(512) null')
end
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountRecord]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[AccountRecord](
	[ID] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetID] [nvarchar](50) NOT NULL,
	[AccountID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Assigned] [decimal](18, 4) NOT NULL,
	[CustomerID] [nvarchar](50) NULL,
	[StackSheetID] [nvarchar](50) NULL,
	[OtherAccount] [nvarchar](50) NULL,
	[Note] [nvarchar](512) NULL,
	[Memo] [nvarchar](200) NULL,
	 CONSTRAINT [PK_AccountRecord] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	)  ON [PRIMARY]
	
	exec ('insert into AccountRecord (id,createdate,customerid,classid,sheetid,accountid,StackSheetID,amount,assigned,memo) select NEWID()as id ,sheetdate,customerid,classid,[ID]as sheetid,'''',StackOutSheetID,amount,assigned,memo from CustomerPayment where state<>4')
END
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AccountRecordAssign]') AND type in (N'U'))
BEGIN
	CREATE TABLE [dbo].[AccountRecordAssign](
	[ID] [uniqueidentifier] NOT NULL,
	[PaymentID] [uniqueidentifier] NOT NULL,
	[ReceivableID] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	 CONSTRAINT [PK_AccountRecordAssign] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)
	) ON [PRIMARY]
	
	exec ('insert into AccountRecordassign (id,paymentid,receivableid,amount) select a.id,b.id as paymentid,a.receivableid,a.amount from CustomerPaymentAssign a inner join accountrecord b on a.PaymentID =b.sheetid ')
END
go

if exists (SELECT * FROM dbo.syscolumns WHERE name ='State' AND id = OBJECT_ID(N'[dbo].[CustomerReceivable]'))
BEGIN
	exec ('alter table CustomerReceivable drop column state')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='Note' AND id = OBJECT_ID(N'[dbo].[CustomerReceivable]'))
BEGIN
	exec ('alter table CustomerReceivable add Note nvarchar(512)')
end
go

if exists (SELECT * FROM dbo.syscolumns WHERE name ='CustomerID' AND id = OBJECT_ID(N'[dbo].[CustomerPayment]'))
BEGIN
	exec ('alter table CustomerPayment alter column CustomerID nvarchar(50) null')
end
go

if not exists (SELECT * FROM dbo.syscolumns WHERE name ='AccountID' AND id = OBJECT_ID(N'[dbo].[ExpenditureRecord]'))
BEGIN
	exec ('alter table ExpenditureRecord add AccountID nvarchar(50) null')
end
go