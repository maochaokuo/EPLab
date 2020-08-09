CREATE TABLE [dbo].[queries] (
    [queryId]           UNIQUEIDENTIFIER CONSTRAINT [DF_queries_queryId] DEFAULT (newid()) NOT NULL,
    [queryName]         NVARCHAR (50)    NOT NULL,
    [queryDesc]         NVARCHAR (999)   NULL,
    [tableId]           UNIQUEIDENTIFIER NULL,
    [tableAlias]        NVARCHAR (50)    NULL,
    [whereExpressionId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_queries] PRIMARY KEY CLUSTERED ([queryId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_queries_1]
    ON [dbo].[queries]([whereExpressionId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_queries]
    ON [dbo].[queries]([queryName] ASC);

