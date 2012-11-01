SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CV_SlideItem](
	[ItemID] [int] IDENTITY(1,1) NOT NULL,
	[Description] [nvarchar](500) NULL,
	[URL] [nvarchar](250) NULL,
	[Title] [nvarchar](250) NULL,
	[FileImage] [nvarchar](250) NULL,
 CONSTRAINT [PK_CV_Slide] PRIMARY KEY CLUSTERED 
(
	[ItemID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO


