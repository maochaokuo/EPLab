﻿CREATE TABLE [dbo].[operators] (
    [operatorId]         UNIQUEIDENTIFIER NOT NULL,
    [source]             VARCHAR (50)     NOT NULL,
    [operatorDesc]       NVARCHAR (999)   NULL,
    [queryId]            UNIQUEIDENTIFIER NULL,
    [stringInSourceCode] NVARCHAR (50)    NOT NULL,
    [isPrefix]           BIT              CONSTRAINT [DF_operators_isPrefix] DEFAULT ((0)) NOT NULL,
    [paraNum]            INT              CONSTRAINT [DF_operators_paraNum] DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_operators] PRIMARY KEY CLUSTERED ([operatorId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_operators_1]
    ON [dbo].[operators]([queryId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_operators]
    ON [dbo].[operators]([source] ASC);


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'number of parameters, must > 0', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'operators', @level2type = N'COLUMN', @level2name = N'paraNum';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'in real code, operator lead (1), or (0) betweeen two parameters', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'operators', @level2type = N'COLUMN', @level2name = N'isPrefix';


GO
EXECUTE sp_addextendedproperty @name = N'MS_Description', @value = N'currently, sql for sql server, or c#', @level0type = N'SCHEMA', @level0name = N'dbo', @level1type = N'TABLE', @level1name = N'operators', @level2type = N'COLUMN', @level2name = N'source';
