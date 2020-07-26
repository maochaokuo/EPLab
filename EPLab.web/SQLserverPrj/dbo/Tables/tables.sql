CREATE TABLE [dbo].[tables] (
    [tableId]   UNIQUEIDENTIFIER CONSTRAINT [DF_Table_1_tableStrId] DEFAULT (newid()) NOT NULL,
    [tableName] NVARCHAR (50)    NOT NULL,
    [tableDesc] NVARCHAR (999)   NULL,
    CONSTRAINT [PK_tables] PRIMARY KEY CLUSTERED ([tableId] ASC)
);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_tables]
    ON [dbo].[tables]([tableName] ASC);

