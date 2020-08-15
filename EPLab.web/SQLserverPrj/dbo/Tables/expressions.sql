CREATE TABLE [dbo].[expressions] (
    [expressionId]   UNIQUEIDENTIFIER CONSTRAINT [DF_expressions_expressionId] DEFAULT (newid()) NOT NULL,
    [source]         VARCHAR (50)     CONSTRAINT [DF_expressions_source] DEFAULT ('sql server') NOT NULL,
    [expressionDesc] NVARCHAR (999)   NULL,
    [queryId]        UNIQUEIDENTIFIER NULL,
    [operatorId]     UNIQUEIDENTIFIER NOT NULL,
    [paraField1id]   UNIQUEIDENTIFIER NOT NULL,
    [paraField2id]   UNIQUEIDENTIFIER NULL,
    [paraField3id]   UNIQUEIDENTIFIER NULL,
    [paraField4id]   UNIQUEIDENTIFIER NULL,
    [paraField5id]   UNIQUEIDENTIFIER NULL,
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

