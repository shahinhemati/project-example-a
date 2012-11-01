CREATE TABLE [dbo].[CV_News](
	[NewsID] [int] IDENTITY(1,1) NOT NULL,
	[CreatedDate] [smalldatetime] NULL,
	[Title] [nvarchar](255) NOT NULL,
	[ShortContent] [nvarchar](255) NULL,
	[Content] [ntext] NOT NULL,
	[ImageName] [nvarchar](255) NULL,
	[CatNewsID] [int] NULL,
 CONSTRAINT [PK_CV_News] PRIMARY KEY CLUSTERED 
(
	[NewsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[CV_News]  WITH CHECK ADD  CONSTRAINT [FK_CV_News_CV_CatNews] FOREIGN KEY([CatNewsID])
REFERENCES [dbo].[CV_CatNews] ([CatID])
GO

ALTER TABLE [dbo].[CV_News] CHECK CONSTRAINT [FK_CV_News_CV_CatNews]
GO


