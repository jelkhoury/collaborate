IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserProfile_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserProfile]'))
ALTER TABLE [dbo].[UserProfile] DROP CONSTRAINT [FK_UserProfile_EmploymentInfo]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_UserPosition_EmploymentInfo]') AND parent_object_id = OBJECT_ID(N'[dbo].[UserPosition]'))
ALTER TABLE [dbo].[UserPosition] DROP CONSTRAINT [FK_UserPosition_EmploymentInfo]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_User_UserProfile]') AND parent_object_id = OBJECT_ID(N'[dbo].[User]'))
ALTER TABLE [dbo].[User] DROP CONSTRAINT [FK_User_UserProfile]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_TextMessage_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[TextMessage]'))
ALTER TABLE [dbo].[TextMessage] DROP CONSTRAINT [FK_TextMessage_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt] DROP CONSTRAINT [FK_ReadReceipt_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_ReadReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[ReadReceipt]'))
ALTER TABLE [dbo].[ReadReceipt] DROP CONSTRAINT [FK_ReadReceipt_TextMessage]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT [FK_MessageReceiver_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT [FK_MessageReceiver_TextMessage]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_ReadReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT [FK_MessageReceiver_ReadReceipt]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_DeliveryReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] DROP CONSTRAINT [FK_MessageReceiver_DeliveryReceipt]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember] DROP CONSTRAINT [FK_GroupMember_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_GroupMember_Group_GroupId]') AND parent_object_id = OBJECT_ID(N'[dbo].[GroupMember]'))
ALTER TABLE [dbo].[GroupMember] DROP CONSTRAINT [FK_GroupMember_Group_GroupId]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_User]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt] DROP CONSTRAINT [FK_DeliveryReceipt_User]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_DeliveryReceipt_TextMessage]') AND parent_object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]'))
ALTER TABLE [dbo].[DeliveryReceipt] DROP CONSTRAINT [FK_DeliveryReceipt_TextMessage]
GO
/****** Object:  Table [dbo].[UserProfile]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserProfile]') AND type in (N'U'))
DROP TABLE [dbo].[UserProfile]
GO
/****** Object:  Table [dbo].[UserPosition]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserPosition]') AND type in (N'U'))
DROP TABLE [dbo].[UserPosition]
GO
/****** Object:  Table [dbo].[User]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type in (N'U'))
DROP TABLE [dbo].[User]
GO
/****** Object:  Table [dbo].[TextMessage]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TextMessage]') AND type in (N'U'))
DROP TABLE [dbo].[TextMessage]
GO
/****** Object:  Table [dbo].[ReadReceipt]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ReadReceipt]') AND type in (N'U'))
DROP TABLE [dbo].[ReadReceipt]
GO
/****** Object:  Table [dbo].[Position]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Position]') AND type in (N'U'))
DROP TABLE [dbo].[Position]
GO
/****** Object:  Table [dbo].[MessageReceiver]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[MessageReceiver]') AND type in (N'U'))
DROP TABLE [dbo].[MessageReceiver]
GO
/****** Object:  Table [dbo].[GroupMember]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[GroupMember]') AND type in (N'U'))
DROP TABLE [dbo].[GroupMember]
GO
/****** Object:  Table [dbo].[Group]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Group]') AND type in (N'U'))
DROP TABLE [dbo].[Group]
GO
/****** Object:  Table [dbo].[EmploymentInfo]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[EmploymentInfo]') AND type in (N'U'))
DROP TABLE [dbo].[EmploymentInfo]
GO
/****** Object:  Table [dbo].[Department]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
DROP TABLE [dbo].[Department]
GO
/****** Object:  Table [dbo].[DeliveryReceipt]    Script Date: 8/6/2017 10:21:37 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeliveryReceipt]') AND type in (N'U'))
DROP TABLE [dbo].[DeliveryReceipt]
GO
/****** Object:  Table [dbo].[DeliveryReceipt]    Script Date: 8/6/2017 10:21:37 PM ******/
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
/****** Object:  Table [dbo].[Department]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[EmploymentInfo]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[Group]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[GroupMember]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[MessageReceiver]    Script Date: 8/6/2017 10:21:38 PM ******/
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
	[ReadReceiptId] [int] NULL,
	[DeliveryReceiptId] [int] NULL,
 CONSTRAINT [PK_MessageReceiver] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Position]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[ReadReceipt]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[TextMessage]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[User]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[UserPosition]    Script Date: 8/6/2017 10:21:38 PM ******/
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
/****** Object:  Table [dbo].[UserProfile]    Script Date: 8/6/2017 10:21:38 PM ******/
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
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (64, 44, 5, 10, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (65, 44, 4, 9, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (66, 45, 5, 12, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (67, 45, 4, 11, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (68, 46, 5, 15, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (69, 46, 4, 13, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (70, 47, 5, 16, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (71, 47, 4, 14, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (72, 48, 4, 18, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (73, 48, 5, 17, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (74, 49, 4, 20, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (75, 49, 5, 19, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (76, 50, 5, 22, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (77, 50, 4, 21, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (78, 51, 4, 25, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (79, 51, 5, 23, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (80, 52, 4, 26, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (81, 52, 5, 24, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (82, 53, 4, 29, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (83, 53, 5, 27, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (84, 54, 5, 30, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (85, 54, 4, 28, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (86, 55, 5, 32, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (87, 55, 4, 31, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (88, 56, 4, 34, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (89, 56, 5, 33, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (90, 57, 4, 36, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (91, 57, 5, 35, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (92, 58, 4, 38, NULL)
GO
INSERT [dbo].[MessageReceiver] ([Id], [TextMessageId], [UserId], [ReadReceiptId], [DeliveryReceiptId]) VALUES (93, 58, 5, 37, NULL)
GO
SET IDENTITY_INSERT [dbo].[MessageReceiver] OFF
GO
SET IDENTITY_INSERT [dbo].[Position] ON 

GO
INSERT [dbo].[Position] ([Id], [Title]) VALUES (1, N'Director')
GO
SET IDENTITY_INSERT [dbo].[Position] OFF
GO
SET IDENTITY_INSERT [dbo].[ReadReceipt] ON 

GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (9, 44, 4, CAST(N'2017-08-05T21:58:20.8809232' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (10, 44, 5, CAST(N'2017-08-05T22:00:40.9128720' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (11, 45, 4, CAST(N'2017-08-05T22:07:35.7518243' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (12, 45, 5, CAST(N'2017-08-05T22:07:39.2017809' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (13, 46, 4, CAST(N'2017-08-05T22:07:59.5501853' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (14, 47, 4, CAST(N'2017-08-05T22:08:01.4747034' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (15, 46, 5, CAST(N'2017-08-05T22:08:15.0750226' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (16, 47, 5, CAST(N'2017-08-05T22:08:15.0750226' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (17, 48, 5, CAST(N'2017-08-05T22:08:46.1732527' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (18, 48, 4, CAST(N'2017-08-05T22:08:47.2508142' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (19, 49, 5, CAST(N'2017-08-05T22:08:51.0516306' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (20, 49, 4, CAST(N'2017-08-05T22:08:51.9160029' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (21, 50, 4, CAST(N'2017-08-05T22:09:35.7447596' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (22, 50, 5, CAST(N'2017-08-05T22:09:36.7499781' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (23, 51, 5, CAST(N'2017-08-05T22:09:39.9693541' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (24, 52, 5, CAST(N'2017-08-05T22:09:44.6528506' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (25, 51, 4, CAST(N'2017-08-05T22:09:46.0855084' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (26, 52, 4, CAST(N'2017-08-05T22:09:47.1235619' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (27, 53, 5, CAST(N'2017-08-05T22:09:50.6391350' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (28, 54, 4, CAST(N'2017-08-05T22:09:56.5528473' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (29, 53, 4, CAST(N'2017-08-05T22:09:56.7728483' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (30, 54, 5, CAST(N'2017-08-05T22:09:58.2089774' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (31, 55, 4, CAST(N'2017-08-05T22:10:42.2423231' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (32, 55, 5, CAST(N'2017-08-05T22:10:43.2351107' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (33, 56, 5, CAST(N'2017-08-06T22:16:50.7850708' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (34, 56, 4, CAST(N'2017-08-06T22:17:04.4115101' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (35, 57, 5, CAST(N'2017-08-06T22:19:23.6711838' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (36, 57, 4, CAST(N'2017-08-06T22:19:43.6573099' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (37, 58, 5, CAST(N'2017-08-06T22:20:36.3156127' AS DateTime2))
GO
INSERT [dbo].[ReadReceipt] ([Id], [TextMessageId], [UserId], [ReadDate]) VALUES (38, 58, 4, CAST(N'2017-08-06T22:20:41.5330797' AS DateTime2))
GO
SET IDENTITY_INSERT [dbo].[ReadReceipt] OFF
GO
SET IDENTITY_INSERT [dbo].[TextMessage] ON 

GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (44, N'first message', 2, 1, 4, CAST(N'2017-08-05T18:58:20.6970000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (45, N'testing read receipt', 2, 1, 4, CAST(N'2017-08-05T19:07:35.5210000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (46, N'ok so now wen you login you should see 2 unread messages', 2, 1, 4, CAST(N'2017-08-05T19:07:59.3720000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (47, N'deal ?', 2, 1, 4, CAST(N'2017-08-05T19:08:01.3580000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (48, N'yes deal, but it is not updating the left side', 2, 1, 5, CAST(N'2017-08-05T19:08:45.9950000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (49, N'and the design is ugly', 2, 1, 5, CAST(N'2017-08-05T19:08:50.9250000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (50, N'what about the delivery receipt, do we need to make it working now ?', 2, 1, 4, CAST(N'2017-08-05T19:09:35.4780000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (51, N'no need', 2, 1, 5, CAST(N'2017-08-05T19:09:39.8590000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (52, N'we will do it later', 2, 1, 5, CAST(N'2017-08-05T19:09:44.4600000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (53, N'lets fix the design for now', 2, 1, 5, CAST(N'2017-08-05T19:09:50.4500000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (54, N'ok deal', 2, 1, 4, CAST(N'2017-08-05T19:09:55.5900000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (55, N'is it working ?', 2, 1, 4, CAST(N'2017-08-05T19:10:42.0200000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (56, N'yup', 2, 1, 5, CAST(N'2017-08-06T19:16:50.6330000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (57, N'nop', 2, 1, 5, CAST(N'2017-08-06T19:19:23.5030000' AS DateTime2))
GO
INSERT [dbo].[TextMessage] ([Id], [Text], [DestinationId], [DestinationType], [SenderUserId], [SenderDate]) VALUES (58, N'.', 2, 1, 5, CAST(N'2017-08-06T19:20:36.1130000' AS DateTime2))
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
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_DeliveryReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_DeliveryReceipt] FOREIGN KEY([DeliveryReceiptId])
REFERENCES [dbo].[DeliveryReceipt] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_DeliveryReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_DeliveryReceipt]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_ReadReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver]  WITH CHECK ADD  CONSTRAINT [FK_MessageReceiver_ReadReceipt] FOREIGN KEY([ReadReceiptId])
REFERENCES [dbo].[ReadReceipt] ([Id])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_MessageReceiver_ReadReceipt]') AND parent_object_id = OBJECT_ID(N'[dbo].[MessageReceiver]'))
ALTER TABLE [dbo].[MessageReceiver] CHECK CONSTRAINT [FK_MessageReceiver_ReadReceipt]
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
