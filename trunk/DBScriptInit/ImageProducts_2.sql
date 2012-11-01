
CREATE TABLE [dbo].[CV_ImageProducts](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[FileName] [nvarchar](255) NULL,
	[ProductID] [int] NULL,
 CONSTRAINT [PK_CV_ImageProducts] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CV_ImageProducts]  WITH CHECK ADD  CONSTRAINT [FK_CV_ImageProducts_CV_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[CV_Products] ([ProductID])
GO

ALTER TABLE [dbo].[CV_ImageProducts] CHECK CONSTRAINT [FK_CV_ImageProducts_CV_Products]
GO


