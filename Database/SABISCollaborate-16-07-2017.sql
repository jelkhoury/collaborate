IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT IF EXISTS [FK_UserProfile_EmploymentInfo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserPosition]') AND type in (N'U'))
ALTER TABLE [dbo].[UserPosition] DROP CONSTRAINT IF EXISTS [FK_UserPosition_EmploymentInfo]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT IF EXISTS [FK_User_UserProfile]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextMessage]') AND type in (N'U'))
ALTER TABLE [dbo].[TextMessage] DROP CONSTRAINT IF EXISTS [FK_TextMessage_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadReceipt]') AND type in (N'U'))
ALTER TABLE [dbo].[ReadReceipt] DROP CONSTRAINT IF EXISTS [FK_ReadReceipt_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadReceipt]') AND type in (N'U'))
ALTER TABLE [dbo].[ReadReceipt] DROP CONSTRAINT IF EXISTS [FK_ReadReceipt_TextMessage]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessageReceiver]') AND type in (N'U'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT IF EXISTS [FK_MessageReceiver_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessageReceiver]') AND type in (N'U'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT IF EXISTS [FK_MessageReceiver_TextMessage]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMember]') AND type in (N'U'))
ALTER TABLE [dbo].[GroupMember] DROP CONSTRAINT IF EXISTS [FK_GroupMember_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMember]') AND type in (N'U'))
ALTER TABLE [dbo].[GroupMember] DROP CONSTRAINT IF EXISTS [FK_GroupMember_Group_GroupId]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]') AND type in (N'U'))
ALTER TABLE [dbo].[DeliveryReceipt] DROP CONSTRAINT IF EXISTS [FK_DeliveryReceipt_User]
GO
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]') AND type in (N'U'))
ALTER TABLE [dbo].[DeliveryReceipt] DROP CONSTRAINT IF EXISTS [FK_DeliveryReceipt_TextMessage]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[UserPosition]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[UserPosition]
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[User]
GO
/****** Object:  Table [dbo].[TextMessage]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[TextMessage]
GO
/****** Object:  Table [dbo].[ReadReceipt]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[ReadReceipt]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[Position]
GO
/****** Object:  Table [dbo].[MessageReceiver]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[MessageReceiver]
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[GroupMember]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[Group]
GO
/****** Object:  Table [dbo].[EmploymentInfo]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[EmploymentInfo]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[Department]
GO
/****** Object:  Table [dbo].[DeliveryReceipt]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP TABLE IF EXISTS [dbo].[DeliveryReceipt]
GO
/****** Object:  User [collaborate]    Script Date: 7/16/2017 10:50:22 PM ******/
DROP USER IF EXISTS [collaborate]
GO
/****** Object:  User [collaborate]    Script Date: 7/16/2017 10:50:22 PM ******/
IF NOT EXISTS (SELECT * FROM sys.database_principals WHERE name = N'collaborate')
CREATE USER [collaborate] FOR LOGIN [collaborate] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [collaborate]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [collaborate]
GO
/****** Object:  Table [dbo].[DeliveryReceipt]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[DeliveryReceipt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MessageId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[DeliveryDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_DeliveryReceipt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Department]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Department](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Department] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[EmploymentInfo]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmploymentInfo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[EmploymentInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmploymentDate] [date] NOT NULL,
 CONSTRAINT [PK_EmploymentInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Group]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Group]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Group](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[CreatedByUserId] [int] NOT NULL,
	[CurrentOwnerUserId] [int] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Group] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMember]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[GroupMember](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[GroupId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_GroupMember] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[MessageReceiver]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessageReceiver]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[MessageReceiver](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextMessageId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[IsRead] [bit] NOT NULL,
 CONSTRAINT [PK_MessageReceiver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Position]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Position](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Position] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[ReadReceipt]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadReceipt]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[ReadReceipt](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[TextMessageId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[ReadDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_ReadReceipt] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TextMessage]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextMessage]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TextMessage](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](max) NOT NULL,
	[DestinationId] [int] NOT NULL,
	[DestinationType] [int] NOT NULL,
	[SenderUserId] [int] NOT NULL,
	[SenderDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_TextMessage] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[User]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserProfileId] [int] NULL,
	[Username] [varchar](50) NOT NULL,
	[PasswordHash] [nvarchar](200) NOT NULL,
	[IdentifierEmail] [nvarchar](200) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreatedDate] [datetime] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserPosition]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserPosition]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserPosition](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DepartmentId] [int] NOT NULL,
	[PositionId] [int] NOT NULL,
	[EmploymentInfoId] [int] NOT NULL,
 CONSTRAINT [PK_UserPosition] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 7/16/2017 10:50:22 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[UserProfile](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Nickname] [nvarchar](50) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Gender] [int] NOT NULL,
	[MaritalStatus] [int] NOT NULL,
	[BirthDate] [date] NULL,
	[PictureId] [varchar](50) NULL,
	[EmploymentInfoId] [int] NULL,
 CONSTRAINT [PK_UserProfile] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET IDENTITY_INSERT [dbo].[Department] ON 

GO
INSERT [dbo].[Department] ([Id], [Name]) VALUES (1, N'Software Development')
GO
SET IDENTITY_INSERT [dbo].[Department] OFF
GO
SET IDENTITY_INSERT [dbo].[EmploymentInfo] ON 

GO
INSERT [dbo].[EmploymentInfo] ([Id], [EmploymentDate]) VALUES (4, CAST(N'0001-01-01' AS Date))
GO
INSERT [dbo].[EmploymentInfo] ([Id], [EmploymentDate]) VALUES (5, CAST(N'0001-01-01' AS Date))
GO
SET IDENTITY_INSERT [dbo].[EmploymentInfo] OFF
GO
SET IDENTITY_INSERT [dbo].[Group] ON 

GO
INSERT [dbo].[Group] ([Id], [Name], [CreatedByUserId], [CurrentOwnerUserId], [CreatedDate]) VALUES (2, N'SABIS IT', 1, 1, CAST(N'2017-07-11T21:09:27.9366667' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[Group] OFF
GO
SET IDENTITY_INSERT [dbo].[GroupMember] ON 

GO
INSERT [dbo].[GroupMember] ([Id], [GroupId], [UserId]) VALUES (8, 2, 4)
GO
INSERT [dbo].[GroupMember] ([Id], [GroupId], [UserId]) VALUES (9, 2, 5)
GO
SET IDENTITY_INSERT [dbo].[GroupMember] OFF
GO
SET IDENTITY_INSERT [dbo].[MessageReceiver] ON 

GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (2, 13, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (3, 13, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (4, 14, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (5, 14, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (6, 15, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (7, 15, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (8, 16, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (9, 16, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (10, 17, 4, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (11, 17, 5, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (12, 18, 4, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (13, 18, 5, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (14, 19, 4, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (15, 19, 5, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (16, 20, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (17, 20, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (18, 21, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (19, 21, 5, 0)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (20, 22, 4, 1)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [IsRead]) VALUES (21, 22, 5, 0)
GO
SET IDENTITY_INSERT [dbo].[MessageReceiver] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

GO
INSERT [dbo].[Position] ([Id], [Title]) VALUES (1, N'Director')
GO
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[TextMessage] ON 

GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (10, N'hello', 2, 1, 4, CAST(N'2017-07-13T19:22:56.3580000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (11, N'test', 2, 1, 4, CAST(N'2017-07-14T20:25:15.6680000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (13, N'999', 2, 1, 4, CAST(N'2017-07-14T20:37:16.8610000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (14, N'test', 2, 1, 4, CAST(N'2017-07-16T19:12:23.6360000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (15, N'ok ?', 2, 1, 4, CAST(N'2017-07-16T19:12:26.1540000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (16, N'deal ?', 2, 1, 4, CAST(N'2017-07-16T19:12:28.0000000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (17, N'ok', 2, 1, 5, CAST(N'2017-07-16T19:15:01.7320000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (18, N'what is this ?', 2, 1, 5, CAST(N'2017-07-16T19:16:26.9990000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (19, N'what ?', 2, 1, 5, CAST(N'2017-07-16T19:16:42.1940000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (20, N'ok ?', 2, 1, 4, CAST(N'2017-07-16T19:16:52.9370000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (21, N'lets go', 2, 1, 4, CAST(N'2017-07-16T19:49:18.0330000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (22, N'where ?', 2, 1, 4, CAST(N'2017-07-16T19:49:23.0540000' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[TextMessage] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

GO
INSERT [dbo].[User] ([Id], [UserProfileId], [Username], [PasswordHash], [IdentifierEmail], [IsActive], [CreatedDate]) VALUES (4, 8, N'jek', N'a+b=*1*b+a', N'joseph.elkhoury@outlook.com', 1, CAST(N'2017-07-13T22:09:33.663' AS DateTime))
GO
INSERT [dbo].[User] ([Id], [UserProfileId], [Username], [PasswordHash], [IdentifierEmail], [IsActive], [CreatedDate]) VALUES (5, 9, N'egh', N'a+b=*1*b+a', N'eghazal@sabis.net', 1, CAST(N'2017-07-13T22:11:44.857' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[UserPosition] ON 

GO
INSERT [dbo].[UserPosition] ([Id], [DepartmentId], [PositionId], [EmploymentInfoId]) VALUES (3, 1, 1, 4)
GO
INSERT [dbo].[UserPosition] ([Id], [DepartmentId], [PositionId], [EmploymentInfoId]) VALUES (4, 1, 1, 5)
GO
SET IDENTITY_INSERT [dbo].[UserPosition] OFF
GO
SET IDENTITY_INSERT [dbo].[UserProfile] ON 

GO
INSERT [dbo].[UserProfile] ([Id], [Nickname], [FirstName], [LastName], [Gender], [MaritalStatus], [BirthDate], [PictureId], [EmploymentInfoId]) VALUES (8, N'jek', N'Joseph', N'El Khoury', 1, 0, CAST(N'1990-05-17' AS Date), NULL, 4)
GO
INSERT [dbo].[UserProfile] ([Id], [Nickname], [FirstName], [LastName], [Gender], [MaritalStatus], [BirthDate], [PictureId], [EmploymentInfoId]) VALUES (9, N'elie', N'Elias', N'El Ghazal', 1, 0, CAST(N'2017-07-03' AS Date), NULL, 5)
GO
SET IDENTITY_INSERT [dbo].[UserProfile] OFF
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryReceipt_TextMessage] FOREIGN KEY([MessageId])
REFERENCES [dbo].[TextMessage] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt] CHECK CONSTRAINT [FK_DeliveryReceipt_TextMessage]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt]  WITH CHECK ADD  CONSTRAINT [FK_DeliveryReceipt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt] CHECK CONSTRAINT [FK_DeliveryReceipt_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_Group_GroupId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_Group_GroupId] FOREIGN KEY([GroupId])
REFERENCES [dbo].[Group] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_Group_GroupId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_Group_GroupId]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember]  WITH CHECK ADD  CONSTRAINT [FK_GroupMember_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember] CHECK CONSTRAINT [FK_GroupMember_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_TextMessage] FOREIGN KEY([TextMessageId])
REFERENCES [dbo].[TextMessage] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_TextMessage]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ReadReceipt_TextMessage] FOREIGN KEY([TextMessageId])
REFERENCES [dbo].[TextMessage] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt] CHECK CONSTRAINT [FK_ReadReceipt_TextMessage]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt]  WITH CHECK ADD  CONSTRAINT [FK_ReadReceipt_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt] CHECK CONSTRAINT [FK_ReadReceipt_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TextMessage_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[TextMessage]'))
ALTER TABLE [dbo].[TextMessage]  WITH CHECK ADD  CONSTRAINT [FK_TextMessage_User] FOREIGN KEY([SenderUserId])
REFERENCES [dbo].[User] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TextMessage_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[TextMessage]'))
ALTER TABLE [dbo].[TextMessage] CHECK CONSTRAINT [FK_TextMessage_User]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_UserProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserProfile] FOREIGN KEY([UserProfileId])
REFERENCES [dbo].[UserProfile] ([Id])
ON DELETE CASCADE
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_UserProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserProfile]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserPosition_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserPosition]'))
ALTER TABLE [dbo].[UserPosition]  WITH CHECK ADD  CONSTRAINT [FK_UserPosition_EmploymentInfo] FOREIGN KEY([EmploymentInfoId])
REFERENCES [dbo].[EmploymentInfo] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserPosition_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserPosition]'))
ALTER TABLE [dbo].[UserPosition] CHECK CONSTRAINT [FK_UserPosition_EmploymentInfo]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserProfile_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile]  WITH CHECK ADD  CONSTRAINT [FK_UserProfile_EmploymentInfo] FOREIGN KEY([EmploymentInfoId])
REFERENCES [dbo].[EmploymentInfo] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserProfile_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile] CHECK CONSTRAINT [FK_UserProfile_EmploymentInfo]
GO
