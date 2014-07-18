
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[InventoryCheckRecord]'))
BEGIN
	CREATE TABLE [dbo].[InventoryCheckRecord](
	[ID] [uniqueidentifier] NOT NULL,
	[CheckDateTime] [datetime] NOT NULL,
	[ProductID] [varchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[WarehouseID] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
    [Unit] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
	[Inventory] [decimal](18, 4) NOT NULL,
	[CheckCount] [decimal](18, 4) NOT NULL,
	[Checker] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
    [Operator] [nvarchar](50) COLLATE Chinese_PRC_CI_AS NOT NULL,
    [Memo] [nvarchar](200) COLLATE Chinese_PRC_CI_AS NOT NULL,
	CONSTRAINT [PK_InventoryCheckRecord] PRIMARY KEY CLUSTERED 
	(
		[ID] ASC
	)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
END