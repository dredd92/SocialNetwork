USE [master]
GO
/****** Object:  Database [SocialNetwork]    Script Date: 9/29/2016 12:06:02 AM ******/
CREATE DATABASE [SocialNetwork]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SocialNetwork', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SocialNetwork.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SocialNetwork_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\SocialNetwork_log.ldf' , SIZE = 1536KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SocialNetwork] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SocialNetwork].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SocialNetwork] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SocialNetwork] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SocialNetwork] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SocialNetwork] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SocialNetwork] SET ARITHABORT OFF 
GO
ALTER DATABASE [SocialNetwork] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SocialNetwork] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SocialNetwork] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SocialNetwork] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SocialNetwork] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SocialNetwork] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SocialNetwork] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SocialNetwork] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SocialNetwork] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SocialNetwork] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SocialNetwork] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SocialNetwork] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SocialNetwork] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SocialNetwork] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SocialNetwork] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SocialNetwork] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SocialNetwork] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SocialNetwork] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SocialNetwork] SET  MULTI_USER 
GO
ALTER DATABASE [SocialNetwork] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SocialNetwork] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SocialNetwork] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SocialNetwork] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [SocialNetwork] SET DELAYED_DURABILITY = DISABLED 
GO
USE [SocialNetwork]
GO
/****** Object:  UserDefinedFunction [dbo].[AdminCount]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[AdminCount](
@username nchar(255)
)
RETURNS bit
AS
BEGIN
	
	DECLARE @result int = (SELECT COUNT(Id) FROM [Admin] WHERE [Username] = @username)
	RETURN @result

END

GO
/****** Object:  UserDefinedFunction [dbo].[GetUserAge]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUserAge](
@birthDate date
)
RETURNS int
AS
BEGIN
	DECLARE @now date = GETDATE()
	DECLARE @result int = (CONVERT(int,CONVERT(char(8),@now,112))-CONVERT(char(8),@birthDate,112))/10000
	RETURN @result
END

GO
/****** Object:  UserDefinedFunction [dbo].[GetUserFriendsXml]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[GetUserFriendsXml](
@id int
)
RETURNS xml
AS
BEGIN

DECLARE @result xml = (
SELECT
		f.Id,
		f.First_Name,
		f.Last_Name,
		f.Sex,
		f.Username,
		f.Date_Of_Birth,
		cF.Id as Hometown_Id,
		cF.Name as Hometown_Name,
		f.[Password]
FROM
		[User] u
		LEFT JOIN
		City cU
		ON cU.Id = u.Hometown_Id
		INNER JOIN
		[User_Friend] ui
		ON u.Id = ui.[User_Id]
		INNER JOIN
		[User] f
		ON f.Id = ui.Friend_Id
		LEFT JOIN
		City cF
		ON cF.Id = f.Hometown_Id
WHERE
		u.Id = @id
FOR XML PATH('Friend'), ROOT('Friends')
)

	RETURN @result

END

GO
/****** Object:  UserDefinedFunction [dbo].[UserCount]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[UserCount](
@username varchar(255)
)
RETURNS int
AS
BEGIN
	
	RETURN (SELECT COUNT(Id) FROM [User] WHERE Username = @username)

END

GO
/****** Object:  Table [dbo].[Admin]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [char](64) NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[City]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[City](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](55) NOT NULL,
 CONSTRAINT [PK_City] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Image]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] NOT NULL,
	[Name] [nvarchar](255) NOT NULL,
	[Mime_Type] [varchar](255) NOT NULL,
	[Contents] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Message]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Message](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Sender_Id] [int] NOT NULL,
	[Receiver_Id] [int] NOT NULL,
	[Is_Read] [bit] NOT NULL,
	[Date_Sent] [datetime] NOT NULL,
	[Content] [nvarchar](2000) NOT NULL,
 CONSTRAINT [PK_Message] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](255) NOT NULL,
	[Password] [char](64) NOT NULL,
	[First_Name] [nvarchar](55) NOT NULL,
	[Last_Name] [nvarchar](55) NOT NULL,
	[Sex] [int] NOT NULL,
	[Hometown_Id] [int] NULL,
	[Date_Of_Birth] [date] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Friend]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Friend](
	[User_Id] [int] NOT NULL,
	[Friend_Id] [int] NOT NULL,
 CONSTRAINT [PK_User_Friend] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Friend_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[User_Image]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User_Image](
	[User_Id] [int] NOT NULL,
	[Image_Id] [int] NOT NULL,
 CONSTRAINT [PK_User_Image] PRIMARY KEY CLUSTERED 
(
	[User_Id] ASC,
	[Image_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  View [dbo].[UserView]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserView]
AS
SELECT        u.Id, u.Username, u.Password, u.First_Name, u.Last_Name, u.Sex, dbo.GetUserFriendsXml(u.Id) AS Friends, c.Id AS Hometown_Id, c.Name AS Hometown_Name, u.Date_Of_Birth
FROM            dbo.[User] AS u LEFT OUTER JOIN
                         dbo.City AS c ON c.Id = u.Hometown_Id

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_Admin_Username]    Script Date: 9/29/2016 12:06:03 AM ******/
CREATE NONCLUSTERED INDEX [IX_Admin_Username] ON [dbo].[Admin]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Message_Subjects]    Script Date: 9/29/2016 12:06:03 AM ******/
CREATE NONCLUSTERED INDEX [IX_Message_Subjects] ON [dbo].[Message]
(
	[Sender_Id] ASC,
	[Receiver_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Name]    Script Date: 9/29/2016 12:06:03 AM ******/
CREATE NONCLUSTERED INDEX [IX_User_Name] ON [dbo].[User]
(
	[First_Name] ASC,
	[Last_Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_User_Username]    Script Date: 9/29/2016 12:06:03 AM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_User_Username] ON [dbo].[User]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User_Receiver] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User_Receiver]
GO
ALTER TABLE [dbo].[Message]  WITH CHECK ADD  CONSTRAINT [FK_Message_User_Sender] FOREIGN KEY([Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Message] CHECK CONSTRAINT [FK_Message_User_Sender]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_City] FOREIGN KEY([Hometown_Id])
REFERENCES [dbo].[City] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_City]
GO
ALTER TABLE [dbo].[User_Friend]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Friend] CHECK CONSTRAINT [FK_User_Friend_User]
GO
ALTER TABLE [dbo].[User_Friend]  WITH CHECK ADD  CONSTRAINT [FK_User_Friend_User1] FOREIGN KEY([Friend_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Friend] CHECK CONSTRAINT [FK_User_Friend_User1]
GO
ALTER TABLE [dbo].[User_Image]  WITH CHECK ADD  CONSTRAINT [FK_User_Image_Image] FOREIGN KEY([Image_Id])
REFERENCES [dbo].[Image] ([Id])
GO
ALTER TABLE [dbo].[User_Image] CHECK CONSTRAINT [FK_User_Image_Image]
GO
ALTER TABLE [dbo].[User_Image]  WITH CHECK ADD  CONSTRAINT [FK_User_Image_User] FOREIGN KEY([User_Id])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[User_Image] CHECK CONSTRAINT [FK_User_Image_User]
GO
/****** Object:  StoredProcedure [dbo].[AddAdmin]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddAdmin](
@username varchar(255),
@password char(64),
@result bit OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @result = 0
	BEGIN TRANSACTION
		IF dbo.AdminCount(@username) = 0
		BEGIN
			INSERT INTO [Admin]([Username], [Password]) VALUES(@username, @password)
		END

		IF dbo.AdminCount(@username) > 1
		BEGIN
			ROLLBACK
			RETURN
		END
		SET @result = 1
		COMMIT

END

GO
/****** Object:  StoredProcedure [dbo].[AddUser]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddUser](
@id int,
@username varchar(255),
@password char(64),
@firstName nvarchar(55),
@lastName nvarchar(55),
@sex int,
@hometownId int NULL,
@dateOfBirth date NULL,
@result bit OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @result = 0
	BEGIN TRANSACTION
    IF dbo.UserCount(@username) = 0
	BEGIN
		INSERT INTO [User](Username, [Password], First_Name, Last_Name, Sex, Hometown_Id, Date_Of_Birth) VALUES(@username, @password, @firstName, @lastName, @sex, @hometownId, @dateOfBirth)
	END

	IF dbo.UserCount(@username) > 1
	BEGIN
		ROLLBACK
		RETURN
	END

	SET @result = 1
	COMMIT
END

GO
/****** Object:  StoredProcedure [dbo].[GetAdminById]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdminById](
@id int
)
AS
BEGIN
	SET NOCOUNT ON;
	SELECT
			Id,
			[Username],
			[Password]
	FROM
			[Admin]
	WHERE
			Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetAdminByUsername]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAdminByUsername](
@username varchar(255)
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
			Username,
			[Password]
	FROM
			[Admin]
	WHERE
			Username = @username
END

GO
/****** Object:  StoredProcedure [dbo].[GetAllUsers]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetAllUsers](
@pageNumber int,
@pageSize int
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
			Id,
			Username,
			[Password],
			First_Name,
			Last_Name,
			Sex,
			Friends,
			Hometown_Id,
			Hometown_Name,
			Date_Of_Birth

	FROM
			UserView
	ORDER BY
			Id
	OFFSET @pageNumber * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserById]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserById](
@id int
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
			Id,
			Username,
			[Password],
			First_Name,
			Last_Name,
			Sex,
			Friends,
			Hometown_Id,
			Hometown_Name,
			Date_Of_Birth
	FROM
			UserView
	WHERE
			Id = @id
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserBySearchData]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserBySearchData](
@name varchar(110) NULL,
@sex int NULL,
@ageFrom int NULL,
@ageTo int NULL,
@hometownId int NULL,
@pageNumber int,
@pageSize int
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
			Id,
			Username,
			[Password],
			First_Name,
			Last_Name,
			Sex,
			Friends,
			Hometown_Id,
			Hometown_Name,
			Date_Of_Birth
	FROM
			UserView
	WHERE
			First_Name + ' ' + Last_Name LIKE ISNULL(@name, '') + '%' AND
			Sex = ISNULL(@sex, Sex) AND
			Hometown_Id = ISNULL(@hometownId, Hometown_Id) 
	ORDER BY
			Id
	OFFSET @pageNumber * @pageSize ROWS FETCH NEXT @pageSize ROWS ONLY
END

GO
/****** Object:  StoredProcedure [dbo].[GetUserByUsername]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetUserByUsername](
@username varchar(255)
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT
			Id,
			Username,
			[Password],
			First_Name,
			Last_Name,
			Sex,
			Friends,
			Hometown_Id,
			Hometown_Name,
			Date_Of_Birth
	FROM
			UserView
	WHERE
			Username = @username
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveAdmin]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveAdmin](
@id int,
@result bit OUTPUT
)
AS
BEGIN
	DELETE [Admin]
	WHERE Id = @id

	SET @result = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[RemoveUser]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RemoveUser](
@id int,
@result bit OUTPUT
)
AS
BEGIN
    DELETE [User]
	WHERE Id = @id

	SET @result = @@ROWCOUNT
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateAdmin]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateAdmin](
@id int,
@newUsername varchar(255) NULL,
@newPassword char(64) NULL,
@result bit OUTPUT
)
AS
BEGIN
	SET @result = 0
	BEGIN TRANSACTION
	IF dbo.AdminUsernameCount(@newUsername) = 0
	BEGIN
		UPDATE [Admin]
		SET Username = ISNULL(@newUsername, Username),
			[Password] = ISNULL(@newPassword, [Password])
	END

	IF dbo.AdminUsernameCount(@newUsername) > 1
	BEGIN
		ROLLBACK
		RETURN
	END

	SET @result = 1
	COMMIT
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 9/29/2016 12:06:03 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser](
@id int,
@newUsername varchar(255) NULL,
@newPassword char(64) NULL,
@newFirstName nvarchar(55) NULL,
@newLastName nvarchar(55) NULL,
@newSex int NULL,
@newHometownId int NULL,
@newDateOfBirth date NULL,
@result bit OUTPUT
)
AS
BEGIN
	SET NOCOUNT ON;
	SET @result = 0
	BEGIN TRANSACTION
	IF dbo.UserCount(@newUsername) = 0
	BEGIN
		UPDATE [User]
		SET Username = ISNULL(@newUsername, Username),
			[Password] = ISNULL(@newPassword, [Password]),
			First_Name = ISNULL(@newFirstName, First_name),
			Last_Name = ISNULL(@newLastName, Last_Name),
			Sex = ISNULL(@newSex, Sex),
			Hometown_Id = ISNULL(@newHometownId, Hometown_Id),
			Date_Of_Birth = ISNULL(@newDateOfBirth, Date_Of_Birth)
	END

	IF dbo.UserCount(@newUsername) > 1
	BEGIN
		ROLLBACK
		RETURN
	END

	SET @result = 1
	COMMIT
			
END

GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "u"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 136
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 4
         End
         Begin Table = "c"
            Begin Extent = 
               Top = 6
               Left = 246
               Bottom = 102
               Right = 416
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserView'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'UserView'
GO
USE [master]
GO
ALTER DATABASE [SocialNetwork] SET  READ_WRITE 
GO
