SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PriceTerm]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PriceTerm](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](50) NULL,
 CONSTRAINT [PK_PriceTerm] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplerPayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplerPayment](
	[ID] [nvarchar](50) NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[SupplierID] [nvarchar](50) NOT NULL,
	[CurrencyType] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Assigned] [decimal](18, 4) NOT NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[CheckNum] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_SupplerPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Unit]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Unit](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Plural] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Unit] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerPayment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerPayment](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[CurrencyType] [nvarchar](50) NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Assigned] [decimal](18, 4) NULL,
	[PaymentMode] [tinyint] NOT NULL,
	[CheckNum] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerPayment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CurrencyType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CurrencyType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Symbol] [nvarchar](50) NOT NULL,
	[ExchangeRate] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Currency] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Port]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Port](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[IsForeign] [bit] NOT NULL,
	[Country] [nvarchar](50) NULL,
	[Region] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Port] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Transport]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Transport](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Tranport] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[OperatorID] [nvarchar](50) NOT NULL,
	[Key] [nvarchar](50) NOT NULL,
	[Value] [ntext] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[OperatorID] ASC,
	[Key] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Operator]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Operator](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[RoleID] [nvarchar](50) NULL,
	[StaffID] [int] NULL,
 CONSTRAINT [PK_Operator] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Staff]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Staff](
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
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Staff] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StaffPhoto]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StaffPhoto](
	[ID] [int] NOT NULL,
	[Photo] [image] NOT NULL,
 CONSTRAINT [PK_StaffPhoto] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customer]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customer](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[ClassID] [tinyint] NOT NULL,
	[CreditLine] [decimal](18, 4) NOT NULL,
	[CategoryID] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Nation] [nvarchar](50) NULL,
	[Telphone] [nvarchar](50) NULL,
	[Fax] [nvarchar](50) NULL,
	[PostalCode] [nvarchar](50) NULL,
	[Website] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[Bank] [nvarchar](100) NULL,
	[BankAccount] [nvarchar](100) NULL,
	[SwiftNO] [nvarchar](50) NULL,
	[Creater] [nvarchar](50) NULL,
	[BusinessMan] [nvarchar](50) NULL,
	[DevelopFrom] [nvarchar](50) NULL,
	[MyID] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Customer] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenditureType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenditureType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ExpanditureType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerReceivable](
	[ID] [uniqueidentifier] NOT NULL,
	[CreateDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetID] [nvarchar](50) NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Haspaid] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerReceivable_1] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerPaymentAssign]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerPaymentAssign](
	[ID] [uniqueidentifier] NOT NULL,
	[PaymentID] [nvarchar](50) NOT NULL,
	[ReceivableID] [uniqueidentifier] NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
 CONSTRAINT [PK_CustomerPaymentAssign] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Role]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Role](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Permission] [nvarchar](4000) NULL,
	[Memo] [varchar](200) NULL,
 CONSTRAINT [PK_Role] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Sysparameter]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Sysparameter](
	[ID] [varchar](50) NOT NULL,
	[Value] [nvarchar](4000) NULL,
	[Memo] [varchar](200) NULL,
 CONSTRAINT [PK_Sysparameter] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AutoCreateNumber]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AutoCreateNumber](
	[Prefix] [nvarchar](50) NOT NULL,
	[NumberType] [nvarchar](50) NOT NULL,
	[Number] [int] NOT NULL,
 CONSTRAINT [PK_AutoCreateNumber] PRIMARY KEY CLUSTERED 
(
	[Prefix] ASC,
	[NumberType] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attachment]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Attachment](
	[ID] [uniqueidentifier] NOT NULL,
	[Value] [image] NULL,
 CONSTRAINT [PK_Attachment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Product]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Product](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[ForeignName] [nvarchar](50) NULL,
	[ShortName] [nvarchar](50) NULL,
	[CategoryID] [nvarchar](50) NOT NULL,
	[BarCode] [nvarchar](50) NULL,
	[Model] [nvarchar](50) NULL,
	[Specification] [nvarchar](50) NULL,
	[Unit] [nvarchar](10) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Cost] [decimal](18, 4) NOT NULL,
	[HSCode] [nvarchar](50) NULL,
	[HSName] [nvarchar](50) NULL,
	[BackTaxes] [decimal](18, 4) NULL,
	[IsService] [bit] NULL,
	[Company] [nvarchar](200) NULL,
	[InternalID] [nvarchar](50) NULL,
	[Point] [bigint] NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_Product] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DocumentOperation]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DocumentOperation](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[OrderItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[OrderItem](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseItem](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StackOutItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StackOutItem](
	[ID] [uniqueidentifier] NOT NULL,
	[SheetNo] [nvarchar](50) NOT NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](10) NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DeliverySheetItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductCategory]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductCategory](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Prefix] [nvarchar](50) NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StackInItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StackInItem](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ProductInventoryItem]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ProductInventoryItem](
	[ID] [uniqueidentifier] NOT NULL,
	[ProductID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NOT NULL,
	[Unit] [nvarchar](50) NOT NULL,
	[Price] [decimal](18, 4) NOT NULL,
	[Count] [decimal](18, 4) NOT NULL,
	[AddDate] [datetime] NOT NULL,
	[FromInventory] [bit] NOT NULL,
	[OrderItem] [uniqueidentifier] NULL,
	[OrderID] [nvarchar](50) NULL,
	[PurchaseItem] [uniqueidentifier] NULL,
	[PurchaseID] [nvarchar](50) NULL,
	[InventoryItem] [uniqueidentifier] NULL,
	[InventorySheet] [nvarchar](50) NULL,
	[DeliveryItem] [uniqueidentifier] NULL,
	[DeliverySheet] [nvarchar](50) NULL,
 CONSTRAINT [PK_ProductInventoryItem] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_CustomerType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[SupplierType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[SupplierType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_SupplierType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[RelatedCompanyType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[RelatedCompanyType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_RelatedCompanyType] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[WareHouse]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[WareHouse](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Parent] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_WareHouse] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Contact]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Contact](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CustomerOtherReceivable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CustomerOtherReceivable](
	[ID] [nvarchar](50) NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[Amount] [decimal](18, 4) NOT NULL,
	[State] [tinyint] NOT NULL,
	[OrderID] [nvarchar](50) NULL,
	[CurrencyType] [nvarchar](50) NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK__DaiFuRecord__2B3F6F97] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Order]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Order](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[PurchaseOrder]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[PurchaseOrder](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpenditureRecord]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ExpenditureRecord](
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
 CONSTRAINT [PK__ExpenditureRecor__29572725] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StackOutSheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StackOutSheet](
	[ID] [nvarchar](50) NOT NULL,
	[ClassID] [tinyint] NOT NULL,
	[SheetDate] [datetime] NOT NULL,
	[LastActiveDate] [datetime] NOT NULL,
	[CustomerID] [nvarchar](50) NOT NULL,
	[WareHouseID] [nvarchar](50) NULL,
	[Linker] [nvarchar](50) NULL,
	[LinkerPhoneCall] [nvarchar](50) NULL,
	[Address] [nvarchar](200) NULL,
	[WithTax] [bit] NOT NULL,
	[Discount] [decimal](18, 4) NOT NULL,
	[SalesPerson] [nvarchar](50) NULL,
	[State] [tinyint] NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_DeliverySheet] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[StackInSheet]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[StackInSheet](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Locker]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Locker](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Locker] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CollectionType]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CollectionType](
	[ID] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Memo] [nvarchar](200) NULL,
 CONSTRAINT [PK_PaymentMode] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttachmentHeader]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[AttachmentHeader](
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
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO

--视图
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_Now]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_Now] AS SELECT     GETDATE() AS Now ' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_OrderItemRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_OrderItemRecord]
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
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_PurchaseItemRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_PurchaseItemRecord]
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
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_StackOutRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_StackOutRecord]
AS
SELECT     a.ID, b.LastActiveDate, a.SheetNo, b.CustomerID, b.WareHouseID, a.ProductID, a.Unit, a.Price, a.Count, a.Amount, b.State, b.SalesPerson, b.WithTax, a.OrderID, 
                      a.OrderItem, a.Memo, b.ClassID
FROM         dbo.StackOutItem AS a INNER JOIN
                      dbo.StackOutSheet AS b ON a.SheetNo = b.ID
' 
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_StackInRecord]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_StackInRecord]
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
IF NOT EXISTS (SELECT * FROM sys.views WHERE object_id = OBJECT_ID(N'[dbo].[View_ProductInventory]'))
EXEC dbo.sp_executesql @statement = N'CREATE VIEW [dbo].[View_ProductInventory]
AS
SELECT     ProductID, WareHouseID, Unit, SUM(CASE WHEN OrderItem IS NULL AND DeliveryItem IS NULL THEN Count ELSE 0 END) AS Valid, 
                      SUM(CASE WHEN OrderItem IS NULL AND DeliveryItem IS NULL THEN Price * Count ELSE 0 END) AS ValidAmount, SUM(CASE WHEN OrderItem IS NOT NULL AND 
                      DeliveryItem IS NULL THEN Count ELSE 0 END) AS Reserved, SUM(CASE WHEN OrderItem IS NOT NULL AND DeliveryItem IS NULL THEN Price * Count ELSE 0 END) 
                      AS ReservedAmount
FROM         dbo.ProductInventoryItem AS a
GROUP BY ProductID, WareHouseID, Unit
' 
GO

--数据
if not exists (select * from operator where id='admin')
insert into operator (ID,Name,Password,RoleID) values('admin','系统管理员','123','SYS')

if not exists (select * from Role where id='SYS')
insert into Role (ID,Name,Memo,Permission) values('SYS','系统管理员','系统管理员，有系统所有的权限.','all')