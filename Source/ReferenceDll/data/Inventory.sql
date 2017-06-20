SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[View_Now]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [View_Now] AS SELECT     GETDATE() AS Now '
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Sysparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [Sysparameter](
	[ID] [varchar](50) NOT NULL,
	[Value] [nvarchar](4000) NULL,
	[Memo] [varchar](200) NULL,
 CONSTRAINT [PK_Sysparameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SupplierType]') AND type in (N'U'))
BEGIN
CREATE TABLE [SupplierType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_SupplierType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[SteelRollSliceRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [SteelRollSliceRecord](
	[ID] [uniqueidentifier] NOT NULL,
	[SliceDate] [datetime] NOT NULL,
	[SliceSource] [uniqueidentifier] NOT NULL,
	[Specification] [nvarchar](50) NULL,
	[Category] [nvarchar](50) NULL,
	[SliceType] [nvarchar](50) NULL,
	[Weight] [decimal](18, 4) NULL,
	[Length] [decimal](18, 4) NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[BeforeWeight] [decimal](18, 4) NOT NULL,
	[BeforeLength] [decimal](18, 4) NOT NULL,
	[AfterWeight] [decimal](18, 4) NOT NULL,
	[AfterLength] [decimal](18, 4) NOT NULL,
	[Customer] [nvarchar](50) NULL,
	[WareHouse] [nvarchar](50) NULL,
	[Slicer] [nvarchar](50) NULL,
	[Operator] [nvarchar](50) NULL,
 CONSTRAINT [PK_SteelRollSlicedRecord] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[StaffPhoto]') AND type in (N'U'))
BEGIN
CREATE TABLE [StaffPhoto](
	[ID] [int] NOT NULL,
	[Photo] [image] NOT NULL,
 CONSTRAINT [PK_StaffPhoto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Staff]') AND type in (N'U'))
BEGIN
CREATE TABLE [Staff](
	[ID] [int] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Certificate] [nvarchar](50) NULL,
	[Sex] [nvarchar](50) NULL,
	[Birthday] [datetime] NULL,
	[UserPosition] [nvarchar](50) NULL,
	[HireDate] [datetime] NULL,
	[Resigned] [bit] NOT NULL,
	[ResignDate] [datetime] NULL,
	[DepartmentID] [nvarchar](50) NULL,
	[Phone] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[StackOutSheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [StackOutSheet](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[WithTax] [bit] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Discount] [decimal](18, 4) NOT NULL,
	[TotalWeight] [decimal](18, 4) NOT NULL,
	[DeadlineDate] [datetime] NULL,
	[WareHouseID] [nvarchar](50) NULL,
	[Linker] [nvarchar](50) NULL,
	[LinkerCall] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Driver] [nvarchar](50) NULL,
	[DriverCall] [nvarchar](50) NULL,
	[CarPlate] [nvarchar](50) NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_StackOutSheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[StackOutItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [StackOutItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Length] [decimal](18, 4) NULL,
	[TotalWeight] [decimal](18, 4) NULL,
	[AddDate] [datetime] NULL,
	[InventoryItem] [uniqueidentifier] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DeliverySheetItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[StackInSheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [StackInSheet](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[SupplierID] [nvarchar](50) NULL,
	[WareHouseID] [nvarchar](50) NOT NULL,
	[Buyer] [nvarchar](50) NULL,
	[WithTax] [bit] NOT NULL,
	[Discount] [decimal](18, 4) NOT NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_InventorySheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[StackInItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [StackInItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[PurchaseOrder] [nvarchar](50) NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_InventorySheetItem_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [Role](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Permission] [nvarchar](4000) NULL,
	[Memo] [varchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_PADDING OFF
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[RelatedCompanyType]') AND type in (N'U'))
BEGIN
CREATE TABLE [RelatedCompanyType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_RelatedCompanyType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[PurchaseOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [PurchaseOrder](
	[ID] [nvarchar](50) NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[SupplierID] [nvarchar](50) NOT NULL,
	[WithTax] [bit] NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[Buyer] [nvarchar](50) NULL,
	[State] [tinyint] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PurchaseOrder] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[PurchaseItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [PurchaseItem](
	[ID] [uniqueidentifier] NOT NULL,
	[PurchaseID] [nvarchar](50) NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PurchaseSheetItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ProductInventoryItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [ProductInventoryItem](
	[ID] [uniqueidentifier] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NOT NULL,
	[Model] [nchar](5) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[OriginalWeight] [decimal](18, 4) NULL,
	[OriginalLength] [decimal](18, 4) NULL,
	[OriginalThick] [decimal](18, 4) NULL,
	[OriginalCount] [decimal](18, 4) NULL,
	[Weight] [decimal](18, 4) NULL,
	[Length] [decimal](18, 4) NULL,
	[RealThick] [decimal](18, 4) NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[State] [tinyint] NOT NULL,
	[Customer] [nvarchar](50) NULL,
	[Supplier] [nvarchar](50) NULL,
	[Manufacture] [nvarchar](50) NULL,
	[SerialNumber] [nvarchar](50) NULL,
	[CostID] [uniqueidentifier] NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[PurchaseID] [nvarchar](50) NULL,
	[InventoryItem] [uniqueidentifier] NULL,
	[InventorySheet] [nvarchar](50) NULL,
	[DeliveryItem] [uniqueidentifier] NULL,
	[DeliverySheet] [nvarchar](50) NULL,
	[SourceID] [uniqueidentifier] NULL,
	[SourceRoll] [uniqueidentifier] NULL,
	[Carplate] [nvarchar](50) NULL,
	[Material] [nvarchar](50) NULL,
	[Position] [nvarchar](50) NULL,
	[Operator] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProductInventoryItem_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[ProductInventoryItem]') AND name = N'index_ProductinventoryItemAddDate')
CREATE NONCLUSTERED INDEX [index_ProductinventoryItemAddDate] ON [ProductInventoryItem] 
(
	[AddDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
IF NOT EXISTS (SELECT * FROM sys.indexes WHERE object_id = OBJECT_ID(N'[ProductInventoryItem]') AND name = N'index_stackoutsheetid')
CREATE NONCLUSTERED INDEX [index_stackoutsheetid] ON [ProductInventoryItem] 
(
	[DeliverySheet] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [ProductCategory](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [Product](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CategoryID] [nvarchar](50) NOT NULL,
	[Specification] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[Length] [decimal](18, 4) NULL,
	[Weight] [decimal](18, 4) NULL,
	[Density] [decimal](18, 4) NULL,
	[IsService] [bit] NULL,
	[Brand] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[OtherReceivableSheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [OtherReceivableSheet](
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [OrderItem](
	[ID] [uniqueidentifier] NOT NULL,
	[OrderID] [nvarchar](50) NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_OrderItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [Order](
	[ID] [nvarchar](50) NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[WithTax] [bit] NOT NULL,
	[DemandDate] [datetime] NOT NULL,
	[State] [tinyint] NOT NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Operator]') AND type in (N'U'))
BEGIN
CREATE TABLE [Operator](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleID] [nvarchar](50) NULL,
	[StaffID] [int] NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[InventoryCheckRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [InventoryCheckRecord](
	[ID] [uniqueidentifier] NOT NULL,
	[CheckDateTime] [datetime] NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[WarehouseID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Inventory] [decimal](18, 4) NOT NULL,
	[CheckCount] [decimal](18, 4) NOT NULL,
	[BeforeWeight] [decimal](18, 4) NULL,
	[BeforeLength] [decimal](18, 4) NULL,
	[Weight] [decimal](18, 4) NULL,
	[Length] [decimal](18, 4) NULL,
	[SourceID] [uniqueidentifier] NULL,
	[Customer] [nvarchar](50) NULL,
	[Checker] [nvarchar](50) NULL,
	[Operator] [nvarchar](50) NULL,
	[Memo] [nvarchar](50) NULL,
 CONSTRAINT [sqlite_autoindex_InventoryCheckRecord_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ExpenditureType]') AND type in (N'U'))
BEGIN
CREATE TABLE [ExpenditureType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ExpanditureType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ExpenditureRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [ExpenditureRecord](
	[ID] [nvarchar](50) NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Category] [nvarchar](50) NULL,
	[OrderID] [nvarchar](50) NULL,
	[Amount] [decimal](10, 2) NOT NULL,
	[Request] [nvarchar](50) NULL,
	[Payee] [nvarchar](50) NULL,
	[CheckNum] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
	[AccountID] [nvarchar](50) NULL,
 CONSTRAINT [PK__ExpenditureRecor__29572725] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[DocumentOperation]') AND type in (N'U'))
BEGIN
CREATE TABLE [DocumentOperation](
	[ID] [uniqueidentifier] NOT NULL,
	[DocumentID] [nvarchar](50) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[OperatDate] [datetime] NOT NULL,
	[Operation] [nvarchar](200) NOT NULL,
	[Operator] [nvarchar](50) NOT NULL,
	[LogID] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DocumentOperation] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [Department](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerType]') AND type in (N'U'))
BEGIN
CREATE TABLE [CustomerType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [CustomerReceivable](
	[ID] [uniqueidentifier] NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[SheetID] [nvarchar](50) NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Haspaid] [decimal](18, 4) NOT NULL,
	[Note] [nvarchar](512) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerReceivable_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[CustomerPayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [CustomerPayment](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Assigned] [decimal](18, 4) NULL,
	[AccountID] [nvarchar](50) NULL,
	[Payer] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[StackOutSheetID] [nvarchar](50) NULL,
	[Note] [nvarchar](512) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [Customer](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[CreditLine] [decimal](18, 4) NOT NULL,
	[CategoryID] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Nation] [nvarchar](50) NULL,
	[Telphone] [nvarchar](200) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[DefaultLinker] [uniqueidentifier] NULL,
	[FileID] [int] NULL,
	[TaxFileID] [int] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Cost]') AND type in (N'U'))
BEGIN
CREATE TABLE [Cost](
	[ID] [uniqueidentifier] NOT NULL,
	[Costs] [nvarchar](256) NOT NULL,
 CONSTRAINT [PK_Cost] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [Contact](
	[ID] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NULL,
	[Company] [nvarchar](50) NOT NULL,
	[TelPhone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[Mobile] [nvarchar](50) NULL,
	[QQ] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AutoCreateNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [AutoCreateNumber](
	[Prefix] [nvarchar](50) NOT NULL,
	[NumberType] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_AutoCreateNumber] PRIMARY KEY CLUSTERED 
(
	[Prefix] ASC,
	[NumberType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AttachmentHeader]') AND type in (N'U'))
BEGIN
CREATE TABLE [AttachmentHeader](
	[ID] [uniqueidentifier] NOT NULL,
	[DocumentID] [nvarchar](50) NOT NULL,
	[DocumentType] [nvarchar](50) NOT NULL,
	[Owner] [nvarchar](50) NOT NULL,
	[UploadDateTime] [datetime] NOT NULL,
	[FileName] [nvarchar](50) NOT NULL,
	[FileSize] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Attachment_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Attachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [Attachment](
	[ID] [uniqueidentifier] NOT NULL,
	[Value] [image] NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AccountRecordAssign]') AND type in (N'U'))
BEGIN
CREATE TABLE [AccountRecordAssign](
	[ID] [uniqueidentifier] NOT NULL,
	[PaymentID] [uniqueidentifier] NOT NULL,
	[ReceivableID] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_AccountRecordAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[AccountRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [AccountRecord](
	[ID] [uniqueidentifier] NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[AccountID] [nvarchar](50) NOT NULL,
	[SheetID] [nvarchar](50) NOT NULL,
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
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[Account]') AND type in (N'U'))
BEGIN
CREATE TABLE [Account](
	[ID] [nvarchar](50) NOT NULL,
	[Class] [tinyint] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Ispublic] [bit] NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[Operator] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[WareHouse]') AND type in (N'U'))
BEGIN
CREATE TABLE [WareHouse](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[View_StackOutRecord20170609]'))
EXEC dbo.sp_executesql @statement = N'
 
 CREATE VIEW [View_StackOutRecord20170609] AS
  SELECT     a.ID,a.AddDate, b.SheetDate, a.SheetNo, b.CustomerID, b.WareHouseID, a.ProductID, a.Unit, a.Price, a.Count, a.Length, a.TotalWeight AS Weight, b.State, b.SalesPerson, b.WithTax, a.OrderID, 
                      a.OrderItem, a.Memo, b.ClassID,f.originalWeight as SourceRollWeight 
   FROM         dbo.StackOutItem AS a INNER JOIN
                      dbo.StackOutSheet AS b ON a.SheetNo = b.ID
             left join (SELECT a.id, case a.model when ''原材料'' then a.OriginalWeight else b.originalWeight end as originalWeight  from ProductInventoryItem a left join ProductInventoryItem b on a.SourceRoll =b.ID ) as f on a.InventoryItem =f.ID 
 '
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[View_StackInRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [View_StackInRecord]
AS
SELECT     a.ID, d.LastActiveDate, a.SheetNo, d.SupplierID, a.ProductID, d.WareHouseID, a.Unit, a.Price, a.Count, a.Amount, d.State, a.OrderID, a.OrderItem, a.PurchaseOrder, 
                      a.PurchaseItem, a.Memo, d.WithTax, d.Buyer, d.ClassID
FROM         dbo.StackInItem AS a INNER JOIN
                      dbo.StackInSheet AS d ON a.SheetNo = d.ID
'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[View_PurchaseItemRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [View_PurchaseItemRecord]
AS
SELECT     a.ID, b.LastActiveDate, a.PurchaseID AS SheetNo, b.SupplierID, b.SheetDate, a.ProductID, a.Unit, a.Price, a.Count, a.Amount, a.DemandDate, b.Buyer, 
                      ISNULL(c.Received, 0) AS Received, b.State, a.OrderID, a.OrderItem, a.Memo
FROM         dbo.PurchaseItem AS a INNER JOIN
                      dbo.PurchaseOrder AS b ON a.PurchaseID = b.ID LEFT OUTER JOIN
                          (SELECT     PurchaseItem, SUM(Count) AS Received
                            FROM          dbo.ProductInventoryItem AS a
                            GROUP BY PurchaseItem) AS c ON a.ID = c.PurchaseItem
'
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[View_OrderItemRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [View_OrderItemRecord]
AS
SELECT     a.ID, o.LastActiveDate, o.SheetDate, a.OrderID AS SheetNo, o.CustomerID, a.ProductID, a.Unit, a.Price, o.WithTax, a.Count, a.Amount, a.DemandDate, 
                      ISNULL(b_1.Inventory, 0) AS Inventory, ISNULL(b_1.Received, 0) AS Received, ISNULL(b_1.Shipped, 0) AS Shipped, ISNULL(c.Purchased, 0) AS Purchased, o.State, 
                      o.SalesPerson, a.Memo
FROM         dbo.OrderItem AS a INNER JOIN
                      dbo.[Order] AS o ON a.OrderID = o.ID LEFT OUTER JOIN
                          (SELECT     OrderItem, SUM(CASE WHEN DeliveryItem IS NULL THEN count ELSE 0 END) AS Inventory, SUM(CASE WHEN PurchaseItem IS NULL 
                                                   THEN 0 ELSE count END) AS Received, SUM(CASE WHEN DeliveryItem IS NULL THEN 0 ELSE count END) AS Shipped
                            FROM          dbo.ProductInventoryItem AS a
                            WHERE      (OrderItem IS NOT NULL)
                            GROUP BY OrderItem) AS b_1 ON a.ID = b_1.OrderItem LEFT OUTER JOIN
                          (SELECT     a.OrderItem, SUM(a.Count) AS Purchased
                            FROM          dbo.PurchaseItem AS a INNER JOIN
                                                   dbo.PurchaseOrder AS b ON a.PurchaseID = b.ID
                            WHERE      (b.State <> 5) AND (a.OrderItem IS NOT NULL)
                            GROUP BY a.OrderItem) AS c ON a.ID = c.OrderItem
'
GO




--数据
if not exists (select * from operator where id='admin')
insert into operator (ID,Name,Password,RoleID) values('admin','系统管理员','123','SYS')

if not exists (select * from Role where id='SYS')
insert into Role (ID,Name,Memo,Permission) values('SYS','系统管理员','系统管理员，有系统所有的权限.','all')
GO
