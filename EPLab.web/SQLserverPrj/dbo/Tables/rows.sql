CREATE TABLE [dbo].[rows] (
    [rowId]   UNIQUEIDENTIFIER CONSTRAINT [DF_rows_rowId] DEFAULT (newid()) NOT NULL,
    [tableId] UNIQUEIDENTIFIER NOT NULL,
    CONSTRAINT [PK_rows] PRIMARY KEY CLUSTERED ([rowId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_rows]
    ON [dbo].[rows]([tableId] ASC);

