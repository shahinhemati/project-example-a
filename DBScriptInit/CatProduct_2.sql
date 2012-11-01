
CREATE TABLE [dbo].[CV_CatProduct](
	[CatID] [int] IDENTITY(1,1) NOT NULL,
	[CatName] [nvarchar](255) NULL,
	[ParentID] [int] NULL,
	[ImageName] [nvarchar](150) NULL,
 CONSTRAINT [PK_CV_CatProduct] PRIMARY KEY CLUSTERED 
(
	[CatID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CV_CatProduct]  WITH CHECK ADD  CONSTRAINT [FK_CV_CatProduct_CV_CatProduct] FOREIGN KEY([ParentID])
REFERENCES [dbo].[CV_CatProduct] ([CatID])
GO

ALTER TABLE [dbo].[CV_CatProduct] CHECK CONSTRAINT [FK_CV_CatProduct_CV_CatProduct]
GO


