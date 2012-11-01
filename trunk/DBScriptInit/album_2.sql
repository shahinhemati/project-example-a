
CREATE TABLE [dbo].[CV_Album](
	[AlbumID] [int] IDENTITY(1,1) NOT NULL,
	[AlbumName] [nvarchar](250) NULL,
	[ShortContent] [nvarchar](500) NULL,
	[ImageName] [nvarchar](150) NULL,
 CONSTRAINT [PK_CV_Album] PRIMARY KEY CLUSTERED 
(
	[AlbumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



