USE [StickyNote]
GO

/****** Object:  Table [dbo].[Category]    Script Date: 10/5/2018 9:30:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[Note]    Script Date: 10/5/2018 9:30:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Note](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Content] [varchar](250) NULL,
	[CreateDate] [datetime] NULL,
	[Stickied] [bit] NULL,
	[Completed] [bit] NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotesPerCategory]    Script Date: 10/5/2018 9:30:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotesPerCategory](
	[CategoryId] [int] NULL,
	[NoteId] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[NotesPerUser]    Script Date: 10/5/2018 9:30:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[NotesPerUser](
	[UserId] [int] NULL,
	[NoteId] [int] NULL
) ON [PRIMARY]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10/5/2018 9:30:09 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserName] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Email] [varchar](50) NULL,
	[CreateDate] [datetime] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[NotesPerCategory]  WITH CHECK ADD  CONSTRAINT [FK_NotesPerCategory_Category] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[NotesPerCategory] CHECK CONSTRAINT [FK_NotesPerCategory_Category]
GO

ALTER TABLE [dbo].[NotesPerCategory]  WITH CHECK ADD  CONSTRAINT [FK_NotesPerCategory_Note] FOREIGN KEY([NoteId])
REFERENCES [dbo].[Note] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[NotesPerCategory] CHECK CONSTRAINT [FK_NotesPerCategory_Note]
GO

ALTER TABLE [dbo].[NotesPerUser]  WITH CHECK ADD  CONSTRAINT [FK_NotesPerUser_Note] FOREIGN KEY([NoteId])
REFERENCES [dbo].[Note] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[NotesPerUser] CHECK CONSTRAINT [FK_NotesPerUser_Note]
GO

ALTER TABLE [dbo].[NotesPerUser]  WITH CHECK ADD  CONSTRAINT [FK_NotesPerUser_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[NotesPerUser] CHECK CONSTRAINT [FK_NotesPerUser_User]
GO


