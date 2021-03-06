USE [Compurenrt]
GO
/****** Object:  Table [dbo].[AlbumSet]    Script Date: 24/01/2021 6:14:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AlbumSet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_AlbumSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 24/01/2021 6:14:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[Mail] [nvarchar](50) NOT NULL,
	[Direction] [nchar](50) NOT NULL,
	[Phone] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PurchaseDetail]    Script Date: 24/01/2021 6:14:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PurchaseDetail](
	[Client_id] [nvarchar](10) NOT NULL,
	[Album_id] [int] NOT NULL,
	[Total] [real] NOT NULL,
	[id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PurchaseDetail] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SongSet]    Script Date: 24/01/2021 6:14:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SongSet](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Album_id] [int] NOT NULL,
 CONSTRAINT [PK_SongSet] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSession]    Script Date: 24/01/2021 6:14:14 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSession](
	[id] [nvarchar](10) NOT NULL,
	[Password] [nvarchar](30) NOT NULL,
	[NameUser] [nvarchar](100) NOT NULL,
	[EmailUser] [nvarchar](50) NOT NULL,
	[Adress] [nvarchar](500) NOT NULL,
	[PhoneUser] [nvarchar](200) NOT NULL,
 CONSTRAINT [PK_UserSession] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[AlbumSet] ON 

INSERT [dbo].[AlbumSet] ([id], [Name]) VALUES (1, N'Thriller - Michael Jackson')
INSERT [dbo].[AlbumSet] ([id], [Name]) VALUES (2, N'Dangerous')
INSERT [dbo].[AlbumSet] ([id], [Name]) VALUES (3, N'Bad')
SET IDENTITY_INSERT [dbo].[AlbumSet] OFF
GO
INSERT [dbo].[Client] ([id], [Name], [Mail], [Direction], [Phone]) VALUES (N'1036598444', N'ADRIAN RAMIREZ', N'adrian.ramirez23@hotmail.com', N'Calle 79 sur # 55 - 15                            ', N'3014881243')
INSERT [dbo].[Client] ([id], [Name], [Mail], [Direction], [Phone]) VALUES (N'1128433392', N'NATALIA HIGUITA', N'nataliahig@gmail.com', N'Calle 75 sur # 53 - 30                            ', N'3192341346')
INSERT [dbo].[Client] ([id], [Name], [Mail], [Direction], [Phone]) VALUES (N'70122996', N'GUSTAVO RAMIREZ', N'guraca2@hotmail.com', N'Calle 75 a sur # 52 F - 90                        ', N'3017345868')
GO
SET IDENTITY_INSERT [dbo].[PurchaseDetail] ON 

INSERT [dbo].[PurchaseDetail] ([Client_id], [Album_id], [Total], [id]) VALUES (N'1036598444', 3, 120000, 1)
INSERT [dbo].[PurchaseDetail] ([Client_id], [Album_id], [Total], [id]) VALUES (N'1128433392', 1, 185000, 2)
INSERT [dbo].[PurchaseDetail] ([Client_id], [Album_id], [Total], [id]) VALUES (N'70122996', 2, 135000, 3)
INSERT [dbo].[PurchaseDetail] ([Client_id], [Album_id], [Total], [id]) VALUES (N'1036598444', 2, 20000, 4)
SET IDENTITY_INSERT [dbo].[PurchaseDetail] OFF
GO
SET IDENTITY_INSERT [dbo].[SongSet] ON 

INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (1, N'Wanna Be Startin Somethin', 1)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (2, N'Baby Be Mine', 1)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (3, N'The Girls Is Mine', 1)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (4, N'Jam - Michael Jackson', 2)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (5, N'Why You Wanna Trip on Me', 2)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (6, N'In The Closet', 2)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (7, N'Bad', 3)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (8, N'The Way You Make Me Fell', 3)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (9, N'Speed Demon', 3)
INSERT [dbo].[SongSet] ([id], [Name], [Album_id]) VALUES (10, N'Dirty Diana', 3)
SET IDENTITY_INSERT [dbo].[SongSet] OFF
GO
INSERT [dbo].[UserSession] ([id], [Password], [NameUser], [EmailUser], [Adress], [PhoneUser]) VALUES (N'1036598444', N'Nicolas1*', N'ADRIAN RAMIREZ', N'adrian.ramirez23@hotmail.com', N'CALLE 75 SUR # 53 -30', N'3014881243')
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [fk2] FOREIGN KEY([Album_id])
REFERENCES [dbo].[AlbumSet] ([id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [fk2]
GO
ALTER TABLE [dbo].[PurchaseDetail]  WITH CHECK ADD  CONSTRAINT [fk3] FOREIGN KEY([Client_id])
REFERENCES [dbo].[Client] ([id])
GO
ALTER TABLE [dbo].[PurchaseDetail] CHECK CONSTRAINT [fk3]
GO
ALTER TABLE [dbo].[SongSet]  WITH CHECK ADD  CONSTRAINT [fk1] FOREIGN KEY([Album_id])
REFERENCES [dbo].[AlbumSet] ([id])
GO
ALTER TABLE [dbo].[SongSet] CHECK CONSTRAINT [fk1]
GO
/****** Object:  StoredProcedure [dbo].[Compurent_PurchaseDetails_History]    Script Date: 24/01/2021 6:14:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Compurent_PurchaseDetails_History](
@Opc int,
@CLient_id nvarchar(10),
@Album_id int,
@Total real
)

AS

IF @Opc=1 BEGIN

   SELECT * FROM PurchaseDetail WHERE Client_id=@CLient_id

END

IF @Opc=2 BEGIN

   INSERT INTO PurchaseDetail 
   SELECT @CLient_id, @Album_id, @Total

END

GO
/****** Object:  StoredProcedure [dbo].[Compurent_User_History_Songs]    Script Date: 24/01/2021 6:14:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Compurent_User_History_Songs](
	@Opc int,
	@NameSong nvarchar(max),
	@Album_id int,
	@id int
	)
AS

IF @Opc=1 BEGIN

   SELECT id, [Name], Album_id FROM SongSet ORDER BY Album_id ASC

END

IF @Opc=2 BEGIN

   INSERT INTO SongSet 
   SELECT @NameSong, @Album_id

END

IF @Opc=3 BEGIN

   SELECT id, [Name], Album_id FROM SongSet WHERE id=@id

END

IF @Opc=4 BEGIN

   UPDATE SongSet
   SET [Name]=@NameSong, Album_id=@Album_id
   WHERE id=@id

END

IF @Opc=5 BEGIN

  IF EXISTS (SELECT '' FROM SongSet WHERE id=@id)BEGIN
     DELETE SongSet WHERE id=@id

	 SELECT 'La Canción ha sido eliminada con éxito'

  END ELSE BEGIN

     SELECT 'La Canción Buscada no existe' 
  END

END
GO
/****** Object:  StoredProcedure [dbo].[Compurent_User_Historys]    Script Date: 24/01/2021 6:14:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Compurent_User_Historys] (
	@opc int,
	@value nvarchar(max),
	@car int
	)
AS
/*HISTORY USER 1*/
IF @opc=1 BEGIN

    IF EXISTS (SELECT '' FROM SongSet WHERE [Name] LIKE '%'+@value+'%')BEGIN

	   SELECT TOP 1 A.id, A.[Name] FROM AlbumSet A INNER JOIN SongSet S ON A.id=S.Album_id
	   WHERE S.[Name] LIKE '%'+@value+'%'

	END ELSE BEGIN

	   SELECT id, [Name]  FROM AlbumSet WHERE [Name] like '%'+@value+'%'

	END

END

/*HISTORY USER 2*/
IF @opc=2 BEGIN

   SELECT id, [Name] FROM AlbumSet

END

IF @opc=3 BEGIN

   INSERT INTO AlbumSet
   SELECT @value

END

IF @opc=4 BEGIN

   UPDATE AlbumSet
   SET[Name]=@value
   WHERE id=@car 

END

IF @opc=5 BEGIN

    SELECT id, [Name] FROM AlbumSet WHERE id=@car 

END

IF @opc=6 BEGIN

   IF NOT EXISTS (SELECT '' FROM PurchaseDetail WHERE Album_id=@car)BEGIN

     DELETE AlbumSet WHERE id=@car 
	 SELECT 'El Álbum ha sido eliminado con éxito'

   END ELSE BEGIN 

     SELECT 'Para Eliminar este Álbum debe Eliminarse los registros de Compra que lo contienen'

   END

END
GO
/****** Object:  StoredProcedure [dbo].[Compurent_UserAdmin_History]    Script Date: 24/01/2021 6:14:15 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Compurent_UserAdmin_History](
@Opc int,
@id nvarchar(10),
@Pass nvarchar(30),
@NameUser nvarchar(100),
@EmailUser nvarchar(50),
@Address nvarchar(500),
@Phone nvarchar(20)
)
AS

IF @Opc=1 BEGIN

   SELECT  * FROM UserSession WHERE EmailUser=@EmailUser AND [Password]=@Pass

END

IF @Opc=2 BEGIN

    IF NOT EXISTS (SELECT '' FROM UserSession WHERE id=@id)BEGIN

	   INSERT INTO UserSession 
	   SELECT @id, @Pass, @NameUser, @EmailUser, @Address, @Phone
	   SELECT 'Registro Exitoso'

   END ELSE BEGIN
   
      SELECT 'El usuario ya se encuentra registrado'

   END
END
GO
