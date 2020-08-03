CREATE TABLE [dbo].[fieldValues] (
    [fieldValueId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [rowId]        UNIQUEIDENTIFIER NOT NULL,
    [fieldId]      UNIQUEIDENTIFIER NOT NULL,
    [fieldValue]   NVARCHAR (450)   CONSTRAINT [DF_fieldValues_fieldValue] DEFAULT ('') NOT NULL,
    [domainCaseId] UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_fieldValues] PRIMARY KEY CLUSTERED ([fieldValueId] ASC)
);




GO
CREATE NONCLUSTERED INDEX [IX_fieldValues_3]
    ON [dbo].[fieldValues]([fieldValue] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fieldValues_2]
    ON [dbo].[fieldValues]([fieldId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fieldValues_1]
    ON [dbo].[fieldValues]([rowId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fieldValues_4]
    ON [dbo].[fieldValues]([rowId] ASC, [fieldId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_fieldValues]
    ON [dbo].[fieldValues]([domainCaseId] ASC);

