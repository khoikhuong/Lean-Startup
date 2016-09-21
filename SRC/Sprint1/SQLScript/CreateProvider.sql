USE [ATMore]
GO

ALTER TABLE [dbo].[Provider] DROP CONSTRAINT [DF_Provider_CreatedDate]
GO

/****** Object:  Table [dbo].[Provider]    Script Date: 9/21/2016 9:04:01 PM ******/
DROP TABLE [dbo].[Provider]
GO

/****** Object:  Table [dbo].[Provider]    Script Date: 9/21/2016 9:04:01 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[Provider](
	[ProviderID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProviderName] [nvarchar](500) NULL,
	[Website] [nvarchar](500) NULL,
	[Phone1] [varchar](50) NULL,
	[Phone2] [varchar](50) NULL,
	[Phone3] [varchar](50) NULL,
	[Address] [nvarchar](500) NULL,
	[Notes] [nvarchar](2000) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Provider] PRIMARY KEY CLUSTERED 
(
	[ProviderID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO

ALTER TABLE [dbo].[Provider] ADD  CONSTRAINT [DF_Provider_CreatedDate]  DEFAULT (getdate()) FOR [CreatedDate]
GO


