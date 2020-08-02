CREATE TABLE [dbo].[fieldText] (
    [fieldTextId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [rowId]       UNIQUEIDENTIFIER NOT NULL,
    [fieldId]     UNIQUEIDENTIFIER NOT NULL,
    [fieldStrMax] NVARCHAR (MAX)   CONSTRAINT [DF_fieldText_fieldText] DEFAULT ('') NOT NULL,
    CONSTRAINT [PK_fieldText] PRIMARY KEY CLUSTERED ([fieldTextId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_fieldText_2]
    ON [dbo].[fieldText]([fieldId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fieldText_1]
    ON [dbo].[fieldText]([rowId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_fieldText_3]
    ON [dbo].[fieldText]([rowId] ASC, [fieldId] ASC);

