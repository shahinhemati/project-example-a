

CREATE TABLE [dbo].[CV_ImageAlbum](
	[ImageID] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](500) NULL,
	[AlbumID] [int] NULL,
	[ImageName] [nvarchar](150) NULL,
 CONSTRAINT [PK_CV_ImageAlbum] PRIMARY KEY CLUSTERED 
(
	[ImageID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[CV_ImageAlbum]  WITH CHECK ADD  CONSTRAINT [FK_CV_ImageAlbum_CV_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[CV_Album] ([AlbumID])
GO

ALTER TABLE [dbo].[CV_ImageAlbum] CHECK CONSTRAINT [FK_CV_ImageAlbum_CV_Album]
GO


