USE [ToDo_test]
GO
/****** Object:  Table [dbo].[categories]    Script Date: 12/12/2016 5:40:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[categories_tasks]    Script Date: 12/12/2016 5:40:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[categories_tasks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[category_id] [int] NULL,
	[task_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[tasks]    Script Date: 12/12/2016 5:40:07 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tasks](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[categories_tasks] ON 

INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (1, 6, 4)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (2, 7, 6)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (3, 7, 7)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (4, 13, 8)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (5, 14, 10)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (6, 14, 11)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (7, 15, 18)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (8, 17, 19)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (9, 23, 20)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (12, 25, 27)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (13, 27, 28)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (14, 33, 29)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (15, 34, 31)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (16, 34, 32)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (18, 41, 34)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (19, 42, 36)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (20, 42, 37)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (22, 44, 42)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (25, 48, 48)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (26, 50, 49)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (28, 57, 51)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (29, 58, 53)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (30, 58, 54)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (10, 24, 22)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (11, 24, 23)
INSERT [dbo].[categories_tasks] ([id], [category_id], [task_id]) VALUES (23, 46, 43)
SET IDENTITY_INSERT [dbo].[categories_tasks] OFF
