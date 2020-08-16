CREATE TABLE [dbo].[expressions] (
    [expressionId]      UNIQUEIDENTIFIER CONSTRAINT [DF_expressions_expressionId] DEFAULT (newid()) NOT NULL,
    [source]            VARCHAR (50)     CONSTRAINT [DF_expressions_source] DEFAULT ('sql server') NOT NULL,
    [expressionDesc]    NVARCHAR (999)   NULL,
    [queryId]           UNIQUEIDENTIFIER NULL,
    [operatorId]        UNIQUEIDENTIFIER NOT NULL,
    [paraField1id]      UNIQUEIDENTIFIER NULL,
    [para1externalName] NVARCHAR (50)    NULL,
    [paraField2id]      UNIQUEIDENTIFIER NULL,
    [para2externalName] NVARCHAR (50)    NULL,
    [paraField3id]      UNIQUEIDENTIFIER NULL,
    [para3externalName] NVARCHAR (50)    NULL,
    [paraField4id]      UNIQUEIDENTIFIER NULL,
    [para4externalName] NVARCHAR (50)    NULL,
    [paraField5id]      UNIQUEIDENTIFIER NULL,
    [para5externalName] NVARCHAR (50)    NULL,
    CONSTRAINT [PK_expressions] PRIMARY KEY CLUSTERED ([expressionId] ASC)
);








GO
CREATE NONCLUSTERED INDEX [IX_expressions_2]
    ON [dbo].[expressions]([operatorId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_expressions_1]
    ON [dbo].[expressions]([queryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_expressions]
    ON [dbo].[expressions]([source] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'currently, sql for sql server, or c#', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'source';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para5''s fieldId if from field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'paraField5id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para4''s fieldId if from field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'paraField4id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para3''s fieldId if from field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'paraField3id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para2''s fieldId if from field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'paraField2id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para1''s fieldId if from field', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'paraField1id';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para5name if from external input', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'para5externalName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para4name if from external input', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'para4externalName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para3name if from external input', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'para3externalName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para2name if from external input', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'para2externalName';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'para1name if from external input', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'expressions', @level2type = N'COLUMN', @level2name = N'para1externalName';

