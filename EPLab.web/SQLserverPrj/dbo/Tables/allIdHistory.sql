CREATE TABLE [dbo].[allIdHistory] (
    [allIdHistoryId] BIGINT           IDENTITY (1, 1) NOT NULL,
    [uid]            UNIQUEIDENTIFIER NOT NULL,
    [fromTable]      VARCHAR (50)     NULL,
    [createtime]     DATETIME         NULL,
    [modifytime]     DATETIME         NULL,
    [createBy]       NVARCHAR (50)    NULL,
    [modifyBy]       NVARCHAR (50)    NULL,
    CONSTRAINT [PK_allIdHistory] PRIMARY KEY CLUSTERED ([allIdHistoryId] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_allIdHistory]
    ON [dbo].[allIdHistory]([uid] ASC);

