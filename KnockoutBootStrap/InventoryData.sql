USE [InventoryControl]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 12/01/2012 14:48:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ItemName] [varchar](100) NULL,
	[ReorderPoint] [int] NULL,
	[CreatedDate] [datetime] NULL,
	[CurrentStock] [varchar](50) NULL,
	[Category] [varchar](50) NULL,
	[Vendor] [varchar](50) NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


