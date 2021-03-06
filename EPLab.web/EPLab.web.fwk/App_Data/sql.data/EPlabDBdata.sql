--USE [EPLlabDB]
--GO
/****** Object:  Table [dbo].[domainCases]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[domainCases](
	[domainCaseId] [uniqueidentifier] NOT NULL,
	[domainId] [uniqueidentifier] NOT NULL,
	[domainCaseName] [nvarchar](50) NOT NULL,
	[rangeMin] [nvarchar](50) NULL,
	[rangeMax] [nvarchar](50) NULL,
	[domainCaseDescription] [nvarchar](999) NULL,
 CONSTRAINT [PK_domainCases] PRIMARY KEY CLUSTERED 
(
	[domainId] ASC,
	[domainCaseName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[domains]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[domains](
	[domainId] [uniqueidentifier] NOT NULL,
	[domainName] [varchar](50) NOT NULL,
	[domainDescription] [nvarchar](999) NULL,
	[basicType] [nvarchar](50) NULL,
	[isDomainCaseId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_domains] PRIMARY KEY CLUSTERED 
(
	[domainId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[expressions]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[expressions](
	[expressionId] [uniqueidentifier] NOT NULL,
	[source] [varchar](50) NOT NULL,
	[expressionDesc] [nvarchar](999) NULL,
	[queryId] [uniqueidentifier] NULL,
	[operatorId] [uniqueidentifier] NOT NULL,
	[paraField1id] [uniqueidentifier] NULL,
	[para1externalName] [nvarchar](50) NULL,
	[subExpression1Id] [uniqueidentifier] NULL,
	[paraField2id] [uniqueidentifier] NULL,
	[para2externalName] [nvarchar](50) NULL,
	[subExpression2Id] [uniqueidentifier] NULL,
	[paraField3id] [uniqueidentifier] NULL,
	[para3externalName] [nvarchar](50) NULL,
	[subExpression3Id] [uniqueidentifier] NULL,
	[paraField4id] [uniqueidentifier] NULL,
	[para4externalName] [nvarchar](50) NULL,
	[subExpression4Id] [uniqueidentifier] NULL,
	[paraField5id] [uniqueidentifier] NULL,
	[para5externalName] [nvarchar](50) NULL,
	[subExpression5Id] [uniqueidentifier] NULL,
 CONSTRAINT [PK_expressions] PRIMARY KEY CLUSTERED 
(
	[expressionId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fields]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fields](
	[fieldId] [uniqueidentifier] NOT NULL,
	[tableId] [uniqueidentifier] NOT NULL,
	[fieldName] [nvarchar](50) NOT NULL,
	[fieldDesc] [nvarchar](999) NULL,
	[primaryOrder] [int] NULL,
	[foreignFieldId] [uniqueidentifier] NULL,
	[defaultValue] [nvarchar](450) NULL,
	[domainId] [uniqueidentifier] NULL,
	[defaultOrder] [int] NULL,
 CONSTRAINT [PK_fields] PRIMARY KEY CLUSTERED 
(
	[fieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[fieldText]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[fieldText](
	[fieldTextId] [bigint] IDENTITY(1,1) NOT NULL,
	[rowId] [uniqueidentifier] NOT NULL,
	[fieldId] [uniqueidentifier] NOT NULL,
	[fieldStrMax] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_fieldText] PRIMARY KEY CLUSTERED 
(
	[fieldTextId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[operators]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[operators](
	[operatorId] [uniqueidentifier] NOT NULL,
	[source] [varchar](50) NOT NULL,
	[operatorName] [nvarchar](50) NOT NULL,
	[operatorDesc] [nvarchar](999) NULL,
	[stringInSourceCode] [nvarchar](50) NOT NULL,
	[isPrefix] [bit] NOT NULL,
	[paraNum] [int] NOT NULL,
 CONSTRAINT [PK_operators] PRIMARY KEY CLUSTERED 
(
	[source] ASC,
	[operatorName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[queries]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[queries](
	[queryId] [uniqueidentifier] NOT NULL,
	[queryName] [nvarchar](50) NOT NULL,
	[queryDesc] [nvarchar](999) NULL,
	[tableId] [uniqueidentifier] NULL,
	[tableAlias] [nvarchar](50) NULL,
	[whereExpressionId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_queries] PRIMARY KEY CLUSTERED 
(
	[queryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[queryFields]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[queryFields](
	[queryFieldId] [uniqueidentifier] NOT NULL,
	[queryId] [uniqueidentifier] NOT NULL,
	[fieldId] [uniqueidentifier] NULL,
	[previousNo] [smallint] NULL,
	[displayOrder] [int] NOT NULL,
	[orderByOrder] [int] NOT NULL,
	[orderByDesc] [bit] NOT NULL,
	[expressionId] [uniqueidentifier] NULL,
	[save2fieldId] [uniqueidentifier] NULL,
 CONSTRAINT [PK_queryFields_1] PRIMARY KEY CLUSTERED 
(
	[queryFieldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[tables]    Script Date: 2020/9/6 下午 08:36:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[tables](
	[tableId] [uniqueidentifier] NOT NULL,
	[tableName] [nvarchar](50) NOT NULL,
	[tableDesc] [nvarchar](999) NULL,
 CONSTRAINT [PK_tables] PRIMARY KEY CLUSTERED 
(
	[tableId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[expressions] ([expressionId], [source], [expressionDesc], [queryId], [operatorId], [paraField1id], [para1externalName], [subExpression1Id], [paraField2id], [para2externalName], [subExpression2Id], [paraField3id], [para3externalName], [subExpression3Id], [paraField4id], [para4externalName], [subExpression4Id], [paraField5id], [para5externalName], [subExpression5Id]) VALUES (N'c9ff5f17-84b0-4cec-ae6f-693985b2c3fd', N'sql', N'operator and, para1: expression1, para2 expression2', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'547a6dd0-ec48-41e5-bc4f-dc029b97a0c9', NULL, NULL, N'e0d487f4-7f90-47ae-b2ce-a1b9c5fe88b6', NULL, NULL, N'a55ceaaa-3df0-4764-968d-f7cdd712c5f8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[expressions] ([expressionId], [source], [expressionDesc], [queryId], [operatorId], [paraField1id], [para1externalName], [subExpression1Id], [paraField2id], [para2externalName], [subExpression2Id], [paraField3id], [para3externalName], [subExpression3Id], [paraField4id], [para4externalName], [subExpression4Id], [paraField5id], [para5externalName], [subExpression5Id]) VALUES (N'e0d487f4-7f90-47ae-b2ce-a1b9c5fe88b6', N'sql', N'operator =, para1:field of dealdate, para2: external parameter @dealdate', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'd425cdab-8d9b-46ea-b73a-a6f3ef281737', N'b205442e-d2e5-48da-be28-5b5a23aa0dcc', NULL, NULL, NULL, N'dealdate', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[expressions] ([expressionId], [source], [expressionDesc], [queryId], [operatorId], [paraField1id], [para1externalName], [subExpression1Id], [paraField2id], [para2externalName], [subExpression2Id], [paraField3id], [para3externalName], [subExpression3Id], [paraField4id], [para4externalName], [subExpression4Id], [paraField5id], [para5externalName], [subExpression5Id]) VALUES (N'd90144da-96f6-4c70-8b08-b64b6e73c398', N'sql', N'operator >, para1: field of open, para2: external parameter @lowestOpen', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'b618b843-9728-4507-a976-91d8e6af0fce', N'9e7a1a9f-e8a6-4c39-8790-6bd5a263f623', NULL, NULL, NULL, N'lowestOpen', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[expressions] ([expressionId], [source], [expressionDesc], [queryId], [operatorId], [paraField1id], [para1externalName], [subExpression1Id], [paraField2id], [para2externalName], [subExpression2Id], [paraField3id], [para3externalName], [subExpression3Id], [paraField4id], [para4externalName], [subExpression4Id], [paraField5id], [para5externalName], [subExpression5Id]) VALUES (N'604ebf3d-c587-49de-871a-c823623e40c8', N'sql', N'operator <=, para1: field of open, para2: field of close', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'795da7b7-a1ef-4b71-805e-60867f24d4ea', N'9e7a1a9f-e8a6-4c39-8790-6bd5a263f623', NULL, NULL, N'2593a7b0-29ba-45d8-a5f7-c112596a2d5b', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[expressions] ([expressionId], [source], [expressionDesc], [queryId], [operatorId], [paraField1id], [para1externalName], [subExpression1Id], [paraField2id], [para2externalName], [subExpression2Id], [paraField3id], [para3externalName], [subExpression3Id], [paraField4id], [para4externalName], [subExpression4Id], [paraField5id], [para5externalName], [subExpression5Id]) VALUES (N'a55ceaaa-3df0-4764-968d-f7cdd712c5f8', N'sql', N'operator or, para1: expression1, para2 expression2', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'7e4dba6f-5dbc-4f1b-8f67-82aa4b56b762', NULL, NULL, N'd90144da-96f6-4c70-8b08-b64b6e73c398', NULL, NULL, N'604ebf3d-c587-49de-871a-c823623e40c8', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'2c2fb31b-8bf1-453a-9e8f-0c2f0553ab21', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'lastdate', N'String', NULL, NULL, NULL, NULL, 5)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'7c59355d-fba7-4912-968a-111aa36eac00', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'lastSvolume', N'Decimal', NULL, NULL, NULL, NULL, 7)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'ba34d2a1-0d05-408f-91e5-19d0747d0c65', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'dealtime', N'String', NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'17697724-9f78-47b0-a1f5-3dec7f20ca1e', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'close', N'Decimal', NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'64042f6f-9c38-4d84-b66a-469a4be4f56e', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'volume', N'Int32', NULL, NULL, NULL, NULL, 8)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'6b283eb4-555d-47e3-8ff1-48c89afb244f', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'dealdatetime', N'String', NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'b205442e-d2e5-48da-be28-5b5a23aa0dcc', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'dealdate', N'String', NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'5da90c8d-769e-4c6a-963b-5fe2fe965e87', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'section', N'Int32', NULL, NULL, NULL, NULL, 10)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'9e7a1a9f-e8a6-4c39-8790-6bd5a263f623', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'open', N'Decimal', NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'7f010fdc-48c0-4a3e-8465-a7d592ba972d', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'aVolume', N'Int32', NULL, NULL, NULL, NULL, 4)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'34b4e727-75b4-47a1-a768-ac48560bcb06', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'lastAvolume', N'Decimal', NULL, NULL, NULL, NULL, 8)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'bcefeebf-a775-404f-a3d2-b7a35dea9097', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'lastclose', N'Decimal', NULL, NULL, NULL, NULL, 6)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'2593a7b0-29ba-45d8-a5f7-c112596a2d5b', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'close', N'Decimal', NULL, NULL, NULL, NULL, 7)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'31b0e136-43a5-410d-9bd2-d89d3bdcc95b', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'low', N'Decimal', NULL, NULL, NULL, NULL, 6)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'105dda3e-f786-41d9-8e0c-d8c614f9b6ef', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'dealmonth', N'String', NULL, NULL, NULL, NULL, 9)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'c9706409-613b-49df-81e5-dd747b9bd840', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'sVolume', N'Int32', NULL, NULL, NULL, NULL, 3)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'fc80744d-4001-42ba-b3f0-e9cd39130382', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'high', N'Decimal', NULL, NULL, NULL, NULL, 5)
INSERT [dbo].[fields] ([fieldId], [tableId], [fieldName], [fieldDesc], [primaryOrder], [foreignFieldId], [defaultValue], [domainId], [defaultOrder]) VALUES (N'0263bd10-90d7-496c-9012-f1618c504aaa', N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'dealdate', N'String', NULL, NULL, NULL, NULL, 1)
GO
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'547a6dd0-ec48-41e5-bc4f-dc029b97a0c9', N'sql', N'SQL_AND', NULL, N'and', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'd425cdab-8d9b-46ea-b73a-a6f3ef281737', N'sql', N'SQL_EQUAL', NULL, N'=', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'b618b843-9728-4507-a976-91d8e6af0fce', N'sql', N'SQL_GREATER', NULL, N'>', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'7b88dc13-80bd-4530-a852-4639dee23f40', N'sql', N'SQL_GREATEROREQUAL', NULL, N'>=', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'0dc81bc9-5576-45b4-892c-f95813307e98', N'sql', N'SQL_ISNULL', NULL, N'is null', 0, 1)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'3bf8aa11-e8c6-4a25-b805-8100c6aac26a', N'sql', N'SQL_NOT', NULL, N'not', 1, 1)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'55aefeb1-440c-4a06-86e3-72bfc851d714', N'sql', N'SQL_NOTEQUAL', NULL, N'!=', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'7e4dba6f-5dbc-4f1b-8f67-82aa4b56b762', N'sql', N'SQL_OR', NULL, N'or', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'23a562f9-b26b-43f3-9400-9b0956c1547b', N'sql', N'SQL_SMALLER', NULL, N'<', 0, 2)
INSERT [dbo].[operators] ([operatorId], [source], [operatorName], [operatorDesc], [stringInSourceCode], [isPrefix], [paraNum]) VALUES (N'795da7b7-a1ef-4b71-805e-60867f24d4ea', N'sql', N'SQL_SMALLEROREQUAL', NULL, N'<=', 0, 2)
GO
INSERT [dbo].[queries] ([queryId], [queryName], [queryDesc], [tableId], [tableAlias], [whereExpressionId]) VALUES (N'75732706-ee00-4ea4-be7a-44e7ed240177', N'QohlcBydate', N'query for table ohlc by dealdate', N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'ohlc', N'e0d487f4-7f90-47ae-b2ce-a1b9c5fe88b6')
GO
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'6de98513-f587-47e6-b871-0998988c0914', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'64042f6f-9c38-4d84-b66a-469a4be4f56e', 0, 6, 0, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'63c8d023-5f60-4b42-adcc-19235d1a6438', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'b205442e-d2e5-48da-be28-5b5a23aa0dcc', 0, 0, 0, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'c173d2b0-6a04-4172-b2f0-385c5c86973b', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'ba34d2a1-0d05-408f-91e5-19d0747d0c65', 0, 1, 1, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'808e3f1d-caf9-4602-ab95-51c0b9dc1ad6', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'31b0e136-43a5-410d-9bd2-d89d3bdcc95b', 0, 4, 0, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'b83e0695-2259-4cbb-8e84-628ba6c2f658', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'fc80744d-4001-42ba-b3f0-e9cd39130382', 0, 3, 0, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'2b8ccd3e-fea7-461f-a132-8da1a6ff63c0', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'2593a7b0-29ba-45d8-a5f7-c112596a2d5b', 0, 5, 0, 0, NULL, NULL)
INSERT [dbo].[queryFields] ([queryFieldId], [queryId], [fieldId], [previousNo], [displayOrder], [orderByOrder], [orderByDesc], [expressionId], [save2fieldId]) VALUES (N'2d156044-c353-4978-8ffc-d71aab231527', N'75732706-ee00-4ea4-be7a-44e7ed240177', N'9e7a1a9f-e8a6-4c39-8790-6bd5a263f623', 0, 2, 0, 0, NULL, NULL)
GO
INSERT [dbo].[tables] ([tableId], [tableName], [tableDesc]) VALUES (N'2b36561f-53c8-42ca-a7a6-0b2de4c2e00e', N'testTable', N'test table desc')
INSERT [dbo].[tables] ([tableId], [tableName], [tableDesc]) VALUES (N'889cd40e-ba39-4985-a434-902e69ec8b7a', N'dealdates', NULL)
INSERT [dbo].[tables] ([tableId], [tableName], [tableDesc]) VALUES (N'ddc58962-c0ae-4327-9ed9-d9e516244431', N'ohlc', NULL)
GO
ALTER TABLE [dbo].[domainCases] ADD  CONSTRAINT [DF_domainCases_domainCaseId]  DEFAULT (newid()) FOR [domainCaseId]
GO
ALTER TABLE [dbo].[domains] ADD  CONSTRAINT [DF_domains_domainId]  DEFAULT (newid()) FOR [domainId]
GO
ALTER TABLE [dbo].[expressions] ADD  CONSTRAINT [DF_expressions_expressionId]  DEFAULT (newid()) FOR [expressionId]
GO
ALTER TABLE [dbo].[expressions] ADD  CONSTRAINT [DF_expressions_source]  DEFAULT ('sql server') FOR [source]
GO
ALTER TABLE [dbo].[fields] ADD  CONSTRAINT [DF_fields_fieldId]  DEFAULT (newid()) FOR [fieldId]
GO
ALTER TABLE [dbo].[fields] ADD  CONSTRAINT [DF_fields_defaultOrder]  DEFAULT ((0)) FOR [defaultOrder]
GO
ALTER TABLE [dbo].[fieldText] ADD  CONSTRAINT [DF_fieldText_fieldText]  DEFAULT ('') FOR [fieldStrMax]
GO
ALTER TABLE [dbo].[operators] ADD  CONSTRAINT [DF_operators_operatorId]  DEFAULT (newid()) FOR [operatorId]
GO
ALTER TABLE [dbo].[operators] ADD  CONSTRAINT [DF_operators_source]  DEFAULT ('sql server') FOR [source]
GO
ALTER TABLE [dbo].[operators] ADD  CONSTRAINT [DF_operators_isPrefix]  DEFAULT ((0)) FOR [isPrefix]
GO
ALTER TABLE [dbo].[operators] ADD  CONSTRAINT [DF_operators_paraNum]  DEFAULT ((0)) FOR [paraNum]
GO
ALTER TABLE [dbo].[queries] ADD  CONSTRAINT [DF_queries_queryId]  DEFAULT (newid()) FOR [queryId]
GO
ALTER TABLE [dbo].[queryFields] ADD  CONSTRAINT [DF_queryFields_queryFieldId]  DEFAULT (newid()) FOR [queryFieldId]
GO
ALTER TABLE [dbo].[queryFields] ADD  CONSTRAINT [DF_queryFields_previousNo]  DEFAULT ((0)) FOR [previousNo]
GO
ALTER TABLE [dbo].[queryFields] ADD  CONSTRAINT [DF_queryFields_displayOrder]  DEFAULT ((0)) FOR [displayOrder]
GO
ALTER TABLE [dbo].[queryFields] ADD  CONSTRAINT [DF_queryFields_orderByOrder]  DEFAULT ((0)) FOR [orderByOrder]
GO
ALTER TABLE [dbo].[queryFields] ADD  CONSTRAINT [DF_queryFields_orderByDesc]  DEFAULT ((0)) FOR [orderByDesc]
GO
ALTER TABLE [dbo].[tables] ADD  CONSTRAINT [DF_Table_1_tableStrId]  DEFAULT (newid()) FOR [tableId]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'currently, sql for sql server, or c#' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para1''s fieldId if from field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'paraField1id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para1name if from external input' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'para1externalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para2''s fieldId if from field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'paraField2id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para2name if from external input' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'para2externalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para3''s fieldId if from field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'paraField3id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para3name if from external input' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'para3externalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para4''s fieldId if from field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'paraField4id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para4name if from external input' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'para4externalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para5''s fieldId if from field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'paraField5id'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'para5name if from external input' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'expressions', @level2type=N'COLUMN',@level2name=N'para5externalName'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'non null if it is one of the primary keys' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'fields', @level2type=N'COLUMN',@level2name=N'primaryOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'currently, sql for sql server, or c#' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'operators', @level2type=N'COLUMN',@level2name=N'source'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'in real code, operator lead (1), or (0) betweeen two parameters' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'operators', @level2type=N'COLUMN',@level2name=N'isPrefix'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'number of parameters, must > 0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'operators', @level2type=N'COLUMN',@level2name=N'paraNum'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'it will be a new calculated field if it is not from original data (when fieldId,pre1fieldId,pre2fieldId all = null)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'queryFieldId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'對應資料庫中的欄位代碼' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'fieldId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'前面的fieldId, 要取query結果中的, 前第previousNo筆, 目前僅規劃0,1,2三種值' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'previousNo'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'for display field, 0: hidden, >0 order by this field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'displayOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'for order by field, 0: hidden, >0 order by this field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'orderByOrder'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'0 asc, 1 desc' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'orderByDesc'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'from expression of expressionId, if this is not from original field' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'expressionId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'這是若expressionId非null, 計算出來的值, 要存回哪個欄位' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'queryFields', @level2type=N'COLUMN',@level2name=N'save2fieldId'
GO
