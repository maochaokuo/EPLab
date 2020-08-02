CREATE TABLE [dbo].[fields] (
    [fieldId]        UNIQUEIDENTIFIER CONSTRAINT [DF_fields_fieldId] DEFAULT (newid()) NOT NULL,
    [tableId]        UNIQUEIDENTIFIER NOT NULL,
    [fieldName]      NVARCHAR (50)    NOT NULL,
    [fieldDesc]      NVARCHAR (999)   NULL,
    [primaryOrder]   INT              NULL,
    [foreignFieldId] UNIQUEIDENTIFIER NULL,
    [defaultValue]   NVARCHAR (450)   NULL,
    CONSTRAINT [PK_fields] PRIMARY KEY CLUSTERED ([fieldId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_fields_2]
    ON [dbo].[fields]([tableId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fields_1]
    ON [dbo].[fields]([fieldName] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_fields_3]
    ON [dbo].[fields]([tableId] ASC, [fieldName] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'non null if it is one of the primary keys', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'fields', @level2type = N'COLUMN', @level2name = N'primaryOrder';

