CREATE TABLE [dbo].[CV_Products](
	[ProductID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [smalldatetime] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ShortContent] [nvarchar](255) NULL,
	[Content] [ntext] NOT NULL,
	[ImageName] [nvarchar](255) NULL,
	[CatID] [int] NULL,
 CONSTRAINT [PK_CV_Products] PRIMARY KEY CLUSTERED 
(
	[ProductID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[CV_Products]  WITH CHECK ADD  CONSTRAINT [FK_CV_Products_CV_CatProduct] FOREIGN KEY([CatID])
REFERENCES [dbo].[CV_CatProduct] ([CatID])
GO

ALTER TABLE [dbo].[CV_Products] CHECK CONSTRAINT [FK_CV_Products_CV_CatProduct]
GO


